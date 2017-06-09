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
-- Create date: 05/06/2017
-- Description:	
-- =============================================
CREATE PROCEDURE usp_insertBillInStockLedger
	-- Add the parameters for the stored procedure here
	@stockId int,
	@invoiceId int,
	@billNumber varchar(100),
	@deliveryDate date,
	@companyId int,
	@yearId int,
	@numberofBags decimal(12,2)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [StockLedger]
           ([TransactionNumber]
           ,[TransactionId]
           ,[TransactionDate]
           ,[TransType]
           ,[Invoice]
           ,[Grade]
           ,[Garden]
           ,[CropYr]
           ,[net]
           ,[StockIn]
           ,[StockOut]
           ,[ParentId]
           ,[companyId]
           ,[yearId])
     
    SELECT  
    @billNumber as 'tranNumber',
    @invoiceId  as 'tId',
    @deliveryDate as 'dDate',
    'BL',StockLedger.Invoice,StockLedger.Grade,StockLedger.Garden,StockLedger.CropYr,
    StockLedger.net,NULL, @numberofBags,StockLedger.StockLedgerId,@companyId,@yearId 
    FROM StockLedger
    WHERE  StockLedger.StockLedgerId =@stockId and StockLedger.TransactionId =@invoiceId
	
END
GO
