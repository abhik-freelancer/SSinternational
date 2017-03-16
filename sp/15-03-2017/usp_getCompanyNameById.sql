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
-- Create date: 14/03/2016
-- Description:	
-- =============================================
CREATE PROCEDURE usp_getCompanyNameById 
	-- Add the parameters for the stored procedure here
	@companyId int,
	@companyName varchar(100) output 
	  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @companyName = '';
    -- Insert statements for procedure here
	SELECT @companyName=companies.companyname FROM companies WHERE companies.companyid= @companyId;

	
END
GO
