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
-- Create date: 18-03-2017
-- Description:	Damage Type Insert
-- =============================================
CREATE PROCEDURE Usp_DamageTypeInsert 
	-- Add the parameters for the stored procedure here
    @DamageId int out,
	@DamageCode varchar(20),
	@Description varchar(120)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[DamageTypes]
           ([DamageCode]
           ,[Description])
     VALUES
           (@DamageCode, 
           @Description)
           
           Set @DamageId=SCOPE_IDENTITY();
END
GO
