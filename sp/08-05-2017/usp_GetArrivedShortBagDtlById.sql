USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetShoertBagDtlById]    Script Date: 05/09/2017 15:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abhik
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetArrivedShortBagDtlById] 
	-- Add the parameters for the stored procedure here
	@arrivalDetailId int
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
      ,[arrivalShortBags].arrivalDtlId
      ,[serial]
		FROM [arrivalShortBags]
		
		INNER JOIN
		ShortTypes ON [arrivalShortBags].shortTypeId = ShortTypes.ShortId
		Where [arrivalShortBags].arrivalDtlId =@arrivalDetailId
END
