/**************************************************************************
-- -Generated by xSQL SDK for Schema Comparison and Synchronization
-- -Date/Time: March 13, 2010 23:40:49

-- -Summary:
    Contains the T-SQL script that makes the database 
    .\SQLEXPRESS.ShoppingTrolleyRelease the same as the database .\SQLEXPRESS.ShoppingTrolley

-- -Action:
    Execute this script on .\SQLEXPRESS.ShoppingTrolleyRelease

-- -SQL Server version: 10.0.1600
**************************************************************************/

BEGIN TRANSACTION
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	SET QUOTED_IDENTIFIER ON
	SET ANSI_NULLS ON
	SET ANSI_PADDING ON
	SET ANSI_WARNINGS ON
	SET ARITHABORT ON
	SET NUMERIC_ROUNDABORT OFF
	SET CONCAT_NULL_YIELDS_NULL ON
	SET XACT_ABORT ON
COMMIT TRANSACTION
GO

IF EXISTS (select * from tempdb..sysobjects where id = OBJECT_ID('tempdb..#ErrorLog')) 
	DROP TABLE #ErrorLog 
CREATE TABLE #ErrorLog 
( pkid [int] IDENTITY(1,1) NOT NULL, errno [int] NOT NULL, errdescr [varchar](100) NULL )
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[un_settings] (
	[setting_id] [int] IDENTITY (1,1) NOT NULL,
	[setting_group] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[setting_key] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[setting_value] varchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add table dbo.un_settings')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE dbo.SettingDelete
(
	@Original_setting_id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [un_settings] WHERE (([setting_id] = @Original_setting_id))
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.SettingDelete')
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE dbo.SettingInsert
(
	@setting_group varchar(50),
	@setting_key varchar(50),
	@setting_value varchar(MAX)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_settings] ([setting_group], [setting_key], [setting_value]) VALUES (@setting_group, @setting_key, @setting_value);
	
SELECT setting_id, setting_group, setting_key, setting_value FROM un_settings WHERE (setting_id = SCOPE_IDENTITY())
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.SettingInsert')
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SettingSelect]
	@setting_group varchar(50)
AS
	SET NOCOUNT ON;
SELECT        un_settings.*
FROM            un_settings
where setting_group = @setting_group
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.SettingSelect')
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE dbo.SettingUpdate
(
	@setting_group varchar(50),
	@setting_key varchar(50),
	@setting_value varchar(MAX),
	@Original_setting_id int,
	@setting_id int
)
AS
	SET NOCOUNT OFF;
UPDATE [un_settings] SET [setting_group] = @setting_group, [setting_key] = @setting_key, [setting_value] = @setting_value WHERE (([setting_id] = @Original_setting_id));
	
SELECT setting_id, setting_group, setting_key, setting_value FROM un_settings WHERE (setting_id = @setting_id)
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.SettingUpdate')
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if not exists (select * from sys.objects where [name] = N'PK_un_settings' and [type] = 'PK')
ALTER TABLE [dbo].[un_settings] ADD 
	CONSTRAINT [PK_un_settings] PRIMARY KEY CLUSTERED 
	(
		[setting_id]
	) ON [PRIMARY];
GO

IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add primary key dbo.un_settings.PK_un_settings')
END
GO
IF EXISTS (Select * from #ErrorLog)
BEGIN
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
END
ELSE
BEGIN
	IF @@TRANCOUNT>0 COMMIT TRANSACTION
END
IF EXISTS (Select * from #ErrorLog)
BEGIN
	Print 'Database synchronization script failed'
	GOTO QuitWithErrors
END
ELSE
BEGIN
	Print 'Database synchronization completed successfully'
END



QuitWithErrors:


