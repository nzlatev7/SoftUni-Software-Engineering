--give me which room number with his lenght is for King room type

SELECT * FROM
	(SELECT [RoomNumber], [RoomTypes].[RoomType], [RoomTypes].[Notes], LEN([RoomTypes].[Notes]) AS NoteLength
	FROM [Rooms] 
	INNER JOIN [RoomTypes] ON [RoomTypes].[RoomType]=[Rooms].[RoomType]) AS RoomsInfo
	WHERE RoomType = 'King';


SELECT [RoomNumber], [RoomTypes].[RoomType], [RoomTypes].[Notes], LEN([RoomTypes].[Notes]) AS NoteLength
	FROM [Rooms]
	INNER JOIN [RoomTypes] ON [RoomTypes].[RoomType]=[Rooms].[RoomType]
	WHERE [RoomTypes].[RoomType] = 'King';


SELECT * FROM RoomTypes;
SELECT * FROM [Rooms];