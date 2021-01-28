using Diary.Commands;
using Diary.Models.Wrappers;
using System;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class ConnectToServerUserSettingsViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public ConnectToServerUserSettingsViewModel(ServerWrapper server = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (server == null)
            {
                Server = new ServerWrapper();
            }
            else
            {
                Server = server;
            }
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public int connectionStatus { get; set; }


        private ServerWrapper _server;
        public ServerWrapper Server
        {
            get { return _server; }
            set
            {
                _server = value;
                OnPropertyChanged();
            }
        }

        private void Confirm(object obj)
        {
            if (Server.IsValid)
            {
                try
                {
                    connectionStatus = _repository.ConnectToDb(this.Server);
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
            }
        }

        private void Close(object obj)
        {
           
        }
        private bool Connect()
        {
            throw new NotImplementedException();
        }
    }
}
