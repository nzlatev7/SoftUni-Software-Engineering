SELECT * FROM Customers;

--DECLARE THE VARIBLE
DECLARE @NewEmergencyNameAmbulance NVARCHAR(50);

--SET THE EXISTING VARIABLE
SET @NewEmergencyNameAmbulance = 'Ambulance';

DECLARE @NewEmergencyNameFire NVARCHAR(50);
SET @NewEmergencyNameFire = 'Fire';

UPDATE Customers
SET EmergencyName = @NewEmergencyNameFire
WHERE LastName LIKE 'U%';
