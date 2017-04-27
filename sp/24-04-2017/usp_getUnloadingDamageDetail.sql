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
ALTER PROCEDURE usp_getUnloadingDamageDetail 
	-- Add the parameters for the stored procedure here
	@unloadingDetailId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT damageBagDtl.id,damageBagDtl.damageTypeId,damageBagDtl.net,
	damageBagDtl.noofpackage,damageBagDtl.unloadingDtlId,DamageTypes.[Description]
	FROM
	damageBagDtl
	INNER JOIN
	unloadingdetail ON damageBagDtl.unloadingDtlId = unloadingdetail.id
	INNER JOIN
	DamageTypes ON damageBagDtl.damageTypeId = DamageTypes.DamageId
	Where damageBagDtl.unloadingDtlId = @unloadingDetailId
END
GO
