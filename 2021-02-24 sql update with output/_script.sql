/*
    if object_id('dbo.DequeueWorker') is not null drop procedure dbo.DequeueWorker;
    if object_id('dbo.WorkerQueue') is not null drop table dbo.WorkerQueue;
*/

INSERT dbo.WorkerQueue
(
    WorkerDetails
)
VALUES
('Do something'),
('Do something else'),
('Do another thing');
GO


SELECT *
FROM dbo.WorkerQueue;

DECLARE @WorkerQueueID INT;
EXEC dbo.DequeueWorker @WorkerQueueID = @WorkerQueueID output;
SELECT @WorkerQueueID;
SELECT *
FROM dbo.WorkerQueue;
