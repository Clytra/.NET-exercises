using HrApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrApp
{
    class Repository
    {
        public List<Employee> GetEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees.ToList();

                return employees;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeeToUpdate = context.Employees.Find(employee.Id);
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.DateOfEmployment = employee.DateOfEmployment;
                employeeToUpdate.Earnings = employee.Earnings;
                employeeToUpdate.Comments = employee.Comments;

                context.SaveChanges();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (var context = new ApplicationDbContext())
            {
                var newEmployee = new Employee();
                newEmployee.FirstName = employee.FirstName;
                newEmployee.LastName = employee.LastName;
                newEmployee.DateOfEmployment = employee.DateOfEmployment;
                newEmployee.DateOfEmployeeDismissal = employee.DateOfEmployeeDismissal;
                newEmployee.Earnings = employee.Earnings;
                newEmployee.Comments = employee.Comments;
                    
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
        }

        internal void DismissEmployee(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var dismissEmployee = context.Employees.Find(id);
                dismissEmployee.DateOfEmployeeDismissal = DateTime.Now;

                context.SaveChanges();
            }
        }
    }
}
