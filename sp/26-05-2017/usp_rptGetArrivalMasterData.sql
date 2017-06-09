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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE usp_rptGetArrivalMasterData
	-- Add the parameters for the stored procedure here
	@arrivalMasterId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT arrivalMaster.[arrivalId]
      ,arrivalMaster.[unloadingId]
      ,arrivalMaster.[arrivalNumber]
      ,arrivalMaster.[dateofarrival]
      ,arrivalMaster.[lotnumber]
      ,arrivalMaster.[gardenid]
      ,gardens.gardenname
      ,arrivalMaster.[carrier]
      ,arrivalMaster.[lorrynum]
      ,arrivalMaster.[brokerid]
      ,Brokers.BrokerName
      ,customers.customername
      ,arrivalMaster.[warehouseid]
      ,Warehouses.Name
      ,arrivalMaster.[cnno]
      ,arrivalMaster.[cndate]
      ,arrivalMaster.[gpno]
      ,arrivalMaster.[wbno]
      ,arrivalMaster.[companyid]
      ,arrivalMaster.[yearid]
  FROM [arrivalMaster]
  INNER JOIN
  gardens ON arrivalMaster.gardenid = gardens.gardenId
  INNER JOIN
  Warehouses ON arrivalMaster.warehouseid =Warehouses.WarehouseId
  INNER JOIN 
  Brokers ON [arrivalMaster].brokerid = Brokers.BrokerId
  INNER JOIN
  customers ON gardens.customerid =customers.id 
  WHERE [arrivalMaster].arrivalId =@arrivalMasterId


	

--
END
GO
