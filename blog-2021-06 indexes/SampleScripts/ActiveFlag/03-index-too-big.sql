-- Taking out the date-only index, leaving the IsActive+Date index
ALTER INDEX IX_LastLoginDate ON dbo.Customers DISABLE;
GO

-- This time we're not filtering out the invalid records
DECLARE @MaxLoginDate DATETIME2 = DATEADD(DAY, -50, SYSDATETIME());
DECLARE @MinLoginDate DATETIME2 = DATEADD(DAY, -100, SYSDATETIME());
SELECT CustomerID FROM dbo.Customers
WHERE LastLoginDate >= @MinLoginDate
AND LastLoginDate <= @MaxLoginDate;

-- The index cannot be used

ALTER INDEX IX_LastLoginDate ON dbo.Customers REBUILD;
GO
