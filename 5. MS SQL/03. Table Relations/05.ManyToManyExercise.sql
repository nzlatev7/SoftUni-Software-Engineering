CREATE DATABASE ManyToManyRelationship;

USE ManyToManyRelationship;

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
);

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
);

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID)
    REFERENCES Exams(ExamID),
	PRIMARY KEY (StudentID,ExamID)
);

INSERT INTO Students([Name])
	VALUES
			('Mila'),
			('Toni'),
			('Ron');

INSERT INTO Exams([Name])
	VALUES
			('SpringMVC'),
			('Neo4j'),
			('Oracle 11g');

SELECT * FROM Students
SELECT * FROM Exams

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES
			(1,101),
			(1,102),
			(2,101),
			(3,103),
			(2,102),
			(2,103);
