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
   public class gardenSL
    {
        public IEnumerable<GardenListVM> getGardenList(int companyId)
        {
            gardens _gardenPOCO = new gardens();
            IEnumerable<GardenListVM> _gardenListVM = Mapper.Map<IEnumerable<gardens>, IEnumerable<GardenListVM>>(_gardenPOCO.getGardenList(companyId));
            return _gardenListVM;

        }

        public int insertGarden(GardenAddEditVM _gardenAddEditVM)
        {
            gardens _gardenPOCO = new gardens();
            _gardenPOCO = Mapper.Map<GardenAddEditVM, gardens>(_gardenAddEditVM);
            return _gardenPOCO.insertGarden(_gardenPOCO);

        }

        public GardenAddEditVM getGardenById(int gardenId)
        {

            gardens _gardenPOCO = new gardens();
            GardenAddEditVM _gardenAddEditVM = Mapper.Map<gardens, GardenAddEditVM>(_gardenPOCO.getGardenById(gardenId));
            return _gardenAddEditVM;

        }

        public void updateGarden(GardenAddEditVM _gardenAddEditVM)
        {
            gardens _gardenPOCO = new gardens();
            _gardenPOCO = Mapper.Map<GardenAddEditVM, gardens>(_gardenAddEditVM);
            _gardenPOCO.upadateGarden(_gardenPOCO);

        }

        public Boolean deleteGardens(int gardenId)
        {
            gardens _gardenPOCO = new gardens();
            return _gardenPOCO.DeleteGarden(gardenId);


        }
    }
}
