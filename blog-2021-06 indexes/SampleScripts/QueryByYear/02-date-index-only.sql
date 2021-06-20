-- Disable the year index
ALTER INDEX IX_GameYear ON dbo.Scores DISABLE;
GO

SELECT COUNT(1)
FROM dbo.Scores
WHERE YEAR(GameDate) = 2019;
GO

-- The date index exists, but since you're querying by a function
-- rather than a date, the date index is not used, and you
-- get a full table scan

-- Re-enable the computed column index
ALTER INDEX IX_GameYear ON dbo.Scores REBUILD;
GO
