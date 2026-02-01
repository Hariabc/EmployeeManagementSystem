using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    // Employee Data Access Layer
    // Handles all interactions with the MySQL database
    public class EmployeeDAL
    {
        // Connection String - Assumes default root user with no password.
        // PLEASE UPDATE 'Pwd' IF YOU HAVE A PASSWORD
        private string connectionString = "Server=localhost;Database=EmployeeDB;Uid=root;Pwd=root;";

        // Add a new Employee
        public void AddEmployee(Employee emp)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, Department, Salary) VALUES (@Name, @Department, @Salary)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee added successfully.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                   Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Get All Employees
        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = new List<Employee>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                MySqlCommand cmd = new MySqlCommand(query, con);

                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(reader["Id"]);
                        emp.Name = reader["Name"].ToString();
                        emp.Department = reader["Department"].ToString();
                        emp.Salary = Convert.ToDecimal(reader["Salary"]);
                        empList.Add(emp);
                    }
                }
                 catch (MySqlException ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return empList;
        }

        // Get Employee by Id
        public Employee GetEmployeeById(int id)
        {
             using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(reader["Id"]);
                        emp.Name = reader["Name"].ToString();
                        emp.Department = reader["Department"].ToString();
                        emp.Salary = Convert.ToDecimal(reader["Salary"]);
                        return emp;
                    }
                }
                 catch (MySqlException ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return null;
        }

        // Update Employee Salary
        public void UpdateSalary(int id, decimal newSalary)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Salary = @Salary WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Salary", newSalary);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Salary updated successfully.");
                    else
                        Console.WriteLine("Employee not found.");
                }
                 catch (MySqlException ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Delete Employee
        public void DeleteEmployee(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Employee deleted successfully.");
                    else
                         Console.WriteLine("Employee not found.");
                }
                 catch (MySqlException ex)
                {
                    Console.WriteLine("Database Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
