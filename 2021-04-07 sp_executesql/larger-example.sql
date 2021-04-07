IF OBJECT_ID('dbo.Accounts') IS NOT NULL DROP TABLE dbo.Accounts;
GO
CREATE TABLE dbo.Accounts (
    AccountID INT NOT NULL IDENTITY PRIMARY KEY
    ,IsActive BIT NOT NULL DEFAULT (1)
    ,CustomerID INT NOT NULL
    ,AccountBalance DECIMAL(18, 5) NOT NULL
);
GO

-- One way: a single statement that does everything:
IF OBJECT_ID('dbo.SearchAccount') IS NOT NULL DROP PROCEDURE dbo.SearchAccount;
GO
CREATE PROCEDURE dbo.SearchAccount (
    @CustomerID INT
    ,@ActiveOnly BIT = 1
    ,@AccountID INT = NULL
    ,@MinBalance DECIMAL(18, 5) = NULL
    ,@MaxBalance DECIMAL(18, 5) = NULL
)
AS
BEGIN
    SELECT * FROM dbo.Accounts
    WHERE CustomerID = @CustomerID
    AND (@ActiveOnly = 0 OR IsActive = 1)
    
    AND (@AccountID IS NULL OR AccountID = @AccountID)
    -- alternatively: AccountID = ISNULL(@AccountID, AccountID)

    AND (@MinBalance IS NULL OR AccountBalance >= @MinBalance)
    AND (@MaxBalance IS NULL OR AccountBalance <= @MaxBalance)
    -- alternatively: AccountBalance BETWEEN ISNULL(@MinBalance, 0) AND ISNULL(@MaxBalance, 999999999999)
END;
GO

-- Another way: dynamic SQL that's built based on what you pass in
IF OBJECT_ID('dbo.SearchAccount') IS NOT NULL DROP PROCEDURE dbo.SearchAccount;
GO
CREATE PROCEDURE dbo.SearchAccount (
    @CustomerID INT
    ,@ActiveOnly BIT = 1
    ,@AccountID INT = NULL
    ,@MinBalance DECIMAL(18, 5) = NULL
    ,@MaxBalance DECIMAL(18, 5) = NULL
)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    -- Be careful to ensure spacing is correct so you don't have runonwords.
    -- I like to just put spaces before and after everything just to be safe.
    SET @SQL = ' SELECT * FROM dbo.Accounts WHERE CustomerID = @CustomerID ';
    IF @ActiveOnly = 1
        SET @SQL += ' AND IsActive = 1 ';
    IF @AccountID IS NOT NULL
        SET @SQL += ' AND AccountID = @AccountID ';
    IF @MinBalance IS NOT NULL
        SET @SQL += ' AND AccountBalance >= @MinBalance ';
    IF @MaxBalance IS NOT NULL
        SET @SQL += ' AND AccountBalance <= @MaxBalance ';

    EXEC sp_executesql
        @SQL
        ,N'@CustomerID INT, @AccountID INT, @MinBalance DECIMAL (18, 5), @MaxBalance DECIMAL (18, 5)'
        ,@CustomerID = @CustomerID
        ,@AccountID = @AccountID
        ,@MinBalance = @MinBalance
        ,@MaxBalance = @MaxBalance;
END;
GO
