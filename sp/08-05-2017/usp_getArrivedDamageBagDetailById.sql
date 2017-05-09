USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[usp_getDamageBagDetailById]    Script Date: 05/09/2017 15:18:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abhik
-- Create date: 09/05/2017
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_getArrivedDamageBagDetailById] 
	-- Add the parameters for the stored procedure here
	@arrivalDetailId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[damageTypeId]
      ,DamageTypes.DamageCode
      ,[noofpackage]
      ,[net]
      ,[arrivalDamageBags].arrivalDtlId
      ,[serial]
  FROM [arrivalDamageBags]
  
  INNER JOIN
  DamageTypes ON arrivalDamageBags.damageTypeId = DamageTypes.DamageId
  WHERE arrivalDamageBags.arrivalDtlId = @arrivalDetailId
END
