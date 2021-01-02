using HrApp.Properties;
using System;
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
    public partial class Main : Form
    {
        private FileHelper<List<Employee>> _fileHelper =
            new FileHelper<List<Employee>>(Program.FilePath);

        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }
            set
            {
                Settings.Default.IsMaximize = value;
            }
        }
        public Main()
        {
            InitializeComponent();
            RefreshData();

            SetColumnsHeader();

            if (IsMaximize)
                WindowState = FormWindowState.Maximized;
            
        }

        private void RefreshData()
        {
            var employees = _fileHelper.DeserializeFromFile();

            if (cbxFilter.SelectedItem != "Wszyscy" && cbxFilter.SelectedItem != null)
            {
                var filter = cbxFilter.SelectedItem.ToString();
                
                if (cbxFilter.SelectedItem == "Zatrudnieni")
                {
                    employees = employees.Where(employee => employee.DateOfEmployeeDismissal == null).ToList();
                }
                else
                {
                    employees = employees.Where(employee => employee.DateOfEmployeeDismissal != null).ToList();
                }
            }

            dvgEmployes.DataSource = employees;
        }

        private void SetColumnsHeader()
        {
            dvgEmployes.Columns[0].HeaderText = "Numer";
            dvgEmployes.Columns[1].HeaderText = "Imię";
            dvgEmployes.Columns[2].HeaderText = "Nazwisko";
            dvgEmployes.Columns[3].HeaderText = "Data zatrudnienia";
            dvgEmployes.Columns[4].HeaderText = "Data zwolnienia";
            dvgEmployes.Columns[5].HeaderText = "Uwagi";
            dvgEmployes.Columns[6].HeaderText = "Zarobki";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditEmployee = new AddEditEmployee();
            addEditEmployee.FormClosing += AddEditEmployee_FormClosing;
            addEditEmployee.ShowDialog();
        }

        private void AddEditEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dvgEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz pracownika, którego dane chcesz edytować");
            }

            var addEditEmployee = new AddEditEmployee(
                Convert.ToInt32(dvgEmployes.SelectedRows[0].Cells[0].Value));
            addEditEmployee.FormClosing += AddEditEmployee_FormClosing;
            addEditEmployee.ShowDialog();
        }

        private void btnDismissal_Click(object sender, EventArgs e)
        {
            if (dvgEmployes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz pracownika, którego chcesz zwolnić");
                return;
            }

            var selectedEmployee = dvgEmployes.SelectedRows[0];

            var confirmDismissal =
                MessageBox.Show($"Czy na pewno chcesz zwolnić pracownika {(selectedEmployee.Cells[1].Value.ToString() + " " + selectedEmployee.Cells[2].Value.ToString()).Trim()}",
                "Zwalnianie pracownika",
                MessageBoxButtons.OKCancel);

            if (confirmDismissal == DialogResult.OK)
            {
                DismissalEmployee(Convert.ToInt32(selectedEmployee.Cells[0].Value));
                RefreshData();
            }
        }

        private void DismissalEmployee(int id)
        {
            var employees = _fileHelper.DeserializeFromFile();

            AddEditEmployee employee = new AddEditEmployee();
            employee.AddNewEmployeeToList(employees, id);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                IsMaximize = true;
            else
                IsMaximize = false;

            Settings.Default.Save();
        }
    }
}
