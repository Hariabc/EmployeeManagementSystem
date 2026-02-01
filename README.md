# Employee Management System

A Console Application built with C# and MySQL to manage employee records. This system allows performing CRUD (Create, Read, Update, Delete) operations on an employee database.

## 🚀 Features

- **Add Employee**: Create new employee records with Name, Department, and Salary.
- **View All Employees**: List all employees currently in the system in a formatted table.
- **Search Employee**: Find details of a specific employee using their unique ID.
- **Update Salary**: Modify the salary of an existing employee.
- **Delete Employee**: Remove an employee record from the database with confirmation.

## 🛠️ Technology Stack

- **Language**: C# (.NET)
- **Database**: MySQL
- **Data Access**: ADO.NET (using `MySql.Data`)
- **Architecture**: Layered (DAL and Console UI)

## 📋 Prerequisites

Before running the application, ensure you have the following installed:

1.  **.NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download)
2.  **MySQL Server**: [Download MySQL Community Server](https://dev.mysql.com/downloads/mysql/)

## ⚙️ Setup & Configuration

### 1. Database Setup

1.  Open your MySQL Client (Workbench or Command Line).
2.  Run the provided SQL script located in the root folder:
    `DatabaseSetup_MySQL.sql`
    
    This script will:
    - Create the database `EmployeeDB`.
    - Create the `Employees` table.
    - Insert initial sample data.

### 2. Configure Connection String

1.  Navigate to `EmployeeManagementSystem/EmployeeDAL.cs`.
2.  Locate the connection string on **line 14**:
    ```csharp
    private string connectionString = "Server=localhost;Database=EmployeeDB;Uid=root;Pwd=root;";
    ```
3.  **IMPORTANT**: Update the `Uid` (Username) and `Pwd` (Password) to match your local MySQL configuration.

## ▶️ How to Run

1.  Open a terminal or command prompt.
2.  Navigate to the project directory:
    ```bash
    cd EmployeeManagementSystem
    ```
3.  Restore dependencies (if needed):
    ```bash
    dotnet restore
    ```
4.  Run the application:
    ```bash
    dotnet run
    ```

## 📝 Usage

Follow the on-screen menu prompts to interact with the system:

```text
--- Employee Management System ---
1. Add Employee
2. View All Employees
3. Search Employee by Id
4. Update Salary
5. Delete Employee
6. Exit
Enter your choice:
```
