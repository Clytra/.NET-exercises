using System;

namespace HrApp.Models.Domains
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfEmployeeDismissal { get; set; }
        public int EmployeeNumber { get; set; }
        public string Comments { get; set; }
        public double Earnings { get; set; }
    }
}
