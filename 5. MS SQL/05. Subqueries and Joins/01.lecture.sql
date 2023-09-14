SELECT * FROM Addresses;
SELECT * FROM Towns;

SELECT * FROM Addresses
JOIN Towns ON Addresses.TownID = Towns.TownID
				--VALUE = VALUE

SELECT * FROM Addresses
JOIN Towns ON Addresses.TownID = Towns.TownID
				--VALUE = VALUE

--CROSS JOIN
SELECT * FROM Addresses
CROSS JOIN Towns;

SELECT * FROM Addresses, Towns;

--task1
SELECT TOP(50) e.FirstName,e.LastName,t.[Name] AS Town,a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName,e.LastName;

--task2
SELECT EmployeeID,FirstName,LastName,'Sales' FROM Employees
WHERE DepartmentID = 3
ORDER BY EmployeeID;

SELECT e.EmployeeID,e.FirstName,e.LastName,d.[Name] FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID;

--task3
SELECT * FROM Employees
WHERE YEAR(HireDate) >= 1999;

SELECT FirstName,LastName,HireDate,[Name] AS DepartmentName FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01' --YEAR-MONTH-DAY FORMAT
	AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY HireDate;

--task4
SELECT TOP(50) e1.EmployeeID,
	CONCAT(e1.FirstName, ' ', e1.LastName) AS EmployeeName,
	CONCAT(e2.FirstName, ' ', e2.LastName) AS ManagerName,
	Name
FROM Employees e1
LEFT JOIN Employees e2 ON e1.ManagerID = e2.EmployeeID
LEFT JOIN Departments d ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID

--task5
SELECT MIN(AvgSalary) FROM
(SELECT AVG(Salary) AS AvgSalary FROM Employees
GROUP BY DepartmentID) AS TEMP
				
