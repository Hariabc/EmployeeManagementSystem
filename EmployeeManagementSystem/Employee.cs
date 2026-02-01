using System;

namespace EmployeeManagementSystem
{
    // Employee Model Class
    // Represents the structure of an Employee object mirroring the database table
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
