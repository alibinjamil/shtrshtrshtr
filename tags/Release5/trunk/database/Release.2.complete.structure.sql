/**************************************************************************
-- -Generated by xSQL SDK for Schema Comparison and Synchronization
-- -Date/Time: February 24, 2010 13:40:17

-- -Summary:
    Contains the T-SQL script that makes the database 
    .\SQLEXPRESS.ShoppingTrolleyRelease the same as the database .\SQLEXPRESS.ShoppingTrolley

-- -Action:
    Execute this script on .\SQLEXPRESS.ShoppingTrolleyRelease

-- -SQL Server version: 10.0.1600
**************************************************************************/


/**************************************************************************
Warnings:
Column price will be dropped from the table dbo.un_wish_list; this can cause the loss of data.
Column total will be dropped from the table dbo.un_wish_list; this can cause the loss of data.
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
DROP PROCEDURE [dbo].[ProductPriceDelete]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.ProductPriceDelete')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[ProductPriceInsert]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.ProductPriceInsert')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[ProductPriceSelect]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.ProductPriceSelect')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[ProductPriceUpdate]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.ProductPriceUpdate')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[WishListDelete]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.WishListDelete')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[WishListInsert]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.WishListInsert')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[WishListSelect]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.WishListSelect')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP PROCEDURE [dbo].[WishListUpdate]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop stored procedure dbo.WishListUpdate')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_wish_list]
	DROP COLUMN [price]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop column dbo.un_wish_list.price')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_wish_list]
	DROP COLUMN [total]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop column dbo.un_wish_list.total')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
DROP TABLE [dbo].[un_product_prices]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to drop table dbo.un_product_prices')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[un_product_videos] (
	[video_id] [int] IDENTITY (1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[text] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[image] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[url] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add table dbo.un_product_videos')
END
GO

IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_wish_list]
	ADD [version_id] [int] NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_wish_list.version_id')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_wish_list]
	ADD [product_detail_id] [int] NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_wish_list.product_detail_id')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_products]
	ADD [terms_url] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_products.terms_url')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_product_versions]
	ADD [discount] [float] NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_product_versions.discount')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[un_product_details]
	ADD [price] [float] NOT NULL
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add column dbo.un_product_details.price')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[GetVersionPrice]
(	@product_id int,
	@version_id int, 
	@discount float)
RETURNS float
AS
BEGIN
DECLARE @totalAmount float;

SELECT @totalAmount = SUM(Price)
  FROM un_product_details
 WHERE product_id = @product_id
   AND mandatory = 1;

IF @discount IS NOT NULL
	SET @totalAmount = @totalAmount - @totalAmount * @discount  / 100;

RETURN @totalAmount;
END
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add user-defined function dbo.GetVersionPrice')
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
ALTER PROCEDURE dbo.ProductDetailInsert
(
	@product_id int,
	@product_detail varchar(100),
	@mandatory bit,
	@sort_order int,
	@price float
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_product_details] ([product_id], [product_detail], [mandatory], [sort_order], [price]) VALUES (@product_id, @product_detail, @mandatory, @sort_order, @price);
	
SELECT product_detail_id, product_id, product_detail, mandatory, sort_order, price FROM un_product_details WHERE (product_detail_id = SCOPE_IDENTITY())
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductDetailInsert')
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
ALTER PROCEDURE [dbo].[ProductDetailSelect]
	@product_id int
AS
	SET NOCOUNT ON;
SELECT        un_product_details.*
FROM            un_product_details
WHERE			product_id = @product_id
order by mandatory desc,sort_order
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductDetailSelect')
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
ALTER PROCEDURE dbo.ProductDetailUpdate
(
	@product_id int,
	@product_detail varchar(100),
	@mandatory bit,
	@sort_order int,
	@price float,
	@Original_product_detail_id int,
	@product_detail_id int
)
AS
	SET NOCOUNT OFF;
UPDATE [un_product_details] SET [product_id] = @product_id, [product_detail] = @product_detail, [mandatory] = @mandatory, [sort_order] = @sort_order, [price] = @price WHERE (([product_detail_id] = @Original_product_detail_id));
	
SELECT product_detail_id, product_id, product_detail, mandatory, sort_order, price FROM un_product_details WHERE (product_detail_id = @product_detail_id)
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductDetailUpdate')
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
ALTER PROCEDURE dbo.ProductInsert
(
	@name varchar(100),
	@description varchar(100),
	@short_name varchar(20),
	@terms_url varchar(200)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_products] ([name], [description], [short_name], [terms_url]) VALUES (@name, @description, @short_name, @terms_url);
	
SELECT product_id, name, description, short_name, terms_url FROM un_products WHERE (product_id = SCOPE_IDENTITY())
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductInsert')
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
CREATE PROCEDURE [dbo].[ProductSelectById]
@product_id int
AS
	SET NOCOUNT ON;
SELECT        un_products.*
FROM            un_products
WHERE	product_id = @product_id
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.ProductSelectById')
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
ALTER PROCEDURE dbo.ProductUpdate
(
	@name varchar(100),
	@description varchar(100),
	@short_name varchar(20),
	@terms_url varchar(200),
	@Original_product_id int,
	@product_id int
)
AS
	SET NOCOUNT OFF;
UPDATE [un_products] SET [name] = @name, [description] = @description, [short_name] = @short_name, [terms_url] = @terms_url WHERE (([product_id] = @Original_product_id));
	
SELECT product_id, name, description, short_name, terms_url FROM un_products WHERE (product_id = @product_id)
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductUpdate')
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
ALTER PROCEDURE dbo.ProductVersionInsert
(
	@product_id int,
	@name varchar(50),
	@min_users tinyint,
	@min_months tinyint,
	@discount float
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_product_versions] ([product_id], [name], [min_users], [min_months], [discount]) VALUES (@product_id, @name, @min_users, @min_months, @discount);
	
SELECT version_id, product_id, name, min_users, min_months, discount FROM un_product_versions WHERE (version_id = SCOPE_IDENTITY())
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductVersionInsert')
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
ALTER PROCEDURE dbo.ProductVersionUpdate
(
	@product_id int,
	@name varchar(50),
	@min_users tinyint,
	@min_months tinyint,
	@discount float,
	@Original_version_id int,
	@version_id int
)
AS
	SET NOCOUNT OFF;
UPDATE [un_product_versions] SET [product_id] = @product_id, [name] = @name, [min_users] = @min_users, [min_months] = @min_months, [discount] = @discount WHERE (([version_id] = @Original_version_id));
	
SELECT version_id, product_id, name, min_users, min_months, discount FROM un_product_versions WHERE (version_id = @version_id)
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductVersionUpdate')
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
CREATE PROCEDURE dbo.ProductVideoDelete
(
	@Original_video_id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [un_product_videos] WHERE (([video_id] = @Original_video_id))
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.ProductVideoDelete')
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
CREATE PROCEDURE dbo.ProductVideoInsert
(
	@product_id int,
	@text varchar(200),
	@image varchar(200),
	@url varchar(200)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [un_product_videos] ([product_id], [text], [image], [url]) VALUES (@product_id, @text, @image, @url);
	
SELECT video_id, product_id, text, image, url FROM un_product_videos WHERE (video_id = SCOPE_IDENTITY())
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.ProductVideoInsert')
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
CREATE PROCEDURE [dbo].[ProductVideoSelect]
	@product_id int
AS
	SET NOCOUNT ON;
SELECT        un_product_videos.*
FROM            un_product_videos
WHERE		product_id = @product_id
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.ProductVideoSelect')
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
CREATE PROCEDURE dbo.ProductVideoUpdate
(
	@product_id int,
	@text varchar(200),
	@image varchar(200),
	@url varchar(200),
	@Original_video_id int,
	@video_id int
)
AS
	SET NOCOUNT OFF;
UPDATE [un_product_videos] SET [product_id] = @product_id, [text] = @text, [image] = @image, [url] = @url WHERE (([video_id] = @Original_video_id));
	
SELECT video_id, product_id, text, image, url FROM un_product_videos WHERE (video_id = @video_id)
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.ProductVideoUpdate')
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
CREATE PROCEDURE dbo.TestSelect
AS
	SET NOCOUNT ON;
SELECT        un_product_details.*, un_product_versions.*, un_product_videos.*, un_products.*
FROM            un_product_details INNER JOIN
                         un_products ON un_product_details.product_id = un_products.product_id INNER JOIN
                         un_product_versions ON un_products.product_id = un_product_versions.product_id INNER JOIN
                         un_product_videos ON un_products.product_id = un_product_videos.product_id
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add stored procedure dbo.TestSelect')
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
ALTER PROCEDURE [dbo].[ProductVersionSelect]
	@product_id int
AS
	SET NOCOUNT ON;
SELECT        un_product_versions.*,dbo.GetVersionPrice(@product_id,version_id,discount) AS price
FROM            un_product_versions
WHERE			product_id = @product_id;
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to alter stored procedure dbo.ProductVersionSelect')
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
if not exists (select * from sys.objects where [name] = N'PK_un_product_videos' and [type] = 'PK')
ALTER TABLE [dbo].[un_product_videos] ADD 
	CONSTRAINT [PK_un_product_videos] PRIMARY KEY CLUSTERED 
	(
		[video_id]
	) ON [PRIMARY];
GO

IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add primary key dbo.un_product_videos.PK_un_product_videos')
END
GO
IF @@TRANCOUNT=0 BEGIN TRANSACTION
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if not exists (select * from sys.objects where [name] = N'FK_un_product_videos_un_products' and [type] = 'F')
ALTER TABLE [dbo].[un_product_videos] ADD 
	CONSTRAINT [FK_un_product_videos_un_products] FOREIGN KEY 
	(
		[product_id]
	)REFERENCES [dbo].[un_products](
		[product_id]
	)ON UPDATE NO ACTION ON DELETE NO ACTION 
GO
IF @@ERROR<>0 
Begin
	IF @@TRANCOUNT>0 ROLLBACK TRANSACTION
	INSERT INTO #ErrorLog (errno,errdescr) values(@@ERROR,'Failed to add foreign key dbo.un_product_videos.FK_un_product_videos_un_products')
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


