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
-- Author:		Abhik Ghosh
-- Create date: 04/05/2017
-- Description:	Insertion of arrival master
-- =============================================
ALTER PROCEDURE usp_arrivalMasterInsertion
	-- Add the parameters for the stored procedure here
		@unloadingId int =NULL,
		@arrivalNumber varchar,
		@dateofarrival date,
		@lotnumber varchar(50),
		@gardenid int,
		@carrier varchar(100)=NULL,
		@lorrynum varchar(50)=NULL,
		@brokerid int,
		@warehouseid int,
		@cnno varchar(50)=NULL,
		@cndate datetime=NULL,
		@gpno varchar(50)=NULL,
		@wbno varchar(50)=NULL,
		@companyid int,
		@yearid int,
		@lastinsertId int output
AS
BEGIN
	INSERT INTO [ssinternational_data].[dbo].[arrivalMaster]
           ([unloadingId]
           ,[arrivalNumber]
           ,[dateofarrival]
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
           ,[companyid]
           ,[yearid])
     VALUES
           (@unloadingId ,
		@arrivalNumber ,
		@dateofarrival ,
		@lotnumber ,
		@gardenid ,
		@carrier ,
		@lorrynum ,
		@brokerid ,
		@warehouseid ,
		@cnno ,
		@cndate ,
		@gpno ,
		@wbno ,
		@companyid ,
		@yearid )
		
		SET @lastinsertId =SCOPE_IDENTITY();
END
GO
