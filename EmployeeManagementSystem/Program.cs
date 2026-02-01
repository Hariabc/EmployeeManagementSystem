using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDAL dal = new EmployeeDAL();
            int option = 0;

            do
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by Id");
                Console.WriteLine("4. Update Salary");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AddEmployee(dal);
                        break;
                    case 2:
                        ViewAllEmployees(dal);
                        break;
                    case 3:
                        SearchEmployeeById(dal);
                        break;
                    case 4:
                        UpdateSalary(dal);
                        break;
                    case 5:
                        DeleteEmployee(dal);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (option != 6);
        }

        static void AddEmployee(EmployeeDAL dal)
        {
            try
            {
                Employee emp = new Employee();
                Console.Write("Enter Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Enter Department: ");
                emp.Department = Console.ReadLine();
                Console.Write("Enter Salary: ");
                emp.Salary = Convert.ToDecimal(Console.ReadLine());

                dal.AddEmployee(emp);
            }
            catch (FormatException)
            {
                 Console.WriteLine("Invalid input format. Please check your entries.");
            }
        }

        static void ViewAllEmployees(EmployeeDAL dal)
        {
            List<Employee> employees = dal.GetAllEmployees();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                Console.WriteLine("\n--- Employee List ---");
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10}", "Id", "Name", "Department", "Salary");
                foreach (Employee emp in employees)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-10}", emp.Id, emp.Name, emp.Department, emp.Salary);
                }
            }
        }

        static void SearchEmployeeById(EmployeeDAL dal)
        {
            try
            {
                Console.Write("Enter Employee Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Employee emp = dal.GetEmployeeById(id);

                if (emp != null)
                {
                    Console.WriteLine("\n--- Employee Details ---");
                    Console.WriteLine("Id: " + emp.Id);
                    Console.WriteLine("Name: " + emp.Name);
                    Console.WriteLine("Department: " + emp.Department);
                    Console.WriteLine("Salary: " + emp.Salary);
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                 Console.WriteLine("Invalid Id format.");
            }
        }

        static void UpdateSalary(EmployeeDAL dal)
        {
            try
            {
                Console.Write("Enter Employee Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter New Salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());

                dal.UpdateSalary(id, salary);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
        }

        static void DeleteEmployee(EmployeeDAL dal)
        {
            try
            {
                Console.Write("Enter Employee Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Confirm deletion
                Console.Write("Are you sure you want to delete this employee? (y/n): ");
                string confirm = Console.ReadLine().ToLower();

                if (confirm == "y")
                {
                    dal.DeleteEmployee(id);
                }
                else
                {
                     Console.WriteLine("Deletion cancelled.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Id format.");
            }
        }
    }
}
