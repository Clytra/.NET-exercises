using ReportService.Repositories;
using System.ServiceProcess;
using System.Timers;

namespace ReportService
{
    public partial class ReportService : ServiceBase
    {
        private const int IntervalInMinutes = 30;
        private Timer _timer = new Timer(IntervalInMinutes * 60000);
        private ErrorRepository _errorRepository = new ErrorRepository();

        public ReportService()
        {
            InitializeComponent(); 
        }

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            SendError();
            SendReport();
        }

        private void SendError()
        {

        }

        private void SendReport()
        {
            var errors = _errorRepository.GetLasErrors(IntervalInMinutes);
        }

        protected override void OnStop()
        {
        }
    }
}
