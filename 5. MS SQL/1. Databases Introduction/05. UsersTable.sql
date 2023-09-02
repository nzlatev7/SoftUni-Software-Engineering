CREATE TABLE Users(
	--by default this is not null
	--instead of using auto_increment, we need to use identity
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	--like byte[]
	ProfilePicture VARBINARY(MAX)
	--this return the size of what is stored in the colomn, return bytes
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
);

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime,IsDeleted)
VALUES
('PESHO','12345', NULL, '05.19.2020', 0),
('gOSH','123456', NULL, '05.19.2020', 0),
('EWE','1234578', NULL, '05.19.2020', 1),
('EF','1234584', NULL, '05.19.2020', 1),
('EGG','1234562', NULL, '05.19.2020', 1);

SELECT * FROM Users;