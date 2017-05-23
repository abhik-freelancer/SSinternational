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
-- Author:		Abheek Ghosh
-- Create date: 
-- Description:	
-- =============================================
ALTER PROCEDURE usp_arrivalStockInsertion 
	-- Add the parameters for the stored procedure here
	  @arrivalId int=NULL,
	  @arrivalInvoiceId int,
	  @invoice varchar(100)=NULL,
	  @grade varchar(100)=NULL,
	  @yearofproduction varchar(100)=NULL,
	  @net decimal(12,2),
	  @invoicequantity decimal(12,2)
	  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @transactionNumber varchar(100)
	DECLARE @transactionDate date
	DECLARE @gardenCode varchar(100)
	DECLARE @companyId int
	DECLARE @yearId int
    -- Insert statements for procedure here
	
	--transaction number fetch from arrivalMaster
	SELECT  @transactionNumber = arrivalMaster.arrivalNumber
	 FROM arrivalMaster WHERE arrivalMaster.arrivalId=@arrivalId
	
	--transaction date fetch from arrivalMaster
	SELECT @transactionDate = arrivalMaster.dateofarrival FROM arrivalMaster
	WHERE arrivalMaster.arrivalId =@arrivalId
	
	---garden code fetch
	SELECT @gardenCode= gardens.gardencode from arrivalMaster
	INNER JOIN
	gardens ON arrivalMaster.gardenid = gardens.gardenId
	WHERE arrivalMaster.arrivalId =@arrivalId 
	--company
	SELECT @companyId = arrivalMaster.companyid from arrivalMaster WHERE arrivalMaster.arrivalId =@arrivalId
	-- year
	SELECT @yearId = arrivalMaster.yearid from arrivalMaster WHERE arrivalMaster.arrivalId =@arrivalId
	
	--insertion
	INSERT INTO [ssinternational_data].[dbo].[StockLedger]
           ([TransactionNumber]
           ,[TransactionId]
           ,[TransactionDate]
           ,[TransType]
           ,[Invoice]
           ,[Grade]
           ,[Garden]
           ,[CropYr]
           ,[net]
           ,[StockIn]
           ,[StockOut]
           ,[ParentId],companyId,yearId)
     VALUES
           (@transactionNumber
           ,@arrivalInvoiceId
           ,@transactionDate
           ,'AR'
           ,@invoice
           ,@grade
           ,@gardenCode
           ,@yearofproduction
           ,@net
           ,@invoicequantity
           ,NULL
           ,NULL,@companyId,@yearId)
	
	
	
END
GO
