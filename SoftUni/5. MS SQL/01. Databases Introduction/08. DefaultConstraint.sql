--adding default constraint to be the current datetime
ALTER TABLE Users 
ADD CONSTRAINT DF_LastLoginTimeNow DEFAULT GETDATE() FOR LastLoginTime;

INSERT INTO Users(Username,[Password],ProfilePicture,IsDeleted)
VALUES
('PESHO1234','123456', NULL, 0);