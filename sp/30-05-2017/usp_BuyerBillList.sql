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
-- Create date: 06/06/2016
-- Description:	Listing of Bills
-- =============================================
CREATE PROCEDURE usp_BuyerBillList
	-- Add the parameters for the stored procedure here
	@company int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [billId]
      ,[billnumber]
      ,[deliverydate]
      ,[buyer]
      ,[sarkar]
      ,[doNumber]
      ,[doDate]
      ,[grandtotalamount]
      ,[companyId]
      ,[yearId]
  FROM [Billmaster]
  WHERE [companyId]=@company
  ORDER BY deliverydate DESC
END
GO
