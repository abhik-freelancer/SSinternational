-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ABHIK
-- Create date: 17/04/2017
-- Description:	
-- =============================================
CREATE PROCEDURE usp_unloadmasterInsert 
	-- Add the parameters for the stored procedure here
	@unloadingnumber varchar(MAX),
	@receiptdate date,
	@lotnumber varchar(50),
	@gardenid int ,
	@carrier varchar(100) = NULL, 
	@lorrynum varchar(50) = NULL,
	@brokerid int ,
	@warehouseid int,
	@cnno varchar(50) = NULL,
	@cndate date = NULL,
	@gpno varchar(50) = NULL,
	@wbno varchar(50) = NULL,
	@companyid int,
	@yearid int,
	@lastInsertId int output
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [unloadingmaster]
           ([unloadingnumber]
           ,[receiptdate]
           ,[lotnumber]
           ,[gardenid]
           ,[carrier]
           ,[lorrynum]
           ,[brokerid]
           ,[warehouseid]
           ,[cnno]
           ,[cndate]
           ,[gpno]
           ,[wbno]
           ,[companyid],[yearid])
     VALUES
           (@unloadingnumber,@receiptdate,@lotnumber,@gardenid,@carrier,@lorrynum
           ,@brokerid,@warehouseid,@cnno,@cndate,@gpno,@wbno,@companyid,@yearid)
     set @lastInsertId =SCOPE_IDENTITY();      
END
GO
