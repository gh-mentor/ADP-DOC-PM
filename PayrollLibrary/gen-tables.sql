/*
This file contains a script of Transact SQL (T-SQL) command to interact with a database named 'Payroll'.
Requirements:
- SQL Server 2022 is installed and running
- database 'Payroll' already exists.
Errors:
If the database 'Payroll' does not exist, the script will fail with the following error: 
Msg 911, Level 16, State 1, Line 1
*/

USE Payroll;

-- Create the Employees table
CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    ReportsTo INT,
    Name NVARCHAR(50),
    Email NVARCHAR(50),
    Mobile NVARCHAR(15),
    DepartmentID INT,
    -- Add a created date column
    CreatedDate DATETIME DEFAULT GETDATE(),
    -- Add a modified date column
    ModifiedDate DATETIME DEFAULT GETDATE()
);

-- Create the HourlyEmployees and SalariedEmployees tables
CREATE TABLE HourlyEmployees
(
    EmployeeID INT PRIMARY KEY,
    HourlyRate DECIMAL(10, 2),
    HoursWorked DECIMAL(10, 2),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE SalariedEmployees
(
    EmployeeID INT PRIMARY KEY,
    WeeklySalary DECIMAL(10, 2),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);


-- create a stored procedure to insert a new employee
CREATE PROCEDURE InsertEmployee
    @EmployeeID INT,
    @ReportsTo INT,
    @Name NVARCHAR(50),
    @Email NVARCHAR(50),
    @Mobile NVARCHAR(15),
    @DepartmentID INT
AS
BEGIN
    INSERT INTO Employees (EmployeeID, ReportsTo, Name, Email, Mobile, DepartmentID)
    VALUES (@EmployeeID, @ReportsTo, @Name, @Email, @Mobile, @DepartmentID);
END;