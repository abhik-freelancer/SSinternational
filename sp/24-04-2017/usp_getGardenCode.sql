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
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_getGardenCode 
	-- Add the parameters for the stored procedure here
	@unloadMasterId int, 
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
unloadingmaster
INNER JOIN
gardens ON unloadingmaster.gardenid = gardens.gardenId
LEFT JOIN
invoiceformat ON gardens.invoiceformatid = invoiceformat.id
WHERE unloadingmaster.id =@unloadMasterId
END
GO
