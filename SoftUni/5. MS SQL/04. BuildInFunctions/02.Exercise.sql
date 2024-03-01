--Exercises: Built-in Functions

--1.
SELECT FirstName, LastName
  FROM [Employees]
  WHERE FirstName LIKE 'Sa%';

--2
SELECT FirstName, LastName
  FROM [Employees]
  WHERE LastName LIKE '%ei%';

--3
SELECT FirstName
  FROM [Employees]
  WHERE DepartmentID IN(3,10) AND YEAR(HireDate) BETWEEN 1995 AND 2005;

--4
SELECT FirstName, LastName
  FROM [Employees]
  WHERE JobTitle NOT LIKE '%engineer%';

--5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name];

--6
SELECT *
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name];

--7
SELECT *
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name];

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE YEAR(HireDate) > 2000;

--9
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5;

--10
SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE  Salary >= 10000 AND Salary <= 50000
ORDER BY Salary DESC;

--addition
SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER(ORDER BY Salary DESC) AS [Rank]
FROM Employees

--11
SELECT * FROM
	(SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY EmployeeId) AS [Rank]
	FROM Employees
	WHERE  Salary >= 10000 AND Salary <= 50000) Demo
WHERE [Rank] = 2
ORDER BY Salary DESC;

--12
SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode;

--13
SELECT PeakName, RiverName, lOWER(PeakName+SUBSTRING(RiverName, 2, LEN(RiverName) - 1)) AS Mix
FROM Peaks 
JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY MIX;

--14
SELECT TOP(50) [Name], FORMAT(Start, 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) = 2011 OR YEAR([Start]) = 2012
ORDER BY [Start],[Name]

--15
SELECT 
    Username,
    SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS EmailProvider
FROM Users
ORDER BY EmailProvider ASC, Username ASC;

--16
SELECT Username,IpAddress 
FROM Users
WHERE IpAddress LIKE '[1-9][0-9][0-9].1[0-9]%.[1-9]%.[1-9][0-9][0-9]'
ORDER BY Username

--another solution
SELECT Username,IpAddress 
FROM Users
WHERE IpAddress LIKE '___.1[0-9]%.[1-9]%.___'
ORDER BY Username

--17
SELECT *
FROM
	(SELECT 
		[Name],
		CASE
			WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18  THEN 'Afternoon'
			WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
		END AS [Part of the Day],
		CASE
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long '
			ELSE 'Extra Long' 
		END AS Duration
	FROM Games) AS GamePartOfTheDay
ORDER BY [Name],Duration,[Part of the Day]

--UNICODE AND ASCII BYTES REPRESENTATIOIN
SELECT DATALENGTH(N'Õ» »')

--18
SELECT ProductName,[OrderDate],
	DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
	DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders].[dbo].[Orders]

--19
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATETIME2 NOT NULL
);

INSERT INTO People([Name], Birthday)
VALUES
		('Victor', '2000-12-07 00:00:00.000'),
		('Steven', '1992-09-10 00:00:00.000'),
		('Stephen', '1910-09-19 00:00:00.000'),
		('John', '2010-01-06 00:00:00.000');

SELECT [Name],
	YEAR(GETDATE()) - YEAR(Birthday) AS [Age in Years],
	DATEDIFF(DAY,Birthday,GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE,Birthday,GETDATE()) AS [Age in Days]
FROM People
