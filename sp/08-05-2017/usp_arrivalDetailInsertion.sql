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
-- Create date: 08/05/2017
-- Description:	
-- =============================================
CREATE PROCEDURE usp_arrivalDetailInsertion 
	-- Add the parameters for the stored procedure here
	@arrivalId int,
	@invoice varchar(100),
	@grade varchar,
	@package int =NULL,
	@yearofproduction varchar(100)=NULL,
	@pkgsrlfrm int,
	@pkgsrlto int,
	@invoicequantity decimal(12,2),
	@receivequantity decimal(12,2),
	@gross decimal(12,2),
	@tare decimal(12,2)=NULL,
	@net decimal(12,2),
	@floorId int,
	
	@lastInsertId int OUTPUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO [ssinternational_data].[dbo].[arrivalDetail]
           ([arrivalId]
           ,[invoice]
           ,[grade]
           ,[package]
           ,[yearofproduction]
           ,[pkgsrlfrm]
           ,[pkgsrlto]
           ,[invoicequantity]
           ,[receivequantity]
           ,[gross]
           ,[tare]
           ,[net]
           ,[floorId])
     VALUES
           ( @arrivalId,
			 @invoice,
			 @grade, 
			 @package,
			 @yearofproduction,
			 @pkgsrlfrm, 
			 @pkgsrlto, 
			 @invoicequantity, 
			 @receivequantity, 
			 @gross, 
			 @tare, 
			 @net, 
			 @floorId)
			 
SET @lastInsertId =SCOPE_IDENTITY();			 
	
END
GO
