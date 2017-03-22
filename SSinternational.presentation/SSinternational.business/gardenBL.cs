using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
   public class gardenBL
    {
        public IEnumerable<GardenListVM> getGardenList(int companyId)
        {
            gardenSL _gardenSL = new gardenSL();
            return _gardenSL.getGardenList(companyId);
        }


        public int insertGarden(GardenAddEditVM _gardenVM)
        {
            int insertion = 0;
            gardenSL _gardenSL = new gardenSL();
            insertion = _gardenSL.insertGarden(_gardenVM);
            return insertion;
        }

        public GardenAddEditVM getGardenById(int gardenId)
        {
            gardenSL _gardenSL = new gardenSL();
            return _gardenSL.getGardenById(gardenId);

        }

        public int upadateGarden(GardenAddEditVM _gardenAddEditVM)
        {
            gardenSL _gardenSL = new gardenSL();
           return _gardenSL.updateGarden(_gardenAddEditVM);

        }

        public Boolean deleteGarden(int gardenId)
        {

            gardenSL _gardenSL = new gardenSL();
            return _gardenSL.deleteGardens(gardenId);

        }

    }
}
