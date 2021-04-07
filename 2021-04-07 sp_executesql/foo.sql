IF OBJECT_ID('dbo.Foos') IS NOT NULL DROP TABLE dbo.Foos;
GO
CREATE TABLE dbo.Foos (
    FooID INT NOT NULL IDENTITY PRIMARY KEY
    ,SomeValue NVARCHAR(100) NOT NULL
);
GO
INSERT dbo.Foos (SomeValue) VALUES ('aaa'), ('bbb'), ('ccc');

DECLARE @SQL NVARCHAR(MAX) = N'
    IF EXISTS (SELECT 1 FROM dbo.Foos WHERE SomeValue = @SomeValue)
        RAISERROR(''This value already exists'', 16, 99);
    
    INSERT dbo.Foos (SomeValue) VALUES (@SomeValue);
';
DECLARE @PARMS NVARCHAR(MAX) = N'@SomeValue NVARCHAR(100)';

-- error is thrown
EXEC sp_executesql @SQL, @PARMS, @SomeValue = 'aaa';

-- inserted successfully
EXEC sp_executesql @SQL, @PARMS, @SomeValue = 'ddd';

-- inserted successfully as-is, no SQL injection
EXEC sp_executesql @SQL, @PARMS, @SomeValue = ''');DROP TABLE Foo';


SET @SQL = N'
    INSERT dbo.Foos (SomeValue) VALUES (@SomeValue);
    SELECT @FooID = SCOPE_IDENTITY();
';
SET @PARMS = N'@SomeValue NVARCHAR(100), @FooID INT OUTPUT';
DECLARE @FooID INT;
EXEC sp_executesql @SQL, @PARMS, @SomeValue = 'ddd', @FooID = @FooID OUTPUT;
PRINT @FooID; -- prints the parameter value
