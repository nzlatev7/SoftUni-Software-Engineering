SELECT * FROM Customers;
SELECT TOP(2) * FROM Customers;

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
	VALUES
			('Peter', 'Stoqnov', 0765432190, 'Police', 112),
			('Vasil', 'Petkov', 0765432190, 'Police', 112)

SELECT LastName, COUNT(*) as NumberOfCustomers
FROM Customers
GROUP BY LastName;

---here we group by the lastname and select the phones count that this lastname have
SELECT LastName, COUNT(PhoneNumber) AS NumberOfEmails
FROM Customers
GROUP BY LastName;

SELECT * FROM Customers WHERE PhoneNumber LIKE '08%'

--give me the lastname and the count of bulgarian phone numbers for this lastname
SELECT LastName, COUNT(CASE WHEN PhoneNumber LIKE '08%' THEN 1 ELSE NULL END) AS IsBulgarianPhoneNumber
FROM Customers
GROUP BY LastName;


SELECT DISTINCT LastName FROM Customers;
