DECLARE @MaxLoginDate DATETIME2 = DATEADD(DAY, -50, SYSDATETIME());
DECLARE @MinLoginDate DATETIME2 = DATEADD(DAY, -100, SYSDATETIME());
SELECT CustomerID FROM dbo.Customers
WHERE IsActive = 1
AND LastLoginDate >= @MinLoginDate
AND LastLoginDate <= @MaxLoginDate;
