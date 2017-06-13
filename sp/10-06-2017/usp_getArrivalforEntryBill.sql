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
-- Create date: 12/06/2017
-- Description:	get arrival 
-- =============================================
ALTER PROCEDURE usp_getArrivalforEntryBill
	-- Add the parameters for the stored procedure here
	@fromDate date,
	 @toDate date,
	 @companyId int,
	 @gardenid int,
	 @brokerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @arrivalInvoiceCount int
	DECLARE @BilledInvoiceCount int
	DECLARE @arrivalId int
	DECLARE @tempTable TABLE(
	arrivalId int
	)

    -- Insert statements for procedure here
    DECLARE arrivalCursor CURSOR FOR
	SELECT arrivalMaster.arrivalId
	FROM
	arrivalMaster 
	WHERE arrivalMaster.gardenid =8  AND arrivalMaster.brokerid =6
	AND arrivalMaster.dateofarrival BETWEEN '2017-05-01' AND '2017-05-30'
	AND arrivalMaster.companyid = 1
	
	OPEN arrivalCursor 
	FETCH NEXT FROM arrivalCursor INTO @arrivalId
	WHILE @@FETCH_STATUS =0
	BEGIN
		SET @arrivalInvoiceCount=0;
		SELECT  @arrivalInvoiceCount = COUNT(arrivalDetail.arrivalId) FROM
		arrivalDetail WHERE arrivalDetail.arrivalId =@arrivalId
		
		SET @BilledInvoiceCount =0;
		
		SELECT @BilledInvoiceCount = COUNT(EntryBillDetail.arrivalId) FROM
		EntryBillDetail WHERE EntryBillDetail.arrivalId = @arrivalId
		
		IF @arrivalInvoiceCount <> @BilledInvoiceCount 
		BEGIN
			INSERT INTO @tempTable (arrivalId)VALUES(@arrivalId)
		END 
	FETCH NEXT FROM arrivalCursor INTO @arrivalId
	END
	CLOSE arrivalCursor
	DEALLOCATE arrivalCursor 
	
	SELECT
	arrivalMaster.arrivalId, 
	arrivalMaster.arrivalNumber,
	arrivalMaster.dateofarrival,
	Brokers.BrokerName
	FROM
	arrivalMaster INNER JOIN Brokers ON arrivalMaster.brokerid = Brokers.BrokerId
	WHERE arrivalMaster.arrivalId IN (SELECT arrivalId FROM @tempTable)
	
	
END
GO


-- EXEC usp_getArrivalforEntryBill '2017-05-12','2017-05-12',1,2,8