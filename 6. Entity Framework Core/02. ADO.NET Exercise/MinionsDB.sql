CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	Name varchar(50) not null
);

CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	Name varchar(50) not null,
	Age tinyint not null,
	TownId INT NOT NULL REFERENCES Towns(Id)
);
CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	Name varchar(50) not null,
	CountryId INT NOT NULL REFERENCES Countries(Id)
);
CREATE TABLE Villains(
	Id INT PRIMARY KEY IDENTITY,
	Name varchar(50) not null,
	EvilnessFactorId INT NOT NULL REFERENCES EvilnessFactors(Id)
);
CREATE TABLE EvilnessFactors(
	Id INT PRIMARY KEY IDENTITY,
	Name varchar(50) not null,
);
CREATE TABLE MinionsVillains(
	MinionId INT NOT NULL REFERENCES Minions(Id),
	VillainId INT NOT NULL REFERENCES Villains(Id),
	PRIMARY KEY(MinionId,VillainId)
);

INSERT INTO Countries(Name)
VALUES ('Bulgaria'),('Spain'),('Romania'),('Serbia'),('Turkey')

INSERT INTO Towns(Name,CountryId)
VALUES ('sofia',1),('madrid',2),('kotva',3),('belgrade',4),('ankara', 5)

INSERT INTO EvilnessFactors(Name)
VALUES ('super good'),('good'),('bad'),('evil'),('super evil')

INSERT INTO Minions(Name, Age, TownId)
VALUES ('Petko',83,1),('Ganio',40,2),('Pencho',18,1),('Stoqn',16,1),('Stamo',53,3)

INSERT INTO Villains(Name, EvilnessFactorId)
VALUES ('Blago',1),('Ivaylo',2),('Gencho',2),('Marian',4),('Koko',1)

INSERT INTO MinionsVillains(MinionId, VillainId)
VALUES (1,5),(1,2),(1,4),(2,1),(2,4),(3,1),(1,3),(2,3),(4,3),(3,4),(4,4),(5,4)

SELECT Name, COUNT(MinionId) FROM Villains v
JOIN MinionsVillains m ON v.Id = m.VillainId
GROUP BY Name
HAVING COUNT(MinionId) > 2
ORDER BY COUNT(MinionId) DESC
