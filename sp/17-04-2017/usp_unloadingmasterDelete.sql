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
-- Author:		Aveek Ghosh [9874141533]
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_unloadingmasterDelete 
	-- Add the parameters for the stored procedure here
	@unloadmasterId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM unloadingmaster where unloadingmaster.id =@unloadmasterId
END
GO
