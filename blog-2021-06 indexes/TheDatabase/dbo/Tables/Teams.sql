CREATE TABLE dbo.Teams (
    TeamID INT IDENTITY NOT NULL
    ,CONSTRAINT PK_Teams PRIMARY KEY (TeamID)

    ,TeamName NVARCHAR (100) NOT NULL
);
GO

CREATE INDEX IX_TeamName ON dbo.Teams (TeamName);
GO
