SELECT SUM(Salary) 
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

SELECT DepartmentID,MAX(FirstName),
	MIN(FirstName),
	STRING_AGG(FirstName, ' ') FROM Employees
GROUP BY DepartmentID

SELECT DepartmentID, 
	FirstName, 
	STRING_AGG(LastName, ', ')
FROM Employees
GROUP BY DepartmentID, FirstName
HAVING COUNT(LastName) > 1
 