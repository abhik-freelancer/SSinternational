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
-- Author:		Shibsankar
-- Create date: 17-03-2017
-- Description:	IsActive state Update Package
-- =============================================
CREATE PROCEDURE Usp_PackageUpdateIsActive
	-- Add the parameters for the stored procedure here
	@PackageId int 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 declare @ActiveStatus bit
	set @ActiveStatus=0
	SELECT @ActiveStatus=[dbo].[Packages].[IsActive]
  FROM [dbo].[Packages] Where PackageId=@PackageId
  
  if(@ActiveStatus=1)
  begin
  Update [dbo].[Packages] Set [dbo].[Packages].[IsActive]=0  Where PackageId=@PackageId
  end
  else
  begin
  Update [dbo].[Packages] Set [dbo].[Packages].[IsActive]=1  Where PackageId=@PackageId
  end
  
 
END
GO
