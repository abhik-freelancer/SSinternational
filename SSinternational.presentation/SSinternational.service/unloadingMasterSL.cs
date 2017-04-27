using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.viewmodel;
using SSinternational.dataaccess.POCO;

namespace SSinternational.service
{
   public class unloadingMasterSL
    {
      

       public int insertUnloadingMaster(UnloadingmasterVM _unldVM) {
           UnloadingmasterPOCO _unloadmstPOCO = new UnloadingmasterPOCO();
           _unloadmstPOCO = Mapper.Map<UnloadingmasterVM, UnloadingmasterPOCO>(_unldVM);
           return _unloadmstPOCO.insertUnloadingMaster(_unloadmstPOCO);
       
       }

       public IEnumerable<UnloadingmasterVM> getUnloadingMasterList(int companyId, int yearId) {
          UnloadingmasterPOCO _unloadmstPOCO = new UnloadingmasterPOCO();
          IEnumerable<UnloadingmasterVM> _unldVM = Mapper.Map<IEnumerable<UnloadingmasterPOCO>, IEnumerable<UnloadingmasterVM>>(_unloadmstPOCO.getUnloadingMasterList(companyId, yearId));
          return _unldVM;
       }
       public Boolean deleteUnloadingMaster(int unloadmasterId) {
           UnloadingmasterPOCO _unloadingPOCO = new UnloadingmasterPOCO();
           return _unloadingPOCO.deleteUnloadingMaster(unloadmasterId);
       }
       public UnloadingmasterVM getUnldMasterDataById(int unloadmstId) {
           UnloadingmasterPOCO _unloadmaster = new UnloadingmasterPOCO();
           UnloadingmasterVM _VM = new UnloadingmasterVM();
           _VM = Mapper.Map<UnloadingmasterPOCO,UnloadingmasterVM>(_unloadmaster.getUnldMasterDataById(unloadmstId));
           return _VM;
       
       }

       public void updateUnloadMaster(UnloadingmasterVM _VM) {
           UnloadingmasterPOCO _unloadmstPOCO = new UnloadingmasterPOCO();
           _unloadmstPOCO = Mapper.Map<UnloadingmasterVM, UnloadingmasterPOCO>(_VM);
           _unloadmstPOCO.updateUnloadingMaster(_unloadmstPOCO);
        
       }

       public int getNumberofInvoices(int unloadingmasterId){
           UnloadingmasterPOCO _unloadmstPOCO = new UnloadingmasterPOCO();
           return _unloadmstPOCO.getNumberofInvoices(unloadingmasterId);
       }
    }
}
