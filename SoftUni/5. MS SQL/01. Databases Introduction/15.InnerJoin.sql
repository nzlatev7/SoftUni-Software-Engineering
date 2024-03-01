
--inner join
SELECT Movies.Id,Movies.Title,Directors.DirectorName FROM Movies
INNER JOIN Directors ON Movies.DirectorId=Directors.Id;

SELECT Movies.Id,Movies.Title,Directors.DirectorName + ' ' + Directors.Notes AS DirectorNameAndNotes FROM Movies
INNER JOIN Directors ON Movies.DirectorId=Directors.Id;

SELECT * FROM Directors
	WHERE DirectorName LIKE '%A'