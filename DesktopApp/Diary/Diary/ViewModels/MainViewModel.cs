using Diary.Commands;
using Diary.Models;
using Diary.Models.Domains;
using Diary.Models.Wrappers;
using Diary.Properties;
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
        private Repository _repository = new Repository();
        public MainViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                var students = context.Students.ToList();
            }

            RefreshStudentsCommand = new RelayCommand(RefreshStudents);
            AddStudentsCommand = new RelayCommand(AddEditStudent);
            EditStudentsCommand = new RelayCommand(AddEditStudent, CanEditDeleteStudent);
            DeleteStudentsCommand = new AsyncRelayCommand(DeleteStudent, CanEditDeleteStudent);
            SettingsCommand = new RelayCommand(SetServerConnection);

            CheckConnection();
            RefreshDiary();
            InitGroups();
        }

        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand AddStudentsCommand { get; set; }
        public ICommand EditStudentsCommand { get; set; }
        public ICommand DeleteStudentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public int connectionStatus { get; set; }

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

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        private ServerWrapper _currentSettings;

        public ServerWrapper CurrentSettings
        {
            get { return _currentSettings; }
            set
            {
                _currentSettings = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private void RefreshStudents(object obj)
        {
            RefreshDiary();
        }

        private void InitGroups()
        {
            var groups = _repository.GetGroups();
            groups.Insert(0, new Group { Id = 0, Name = "Wszystkie" });

            Groups = new ObservableCollection<Group>(groups);

            SelectedGroupId = 0;
        }

        private bool CanEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }

        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Usuwanie ucznia", 
                $"Czy na pewno chcesz" +
                $"usunąć ucznia {SelectedStudent.FirstName} {SelectedStudent.LastName}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;

            _repository.DeleteStudent(SelectedStudent.Id);
        }

        private void AddEditStudent(object obj)
        {
            var addEditStudentWindow = new AddEditStudentView(obj as StudentWrapper);
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void RefreshDiary()
        {
            Students = new ObservableCollection<StudentWrapper>
                (_repository.GetStudents(SelectedGroupId));
        }

        private void SetServerConnection(object obj)
        {
            var connectToServerUserSettingsWindow = new ConnectToServerUserSettingsView(obj as ServerWrapper);
            connectToServerUserSettingsWindow.Closed += connectToServerUserSettingsWindow_Closed;
            connectToServerUserSettingsWindow.ShowDialog();
        }

        private void connectToServerUserSettingsWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }
        private void CheckConnection()
        {
            ServerWrapper model = new ServerWrapper
            {
                ServerAddress = Settings.Default.ServerAddress,
                ServerName = Settings.Default.ServerName,
                DbName = Settings.Default.DbName,
                UserName = Settings.Default.UserName,
                Password = Settings.Default.Password
            };

            connectionStatus = _repository.ConnectToDb(model);

            switch (connectionStatus)
            {
                case 3:
                    ServerWrapper server = new ServerWrapper();
                    SetServerConnection(server);
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}
