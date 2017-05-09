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
CREATE PROCEDURE usp_arrivalDamageBagDetailInsertion 
	-- Add the parameters for the stored procedure here
	@damageTypeId int,
	@noofpackage decimal(12,2)=NULL,
	@net decimal(12,2)=NULL,
	@arrivalDtlId int=NULL,
	@serial int =NULL



AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ssinternational_data].[dbo].[arrivalDamageBags]
           ([damageTypeId]
           ,[noofpackage]
           ,[net]
           ,[arrivalDtlId]
           ,[serial])
     VALUES
           (@damageTypeId
           ,@noofpackage 
           ,@net 
           ,@arrivalDtlId 
           ,@serial)



	
	
	
END
GO
