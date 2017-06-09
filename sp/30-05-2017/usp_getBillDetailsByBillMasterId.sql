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
-- Create date: 07/06/2017
-- Description:	Get Bill Details
-- =============================================
CREATE PROCEDURE usp_getBillDetailsByBillMasterId 
	-- Add the parameters for the stored procedure here
	@billMasterId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [Billdetails].[id]
      ,[Billdetails].[billmasterid]
      ,[Billdetails].[stockid]
      ,[Billdetails].[invoiceId]
      ,[arrivalDetail].[invoice]
      ,[Billdetails].[numberofbags]
      ,[Billdetails].[saleno]
      ,[Billdetails].[lotnumber]
      ,[Billdetails].[doLodgDate]
      ,[Billdetails].[promptdate]
      ,[Billdetails].[extdDate]
      ,[Billdetails].[weeksdue]
      ,[Billdetails].[addtionalRentBgas]
      ,[Billdetails].[addtionalRentRate]
      ,[Billdetails].[addtionalRentAmount]
      ,[Billdetails].[streetRmvBags]
      ,[Billdetails].[streetRmvRent]
      ,[Billdetails].[streetRmvAmount]
      ,[Billdetails].[chkWghBags]
      ,[Billdetails].[chkWghRate]
      ,[Billdetails].[chkWghAmount]
      ,[Billdetails].[samplingWghBag]
      ,[Billdetails].[samplingRate]
      ,[Billdetails].[samplingAmount]
      ,[Billdetails].[totalAmount]
  FROM [Billdetails]
  INNER JOIN
  arrivalDetail ON [Billdetails].invoiceId = arrivalDetail.id
  WHERE [Billdetails].billmasterid=@billMasterId
  ORDER BY [Billdetails].id desc
END
GO
