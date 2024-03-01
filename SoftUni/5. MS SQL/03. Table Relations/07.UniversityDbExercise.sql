CREATE DATABASE University;

USE University;

CREATE TABLE Majors(
	MajorId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
);

CREATE TABLE Students(
	StudentId INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(7) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorId INT NOT NULL,
	CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorId)
    REFERENCES Majors(MajorId)
);

CREATE TABLE Payments(
	PaymentId INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL(7,2) NOT NULL,
	StudentId INT NOT NULL,
	CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentId)
    REFERENCES Students(StudentId)
);

CREATE TABLE Subjects(
	SubjectId INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(50) NOT NULL,
);

CREATE TABLE Agenda(
	StudentId INT NOT NULL,
	SubjectId INT NOT NULL,
	CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentId)
    REFERENCES Students(StudentId),
	CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectId)
    REFERENCES Subjects(SubjectId),
	CONSTRAINT PK_Agenda_Composite PRIMARY KEY (StudentId, SubjectId)
);