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
-- Create date: 17/04/2017
-- Description:	
-- =============================================
ALTER PROCEDURE usp_getUnloadingMasterList 
	-- Add the parameters for the stored procedure here
	@companyId Int,
	@yearId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT unloadingmaster.[id]
      ,unloadingmaster.[unloadingnumber]
       ,CONVERT(VARCHAR(10), [receiptdate], 103)as [receiptdate]
      ,unloadingmaster.[lotnumber]
      ,unloadingmaster.[gardenid],gardens.gardenname
      ,unloadingmaster.[carrier]
      ,unloadingmaster.[lorrynum]
      ,unloadingmaster.[brokerid],Brokers.BrokerName
      ,unloadingmaster.[warehouseid],Warehouses.Name
      ,unloadingmaster.[cnno]
      ,unloadingmaster.[cndate]
      ,unloadingmaster.[gpno]
      ,unloadingmaster.[wbno]
      ,unloadingmaster.[companyid]
      ,unloadingmaster.[yearid]
      ,COUNT(unloadingdetail.id)as cnt
  FROM [unloadingmaster] 
  INNER JOIN gardens ON unloadingmaster.gardenid = gardens.gardenId
  INNER JOIN Warehouses ON unloadingmaster.warehouseid = Warehouses.WarehouseId
  INNER JOIN Brokers ON unloadingmaster.brokerid = Brokers.BrokerId
  LEFT JOIN unloadingdetail ON unloadingmaster.id = unloadingdetail.unloadingmasterid
  WHERE unloadingmaster.[companyid] =@companyId AND unloadingmaster.[yearid]=@yearId
  GROUP BY unloadingmaster.id,unloadingmaster.[unloadingnumber]
   ,unloadingmaster.[receiptdate],unloadingmaster.[lotnumber]
   ,unloadingmaster.[gardenid],gardens.gardenname
      ,unloadingmaster.[carrier]
      ,unloadingmaster.[lorrynum]
      ,unloadingmaster.[brokerid],Brokers.BrokerName
      ,unloadingmaster.[warehouseid],Warehouses.Name
      ,unloadingmaster.[cnno]
      ,unloadingmaster.[cndate]
      ,unloadingmaster.[gpno]
      ,unloadingmaster.[wbno]
      ,unloadingmaster.[companyid]
      ,unloadingmaster.[yearid]



END
GO
