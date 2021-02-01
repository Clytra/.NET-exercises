using Diary.Models.Domains;
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
        public ConnectToServerUserSettingsView(Server server = null)
        {
            InitializeComponent();
            DataContext = new ConnectToServerUserSettingsViewModel(server);
        }
    }
}
