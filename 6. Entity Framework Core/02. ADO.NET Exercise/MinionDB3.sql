delete from MinionsVillains where MinionId = 2 and VillainId = 2
select * from Minions
select * from Villains;
select * from MinionsVillains

delete from MinionsVillains where VillainId = 2
select * from Towns

delete from Villains where Id = 5

CREATE PROCEDURE usp_GetOlder(@MinionId INT)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE Id = @MinionId
END

EXEC usp_GetOlder 1