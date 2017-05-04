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
CREATE PROCEDURE usp_arrivalMasterGetById
	-- Add the parameters for the stored procedure here
	@arrivalId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [arrivalId]
      ,[unloadingId]
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
      ,[yearid]
FROM [arrivalMaster]
WHERE [arrivalMaster].[arrivalId] =@arrivalId
END
GO
