using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.viewmodel;
using SSinternational.service;
namespace SSinternational.business
{
    public class OkaybybrokerBL
    {
        public OkaybybrokerVM OkaybybrokerMasterData(int arrivalDetailId) {
            OkaybybrokerSL _SL = new OkaybybrokerSL();
            return _SL.OkaybybrokerMasterData(arrivalDetailId);
        }

        public int UpdateOkayByBroker( OkaybybrokerVM inspectionResult){
             OkaybybrokerSL _SL = new OkaybybrokerSL();
             return _SL.UpdateOkayByBroker(inspectionResult);
        }
    }
}
