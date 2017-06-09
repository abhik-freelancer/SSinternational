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
-- Create date: 09/06/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_getEntryBillList
	-- Add the parameters for the stored procedure here
	@companyId int,
	@yearId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		EntryBillMaster.EntryBillId,
		EntryBillMaster.EntryBillNumber,
		EntryBillMaster.EntrybillDate,
		EntryBillMaster.CustomerId,
		customers.customername,
		EntryBillMaster.Garden,
		gardens.gardencode,
		EntryBillMaster.BrokerId,
		Brokers.BrokerName,
		EntryBillMaster.totalBillAmount
FROM 
EntryBillMaster
INNER JOIN
customers ON EntryBillMaster.CustomerId= customers.id
INNER JOIN
gardens On EntryBillMaster.Garden = gardens .gardenId
Inner Join 
Brokers ON EntryBillMaster.BrokerId = Brokers.BrokerId
WHERE EntryBillMaster.companyId = @companyId AND EntryBillMaster.yearId =@yearId
ORDER BY EntryBillMaster.EntrybillDate DESC
END
GO
