ALTER TABLE Users 
DROP CONSTRAINT PK_Users_CompositeIdUsername;

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id PRIMARY KEY (id);

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_Username UNIQUE (Username);

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Username_Length CHECK(LEN(Username) >= 3);

INSERT INTO Users(Username, [Password])
VALUES('pee', '123455666')

DELETE FROM Users
WHERE LEN(Username) < 3;