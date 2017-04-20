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
    }
}
