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
-- Author:		usp_gardenInsertion
-- Create date: 16/03/2017
-- Description:	
-- =============================================
CREATE PROCEDURE  usp_gardenInsertion
	-- Add the parameters for the stored procedure here
	@gardenname varchar(100),
	@gardencode varchar(50) = Null,
	@customerid int = null,
	@companyid int,
	@lastInsertId int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[gardens]
           ([gardenname]
           ,[gardencode]
           ,[customerid]
           ,[companyid])
     VALUES
           (@gardenname
           ,@gardencode
           ,@customerid
           ,@companyid)

	SET @lastInsertId = SCOPE_IDENTITY();
END
GO
