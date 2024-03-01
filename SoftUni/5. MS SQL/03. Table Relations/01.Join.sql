SELECT MountainRange,PeakName,Elevation 
FROM Peaks p
JOIN Mountains m ON p.MountainId=m.Id
WHERE MountainId = 17
ORDER BY Elevation DESC;