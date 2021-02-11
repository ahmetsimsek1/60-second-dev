ALTER TABLE [dbo].[Games] SET ( SYSTEM_VERSIONING = OFF  )
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Games]') AND type in (N'U'))
DROP TABLE [dbo].[Games]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GamesHistory]') AND type in (N'U'))
DROP TABLE [dbo].[GamesHistory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sports]') AND type in (N'U'))
DROP TABLE [dbo].[Sports]
GO
