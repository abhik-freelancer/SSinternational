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
ALTER PROCEDURE usp_arrivalShortBadDetailInsertion 
	-- Add the parameters for the stored procedure here
		@shortTypeId int,
		@shortpackage decimal(12,2)=NULL,
		@shortPkgNet decimal(12,2),
		@arrivalDtlId int=NULL,
		@serial int =NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [arrivalShortBags]
           ([shortTypeId]
           ,[shortpackage]
           ,[shortPkgNet]
           ,[arrivalDtlId]
           ,[serial])
     VALUES
           (@shortTypeId
           ,@shortpackage
           ,@shortPkgNet
           ,@arrivalDtlId
           ,@serial)
END
GO
