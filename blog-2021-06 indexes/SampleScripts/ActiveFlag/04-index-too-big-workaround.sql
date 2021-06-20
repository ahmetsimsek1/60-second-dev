-- Taking out the date-only index, leaving the IsActive+Date index
ALTER INDEX IX_LastLoginDate ON dbo.Customers DISABLE;
GO

-- This time we're not filtering out the invalid records

-- If we query all records, then we won't be able to use a seek, and the whole table will be scanned

-- Instead, since we know we've got an index, we'll cheat and use it. Since it's a BIT field, we just have
-- to run this twice:

DECLARE @result TABLE (CustomerID INT);

DECLARE @MaxLoginDate DATETIME2 = DATEADD(DAY, -50, SYSDATETIME());
DECLARE @MinLoginDate DATETIME2 = DATEADD(DAY, -100, SYSDATETIME());

INSERT @result
SELECT CustomerID FROM dbo.Customers
WHERE LastLoginDate >= @MinLoginDate
AND LastLoginDate <= @MaxLoginDate
AND IsActive = 0;

INSERT @result
SELECT CustomerID FROM dbo.Customers
WHERE LastLoginDate >= @MinLoginDate
AND LastLoginDate <= @MaxLoginDate
AND IsActive = 1;

SELECT * FROM @result;

ALTER INDEX IX_LastLoginDate ON dbo.Customers REBUILD;
GO
