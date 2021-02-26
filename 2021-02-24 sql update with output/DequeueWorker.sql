CREATE PROCEDURE dbo.DequeueWorker
(@WorkerQueueID INT OUTPUT)
AS
BEGIN
    DECLARE @result TABLE
    (
        WorkerQueueID INT
    );

    ;WITH first_record
    AS (SELECT WorkerQueueID, StatusCode
        FROM dbo.WorkerQueue WITH (ROWLOCK, READPAST, UPDLOCK)
        WHERE StatusCode = 'NEW'
        ORDER BY WorkerQueueID
        OFFSET 0 ROWS
        FETCH NEXT 1 ROW ONLY)
    UPDATE first_record
    SET StatusCode = 'RUN'
    OUTPUT inserted.WorkerQueueID
    INTO @result
    FROM first_record WITH (ROWLOCK, READPAST, UPDLOCK);

    SELECT @WorkerQueueID = WorkerQueueID
    FROM @result;
END;
GO

