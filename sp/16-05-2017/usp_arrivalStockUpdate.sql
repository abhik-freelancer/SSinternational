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
CREATE PROCEDURE usp_arrivalStockUpdate
	-- Add the parameters for the stored procedure here
	  @arrivalId int=NULL,
	  @arrivalInvoiceId int,
	  @invoice varchar(100)=NULL,
	  @grade varchar(100)=NULL,
	  @yearofproduction varchar(100)=NULL,
	  @net decimal(12,2),
	  @invoicequantity decimal(12,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @StockId int
	SET NOCOUNT ON;
	
	SELECT @StockId = StockLedger.StockLedgerId FROM StockLedger
	WHERE StockLedger.TransactionId = @arrivalInvoiceId AND StockLedger.TransType ='AR';
    -- Insert statements for procedure here
    UPDATE [StockLedger]
    SET 
       [Invoice] = @Invoice
      ,[Grade] = @Grade
      ,[CropYr] = @yearofproduction
      ,[net] = @net
      ,[StockIn] =  @invoicequantity
     
   WHERE [StockLedger].StockLedgerId =@StockId
  
    
	
END
GO
