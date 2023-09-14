SELECT * FROM Employees;

--CONCAT
SELECT *,CONCAT(FirstName,'.', MiddleName,'.',LastName) AS FullName
FROM Employees;

--CONCAT_WS - CONCAT THE NOT NULL VALUE
SELECT *,CONCAT_WS('.',FirstName,MiddleName,LastName) AS FullName
FROM Employees;

--SUBSTRING
SELECT *,SUBSTRING(FirstName, 1,3) AS Name
FROM Employees;

--REPLACE
SELECT *,REPLACE(JobTitle, 'Manager','Man...') AS JobTitle2
FROM Employees;

--REVERSE
SELECT *,REVERSE(JobTitle) AS JobTitle2
FROM Employees;

--REPLICATE
SELECT *,REPLICATE(JobTitle + ' ',2) AS JobTitle2
FROM Employees;