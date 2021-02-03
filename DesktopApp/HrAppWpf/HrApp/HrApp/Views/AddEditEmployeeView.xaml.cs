using HrApp.Models.Domains;
using HrApp.ViewModels;
using System.Windows;

namespace HrApp.Views
{
    /// <summary>
    /// Interaction logic for AddEditEmployeeView.xaml
    /// </summary>
    public partial class AddEditEmployeeView : Window
    {
        public AddEditEmployeeView(Employee employee = null)
        {
            InitializeComponent();
            DataContext = new AddEditEmployeeViewModel(employee);
        }
    }
}
