using Diary.Commands;
using Diary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            RefreshStudentsCommand = new RelayCommand(RefreshStudents, CanRefreshStudents);

            Students = new ObservableCollection<Student>
            {
                new Student
                {
                    FirstName ="Janusz",
                    LastName="Januszowy",
                    Group = new Group { Id = 1}
                },
                new Student
                {
                    FirstName ="Marek",
                    LastName="Januszowy",
                    Group = new Group { Id = 2}
                },
                new Student
                {
                    FirstName ="Grażyna",
                    LastName="Januszowa",
                    Group = new Group { Id = 3}
                },
            };
        }

        public ICommand RefreshStudentsCommand { get; set; }

        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }
        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set 
            { 
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }


        private bool CanRefreshStudents(object obj)
        {
            return true;
        }

        private void RefreshStudents(object obj)
        {
            MessageBox.Show("RefreshStudent");
        }
    }
}
