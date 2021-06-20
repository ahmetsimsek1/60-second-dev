CREATE TABLE dbo.Customers (
    CustomerID INT NOT NULL IDENTITY
    ,CONSTRAINT PK_Customers PRIMARY KEY (CustomerID)

    ,IsActive BIT NOT NULL
        CONSTRAINT DF_Customers_IsActive DEFAULT (1)

    ,FullName NVARCHAR(200) NOT NULL
    ,LastLoginDate DATETIME2 NOT NULL
);
GO

-- Just the login date
CREATE INDEX IX_LastLoginDate ON dbo.Customers (LastLoginDate);
GO

-- Login date plus the IsActive flag
CREATE INDEX IX_IsActiveLastLoginDate ON dbo.Customers (IsActive, LastLoginDate);
GO
