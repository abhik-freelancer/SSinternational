using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class WarehousesBL
    {
        public int InsertWarehouse(WarehousesVM _warehouse)
        {
            WarehousesSL _SL = new WarehousesSL();
           
            return _SL.InsertWarehouse(_warehouse);
        }
        public int UpdateWarehouse(WarehousesVM _warehouse)
        {
            WarehousesSL _SL = new WarehousesSL();
           
            return _SL.UpdateWarehouse(_warehouse);

        }

        public Boolean DeleteWarehouse(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.DeleteWarehouse(WarehouseId);

        }

        public void UpdateWarehouseIsActiveState(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            _SL.UpdateWarehouseIsActiveState(WarehouseId);

        }

        public WarehousesVM GetById(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.GetById(WarehouseId);
        }

        public IEnumerable<WarehousesVM> GetAllWarehouse(int companyId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.GetAllWarehouse(companyId);
        }
        public IEnumerable<WarehousesVM> GetAllActiveWarehouse(int companyId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.GetAllActiveWarehouse(companyId);
        }
    }
}
