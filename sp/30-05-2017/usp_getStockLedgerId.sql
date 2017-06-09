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
-- Author:		Abhik Ghsoh
-- Create date: 01-06-2017
-- Description:	Fetching arrival invoices by garden invoice grade nett companyid
-- =============================================
CREATE PROCEDURE usp_getStockLedgerId
	-- Add the parameters for the stored procedure here
	@garden varchar(100),
	@invoice varchar(100),
	@grade varchar(100),
	@nett decimal(12,2),
	@companyId int,
	@stockLedgerId int OUTPUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SET @stockLedgerId =0;
	SELECT 
	@stockLedgerId= StockLedger.StockLedgerId 
	FROM StockLedger
	WHERE StockLedger.Garden=@garden AND StockLedger.Invoice=@invoice AND StockLedger.Grade=@grade
	AND StockLedger.net=@nett AND StockLedger.TransType ='AR'
	AND StockLedger.companyId=@companyId
END
GO
