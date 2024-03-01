SELECT Name, COUNT(MinionId) AS [Count] FROM Villains v JOIN MinionsVillains m ON v.Id = m.VillainId GROUP BY Name HAVING COUNT(MinionId) > 2 ORDER BY COUNT(MinionId) DESC


insert into Villains(Name, EvilnessFactorId) values ('kaio', 2);
select Name from Villains where id = 17;
SELECT Name, Age FROM Minions m JOIN MinionsVillains mv ON m.Id = mv.MinionId WHERE MV.VillainId = 4 ORDER BY Name

SELECT m.Id FROM Minions m JOIN Towns t ON m.TownId = t.Id where t.Name = 'sofia'

select * from Minions
insert into Towns(Name, CountryId) values ('', 1);

select count(*) from Villains where Name = 'pepi'

delete from Towns where name = 'haskovo'
select * from Towns
insert into Towns(Name, CountryId) values ('haskovo', 1)

select * from Villains
select * from MinionsVillains

(7,1)

Minion: Petko 83 haskovo
Villain: gergi

--haskovo
--gergi


