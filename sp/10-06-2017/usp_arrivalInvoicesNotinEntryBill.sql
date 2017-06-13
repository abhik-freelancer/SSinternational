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
-- Create date: 13/06/2017
-- Description:	Fetch arrival invoices by arrivalid those are not in entry bill details
-- =============================================
CREATE PROCEDURE usp_arrivalInvoicesNotinEntryBill
	-- Add the parameters for the stored procedure here
	@arrivalId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT arrivalDetail.id,
	arrivalDetail.arrivalId,
	arrivalDetail.invoice,arrivalDetail.grade,
	arrivalDetail.net,arrivalDetail.receivequantity
	FROM arrivalDetail
	WHERE arrivalDetail.arrivalId = 12 
	AND arrivalDetail.id not in 
	(SELECT EntryBillDetail.invoiceid FROM EntryBillDetail WHERE EntryBillDetail.arrivalId=12 )
END
GO
