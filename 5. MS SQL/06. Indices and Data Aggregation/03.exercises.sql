SELECT * FROM WizzardDeposits

--exercise1
SELECT COUNT(*) 
FROM WizzardDeposits;

--exercise2
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits;

--exercise3
SELECT DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup;

--exercise4
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--exercise5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--exercise6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--exercise7
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--exercise8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--exercise9
SELECT AgeGroup, COUNT(*) AS WizardCount
FROM
	(SELECT
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits) AS temp
GROUP BY AgeGroup;

--exercise10
SELECT FirstLetter
FROM
	(SELECT SUBSTRING(FirstName,1,1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest') AS TrollChestFirstLetters
GROUP BY FirstLetter
ORDER BY FirstLetter

--exercise11
SELECT DepositGroup,IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

SELECT * FROM WizzardDeposits


--selecting the previous, the current and the next
SELECT * 
FROM
	(SELECT
	LAG(FirstName) OVER (ORDER BY Id) PreviousValue,
	FirstName,
	LEAD(FirstName) OVER (ORDER BY Id) NextValue
	FROM WizzardDeposits) AS TEM
WHERE NextValue IS NOT NULL

--current and next without the last record
SELECT * 
FROM
	(SELECT
	FirstName,
	LEAD(FirstName) OVER (ORDER BY Id) NextValue
	FROM WizzardDeposits) AS TEM
WHERE NextValue IS NOT NULL

SELECT
FirstName,
LEAD(FirstName) OVER (ORDER BY Id) NextValue,
LEAD(LEAD(FirstName) OVER (ORDER BY Id)) OVER (ORDER BY Id) NextValue2
FROM WizzardDeposits

--the old way without the build in functions in sql server
WITH RankedFirstName AS (
SELECT
	rownum = RANK() OVER (ORDER BY Id),
	FirstName,
	DepositAmount
FROM WizzardDeposits
)

SELECT SUM([Difference]) AS SumDifference
FROM
	(SELECT
		RankedFirstName.FirstName AS [Host Wizard],
		RankedFirstName.DepositAmount AS [Host Wizard Deposit],
		Nex.FirstName AS [Guest Wizard],
		Nex.DepositAmount AS [Guest Wizard Deposit],
		RankedFirstName.DepositAmount  - Nex.DepositAmount AS Difference
	FROM RankedFirstName
	JOIN RankedFirstName AS Nex ON Nex.rownum = RankedFirstName.rownum + 1) AS AllDifferencies

--exercise12
SELECT SUM([Difference]) 
FROM
	(SELECT FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
		LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
		DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
	FROM WizzardDeposits) AS AllDifferencies

--exercise13
USE SoftUni

SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

--exercise14
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--exercise15
SELECT * INTO EmployeesDemo
FROM Employees
WHERE Salary > 30000

DELETE 
FROM EmployeesDemo 
WHERE ManagerID = 42;

UPDATE EmployeesDemo
SET Salary = Salary + 5000
WHERE DepartmentID = 1;

SELECT DepartmentID,
	AVG(Salary) AS AverageSalary
FROM EmployeesDemo
GROUP BY DepartmentID

--exercise16
SELECT DepartmentID,
	MAX(Salary)
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--exercise17
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

--exercise18
SELECT DepartmentID, Salary AS [ThirdHighestSalary]
FROM
	(SELECT DepartmentID, 
		Salary,
		RANK() OVER (PARTITION BY DEPARTMENTID ORDER BY SALARY DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary) AS RankedSalaryPerDepartment
WHERE [Rank] = 3;

--exercise19
SELECT DepartmentID,
	AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID

SELECT TOP(10) FirstName,
	LastName,
	e.DepartmentID FROM Employees e
JOIN (SELECT DepartmentID,
		AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID) AS AveragePerDepartment
ON AveragePerDepartment.DepartmentID = e.DepartmentID
WHERE e.Salary > AveragePerDepartment.AvgSalary
ORDER BY DepartmentID


