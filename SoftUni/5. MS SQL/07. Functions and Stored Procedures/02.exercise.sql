--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

EXECUTE usp_GetEmployeesSalaryAbove35000

--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number
END

EXECUTE usp_GetEmployeesSalaryAboveNumber 48100

--3
CREATE PROCEDURE usp_GetTownsStartingWith(@String NVARCHAR(10))
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE SUBSTRING([Name], 1, LEN(@String)) = @String
END

EXECUTE usp_GetTownsStartingWith 'b'

--4
CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName NVARCHAR(50))
AS
BEGIN
	SELECT FirstName, LastName 
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	WHERE t.Name = @TownName
END

EXECUTE usp_GetEmployeesFromTown  'Sofia'

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	IF(@salary < 30000)
		RETURN 'Low'
	ELSE IF(@salary <= 50000)
		RETURN 'Average'
	ELSE
		RETURN 'High'
	RETURN NULL
END;

SELECT Salary, 
dbo.ufn_GetSalaryLevel(20000) AS [Salary Level]
FROM Employees

--6
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
END

EXECUTE usp_EmployeesBySalaryLevel 'High'

--7 - need to finish this solution 1cycle and two variab	les
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS CHAR(1)
AS
BEGIN
	DECLARE @i1 INT = LEN(@word)
	DECLARE @i2 INT = LEN(@setOfLetters)

	DECLARE @currentWordCh CHAR(1) = ''
	DECLARE @currentLetterCh CHAR(1) = ''

	--SET IT BY DEFAULT TO FALSE
	DECLARE @trueFalseValue CHAR(1) = 0;

	WHILE(@i1 > 0)
	BEGIN
		
		SET @currentWordCh = SUBSTRING(@word, @i1, 1)
		SET @i1 -= 1

		WHILE(@i2 > 0)
		BEGIN
			SET @currentLetterCh = SUBSTRING(@setOfLetters, @i2, 1)
			SET @i2 -= 1

			IF(@currentLetterCh = @currentWordCh)
			BEGIN
				SET @trueFalseValue = 1;
				BREAK
			END
		END

		IF(@trueFalseValue = 0)
			RETURN 0

		SET @trueFalseValue = 0
		SET @i2 = LEN(@setOfLetters)
	END

	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

--8
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId  INT)
AS
BEGIN
	--one reference
	DELETE ep FROM EmployeesProjects ep
	JOIN Employees e ON ep.EmployeeId = e.EmployeeId
	WHERE e.DepartmentID = @departmentId

	--alter the managerId in departments
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT NULL;
	
	--set it to null because we will delete it
	UPDATE d
	SET d.ManagerId = NULL
	FROM Departments d
	JOIN Employees e ON d.ManagerID = e.EmployeeID
	WHERE e.DepartmentID = @departmentId

	--set it to null because we will delete it
	UPDATE e2
	SET e2.ManagerId = NULL
	FROM Employees e1
	JOIN Employees e2 ON e1.EmployeeID = e2.ManagerID
	WHERE e1.DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId;
END

EXECUTE usp_DeleteEmployeesFromDepartment 7



--here i see the differenct tables and think about the solution
ALTER TABLE Employees
ALTER COLUMN Addressid INT  NULL;

update Employees
set DepartmentID = null
where DepartmentID = 5

select * from Employees
select * from EmployeesProjects
select * from Departments
delete from Departments where DepartmentID = 5

SELECT * FROM Departments d
JOIN Employees e ON d.ManagerID = e.EmployeeID
where e.DepartmentID = 2

--9
SELECT * FROM AccountHolders
SELECT * FROM Accounts

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name] 
	FROM AccountHolders
END

EXECUTE usp_GetHoldersFullName

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName
	FROM AccountHolders ah
	JOIN Accounts a ON a.AccountHolderId = ah.Id
	GROUP BY AH.Id, FirstName, LastName
	HAVING SUM(Balance) > @minBalance
	ORDER BY FirstName, LastName
END

usp_GetHoldersWithBalanceHigherThan 20000


--11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @yearsNum INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @yearlyInterestRate, @yearsNum))
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


--12
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	DECLARE @currentBalance DECIMAL(12,2) = 
		(SELECT TOP(1) Balance FROM Accounts
		WHERE AccountHolderId = @accountId)

	SELECT Id, 
		FirstName, 
		LastName, 
		@currentBalance,
		dbo.ufn_CalculateFutureValue(@currentBalance, @yearlyInterestRate, 5)
	FROM AccountHolders
	WHERE Id = @accountId
END

EXECUTE usp_CalculateFutureValueForAccount 1, 0.1


--13
CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS @table TABLE(
	SumCash DECIMAL(12,2)
)
AS
BEGIN
	DECLARE @gameId INT = 
	(SELECT Id 
	FROM Games
	WHERE Name = @gameName)

	INSERT INTO @table
	SELECT SUM(Cash) FROM (SELECT Cash,
		ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [Rank]
		FROM UsersGames
		WHERE GameId = @gameId) AS RankedCDash
	WHERE [Rank] % 2 <> 0

	RETURN;
END

SELECT * FROM ufn_CashInUsersGames('Love in a mist')
SELECT dbo.ufn_CashInUsersGames('Sweet William')

SELECT * FROM UsersGames
WHERE GameId = 90
SELECT * FROM Games WHERE Id = 90


--onother way
CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT(
	SELECT SUM(Cash) FROM (SELECT Cash,
		ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [Rank]
		FROM UsersGames
		WHERE GameId = (SELECT Id 
			FROM Games
			WHERE [Name] = @gameName)) AS RankedCDash
	WHERE [Rank] % 2 <> 0) AS SumCash

SELECT * FROM ufn_CashInUsersGames('Love in a mist')