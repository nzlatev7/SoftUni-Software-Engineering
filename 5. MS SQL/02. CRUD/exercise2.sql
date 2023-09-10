SELECT * FROM Departments
SELECT * FROM Employees

SELECT AVG(Salary) AS AverageSalaryForMarketing FROM Employees
WHERE DepartmentID = 4

SELECT SUM(AverageSalary) 
FROM (SELECT AVG(Salary) AS AverageSalary FROM Employees
GROUP BY DepartmentID) AS [TABLE]

SELECT SUM(Salary) 
FROM Employees 
WHERE DepartmentID = 9;

SELECT *
FROM Employees 
WHERE DepartmentID = 9;

SELECT TOP(1) * FROM Employees
WHERE DepartmentID = 9
ORDER BY Salary DESC;

SELECT TOP(1) * 
FROM Departments d
JOIN(
	SELECT DepartmentID, SUM(Salary) AS DepartmentsSalary
	FROM Employees e
	GROUP BY e.DepartmentID
) e ON d.DepartmentID = e.DepartmentID
ORDER BY e.DepartmentsSalary DESC;

SELECT TOP(1) * 
FROM Departments d
JOIN(
	SELECT DepartmentID, AVG(Salary) AS DepartmentsSalary
	FROM Employees e
	GROUP BY e.DepartmentID
) e ON d.DepartmentID = e.DepartmentID
ORDER BY e.DepartmentsSalary DESC;

--IN WHICH TOWN THE Employees HAVE THE HIGHEST SALARY
SELECT * FROM Towns
SELECT * FROM Employees
SELECT * FROM Addresses

SELECT Addresses.AddressText,Towns.[Name] FROM Addresses
JOIN Towns ON Addresses.TownID = Towns.TownID;

SELECT TOP(1) SUM(Salary) AS TotalSalary FROM Employees
JOIN Addresses ON Addresses.AddressId = Employees.AddressId
JOIN Towns ON Towns.TownID = Addresses.TownID
GROUP BY Towns.TownID
ORDER BY TotalSalary DESC;

