﻿using EmailSender;
using ReportService.Models;
using ReportService.Repositories;
using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace ReportService
{
    public partial class ReportService : ServiceBase
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private const int SendHour = 8;
        private const int IntervalInMinutes = 30;
        private Timer _timer = new Timer(IntervalInMinutes * 60000);
        private ErrorRepository _errorRepository = new ErrorRepository();
        private ReportRepository _reportRepository = new ReportRepository();
        private Email _email;
        private GenerateHtmlEmail _htmlEmail = new GenerateHtmlEmail();
        private string _emailReceiver = "przykładowymail@com";

        public ReportService()
        {
            InitializeComponent();

            _email = new Email(new EmailParams
            {
                HostSmtp = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                SenderName = "Hohohiho",
                SenderEmail = "",
                SenderEmailPassword = ""
            });
        }

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
            Logger.Info("Service started...");
        }

        private async void DoWork(object sender, ElapsedEventArgs e)
        {
            try
            {
                await SendError();
                await SendReport();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task SendError()
        {
            var errors = _errorRepository.GetLasErrors(IntervalInMinutes);

            if (errors == null || !errors.Any())
                return;

            await _email.Send("Błędy w aplikacji", _htmlEmail.GenerateErrors(errors, 
                IntervalInMinutes), _emailReceiver);

            Logger.Info("Error sent.");
        }

        private async Task SendReport()
        {
            var actualHour = DateTime.Now.Hour;

            if (actualHour < SendHour)
                return;

            var report = _reportRepository.GetLastNotSentReport();

            if (report == null)
                return;

            await _email.Send("Raport dobowy", _htmlEmail.GenerateReport(report), _emailReceiver);

            _reportRepository.ReportSend(report);

            Logger.Info("Report sent.");
        }

        protected override void OnStop()
        {
            Logger.Info("Service stopped...");
        }
    }
}
