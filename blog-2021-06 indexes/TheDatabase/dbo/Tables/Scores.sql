CREATE TABLE dbo.Scores (
    ScoreID INT IDENTITY NOT NULL
    ,CONSTRAINT PK_Scores PRIMARY KEY (ScoreID)

    ,Team1ID INT NOT NULL
    ,CONSTRAINT FK_Scores_Team1ID FOREIGN KEY (Team1ID) REFERENCES dbo.Teams (TeamID)

    ,Team2ID INT NOT NULL
    ,CONSTRAINT FK_Scores_Team2ID FOREIGN KEY (Team2ID) REFERENCES dbo.Teams (TeamID)

    ,Team1Score INT NOT NULL
    ,Team2Score INT NOT NULL
    ,GameDate DATETIME2 NOT NULL
    ,_WinningTeamID AS (
        CASE
            WHEN Team1Score > Team2Score THEN Team1ID 
            WHEN Team2Score > Team1Score THEN Team2ID 
        END
    )
    ,_GameYear AS DATEPART(YEAR, GameDate)
);
GO

-- Index on the date
CREATE INDEX IX_GameDate
ON dbo.Scores (GameDate);
GO

-- Index on computed column
CREATE INDEX IX_GameYear
ON dbo.Scores (_GameYear);
GO

-- Covered
CREATE INDEX IX_Team1ID_Covered
ON dbo.Scores (Team1ID)
INCLUDE (Team2ID, Team1Score, Team2Score, GameDate, _WinningTeamID);
GO

-- Uncovered
CREATE INDEX IX_Team1ID_Uncovered
ON dbo.Scores (Team1ID);
GO
