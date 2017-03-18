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
-- Author:		Shibsankar
-- Create date: 18-03-2016
-- Description:	Broker Update
-- =============================================
CREATE PROCEDURE Usp_BrokerUpdate
	-- Add the parameters for the stored procedure here
	 
      @BrokerCode Varchar(20),
      @BrokerName varchar(50),
      @EstateId int,
      @BrokerId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Brokers]
   SET [BrokerCode] =@BrokerCode
      ,[BrokerName] = @BrokerName
      ,[EstateId] = @EstateId
 WHERE BrokerId=@BrokerId
           
           Set @BrokerId=Scope_Identity();
END
GO
