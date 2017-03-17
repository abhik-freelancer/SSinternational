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

        public void DeleteWarehouse(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            _SL.DeleteWarehouse(WarehouseId);

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

        public IEnumerable<WarehousesVM> GetAllWarehouse(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.GetAllWarehouse(WarehouseId);
        }
        public IEnumerable<WarehousesVM> GetAllActiveWarehouse(int WarehouseId)
        {
            WarehousesSL _SL = new WarehousesSL();
            return _SL.GetAllActiveWarehouse(WarehouseId);
        }
    }
}
