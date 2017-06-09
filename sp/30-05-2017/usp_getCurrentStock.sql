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
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_getCurrentStock 
	-- Add the parameters for the stored procedure here
	@garden varchar(100),
	@invoice varchar(100),
	@grade varchar(100),
	@nett decimal(12,2),
	@companyId int,
	
	@balance decimal(12,2) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @inStock decimal(12,2)
	DECLARE @outStock decimal(12,2)
	
	
	SET NOCOUNT ON;
	
	SET @inStock=0;
	SET @outStock =0;
	
	SELECT @inStock = SUM(ISNULL(StockLedger.StockIn,0)) 
	FROM StockLedger
	WHERE  StockLedger.TransType <>'BL'
	GROUP BY 
	StockLedger.Garden,StockLedger.Invoice,StockLedger.Grade,StockLedger.net,StockLedger.companyId
	HAVING StockLedger.Garden=@garden AND StockLedger.Invoice=@invoice
	AND StockLedger.Grade=@grade AND StockLedger.net =@nett AND StockLedger.companyId=@companyId
	
	
	SELECT @outStock = SUM(ISNULL(StockLedger.StockOut,0)) 
	FROM StockLedger
	WHERE  StockLedger.TransType ='BL'
	GROUP BY 
	StockLedger.Garden,StockLedger.Invoice,StockLedger.Grade,StockLedger.net,StockLedger.companyId
	HAVING StockLedger.Garden=@garden AND StockLedger.Invoice=@invoice
	AND StockLedger.Grade=@grade AND StockLedger.net =@nett AND StockLedger.companyId=@companyId
	
	SET @balance = @inStock - @outStock
	
    -- Insert statements for procedure here
	
END
GO
