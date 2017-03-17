using AutoMapper;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.service
{
    public class WarehousesSL
    {

        public int InsertWarehouse(WarehousesVM _warehouse)
        {
            Warehouses _warehousePoco = new Warehouses();
            _warehousePoco = Mapper.Map<WarehousesVM, Warehouses>(_warehouse);
            return _warehousePoco.InsertWarehouse(_warehousePoco);
        }
        public int UpdateWarehouse(WarehousesVM _warehouse)
        {
            Warehouses _warehousePoco = new Warehouses();
            _warehousePoco = Mapper.Map<WarehousesVM, Warehouses>(_warehouse);
            return _warehousePoco.UpdateWarehouse(_warehousePoco);

        }
        
        public Boolean DeleteWarehouse(int WarehouseId)
        {
            Warehouses _warehousePoco = new Warehouses();
            return _warehousePoco.DeleteWarehouse(WarehouseId);

        }

        public void UpdateWarehouseIsActiveState(int WarehouseId)
        {
            Warehouses _warehousePoco = new Warehouses();
            _warehousePoco.UpdateWarehouseIsActiveState(WarehouseId);

        }

        public WarehousesVM GetById(int WarehouseId)
        {
            Warehouses _warehousePoco = new Warehouses();
            return Mapper.Map<Warehouses, WarehousesVM>(_warehousePoco.GetById(WarehouseId));
        }

        public IEnumerable<WarehousesVM> GetAllWarehouse(int companyId)
        {
            Warehouses _warehousePoco = new Warehouses();
            return Mapper.Map<IEnumerable<Warehouses>, IEnumerable<WarehousesVM>>(_warehousePoco.GetAllWarehouse(companyId));
        }
        public IEnumerable<WarehousesVM> GetAllActiveWarehouse(int companyId)
        {
            Warehouses _warehousePoco = new Warehouses();
            return Mapper.Map<IEnumerable<Warehouses>, IEnumerable<WarehousesVM>>(_warehousePoco.GetAllActiveWarehouse(companyId));
        }
    }
}
