using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using AutoMapper;

namespace SSinternational.service
{
  public  class OkaybybrokerSL
    {

      public OkaybybrokerVM OkaybybrokerMasterData(int arrivalDetailId)
      {
          OkaybybrokerPOCO okayByBrokerPOCO = new OkaybybrokerPOCO();
          OkaybybrokerVM _VM = Mapper.Map<OkaybybrokerPOCO, OkaybybrokerVM>(okayByBrokerPOCO.OkaybybrokerMasterData(arrivalDetailId));
          return _VM;
      }

      public int UpdateOkayByBroker(OkaybybrokerVM inspectionResult) {
          OkaybybrokerPOCO okayByBrokerPOCO = new OkaybybrokerPOCO();
          okayByBrokerPOCO = Mapper.Map<OkaybybrokerVM, OkaybybrokerPOCO>(inspectionResult);
          return okayByBrokerPOCO.UpdateOkayByBroker(okayByBrokerPOCO);
      }
    }
}
