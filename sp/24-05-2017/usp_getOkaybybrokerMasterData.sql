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
ALTER PROCEDURE usp_getOkaybybrokerMasterData 
	-- Add the parameters for the stored procedure here
	@arrivalDetailId int = 0 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT 
	arrivalMaster.arrivalId,
	arrivalMaster.arrivalNumber,
	gardens.gardenname,
	arrivalDetail.yearofproduction,
	arrivalDetail.invoice,
	arrivalDetail.net,
	arrivalMaster.brokerid,
	arrivalDetail.id
	FROM 
	arrivalMaster
	INNER JOIN
	arrivalDetail ON arrivalMaster.arrivalId =arrivalDetail.arrivalId
	LEFT JOIN
	gardens ON arrivalMaster.gardenid =gardens.gardenId
	
	WHERE arrivalDetail.id =@arrivalDetailId
	
	
	
	
END
GO
