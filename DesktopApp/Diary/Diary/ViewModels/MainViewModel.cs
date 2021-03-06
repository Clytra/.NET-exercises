﻿using Diary.Commands;
using Diary.Models.Domains;
using Diary.Models.Wrappers;
using Diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            IsConnected = CheckConnection();

            if (IsConnected)
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

                RefreshDiary();
                InitGroups();
            }
            else
            {
                var result = MessageBox
                    .Show("Nie udało się nawiązać połączenia z bazą danych." +
                    " Czy chcesz zmienić ustawienia?",
                    "Błąd połączenia",
                    MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Server server = new Server();
                    SetServerConnection(server);
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }           
            }

        }

        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand AddStudentsCommand { get; set; }
        public ICommand EditStudentsCommand { get; set; }
        public ICommand DeleteStudentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public static string ConnectionString { get; set; }
        public bool IsConnected { get; set; }

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
            var connectToServerUserSettingsWindow = new ConnectToServerUserSettingsView(obj as Server);
            connectToServerUserSettingsWindow.Closed += connectToServerUserSettingsWindow_Closed;
            connectToServerUserSettingsWindow.ShowDialog();
        }

        private void connectToServerUserSettingsWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private bool CheckConnection()
        {
            var connectionString = ServerWrapper.GetConnectionString();

            try
            {
                SqlConnection testConnection = new SqlConnection(connectionString);
                testConnection.Open();
                testConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
