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
-- Create date: 10/05/2017
-- Description:	Generate arrival automatically from unloading
-- =============================================
CREATE PROCEDURE usp_generateUnloadingFromArrival
	-- Add the parameters for the stored procedure here
	@unloadingMasterId int,
	@arrivalnumber varchar(100),
	@arrivalDate date
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @arrivalMasterId int
	DECLARE @arrivalDetailId int
	
	DECLARE @unldDtlId int
	DECLARE @invoice varchar(100)
	DECLARE @grade varchar(100)
	DECLARE @package decimal(12,2) 
	DECLARE @yearofproduction varchar(100)
    DECLARE @pkgsrlfrm int
	DECLARE @pkgsrlto int
	DECLARE @invoicequantity decimal(12,2)
	DECLARE @receivequantity decimal(12,2)
	DECLARE @gross decimal(12,2)
	DECLARE @tare decimal(12,2)
	DECLARE @net decimal(12,2)
    DECLARE @floorId int
	SET NOCOUNT ON;
	

    -- Insert statements for procedure here
	BEGIN TRY
		BEGIN TRANSACTION 
		-- Arrival master insertion
		INSERT INTO [ssinternational_data].[dbo].[arrivalMaster]
           ([unloadingId]
           ,[arrivalNumber]
           ,[dateofarrival]
           ,[lotnumber]
           ,[gardenid]
           ,[carrier]
           ,[lorrynum]
           ,[brokerid]
           ,[warehouseid]
           ,[cnno]
           ,[cndate]
           ,[gpno]
           ,[wbno]
           ,[companyid]
           ,[yearid])
     
    SELECT [id]
      ,@arrivalnumber
      ,@arrivalDate
      ,[lotnumber]
      ,[gardenid]
      ,[carrier]
      ,[lorrynum]
      ,[brokerid]
      ,[warehouseid]
      ,[cnno]
      ,[cndate]
      ,[gpno]
      ,[wbno]
      ,[companyid]
      ,[yearid]
  FROM [unloadingmaster]
  WHERE [unloadingmaster].id=@unloadingMasterId
	
  SET @arrivalMasterId =SCOPE_IDENTITY();
  ---Arrival master insert
  
  DECLARE unloadingDetail CURSOR FOR
  SELECT 
	   [id]	
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
      ,[floorId]
  FROM [unloadingdetail]
  WHERE [unloadingmasterid]=@unloadingMasterId	
-- 
  OPEN unloadingDetail
  FETCH NEXT FROM unloadingDetail INTO @unldDtlId, 
	@invoice,@grade,@package,@yearofproduction,@pkgsrlfrm,@pkgsrlto,@invoicequantity,@receivequantity,@gross,
	@tare,@net,@floorId
  WHILE @@FETCH_STATUS = 0
  BEGIN
	--arrival detail insertion
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
     VALUES(@arrivalMasterId,@invoice,@grade,@package,@yearofproduction,@pkgsrlfrm,@pkgsrlto,
			@invoicequantity,@receivequantity,@gross,@tare,@net,@floorId
     )
	set @arrivalDetailId =SCOPE_IDENTITY()
	
	--damage bag
	INSERT INTO [ssinternational_data].[dbo].[arrivalDamageBags]
           ([damageTypeId]
           ,[noofpackage]
           ,[net]
           ,[arrivalDtlId]
           ,[serial])
	SELECT 
		  [damageTypeId]
		  ,[noofpackage]
		  ,[net]
		  ,@arrivalDetailId
		  ,[serial]
   FROM [damageBagDtl] WHERE damageBagDtl.unloadingDtlId =@unldDtlId
   
   
   --shortage bag
   
   INSERT INTO [ssinternational_data].[dbo].[arrivalShortBags]
           ([shortTypeId]
           ,[shortpackage]
           ,[shortPkgNet]
           ,[arrivalDtlId]
           ,[serial])
     SELECT 
       [shortTypeId]
      ,[shortpackage]
      ,[shortPkgNet]
      ,@arrivalDetailId
      ,[serial]
  FROM [shortBagDetail] WHERE [shortBagDetail].unloadingDetailId =@unldDtlId
   
   
   
   
  
   FETCH NEXT FROM unloadingDetail INTO 
	@unldDtlId,@invoice,@grade,@package,@yearofproduction,@pkgsrlfrm,@pkgsrlto,@invoicequantity,@receivequantity,@gross,
	@tare,@net,@floorId
  END
  
  CLOSE unloadingDetail
  DEALLOCATE unloadingDetail
--		
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
GO
