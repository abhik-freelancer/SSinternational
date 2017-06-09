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
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE usp_BillDtlInsertion
	-- Add the parameters for the stored procedure here
 @billmasterid int,
 @stockid int,
 @invoiceId int,
 @numberofbags int,
 @saleno varchar(50),
 @lotnumber varchar(50),
 @doLodgDate date= NULL,
 @promptdate date,
 @extdDate date,
 @weeksdue decimal(12,2),
 @addtionalRentBgas int,
 @addtionalRentRate decimal(12,2),
 @addtionalRentAmount decimal(12,2),
 @streetRmvBags int,
 @streetRmvRent decimal(12,2),
 @streetRmvAmount decimal(12,2),
 @chkWghBags int,
 @chkWghRate decimal(12,2),
 @chkWghAmount decimal(12,2),
 @samplingWghBag int,
 @samplingRate decimal(12,2),
 @samplingAmount decimal(12,2),
 @totalAmount decimal(12,2)
 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [ssinternational_data].[dbo].[Billdetails]
           ([billmasterid]
           ,[stockid]
           ,[invoiceId]
           ,[numberofbags]
           ,[saleno]
           ,[lotnumber]
           ,[doLodgDate]
           ,[promptdate]
           ,[extdDate]
           ,[weeksdue]
           ,[addtionalRentBgas]
           ,[addtionalRentRate]
           ,[addtionalRentAmount]
           ,[streetRmvBags]
           ,[streetRmvRent]
           ,[streetRmvAmount]
           ,[chkWghBags]
           ,[chkWghRate]
           ,[chkWghAmount]
           ,[samplingWghBag]
           ,[samplingRate]
           ,[samplingAmount]
           ,[totalAmount])
     VALUES
           ( @billmasterid ,
			 @stockid ,
			 @invoiceId ,
			 @numberofbags ,
			 @saleno ,
			 @lotnumber ,
			 @doLodgDate,
			 @promptdate ,
			 @extdDate ,
			 @weeksdue ,
			 @addtionalRentBgas ,
			 @addtionalRentRate ,
			 @addtionalRentAmount ,
			 @streetRmvBags ,
			 @streetRmvRent ,
			 @streetRmvAmount ,
			 @chkWghBags ,
			 @chkWghRate ,
			 @chkWghAmount ,
			 @samplingWghBag ,
			 @samplingRate ,
			 @samplingAmount ,
			 @totalAmount )
			
END
GO
