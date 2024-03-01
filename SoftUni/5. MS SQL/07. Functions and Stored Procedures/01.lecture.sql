--declare variable
DECLARE @Year SMALLINT = 2023;
SET @Year = 2022;

SELECT @Year;

--Functions
--user defined functions
--power build in function custom making
SELECT POWER(2,3)

CREATE FUNCTION udf_Power (@base TINYINT, @ext TINYINT)
RETURNS BIGINT
AS
BEGIN
    DECLARE @result BIGINT = 1;

	WHILE (@ext > 0)
	BEGIN
		SET @result *= @base;
		SET @ext = @ext - 1;
	END

    RETURN @result
END;

--FIRST CUSTOM BUILD IN FUNCTION
SELECT [dbo].[udf_Power](10,2)
   
--drop
DROP FUNCTION [dbo].[udf_Power]

--creating a fucntion that count the weeks
CREATE FUNCTION udf_WeeksCount (@StartDate DATETIME2, @EndDate DATETIME2)
RETURNS INT
AS
BEGIN
    IF (@EndDate IS NULL)
	BEGIN
		SET @EndDate = GETDATE();
	END

    RETURN DATEDIFF(WEEK, @StartDate, @EndDate)
END;

SELECT Name,
StartDate,
EndDate,
[dbo].[udf_WeeksCount](StartDate, EndDate) AS WeeksCount
FROM Projects

--exercise to return the count of employees hired on date

CREATE FUNCTION udf_GetHiredEmployeesCountOnYear(@Year INT)
RETURNS INT
AS
BEGIN
	RETURN 
		(SELECT COUNT(*) 
		FROM Employees
		WHERE YEAR(HireDate) = @Year)
END

--the count is 16
SELECT COUNT(*) 
FROM Employees
WHERE YEAR(convert(DATETIME2, HireDate)) = 2000

--the count is 16
SELECT [dbo].[udf_GetHiredEmployeesCountOnYear](2000)


--salary exercise
CREATE FUNCTION ufn_GetSlaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10)
	IF(@Salary < 30000)
	SET @result = 'Low';
	ELSE IF(@Salary >= 30000 AND @Salary <= 50000)
	SET @result = 'Average';
	ELSE IF(@Salary > 50000)
	SET @result = 'High';

	RETURN @result;
END

SELECT FirstName,
	LastName,
	Salary,
	dbo.ufn_GetSlaryLevel(Salary) as SalaryLevel
FROM Employees



--store procedures -> two types
	-- User defined procedures
	-- System defined procedures

EXEC sys.sp_tables

--HERE WE MAKE A CODE THAT WE WANT TO EXECUTE MORE THAT ONE TIME, 
--WE WANT TO USE IT OVER AND OVER AGAIN
CREATE OR ALTER PROCEDURE sp_InsertEmployeeForProject(@EmployeeId INT, @ProjectId INT)
AS
	DECLARE @CurrentEmployeeProjectsCount INT = 0;
	SET @CurrentEmployeeProjectsCount = (SELECT COUNT(*) 
		FROM EmployeesProjects
		WHERE EmployeeID = @EmployeeId)

	IF(@CurrentEmployeeProjectsCount > 2)
	BEGIN
		THROW 50001, 'The current user has so many projects for now!', 1
	END

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	VALUES (@EmployeeId,@ProjectId)
GO

--the correct way
EXECUTE [dbo].[sp_InsertEmployeeForProject] 240,1

--when we throw error
EXECUTE [dbo].[sp_InsertEmployeeForProject] 246,1

SELECT * FROM Projects

SELECT * FROM EmployeesProjects
WHERE EmployeeID = 240

--TRY WITH 1 EMPLOYEE
--TRY WITH 240 EMPLOYEEID, ADD PROJECT WITH ID = 1

--here we set year to 19 by default
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience
(
	@Year INT = 19, 
	@MinSalary MONEY = 10000,
	@Count INT OUT
)
AS
	SET @Count =
		(SELECT COUNT(*) FROM Employees
		WHERE YEAR(GETDATE()) - YEAR(HireDate) > @Year
			AND Salary > @MinSalary)
GO

DECLARE @CountResult INT;
EXECUTE dbo.sp_GetEmployeesByExperience @Count = @CountResult OUTPUT; 

SELECT @CountResult


CREATE OR ALTER PROCEDURE sp_GetAllDepartments
AS
	SELECT * FROM Towns
	select * from Employees
GO

DECLARE @T TABLE (
	TownId INT PRIMARY KEY, 
	Name VARCHAR(50) NOT NULL);

Insert @T EXEC sp_GetAllDepartments
select * from @T
