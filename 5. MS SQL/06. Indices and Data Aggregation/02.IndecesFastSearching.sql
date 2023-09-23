SELECT *
  FROM [Demo].[dbo].[Customers]
  WHERE PaymentNumber LIKE '5%'

-- DELETE THE LOADED CACHE
DBCC DROPCLEANBUFFERS;

--BEFORE INSERTING -> 293 records
SELECT *
  FROM [Demo].[dbo].[Customers]
  where PaymentNumber like '1%' and  PaymentNumber like '%4'

--DECFLARE VARIABLES
DECLARE @Counter int = 294;
DECLARE @FirstName NVARCHAR(50) = (SELECT TOP(1) FirstName FROM Customers);
DECLARE @PaymentNumber char(16) = (SELECT TOP(1) PaymentNumber FROM Customers);

--LOOP FOR INSERTING RECORDS
WHILE (SELECT COUNT(*) FROM [Customers]) < 30000
BEGIN
	
	INSERT INTO Customers(CustomerID, FirstName, PaymentNumber) 
	VALUES (@Counter, @FirstName, @PaymentNumber)
	SET @Counter = @Counter + 1
END

-- CREATE NON CLUSTERED INDEX FOR PaymentNumber COLUMN FOR FAST SEARCHING
CREATE INDEX IX_Customers_PaymentNumber
ON Customers (PaymentNumber);

--DROP THE INDEX
DROP INDEX [IX_Customers_PaymentNumber] ON CUSTOMERS;

--AFTER INSERTING -> 30000 records
SELECT *
  FROM [Demo].[dbo].[Customers]
  where PaymentNumber like '1%' and  PaymentNumber like '%4'




