--Exercise
SELECT * FROM AccountHolders;
SELECT * FROM Accounts;

--1
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	OldSum DECIMAL(9,2) NOT NULL,
	NewSum DECIMAL(9,2) NOT NULL
)

CREATE TRIGGER LogUserAmount
ON Accounts
FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT d.Id, d.Balance, i.Balance
	FROM deleted d
	JOIN inserted i ON d.Id = i.Id
END

UPDATE Accounts
SET Balance += 200
WHERE Id = 7

SELECT * FROM Logs

--2
CREATE OR ALTER TRIGGER EmailNotificationLog
ON Logs
FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient,[Subject],Body)
	SELECT AccountId, 'Balance change for account: '+ CONVERT(NVARCHAR,AccountId), 'On ' + CONVERT(NVARCHAR,GETDATE()) + ' your balance was changed from ' +  CONVERT(NVARCHAR,OldSum) + ' to ' +  CONVERT(NVARCHAR,NewSum) + '.'
	FROM inserted
END

CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL REFERENCES Accounts(Id),
	[Subject] NVARCHAR(100) NOT NULL,
	Body NVARCHAR(MAX) NOT NULL
)

SELECT * FROM NotificationEmails;

--3

CREATE OR ALTER PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(12,4))
AS
BEGIN
	IF(@MoneyAmount <= 0)
	RETURN

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
END


EXEC usp_DepositMoney 1, 10

--4
CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(12,4))
AS
BEGIN
	IF(@MoneyAmount <= 0)
	RETURN

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
END

EXEC usp_WithdrawMoney 1, 10

--5
CREATE OR ALTER PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(12,4))
AS
BEGIN
	BEGIN TRANSACTION;

	IF(@Amount <= 0)
	RETURN;

	EXEC usp_WithdrawMoney @SenderId, @Amount
	EXEC usp_DepositMoney @ReceiverId, @Amount
	COMMIT
END

EXEC usp_TransferMoney 2, 1, 574.23

--6
USE Diablo

SELECT u.Username,ug.[Level],ug.Cash, i.MinLevel FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
where GameId = 212;

UPDATE ug
SET Cash += 50000
FROM UsersGames ug
JOIN Users u ON ug.UserId = u.Id
WHERE Username IN ('baleremuda','loosenoise','inguinalself','buildingdeltoid','monoxidecos ') AND GameId = 212;

CREATE TRIGGER checkLevel
ON UserGameItems
FOR INSERT
AS
BEGIN
	IF((SELECT COUNT(*) FROM UserGameItems i
		JOIN UsersGames ug ON ug.Id = i.UserGameId
		JOIN Items it ON it.Id = i.ItemId
		WHERE [Level] < MinLevel) <> 0)
	ROLLBACK TRANSACTION
END

SELECT * FROM UsersGames WHERE ID = 103
SELECT * FROM Items WHERE ID= 2
SELECT * FROM UserGameItems
INSERT INTO UserGameItems(ItemId,UserGameId) VALUES (2,103),(2,100)

INSERT INTO UserGameItems(ItemId,UserGameId)
SELECT i.Id, tmp.Id FROM Items i
CROSS JOIN 
	(SELECT ug.Id,ug.[Level] FROM UsersGames ug
	JOIN Users u ON ug.UserId = u.Id
	WHERE Username IN ('baleremuda','loosenoise','inguinalself','buildingdeltoid','monoxidecos ') AND GameId = 212) as tmp
WHERE ((i.Id BETWEEN 251 AND 299) OR (i.Id BETWEEN 501 AND 539)) AND [Level] >= MinLevel


--all current inserted in UserGameItems -> 2407 (SELECT * FROM UserGameItems)
--all records when making a cross join -> 440
--valid for inserting after AND [Level] >= MinLevel -> 277

SELECT * FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
JOIN Games g ON g.Id = ug.GameId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE G.Id = 100
ORDER BY Username, i.[Name]

--7
CREATE OR ALTER PROCEDURE buyItems
AS
BEGIN
	BEGIN TRANSACTION
		INSERT INTO UserGameItems(ItemId, UserGameId)
		SELECT Id, 110 FROM Items
		WHERE (MinLevel BETWEEN 11 AND 12) OR (MinLevel BETWEEN 19 AND 21)

		IF((SELECT Cash FROM UsersGames WHERE Id = 110) < 
			(SELECT SUM(Price) FROM Items WHERE (MinLevel BETWEEN 11 AND 12) OR (MinLevel BETWEEN 19 AND 21)))
		BEGIN
			ROLLBACK
		END
		ELSE COMMIT
END

EXEC buyItems

--THE CURRENT USER
SELECT * FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON g.Id = ug.GameId
WHERE Username = 'STAMAT' AND [Name] = 'SAFFLOWER'

UPDATE UsersGames
SET Cash += 10000
WHERE ID = 110;

--CURRENTLY THIS PERSON HAVE 11 ITEMS
SELECT * FROM UserGameItems WHERE UserGameId = 110;

SELECT SUM(Price) FROM Items
WHERE (MinLevel BETWEEN 11 AND 12) OR (MinLevel BETWEEN 19 AND 21)

SELECT * FROM UserGameItems ugi
JOIN Items i ON i.Id = ugi.ItemId
WHERE UserGameId = 110
ORDER BY [Name]

--8
USE SoftUni
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	IF((SELECT COUNT(*) FROM Employees e
		JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
		WHERE e.EmployeeID = @emloyeeId) >= 3)
	BEGIN
		THROW 50001, 'The employee has too many projects!', 1;
	END

	INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
	VALUES(@emloyeeId,@projectID)
END

EXEC usp_AssignProject 2, 13

SELECT * FROM EmployeesProjects


--9
-- TO REMOVE THE RELATIONS
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(DepartmentID),
	Salary MONEY NOT NULL
)

CREATE OR ALTER TRIGGER InsertDeletedRecord
ON Employees
FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees(EmployeeId, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT EmployeeID,FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary FROM deleted
END

SELECT * FROM Employees

SELECT * FROM Deleted_Employees

SELECT * FROM Departments
WHERE ManagerID IS NULL

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID BETWEEN 11 AND 21

DELETE FROM Employees
WHERE EmployeeID BETWEEN 11 AND 21

DELETE FROM EmployeesProjects
WHERE EmployeeID BETWEEN 11 AND 21

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID BETWEEN 2 AND 9

DELETE FROM EmployeesProjects
WHERE EmployeeID BETWEEN 2 AND 9

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID BETWEEN 2 AND 9
DELETE FROM Departments
WHERE ManagerID BETWEEN 2 AND 9

--custom exercise
CREATE TABLE CustomLogs(
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(100) NOT NULL
)

BEGIN TRANSACTION
WHILE ((SELECT COUNT(*) FROM CustomLogs) < 50000)
INSERT INTO CustomLogs([Message]) VALUES('OPA')
COMMIT

SELECT * FROM CustomLogs
