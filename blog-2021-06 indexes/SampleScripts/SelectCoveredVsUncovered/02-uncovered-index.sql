-- Disable the covered index so the uncovered one will be used
ALTER INDEX IX_Team1ID_Covered ON dbo.Scores DISABLE;
GO

SELECT
	ScoreID, Team1ID, Team2ID, Team1Score, Team2Score
FROM dbo.Scores
WHERE Team1ID = 475
GO

-- See the result has extra steps to join the Team1ID index back to the clustered index

-- Re-enable the covered index
ALTER INDEX IX_Team1ID_Covered ON dbo.Scores REBUILD;
GO
