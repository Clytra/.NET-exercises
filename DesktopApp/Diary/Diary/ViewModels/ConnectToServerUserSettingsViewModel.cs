using Diary.Commands;
using Diary.Models.Domains;
using System;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class ConnectToServerUserSettingsViewModel : ViewModelBase
    {
        public ConnectToServerUserSettingsViewModel(Server server = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }


        private Server _server;
        public Server Server
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
            throw new NotImplementedException();
        }

        private void Close(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
