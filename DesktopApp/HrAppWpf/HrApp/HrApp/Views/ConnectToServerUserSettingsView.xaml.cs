using HrApp.Models.Domains;
using HrApp.ViewModels;
using MahApps.Metro.Controls;

namespace HrApp.Views
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
