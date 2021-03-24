IF OBJECT_ID('tempdb..#Devices') IS NOT NULL DROP TABLE #Devices;
IF OBJECT_ID('tempdb..#UpdatedPrinterList') IS NOT NULL DROP TABLE #UpdatedPrinterList;

CREATE TABLE #Devices (
	DeviceID INT NOT NULL IDENTITY PRIMARY KEY
	,DeviceType NVARCHAR(10)
	,DeviceName NVARCHAR(100)
);

INSERT #Devices (DeviceType, DeviceName)
	SELECT x.DeviceType, x.PrinterName
	FROM (VALUES 
		('PRINTER', 'Lexmark')
		,('PRINTER', 'Epson')
		,('SCANNER', 'Dell')
		,('PRINTER', 'Brother')
		,('MOUSE', 'Logitech')
		,('PRINTER','Xerox')
	) x (DeviceType, PrinterName);

SELECT * FROM #Devices;

CREATE TABLE #UpdatedPrinterList (PrinterID INT, PrinterName NVARCHAR(100));
INSERT #UpdatedPrinterList (PrinterID, PrinterName)
	VALUES (1, 'Lexmark'), (2, 'EPSON INC'), (6, 'Xerox'), (7, 'HP');

SELECT * FROM #UpdatedPrinterList;

SET IDENTITY_INSERT #Devices ON;

-- Option 1: "where" clause on the NOT MATCHED line
MERGE #Devices tgt
USING #UpdatedPrinterList src ON tgt.DeviceID = src.PrinterID
WHEN MATCHED THEN
	UPDATE SET DeviceName = src.PrinterName
WHEN NOT MATCHED BY SOURCE AND DeviceType = 'PRINTER' THEN
	DELETE
WHEN NOT MATCHED BY TARGET THEN
	INSERT (DeviceID, DeviceType, DeviceName) VALUES (src.PrinterID, 'PRINTER', src.PrinterName);

-- Option 2: update a pre-filtered CTE
;WITH tgt AS (
	SELECT * FROM #Devices WHERE DeviceType = 'PRINTER'
)
MERGE tgt
USING #UpdatedPrinterList src ON tgt.DeviceID = src.PrinterID
WHEN MATCHED THEN
	UPDATE SET DeviceName = src.PrinterName
WHEN NOT MATCHED BY SOURCE THEN
	DELETE
WHEN NOT MATCHED BY TARGET THEN
	INSERT (DeviceID, DeviceType, DeviceName) VALUES (src.PrinterID, 'PRINTER', src.PrinterName);

SELECT * FROM #Devices;

SET IDENTITY_INSERT #Devices OFF;
