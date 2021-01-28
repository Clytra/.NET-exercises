using Diary.Commands;
using Diary.Models.Wrappers;
using System;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class ConnectToServerUserSettingsViewModel : ViewModelBase
    {
        public ConnectToServerUserSettingsViewModel(ServerWrapper server = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }


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
            
        }

        private void Close(object obj)
        {
           
        }
    }
}
