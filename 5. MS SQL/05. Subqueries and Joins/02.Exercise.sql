--exercise1
SELECT TOP(5) EmployeeID, JobTitle, a.AddressID, a.AddressText 
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER  BY AddressID;

--exercise2
SELECT TOP(50) FirstName, LastName, t.[Name], a.AddressText 
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
ORDER BY FirstName,LastName;

--exercise3
SELECT EmployeeID, FirstName, LastName, d.[Name]
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID;

--exercise4
SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name]
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID;

--exercise5
SELECT TOP(3) e.EmployeeID, FirstName
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE e.EmployeeID NOT IN(SELECT EmployeeID FROM EmployeesProjects)
ORDER BY EmployeeID;

--exercise6
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY HireDate;

--exercise7
SELECT TOP(5) e.EmployeeID, FirstName, p.Name
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND EndDate IS NULL
ORDER BY e.EmployeeID;

--exercise8
SELECT e.EmployeeID, FirstName,
	CASE
    WHEN YEAR(p.StartDate) >= 2005 THEN NULL
    ELSE p.Name
END AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24;

--exercise9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID

--exercise10
SELECT TOP(50) e.EmployeeID, 
	CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName, 
	CONCAT(m.FirstName,' ', m.LastName) AS ManagerName, 
	d.[Name] AS DepartmentName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY E.EmployeeID

--exercise11
SELECT MIN(Salary) FROM
(SELECT AVG(Salary) AS Salary FROM Employees
GROUP BY DepartmentID) AS tmp

--exercise12
SELECT * FROM Peaks
SELECT * FROM Mountains
SELECT * FROM MountainsCountries


SELECT CountryCode, MountainRange, PeakName, Elevation
FROM Peaks p
JOIN Mountains m ON p.MountainId = m.Id
JOIN MountainsCountries mc ON mc.MountainId = m.Id
WHERE CountryCode = 'BG' AND Elevation > 2835
ORDER BY Elevation DESC;

--exercise13
SELECT CountryCode, COUNT(CountryCode)
FROM MountainsCountries
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode;

--exercise14
SELECT * FROM Countries
SELECT * FROM Rivers
SELECT * FROM CountriesRivers

SELECT TOP(5) CountryName, RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE ContinentCode = 'AF'
ORDER BY CountryName;

--exercise15
SELECT * FROM Continents
SELECT * FROM Currencies
SELECT * FROM Countries


SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM
	(SELECT ContinentCode,
			CurrencyCode, 
			COUNT(*) AS CurrencyUsage,
			RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(*) DESC) AS [Rank]
	FROM Countries
	GROUP BY CurrencyCode,ContinentCode) AS TEMP
WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode;


--exercise16
SELECT
	(SELECT COUNT(CountryCode) FROM Countries) -
	(SELECT COUNT(CountryCode) 
	FROM 
		(SELECT MC.CountryCode
		FROM Countries c
		JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
		GROUP BY MC.CountryCode) AS TMP) AS [Count]


--exercise17
SELECT TOP(5) [first].CountryName, HighestPeakElevation, LongestRiverLength FROM (SELECT CountryName,HighestPeakElevation FROM
(
	SELECT c.CountryName, Elevation AS HighestPeakElevation,
	RANK() OVER (PARTITION BY c.CountryName ORDER BY Elevation DESC) AS [Rank]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id) AS tmp
WHERE [Rank] = 1) AS [first]
JOIN 
(
	SELECT CountryName,LongestRiverLength FROM
	(
		SELECT c.CountryName, [Length] AS LongestRiverLength,
		RANK() OVER (PARTITION BY c.CountryName ORDER BY [Length] DESC) AS [Rank]
		FROM Countries c
		LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers r ON r.Id = cr.RiverId) as tmp
	WHERE [Rank] = 1) AS [second]
ON [first].CountryName = [second].CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC, [first].CountryName;

--17 ANOTHER WAY
SELECT TOP(5) CountryName, 
	MAX(Elevation) AS HighestPeakElevation,
	MAX([Length]) AS LongestRiverLength
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON m.Id = mc.MountainId
LEFT JOIN Peaks p ON p.MountainId = m.Id
LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--exercise18
SELECT TOP(5) CountryName, 
	[Highest Peak Name], 
	[Highest Peak Elevation], 
	Mountain 
FROM
	(SELECT c.CountryName,
			CASE
				WHEN p.PeakName IS NULL THEN '(no highest peak)'
				ELSE p.PeakName
			END AS [Highest Peak Name],
			CASE
				WHEN MAX(Elevation) IS NULL THEN '0'
				ELSE MAX(Elevation)
			END AS [Highest Peak Elevation],
			CASE
				WHEN MountainRange IS NULL THEN '(no mountain)'
				ELSE MountainRange
			END AS [Mountain],
			RANK() OVER(PARTITION BY c.CountryName ORDER BY Elevation DESC) AS [PeakRank]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON C.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY c.CountryName,MountainRange,p.PeakName,Elevation) as Tmp
WHERE [PeakRank] = 1
ORDER BY CountryName, [Highest Peak Name];