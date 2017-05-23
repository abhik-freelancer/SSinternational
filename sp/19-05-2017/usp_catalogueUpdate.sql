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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_catalogueUpdate
	-- Add the parameters for the stored procedure here
	@catalogId int,
	@catalougedate date,
    @saleNumber varchar(50),
    @lotNumber varchar(50),
    @brokerId int,
    @bagSerial int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [ssinternational_data].[dbo].[Catalogue]
   SET 
       [catalougedate] = @catalougedate
      ,[saleNumber] = @saleNumber
      ,[lotNumber] = @lotNumber
      ,[brokerId] = @brokerId
      ,[bagSerial] = @bagSerial
      
 WHERE [Catalogue].catalogId =@catalogId
END
GO
