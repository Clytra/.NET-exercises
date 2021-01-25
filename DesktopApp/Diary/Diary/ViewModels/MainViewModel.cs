using Diary.Commands;
using Diary.Models.Wrappers;
using Diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                var students = context.Students.ToList();
            }

            RefreshStudentsCommand = new RelayCommand(RefreshStudents);
            AddStudentCommand = new RelayCommand(AddEditStudent);
            EditStudentCommand = new RelayCommand(AddEditStudent, CanEditDeleteStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, CanEditDeleteStudent);

            InitGroups();
        }

        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }

        private StudentWrapper _selectedStudent;
        public StudentWrapper SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentWrapper> _students;
        public ObservableCollection<StudentWrapper> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private GroupWrapper _selectedGroupId;
        public GroupWrapper SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<GroupWrapper> _groups;
        public ObservableCollection<GroupWrapper> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        private bool CanEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }
        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Usuwanie ucznia", 
                $"Czy na pewno chcesz usunąć ucznia {SelectedStudent.FisrtName}" +
                $" {SelectedStudent.LastName}?", 
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
            {
                return;

                RefreshDiary();
            }
        }

        private void AddEditStudent(object obj)
        {
            var addEditStudentWindow = new AddEditStudentView(obj as StudentWrapper);
            addEditStudentWindow.Closed += addEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void addEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void RefreshStudents(object obj)
        {
            RefreshDiary();
        }

        private void InitGroups()
        {
        }
    }
}
