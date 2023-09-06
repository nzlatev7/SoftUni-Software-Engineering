CREATE VIEW view_AllColumnAndFullNameByCondition2 AS
	SELECT *, FirstName + ' ' + LastName AS FullName 
	FROM Customers
	WHERE LastName = 'Petkov';


SELECT *, FirstName + ' ' + LastName AS FullName 
FROM Customers
WHERE LastName = 'Petkov';

SELECT * FROM view_AllColumnAndFullNameByCondition2;