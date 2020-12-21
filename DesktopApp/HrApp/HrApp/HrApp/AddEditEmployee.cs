﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrApp
{
    public partial class AddEditEmployee : Form
    {
        private int _employeeId;
        private Employee _employee;

        private FileHelper<List<Employee>> _fileHelper =
            new FileHelper<List<Employee>>(Program.FilePath);

        public AddEditEmployee(int id = 0)
        {
            InitializeComponent();
            _employeeId = id;

            GetEmployeeData();
            tbFirstName.Select();
        }

        private void GetEmployeeData()
        {
            if (_employeeId != 0)
            {
                Text = "Edytowanie danych pracownika";

                var employee = _fileHelper.DeserializeFromFile();
                _employee = employee.FirstOrDefault(x => x.Id == _employeeId);

                if (_employee == null)
                    throw new Exception("Brak pracownika o podanym Id");

                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {
            tbId.Text = _employee.Id.ToString();
            tbFirstName.Text = _employee.FirstName;
            tbLastName.Text = _employee.LastName;
            tbDateOfEmployment.Text = _employee.DateOfEmployment.ToString();
            tbEarnings.Text = _employee.Earnings.ToString();
            rtbComments.Text = _employee.Comments;
        }

        private void AddNewEmployeeToList(List<Employee> employees)
        {
            var employee = new Employee
            {
                Id = _employeeId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                DateOfEmployment = DateTime.Parse(tbDateOfEmployment.Text),
                Earnings = Double.Parse(tbEarnings.Text),
                Comments = rtbComments.Text
            };

            employees.Add(employee);
        }
        
        private void AssignIdToNewEmployee(List<Employee> employees)
        {
            var employeeWithHighestId = employees
                .OrderByDescending(x => x.Id).FirstOrDefault();

            _employeeId = employeeWithHighestId == null ?
                1 : employeeWithHighestId.Id + 1;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var employees = _fileHelper.DeserializeFromFile();

            AssignIdToNewEmployee(employees);

            AddNewEmployeeToList(employees);

            _fileHelper.SerializeToFile(employees);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
