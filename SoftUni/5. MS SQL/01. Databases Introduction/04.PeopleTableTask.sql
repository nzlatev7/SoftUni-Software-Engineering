CREATE TABLE People(
	--by default this is not null
	--instead of using auto_increment, we need to use identity
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
);

INSERT INTO People([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography])
	VALUES
			('PESHO',NULL, 122.4, 100,'m', '1990-09-15 10:30:45.123456', 'I am a software engineer'),
			('PESHO',NULL, 122.4, 100,'m', '1990-09-15 10:30:45.123456', 'I am a software engineer'),
			('PESHO',NULL, 122.4, 100,'m', '1990-09-15 10:30:45.123456', 'I am a software engineer'),
			('PESHO',NULL, 122.4, 100,'m', '1990-09-15 10:30:45.123456', 'I am a software engineer'),
			('PESHO',NULL, 122.4, 100,'m', '1990-09-15 10:30:45.123456', 'I am a software engineer');
