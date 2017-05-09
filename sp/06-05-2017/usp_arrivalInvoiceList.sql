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
-- Author:		ABHIK GHOSH
-- Create date: 05/03/2017
-- Description:	
-- =============================================
CREATE PROCEDURE usp_arrivalInvoiceList 
	-- Add the parameters for the stored procedure here
	  @arrivalMasterId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT arrivalDetail.[id]
      ,arrivalDetail.[arrivalId]
      ,arrivalDetail.[invoice]
      ,arrivalDetail.[grade]
      ,arrivalDetail.[package]
      ,arrivalDetail.[yearofproduction]
      ,arrivalDetail.[pkgsrlfrm]
      ,arrivalDetail.[pkgsrlto]
      ,arrivalDetail.[invoicequantity]
      ,arrivalDetail.[receivequantity]
      ,arrivalDetail.[gross]
      ,arrivalDetail.[tare]
      ,arrivalDetail.[net]
      ,arrivalDetail.[floorId]
      ,arrivalMaster.arrivalNumber
      ,CONVERT(varchar(10),[arrivalMaster].[dateofarrival],105)as dateofarrival
      ,floors.floorName
      ,Warehouses.Name 
      
  FROM [arrivalDetail]
  INNER JOIN 
  arrivalMaster ON arrivalMaster.arrivalId =arrivalDetail.arrivalId
  INNER JOIN
  floors
  ON arrivalDetail.floorId = floors.floorId
  LEFT JOIN
  Warehouses ON floors.warehouseId = Warehouses.WarehouseId
  WHERE arrivalMaster.arrivalId = @arrivalMasterId
  
END
GO
