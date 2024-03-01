CREATE DATABASE OneToOneRelationship;

USE OneToOneRelationship;

CREATE TABLE Persons(
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2),
	PassportId INT NOT NULL
);

CREATE TABLE Passports(
	PassportId INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber CHAR(8) NOT NULL,
);

INSERT INTO Persons(FirstName, Salary, PassportId)
	VALUES
			('Roberto', '43300.00',102),
			('Tom', '56100.00',103),
			('Yana', '60200.00',101);

INSERT INTO Passports(PassportNumber)
	VALUES
			('N34FG21B'),
			('K65LO4R7'),
			('ZE657QP2');

SELECT * FROM Persons;
SELECT * FROM Passports;

SELECT *
FROM Persons
JOIN Passports ON Persons.PassportId = Passports.PassportId;

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportId) REFERENCES Passports(PassportId);

ALTER TABLE Persons
ADD CONSTRAINT UC_Persons_PassportId UNIQUE (PassportId);