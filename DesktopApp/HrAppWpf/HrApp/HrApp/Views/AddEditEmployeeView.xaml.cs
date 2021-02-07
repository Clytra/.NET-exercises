using HrApp.Models.Domains;
using HrApp.ViewModels;
using MahApps.Metro.Controls;

namespace HrApp.Views
{
    /// <summary>
    /// Interaction logic for AddEditEmployeeView.xaml
    /// </summary>
    public partial class AddEditEmployeeView : MetroWindow
    {
        public AddEditEmployeeView(Employee employee = null)
        {
            InitializeComponent();
            DataContext = new AddEditEmployeeViewModel(employee);
        }
    }
}
