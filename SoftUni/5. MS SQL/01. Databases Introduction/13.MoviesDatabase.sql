CREATE DATABASE Movies;

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(150)
);

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(150)
);

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(150)
);

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear Date NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating TINYINT NOT NULL,
	Notes NVARCHAR(150)
);

INSERT INTO Directors(DirectorName,Notes)
VALUES
		('Sami', 'wdwdwdwd'),
		('Bogi', NULL),
		('Kolio', NULL),
		('Kalata', 'DIRECTOR FROM 10 YEARS'),
		('Niki', 'wdwdwdwd');

INSERT INTO Genres(GenreName,Notes)
VALUES
		('Horror', 'scary film'),
		('Western', 'american type of films'),
		('Action', 'great  for watching'),
		('Comedy', 'more for families'),
		('Romance', 'for girls!');

INSERT INTO Categories(CategoryName)
VALUES
		('fiction'),
		('fiction'),
		('fiction'),
		('non-fiction'),
		('non-fiction');

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES 
		('phineas and ferb', 1, '2023-09-04', 100000, 3, 6, 5, 'playing outside every day!'),
		('phineas and ferb', 5, '2023-09-04', 100000, 3, 8, 4, 'playing outside every day!'),
		('phineas and ferb', 2, '2023-09-04', 100000, 3, 10, 3, 'playing outside every day!'),
		('phineas and ferb', 5, '2023-09-04', 100000, 3, 9, 2, 'playing outside every day!'),
		('phineas and ferb', 4, '2023-09-04', 100000, 3, 8, 1, 'playing outside every day!');

SELECT * FROM Categories;
SELECT * FROM Directors;
SELECT * FROM Genres;
SELECT * FROM Movies;
