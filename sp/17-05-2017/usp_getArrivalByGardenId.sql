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
-- Create date: 17/05/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_getArrivalByGardenId
	-- Add the parameters for the stored procedure here
	@gardenId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select 
	arrivalMaster.arrivalNumber,
	CONVERT(varchar(10),[arrivalMaster].[dateofarrival],105)as dateofarrival,
	arrivalDetail.grade,arrivalDetail.net,arrivalDetail.receivequantity,
	arrivalDetail.invoicequantity,arrivalDetail.id,arrivalDetail.invoice
	FROM arrivalMaster
	INNER JOIN
	arrivalDetail ON arrivalMaster.arrivalId = arrivalDetail.arrivalId
	WHERE arrivalMaster.gardenid =@gardenId
END
GO
