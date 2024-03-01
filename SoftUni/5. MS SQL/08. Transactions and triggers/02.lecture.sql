SELECT * FROM AccountHolders;
SELECT * FROM Accounts;

DROP TRIGGER OnDelete

CREATE OR ALTER TRIGGER OnDelete
ON AccountHolders
INSTEAD OF DELETE
AS
BEGIN
    -- Update the isDeleted column to 1 (true) for the deleted user
    UPDATE AccountHolders
    SET isDeleted = 1
    WHERE Id IN (SELECT Id FROM DELETED);
	 PRINT 'AFTER Trigger BeforeTriggerExample1 executed!'
END;

DELETE FROM AccountHolders
WHERE Id = 13

CREATE TABLE Logs(
Id INT PRIMARY KEY IDENTITY,
DeletedName NVARCHAR(50) NOT NULL,
[Date] DATETIME2 NOT NULL
)

CREATE OR ALTER TRIGGER OnDeleteLog
ON AccountHolders
INSTEAD OF DELETE
AS
BEGIN
    INSERT INTO Logs(DeletedName, [Date])
VALUES((SELECT top(1) FirstName from deleted), getdate())
END;
-- we can not make this trigger,
--because sql server does not allow multiple INSTEAD OF triggers

--SAVE THE DELETED ACCOUNTS WITH DATE
SELECT * FROM Logs

--CHECK FOR A CLIENT WITHOUT ACCOUNT
SELECT * FROM Accounts a
RIGHT JOIN AccountHolders ah ON a.AccountHolderId = ah.Id

--MAKE THIS CLIENT BECAUSE EVERY CLIENT HAVE ACCOUNT
INSERT INTO AccountHolders(Id,FirstName,LastName,SSN,IsDeleted)
VALUES (13,'Gencho','Penev','123333333',0)

--to insert data in another table(Logs) that will be called deletedTable and to delete the data
CREATE OR ALTER TRIGGER LogDeletedRecord
ON AccountHolders
FOR DELETE
AS
BEGIN
	PRINT 'AFTER Trigger AfterTriggerExample2 executed!'
    INSERT INTO Logs(DeletedName, [Date])
	SELECT FirstName,GETDATE() 
	FROM deleted
END;