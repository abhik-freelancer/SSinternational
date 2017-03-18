USE [ssinternational_data]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetAllBroker]    Script Date: 03/18/2017 18:25:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Shibsankar
-- Create date: 18-03-2017
-- Description:	Get All Broker
-- =============================================
Create PROCEDURE [dbo].[Usp_BrokerDeleteById] 
	-- Add the parameters for the stored procedure here
@BrokerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete
  FROM [dbo].[Brokers]
  
  where BrokerId=@BrokerId
END
