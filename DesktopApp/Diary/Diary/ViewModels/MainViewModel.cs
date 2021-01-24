using Diary.Commands;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            RefreshStudentsCommand = new RelayCommand(RefreshStudents);
        }
        public ICommand RefreshStudentsCommand { get; set; }

        private void RefreshStudents(object obj)
        {
            MessageBox.Show("RefreshStudents");
        }
    }
}
