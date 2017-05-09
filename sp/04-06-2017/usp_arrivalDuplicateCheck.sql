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
-- Create date: 05/05/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE usp_arrivalDuplicateCheck
	-- Add the parameters for the stored procedure here
	@companyId int,
	@yearId int,
	@arrivalNumber varchar(100),
	
	@numberofRecord int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @numberofRecord =0
    -- Insert statements for procedure here
	SELECT @numberofRecord = COUNT(*) from arrivalMaster 
	WHERE arrivalMaster.companyid =@companyId AND arrivalMaster.yearid = @yearId
	AND arrivalMaster.arrivalNumber =@arrivalNumber;
	
END
GO
