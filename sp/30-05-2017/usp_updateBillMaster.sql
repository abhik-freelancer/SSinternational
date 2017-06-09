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
-- Author:		Abhik Ghosh
-- Create date: 08/06/2017
-- Description:	Update Bill Master
-- =============================================
CREATE PROCEDURE usp_updateBillMaster
	-- Add the parameters for the stored procedure here
	@billId int,
	@deliverydate  date,
	@buyer varchar(100), 
	@sarkar  varchar(100),
	@doNumber varchar(100),
	@grandtotalamount decimal(12,2),
	@doDate date
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [Billmaster]
   SET 
       [deliverydate] = @deliverydate
      ,[buyer] = @buyer
      ,[sarkar] = @sarkar
      ,[doNumber] = @doNumber
      ,[doDate] = @doDate
      ,[grandtotalamount] = @grandtotalamount
 WHERE [Billmaster].billId =@billId
END
GO
