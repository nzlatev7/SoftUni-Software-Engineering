CREATE DATABASE Hotel;

USE Hotel;

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(100)
);

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(100)
);


CREATE TABLE RoomStatus(
	-- first way -> assume that 0 is freely, 1 is busy -> RoomStatus BIT NOT NULL
	-- second way -> assume that these are the possible values: occupied, vacant, dirty, clean, ready and out of order
	RoomStatus VARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(100)
);

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(100)
);

CREATE TABLE BedTypes(
	BedType NVARCHAR(10) PRIMARY KEY,
	Notes NVARCHAR(100)
);

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate TINYINT,
	RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(100)
);


CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(9,2) NOT NULL,
	TaxRate DECIMAL(5,2) NOT NULL,
	TaxAmount DECIMAL(9,2) NOT NULL,
	PaymentTotal DECIMAL(9,2) NOT NULL,
	Notes NVARCHAR(100)
);

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(7,2) NOT NULL,
	PhoneCharge DECIMAL(7,2) NOT NULL,
	Notes NVARCHAR(100)
);

INSERT INTO Employees(FirstName, LastName, Title, Notes)
	VALUES
		('Atanas','Ivanov','bartender','making shots'),
		('Ivan','Ivanov','cooker','cook dishes'),
		('Nikolay','Petkov','cleaner','clean the room after the customers');


INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	VALUES
		('Peter','Petkov','0896744432','Police','112',NULL),
		('Miroslav','Petrov','0765432190','Police','112',NULL),
		('Genadii','Ugnqnov','0765432190','Police','112',NULL);

INSERT INTO RoomStatus(RoomStatus, Notes)
	VALUES
		('occupied','the room is occupied'),
		('vacant',NULL),
		('dirty','the room is dirty so for this reason we can not make it ready for customers'),
		('ready','ready for customers');

INSERT INTO RoomTypes(RoomType, Notes)
	VALUES
		('King','the best choice but quite expensive'),
		('Suite','normal suite'),
		('Studio','bed-sitter, or bachelor apartment');

INSERT INTO BedTypes(BedType, Notes)
	VALUES
		('Cribs','best for children'),
		('King Bed','the alfa bed'),
		('Queen bed','for queens'),
		('Sofa','');

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus)
	VALUES
		('King','Cribs',5,'occupied'),
		('Studio','King Bed',NULL,'ready'),
		('Suite','Sofa',4,'dirty');


INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber,FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
	VALUES
		(1, GETDATE(), 1, GETDATE(), '09-' + cast(DAY(GETDATE()) + 5 AS varchar(2))  + '-2023', DAY(GETDATE()) + 5, 2000, 10, 200, 2200),
		(3, GETDATE(), 2, GETDATE(), '09-' + cast(DAY(GETDATE()) + 6 AS varchar(2))  + '-2023', DAY(GETDATE()) + 6, 3000, 12, 360, 3360),
		(2, GETDATE(), 2, GETDATE(), '09-' + cast(DAY(GETDATE()) + 7 AS varchar(2))  + '-2023', DAY(GETDATE()) + 7, 10000, 11, 1100, 11100);

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	VALUES
		(1, GETDATE(), 1, 8, 30, 10, NULL),
		(3, GETDATE(), 2, 6, 22, 12, NULL),
		(2, GETDATE(), 2, 7, 21, 11, NULL);



SELECT * FROM Employees;
SELECT * FROM Customers;
SELECT * FROM RoomStatus;
SELECT * FROM RoomTypes;
SELECT * FROM BedTypes;
SELECT * FROM Rooms;
SELECT * FROM Payments;
SELECT * FROM Occupancies;