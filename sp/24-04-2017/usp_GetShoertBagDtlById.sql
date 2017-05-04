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
-- Author:		Abhik
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_GetShoertBagDtlById 
	-- Add the parameters for the stored procedure here
	@unloadingDtlId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[shortTypeId]
      ,ShortTypes.ShortCode
      ,[shortpackage]
      ,[shortPkgNet]
      ,[unloadingDetailId]
      ,[serial]
		FROM [shortBagDetail]
		INNER JOIN
		ShortTypes ON [shortBagDetail].shortTypeId = ShortTypes.ShortId
		Where shortBagDetail.unloadingDetailId =@unloadingDtlId
END
GO
