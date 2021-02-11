SELECT * FROM dbo.Games g;
SELECT * FROM dbo.GamesHistory gh;

INSERT dbo.Games (Team1Score, Team2Score, GameDate)
VALUES (7, 6, '2021-01-19 19:00'),
       (108, 90, '2021-01-20 20:00');

SELECT * FROM dbo.Games g;
SELECT * FROM dbo.GamesHistory gh;

DELETE dbo.Games WHERE GameID = 1;
UPDATE dbo.Games SET Team2Score += 1 WHERE GameID = 2;

SELECT * FROM dbo.Games g;
SELECT * FROM dbo.GamesHistory gh;
