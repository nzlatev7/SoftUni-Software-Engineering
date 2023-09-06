CREATE DATABASE Minions;

CREATE TABLE Minions(
    Id INT PRIMARY KEY NOT NULL,
	--here we escape the Name colomn because is a special word in sql
	[Name] NVARCHAR(50) NOT NULL,
	--TINYINT -> 0 to 255
	Age TINYINT
);

CREATE TABLE Towns(
    Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
);

SELECT * FROM Minions;

--delete table
DROP TABLE Towns;

--ALTER THE TABLE -> ADD FOREIGN KEY THAT REFERENCE TO THE TOWNS ID COLOMN
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY 
REFERENCES Towns (id);