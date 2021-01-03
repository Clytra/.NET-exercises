using System;

namespace HrApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfEmployeeDismissal { get; set; }
        public string Comments { get; set; }
        public double Earnings { get; set; }
    }
}
