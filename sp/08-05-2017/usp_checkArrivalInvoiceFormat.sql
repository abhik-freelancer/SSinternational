USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[usp_checkInvoiceFormat]    Script Date: 05/08/2017 12:39:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aveek Ghosh
-- Create date: 03/05/2017
-- Description:	check invoice format
-- =============================================
CREATE PROCEDURE [dbo].[usp_checkArrivalInvoiceFormat] 
	-- Add the parameters for the stored procedure here
	@arrivalId int,
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
arrivalMaster
INNER JOIN
gardens ON arrivalMaster.gardenid = gardens.gardenId
LEFT JOIN
invoiceformat ON gardens.invoiceformatid = invoiceformat.id
WHERE arrivalMaster.arrivalId =@arrivalId

END
