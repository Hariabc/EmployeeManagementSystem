-- Create Database
CREATE DATABASE IF NOT EXISTS EmployeeDB;
USE EmployeeDB;

-- Create Employees Table
CREATE TABLE IF NOT EXISTS Employees (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL
);

-- Insert Sample Data
INSERT INTO Employees (Name, Department, Salary) VALUES 
('John Doe', 'IT', 60000.00),
('Jane Smith', 'HR', 55000.00),
('Mike Johnson', 'Finance', 70000.00);

-- Select all to verify
SELECT * FROM Employees;
