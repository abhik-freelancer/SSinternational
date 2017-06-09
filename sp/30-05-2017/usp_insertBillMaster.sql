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
-- Create date: 05/06/2017
-- Description:	
-- =============================================
ALTER PROCEDURE usp_insertBillMaster
	-- Add the parameters for the stored procedure here
	@billnumber varchar(100),
	@deliverydate date,
	@buyer varchar(100),
	@sarkar varchar(100)=NULL,
	@doNumber varchar(100),
	@doDate date,
	@grandtotalamount decimal(12,2),
	@companyId int,
	@yearId int,
	@lastInsertId int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Billmaster]
           ([billnumber]
           ,[deliverydate]
           ,[buyer]
           ,[sarkar]
           ,[doNumber]
           ,[doDate]
           ,[grandtotalamount]
           ,[companyId]
           ,[yearId])
     VALUES
           (@billnumber 
           ,@deliverydate
           ,@buyer
           ,@sarkar
           ,@doNumber
           ,@doDate
           ,@grandtotalamount
           ,@companyId
           ,@yearId)
    set @lastInsertId =SCOPE_IDENTITY();       
END
GO
