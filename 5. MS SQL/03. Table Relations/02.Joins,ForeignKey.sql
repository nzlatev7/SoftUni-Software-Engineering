--one to many join
SELECT * 
FROM Courses c
JOIN Towns t ON c.TownId = t.Id;

--many to many join
SELECT s.Name,c.Name
FROM Students s
JOIN StudentsInCourses sc ON s.Id=sc.StudentId
JOIN Courses c ON sc.CouseId = c.Id;

ALTER TABLE Courses
ADD CONSTRAINT FK_TownId
FOREIGN KEY (TownId) REFERENCES Towns(Id);