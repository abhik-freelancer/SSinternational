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
-- Create date: 19/05/2017
-- Description:	
-- =============================================
ALTER PROCEDURE usp_catalogueInsert 
	-- Add the parameters for the stored procedure here
	 @catalognumber varchar(100),
	 @catalougedate date,
	 @arrivalInvoiceId int,
	 @saleNumber varchar(50),
	 @lotNumber varchar(50),
	 @brokerId int,
	 @bagSerial int,
	 @net decimal(12,2)=NULL,
	 @sampleqty decimal(12,2)=Null,
	 @companyId int,
	 @yearId int
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Catalogue]
           ([catalognumber]
           ,[catalougedate]
           ,[arrivalInvoiceId]
           ,[saleNumber]
           ,[lotNumber]
           ,[brokerId]
           ,[bagSerial]
           ,[net]
           ,[sampleqty],companyId,yearId)
     VALUES
           (@catalognumber
           ,@catalougedate
           ,@arrivalInvoiceId
           ,@saleNumber
           ,@lotNumber
           ,@brokerId
           ,@bagSerial
           ,@net
           ,@sampleqty,@companyId,@yearId)
END
GO
