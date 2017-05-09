USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[usp_getGardenCode]    Script Date: 05/08/2017 12:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aveek Ghosh
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_getArrivalGardenCode] 
	-- Add the parameters for the stored procedure here
	@arrivalId int, 
	@gardencode varchar(100) output

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @gardencode=''
    -- Insert statements for procedure here
SELECT  @gardencode = gardens.gardencode

FROM
arrivalMaster
INNER JOIN
gardens ON arrivalMaster.gardenid = gardens.gardenId
LEFT JOIN
invoiceformat ON gardens.invoiceformatid = invoiceformat.id
WHERE arrivalMaster.arrivalId =@arrivalId
END
