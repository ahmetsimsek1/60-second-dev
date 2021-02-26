CREATE TABLE dbo.WorkerQueue
(
    WorkerQueueID INT NOT NULL IDENTITY,
    CONSTRAINT PK_WorkerQueue
        PRIMARY KEY (WorkerQueueID),
    CreateDateUTC DATETIME NOT NULL
        CONSTRAINT DF_WorkerQueue_CreateDate
            DEFAULT (SYSUTCDATETIME()),
    WorkerDetails NVARCHAR(100),
    StatusCode NCHAR(3)
        CONSTRAINT DF_WorkerQueue_StatusCode
            DEFAULT ('NEW')
);
go
