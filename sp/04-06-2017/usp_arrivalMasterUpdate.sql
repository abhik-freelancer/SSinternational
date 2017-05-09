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
-- Description:	
-- =============================================
ALTER
 PROCEDURE usp_arrivalMasterUpdate 
	-- Add the parameters for the stored procedure here
		@arrivalId int,
		@unloadingId int,
		@arrivalNumber varchar(MAX),
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
		@wbno varchar(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [arrivalMaster]
   SET [unloadingId] = @unloadingId 
      ,[arrivalNumber] = @arrivalNumber 
      ,[dateofarrival] = @dateofarrival 
      ,[lotnumber] = @lotnumber 
      ,[gardenid] = @gardenid 
      ,[carrier] = @carrier
      ,[lorrynum] = @lorrynum
      ,[brokerid] = @brokerid 
      ,[warehouseid] = @warehouseid 
      ,[cnno] = @cnno
      ,[cndate] = @cndate
      ,[gpno] = @gpno 
      ,[wbno] = @wbno 
      
 WHERE 
arrivalMaster.arrivalId =@arrivalId
END
GO
