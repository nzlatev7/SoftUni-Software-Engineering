
--FROM 5645322227179083 TO 564532**********
SELECT 
    CONCAT(
        LEFT(PaymentNumber, 6),
        REPLICATE('*', LEN(PaymentNumber) - 6)
    ) AS PaymentNumber
FROM Customers;

--area of triangle
SELECT
	A * H / 2 AS Area	
FROM Triangles2

--length of a line by coordinates
SELECT Id,
	SQRT(SQUARE(ABS(X1) + ABS(X2))  + SQUARE(ABS(Y1) + ABS(Y2)))
	AS [Length]
FROM Lines;

--palletCount exercise
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Quantity]
      ,[BoxCapacity]
      ,[PalletCapacity],
	  CEILING(1.0 * [Quantity] /  ([BoxCapacity] * [PalletCapacity])) AS PalletCount
  FROM [Demo].[dbo].[Products]

--quarter and other stuff using DATEPART

SELECT [InvoiceId], [Total],
	DATEPART(QUARTER,[InvoiceDate]) AS [Quarter],
	DATEPART(MONTH,[InvoiceDate]) AS [Month],
	DATEPART(YEAR,[InvoiceDate]) AS [Year],
	DATEPART(DAY,[InvoiceDate]) AS [Day]
  FROM [Demo].[dbo].[Invoices]


