using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
    public class unloadingBL
    {
        public int insertUnloadingMaster(UnloadingmasterVM _VM) {
            unloadingMasterSL _unldmst = new unloadingMasterSL();
            return _unldmst.insertUnloadingMaster(_VM);
        }
    }
}
