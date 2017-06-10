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
-- Create date: 10/06/2017
-- Description:	Fetch arrival by date range
-- =============================================
ALTER PROCEDURE usp_GetarrivalByDateRange 
	-- Add the parameters for the stored procedure here
	 @fromDate date,
	 @toDate date,
	 @companyId int,
	 @gardenid int
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT arrivalMaster.arrivalId,
    arrivalMaster.arrivalNumber,
    CONVERT(varchar(10),arrivalMaster.dateofarrival,103)as dateofarrival,
    arrivalMaster.brokerid,
    Brokers.BrokerCode
    FROM arrivalMaster
    INNER JOIN
    Brokers ON arrivalMaster.brokerid = Brokers.BrokerId
    WHERE arrivalMaster.gardenid = @gardenid AND arrivalMaster.dateofarrival BETWEEN
    @fromDate AND @toDate
END
GO
