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
-- Description:	Broker Insert
-- =============================================
CREATE PROCEDURE Usp_BrokerInsert 
	-- Add the parameters for the stored procedure here
	 
      @BrokerCode Varchar(20),
      @BrokerName varchar(50),
      @EstateId int,
      @BrokerId int Out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Brokers]
           ([BrokerCode]
           ,[BrokerName]
           ,[EstateId])
     VALUES
           (@BrokerCode
           ,@BrokerName
           ,@EstateId)
           
           Set @BrokerId=Scope_Identity();
END
GO
