using HrApp.Commands;
using HrApp.Models.Domains;
using HrApp.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HrApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public MainViewModel()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();
            }

            AddEmployeeCommand = new RelayCommand(AddEditEmployee);
            EditEmployeeCommand = new RelayCommand(AddEditEmployee, CanEditDismissalEmployee);
            DismissalEmployeeCommand = new AsyncRelayCommand(DismissalEmployee, CanEditDismissalEmployee);

            InitFilter();
            RefreshList();
        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand DismissalEmployeeCommand { get; set; }


        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Filter> _filters;

        public ObservableCollection<Filter> Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                OnPropertyChanged();
            }
        }

        private int _selectedFilterId;

        public int SelectedFilterId
        {
            get { return _selectedFilterId; }
            set
            {
                _selectedFilterId = value;
                OnPropertyChanged();
            }
        }

        private bool CanEditDismissalEmployee(object obj)
        {
            return SelectedEmployee != null;
        }

        private async Task DismissalEmployee(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Zwalnianie pracownika",
                $"Czy na pewno chcesz zwolnić pracownika {SelectedEmployee.FirstName}" +
                $" {SelectedEmployee.LastName}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;

            _repository.DismissEmployee(SelectedEmployee.Id);
            RefreshList();
        }

        private void AddEditEmployee(object obj)
        {
            var addEditEmployeeWindow = new AddEditEmployeeView(obj as Employee);
            addEditEmployeeWindow.Closed += addEditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();
        }

        private void addEditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            Employees = new ObservableCollection<Employee>
                (_repository.GetEmployees(SelectedFilterId));
        }

        private void InitFilter()
        {
            var filters = _repository.GetFilters();
            filters.Insert(0, new Filter { Id = 0, Name = "Wszyscy" });

            Filters = new ObservableCollection<Filter>(filters);

            SelectedFilterId = 0;
        }
    }
}
