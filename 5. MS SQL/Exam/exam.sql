--EXAM

--1
CREATE DATABASE Accounting;
USE Accounting;

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT NOT NULL REFERENCES Countries(Id)
)

CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(10) NOT NULL,
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(35) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	VendorId INT NOT NULL REFERENCES Vendors(Id)
)

CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DateTime2 NOT NULL,
	DueDate DateTime2 NOT NULL,
	Amount DECIMAL(18,2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT NOT NULL REFERENCES Clients(Id)
)

CREATE TABLE ProductsClients(
	ProductId INT REFERENCES Products(Id),
	ClientId INT REFERENCES Clients(Id),
	PRIMARY KEY(ProductId,ClientId)
)

--2
INSERT INTO Products(Name,Price,CategoryId,VendorId)
VALUES('SCANIA Oil Filter XD01','78.69',1,1),
	('MAN Air Filter XD01','97.38',1,5),
	('DAF Light Bulb 05FG87','55.00',2,13),
	('ADR Shoes 47-47.5','49.85',3,5),
	('Anti-slip pads S','5.87',5,7)

INSERT INTO Invoices(Number,IssueDate,DueDate,Amount,Currency,ClientId)
VALUES(1219992181,'2023-03-01','2023-04-30', 180.96,'BGN',3),
	(1729252340,'2022-11-06','2023-01-04', 158.18,'EUR',13),
	(1950101013,'2023-02-17','2023-04-18', 615.15,'USD',19)

--3
SELECT * FROM Invoices

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE DATEPART(YEAR,IssueDate) = 2022 AND DATEPART(MONTH,IssueDate) = 11

SELECT * FROM Clients
WHERE Name LIKE '%CO%'

SELECT * FROM Addresses

UPDATE Clients
SET AddressId = 3
WHERE Name LIKE '%CO%'

--4
SELECT * FROM Clients

DELETE FROM ProductsClients
WHERE ClientId IN (SELECT ClientId FROM Clients WHERE NumberVAT LIKE 'IT%')

DELETE FROM Invoices
WHERE ClientId IN (SELECT ClientId FROM Clients WHERE NumberVAT LIKE 'IT%')

DELETE FROM Clients
WHERE NumberVAT LIKE 'IT%'

--5
SELECT Number,Currency FROM Invoices
ORDER BY Amount DESC,DueDate

--6
SELECT p.Id,p.Name,Price, c.Name
FROM Products p
JOIN Categories c ON p.CategoryId = c.Id
WHERE CategoryId = 3 OR CategoryId = 5
ORDER BY Price DESC

--7

SELECT * FROM Addresses

--FIRST WAY
SELECT Id,Name,AddressId FROM Clients c
LEFT JOIN ProductsClients p ON C.Id = p.ClientId
WHERE ProductId IS NULL

--SECOND WAY
SELECT c.Id,c.Name as Client,CONCAT(a.StreetName,' ',a.StreetNumber,', ',a.City,', ',a.PostCode,', ',ct.Name) as  Address
FROM Clients c
JOIN Addresses a ON c.AddressId = a.Id
JOIN Countries ct ON ct.Id = a.CountryId
WHERE c.Id NOT IN (SELECT ClientId FROM ProductsClients)


--8
SELECT TOP(7) Number,Amount,c.Name FROM Invoices i
JOIN Clients c ON i.ClientId = c.Id
WHERE (IssueDate < '01-01-2023' AND Currency = 'EUR') OR (Amount > 500.00 AND c.NumberVAT LIKE 'DE%')
ORDER BY Number, Amount DESC

--9
--one way
SELECT Name,Price,NumberVAT
FROM (SELECT c.Id,c.Name,Price,NumberVAT,ROW_NUMBER() OVER(PARTITION BY c.Name ORDER BY PRICE DESC) AS [RANK]
		FROM Clients c
		JOIN ProductsClients pc ON pc.ClientId = c.Id
		JOIN Products p ON p.Id = pc.ProductId
		WHERE c.Name NOT LIKE '%KG') AS tmp
WHERE [RANK] = 1
ORDER BY Price DESC

--another way
SELECT c.Name,MAX(Price),NumberVAT FROM Clients c
JOIN ProductsClients pc ON pc.ClientId = c.Id
JOIN Products p ON p.Id = pc.ProductId
WHERE c.Name NOT LIKE '%KG'
GROUP BY c.Name, NumberVAT
ORDER BY MAX(Price) DESC;


--10
SELECT c.Name, CONVERT(INT,AVG(Price)) AS AVGPrice FROM Clients c
JOIN ProductsClients pc ON c.Id = pc.ClientId
JOIN Products p ON pc.ProductId = p.Id
JOIN Vendors v ON p.VendorId = v.Id
WHERE v.NumberVAT LIKE 'FR%'
GROUP BY pc.ClientId,c.Name
ORDER BY AVGPrice, c.Name DESC


SELECT * FROM Clients
SELECT * FROM Products
SELECT * FROM Vendors

SELECT CONVERT(INT, 12.7)

--11

CREATE OR ALTER FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*) FROM Products p
	JOIN ProductsClients pc ON p.Id = pc.ProductId
	WHERE p.Name = @name)
END

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')


--12
CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(10))
AS
BEGIN
	SELECT v.Name, NumberVAT, 
	CONCAT(StreetName,' ',StreetNumber) AS [Street Info],
	CONCAT(City, ' ', PostCode)
	FROM Vendors v
	JOIN Addresses a ON a.Id = v.AddressId
	JOIN Countries c ON c.Id = a.CountryId
	WHERE c.Name = @country
	ORDER BY v.Name, City
END

EXEC usp_SearchByCountry 'France'