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
-- Author:		Aveek Ghosh
-- Create date: 03/05/2017
-- Description:	check invoice format
-- =============================================
ALTER PROCEDURE usp_checkInvoiceFormat 
	-- Add the parameters for the stored procedure here
	@unloadingmasterId int,
	@invoiceFormatId int output
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SET @invoiceFormatId=0
    -- Insert statements for procedure here
SELECT  @invoiceFormatId = ISNULL(invoiceformat.id, 0 )

FROM
unloadingmaster
INNER JOIN
gardens ON unloadingmaster.gardenid = gardens.gardenId
LEFT JOIN
invoiceformat ON gardens.invoiceformatid = invoiceformat.id
WHERE unloadingmaster.id =@unloadingmasterId

END
GO
