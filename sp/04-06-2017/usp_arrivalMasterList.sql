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
-- Author:		Abhik
-- Create date: 03/05/2017
-- Description:	
-- =============================================
CREATE PROCEDURE usp_arrivalMasterList 
	-- Add the parameters for the stored procedure here
	@companyId int,
	@yearid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [arrivalMaster].[arrivalId]
      ,[arrivalMaster].[unloadingId]
      ,[arrivalMaster].[arrivalNumber]
      ,[arrivalMaster].[dateofarrival]
      ,[arrivalMaster].[lotnumber]
      ,[arrivalMaster].[gardenid]
      ,[arrivalMaster].[carrier]
      ,[arrivalMaster].[lorrynum]
      ,[arrivalMaster].[brokerid]
      ,[arrivalMaster].[warehouseid]
      ,[arrivalMaster].[cnno]
      ,[arrivalMaster].[cndate]
      ,[arrivalMaster].[gpno]
      ,[arrivalMaster].[wbno]
      ,[Brokers].BrokerName
      ,[unloadingmaster].unloadingnumber
      ,[arrivalMaster].[companyid]
      ,[arrivalMaster].[yearid]
  FROM [arrivalMaster]
  LEFT JOIN
  unloadingmaster ON [arrivalMaster].[unloadingId] = unloadingmaster.id
  INNER JOIN 
  Brokers ON [arrivalMaster].[brokerid]=Brokers.BrokerId
  WHERE [arrivalMaster].[companyid] =@companyId
  AND [arrivalMaster].[yearid] = @yearid
END
GO
