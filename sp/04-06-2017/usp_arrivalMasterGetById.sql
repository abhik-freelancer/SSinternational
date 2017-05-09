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
ALTER PROCEDURE usp_arrivalMasterGetById
	-- Add the parameters for the stored procedure here
	@arrivalId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [arrivalId]
      ,arrivalMaster.[unloadingId]
      ,arrivalMaster.[arrivalNumber]
      --,arrivalMaster.[dateofarrival]
      ,Convert(VARCHAR(10),CONVERT(date,[arrivalMaster].[dateofarrival],106),103)as dateofarrival
      ,arrivalMaster.[lotnumber]
      ,arrivalMaster.[gardenid]
      ,arrivalMaster.[carrier]
      ,arrivalMaster.[lorrynum]
      ,arrivalMaster.[brokerid]
      ,arrivalMaster.[warehouseid]
      ,arrivalMaster.[cnno]
      ,arrivalMaster.[cndate]
      ,arrivalMaster.[gpno]
      ,arrivalMaster.[wbno]
      ,arrivalMaster.[companyid]
      ,arrivalMaster.[yearid]
      ,unloadingmaster.unloadingnumber
      ,CONVERT(varchar(10),convert(date, unloadingmaster.receiptdate,106),103) as receiptdate
FROM [arrivalMaster]
LEFT JOIN unloadingmaster ON arrivalMaster.unloadingId = unloadingmaster.id
WHERE [arrivalMaster].[arrivalId] =@arrivalId
END
GO
--usp_arrivalMasterGetById 4