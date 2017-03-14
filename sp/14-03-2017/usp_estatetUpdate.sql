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
-- Create date: 14/03/2016
-- Description:	
-- =============================================
CREATE PROCEDURE usp_estatetUpdate 
	-- Add the parameters for the stored procedure here
	@estateId int,
	@estate varchar(100),
	@estatecode varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
  UPDATE [dbo].[estates]
   SET 
       [estate] = @estate
      ,[estatecode] = @estatecode
      
   WHERE [estateId]=@estateId;
END
GO
