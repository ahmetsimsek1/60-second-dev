SELECT
	i.[name] [index]
	,ddips.[index_type_desc]
	,ddips.[avg_fragmentation_in_percent] [FragmentationPercent]
	,ddips.[fragment_count]
	,ddips.[page_count]
FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'limited') ddips
JOIN sys.[indexes] i ON ddips.[object_id] = i.[object_id] AND ddips.[index_id] = i.[index_id]
WHERE OBJECT_NAME(ddips.object_id, db_id()) = 'Apps'
GO

SELECT
	tn.[name] [TableName]
	,ix.[name] [IndexName]
	,SUM(sz.[used_page_count]) * 8 AS [Index size (KB)]
FROM sys.dm_db_partition_stats AS sz
INNER JOIN sys.indexes ix 
	ON sz.[object_id] = ix.[object_id]
	AND sz.[index_id] = ix.[index_id]
INNER JOIN sys.tables tn ON tn.OBJECT_ID = ix.object_id
WHERE tn.[name] = 'Apps'
GROUP BY tn.[name], ix.[name]
ORDER BY tn.[name]
GO
