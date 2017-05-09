USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[usp_getNumberofUnloadingInvoice]    Script Date: 05/08/2017 11:35:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abhik
-- Create date: 08/05/2017
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_getNumberofArrivalInvoice] 
	-- Add the parameters for the stored procedure here
	@arrivalId int,
	@numberofinvoice int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @numberofinvoice =0;
    -- Insert statements for procedure here
	SELECT @numberofinvoice = COUNT(*) from  arrivalDetail 
	WHERE arrivalDetail.arrivalId  =@arrivalId
END