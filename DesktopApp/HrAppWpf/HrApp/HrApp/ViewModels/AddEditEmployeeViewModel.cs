using HrApp.Commands;
using HrApp.Models.Domains;
using System;
using System.Windows;

namespace HrApp.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeViewModel(Employee employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new Employee();
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }
        }

        public RelayCommand CloseCommand { get; }
        public RelayCommand ConfirmCommand { get; }


        private Employee _employee;
        public Employee Employee 
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private bool _isUpdate;
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }


        private void Confirm(object obj)
        {
            if (!IsUpdate)
                AddEmployee();
            else
                UpdateEmployee();

            CloseWindow(obj as Window);
        }

        private void UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        private void AddEmployee()
        {
            throw new NotImplementedException();
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            throw new NotImplementedException();
        }
    }
}
