/**************************************************************************
-- -Generated by xSQL SDK for Schema Comparison and Synchronization
-- -Date/Time: March 08, 2010 15:10:08

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
ALTER TABLE [dbo].[un_transactions]
	ADD [country_code] [char](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_transactions.country_code')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_transactions]
	ADD [exchange_rate] [float] NOT NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_transactions.exchange_rate')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
ALTER PROCEDURE [dbo].[TransactionInsert]
(
	@user_id int,
	@country_code char(3),
	@exchange_rate float
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_transactions] ([user_id], [created_time], [transaction_unid],[country_code],[exchange_rate]) 
VALUES (@user_id, GETDATE(), newid(),@country_code,@exchange_rate);
	
SELECT * FROM un_transactions WHERE (transaction_id = SCOPE_IDENTITY());


GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.TransactionInsert')
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
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


