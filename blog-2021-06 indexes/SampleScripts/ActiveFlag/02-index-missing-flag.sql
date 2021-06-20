-- Dropping the index with the IsActive flag, leaving the date index
ALTER INDEX IX_IsActiveLastLoginDate ON dbo.Customers DISABLE;
GO

DECLARE @MaxLoginDate DATETIME2 = DATEADD(DAY, -50, SYSDATETIME());
DECLARE @MinLoginDate DATETIME2 = DATEADD(DAY, -100, SYSDATETIME());
SELECT CustomerID FROM dbo.Customers
WHERE LastLoginDate >= @MinLoginDate
AND LastLoginDate <= @MaxLoginDate
AND IsActive = 1

-- Index is not used, so you get a full table scan

-- Putting the index back
ALTER INDEX IX_IsActiveLastLoginDate ON dbo.Customers REBUILD;
GO
