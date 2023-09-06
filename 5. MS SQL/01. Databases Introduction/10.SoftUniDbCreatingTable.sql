CREATE DATABASE SoftUni;

USE SoftUni;

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT NOT NULL 
	FOREIGN KEY REFERENCES Towns(Id) 
);

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT NOT NULL
	FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(9,2) NOT NULL,
	AddressId INT NOT NULL
	FOREIGN KEY REFERENCES Addresses(Id)
);

ALTER TABLE Employees
ALTER COLUMN AddressId INT NULL;

INSERT INTO Towns([Name])
VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas');

INSERT INTO Departments([Name])
VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance');

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
		('Ivna', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88);