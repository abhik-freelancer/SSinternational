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
-- Create date: 16/03/2017
-- Description:	
-- =============================================
ALTER PROCEDURE usp_gardenUpdate 
	-- Add the parameters for the stored procedure here
	 @gardenId int,
	 @gardenname varchar(100),
	 @gardencode varchar(50),
	 @customerid int =null,
	 @invoiceformatid int =null,
	 @gardenalias varchar(100) =null,
	 @companyid  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [dbo].[gardens]
   SET [gardenname] = @gardenname
      ,[gardencode] = @gardencode
      ,[customerid] = @customerid
      ,[companyid] = @companyid
	  ,[invoiceformatid]=@invoiceformatid
	  ,[gardenalias] = @gardenalias
  WHERE [gardens].gardenId=@gardenId
END
GO
