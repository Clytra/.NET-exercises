using ReportErrorsService.Repositories;
using SmsSender;
using System;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace ReportErrorsService
{
    public partial class ReportErrorsService : ServiceBase
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private const int _intervalInMinutes = 60;
        private Timer _timer = new Timer(_intervalInMinutes * 60000);
        private ErrorRepository _errorRepository = new ErrorRepository();
        private Sms _sms;

        public ReportErrorsService()
        {
            InitializeComponent();

            try
            {
                _sms = new Sms(new SmsParams
                {
                    Sender = ConfigurationManager.AppSettings["Sender"],
                    SendTo = ConfigurationManager.AppSettings["SendTo"]
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
            _logger.Info("Service started...");
        }

        private async void DoWork(object sender, ElapsedEventArgs e)
        {
            try
            {
                await SendSmsErrorMessage();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task SendSmsErrorMessage()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var errors = _errorRepository.GetLastError(_intervalInMinutes, connectionString);

            if (errors == null || !errors.Any())
                return;

            //await _sms.SendSms();

            _logger.Info("Error sent.");
        }

        protected override void OnStop()
        {
            _logger.Info("Service stopped");
        }
    }
}
