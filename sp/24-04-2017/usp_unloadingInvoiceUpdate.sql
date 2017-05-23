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
-- Create date: 
-- Description:	
-- =============================================
ALTER PROCEDURE usp_unloadingInvoiceUpdate 
	-- Add the parameters for the stored procedure here
	@unloadingdetailId int ,
	@unloadingmasterid int,
	@invoice varchar(100),
	@grade varchar(100)=null,
	@package int=null,
	@yearofproduction varchar(100)=null,
	@pkgsrlfrm int,
	@pkgsrlto int,
	@invoicequantity decimal(12,2),
	@receivequantity decimal(12,2),
	@gross decimal(12,2),
	@tare decimal(12,2) = null,
	@net decimal(12,2),
	@floorId int
	 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- -Insert statements for procedure here
   UPDATE [unloadingdetail]
   SET [unloadingmasterid] = @unloadingmasterid 
      ,[invoice] = @invoice 
      ,[grade] = @grade 
      ,[package] = @package
      ,[yearofproduction] =@yearofproduction 
      ,[pkgsrlfrm] =@pkgsrlfrm 
      ,[pkgsrlto] = @pkgsrlto
      ,[invoicequantity] = @invoicequantity
      ,[receivequantity] = @receivequantity
      ,[gross] = @gross 
      ,[tare] =@tare
      ,[net] = @net
      ,[floorId] = @floorId
 WHERE [unloadingdetail].id = @unloadingdetailId



    
	---
	
	
	
END
GO
