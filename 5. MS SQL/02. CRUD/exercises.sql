--2 exercise
SELECT * FROM Departments;

--3 exercise
SELECT [Name] FROM Departments;

--4 exercise
SELECT FirstName, LastName, Salary FROM Employees;

--5 exercise
SELECT FirstName, MiddleName, LastName FROM Employees;

--6 exercise
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address] FROM Employees;

--7 exercise
--first way
SELECT DISTINCT Salary FROM Employees;

--second way
SELECT Salary 
FROM Employees
GROUP BY Salary;

--8 exercise
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative';

--9 exercise
SELECT FirstName, LastName, JobTitle 
FROM Employees 
WHERE Salary BETWEEN 20000 AND 30000;

SELECT FirstName, LastName, JobTitle 
FROM Employees 
WHERE Salary >= 20000 AND Salary <= 30000;

--10 exercise
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] 
FROM Employees
WHERE Salary IN (25000, 14000, 12500,23600)

--11 exercise
SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL;

--12 exercise
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--13 exercise
SELECT TOP(5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC

--14 exercise
SELECT FirstName, LastName
FROM Employees
WHERE DepartmentID != 4

--15 exercise
SELECT *
FROM Employees
ORDER BY Salary DESC, 
		FirstName ASC, 
		LastName DESC, 
		MiddleName ASC

--16 exercise
CREATE VIEW V_EmployeesSalaries AS
 SELECT FirstName, LastName, Salary 
 FROM Employees;

SELECT * FROM V_EmployeesSalaries;	

--17 exercise
--first way
CREATE VIEW V_EmployeeNameJobTitle AS
 SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle 
 FROM Employees;

--second way
--CREATE VIEW V_EmployeeNameJobTitle AS
-- SELECT FirstName + ' ' + COALESCE(MiddleName, '') + ' ' + LastName AS [Full Name], JobTitle 
-- FROM Employees;

SELECT * FROM V_EmployeeNameJobTitle;

--18 exercise
SELECT DISTINCT JobTitle 
FROM Employees;

--19 exercise
SELECT TOP(10) * 
FROM Projects
ORDER BY StartDate,[Name];

--20 exercise
SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC;

--21 exercise
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (1,2,4,11);

SELECT * FROM Employees;

UPDATE Employees
SET Salary = Salary / 1.12
WHERE DepartmentID IN (1,2,4,11);

SELECT Salary FROM Employees;

--22 exercise
USE Geography;

SELECT PeakName 
FROM Peaks
ORDER BY PeakName;

--23 exercise
SELECT TOP(30) CountryName, [Population] 
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName;

--24 exercise
SELECT 
	CountryName, 
	CountryCode, 
	CASE
        WHEN CurrencyCode = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END AS Currency
FROM Countries
ORDER BY CountryName;

--25 exercise
USE Diablo;

SELECT [Name]
FROM Characters
ORDER BY [Name];

--26 exercise
SELECT SUM([Salary]) 
FROM (SELECT TOP(5) [Salary] FROM [Employees]) AS [Table];