using Diary.Models.Wrappers;
using Diary.ViewModels;
using MahApps.Metro.Controls;

namespace Diary.Views
{
    /// <summary>
    /// Interaction logic for ConnectToServerUserSettingsView.xaml
    /// </summary>
    public partial class ConnectToServerUserSettingsView : MetroWindow
    {
        public ConnectToServerUserSettingsView(ServerWrapper server = null)
        {
            InitializeComponent();
            DataContext = new ConnectToServerUserSettingsViewModel(server);
        }
    }
}
