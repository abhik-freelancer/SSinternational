using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
   public class Warehouses
   {
       #region Propaties
       public int     WarehouseId {get;set;}
       public string  Name        {get;set;}
       public string  Description {get;set;}
       public int     CompanyId   {get;set;}
       public bool    IsActive    {get; set;}
       public int UserId { get; set; }
       #endregion

       public int InsertWarehouse(Warehouses _warehouse)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           return _DAL.InsertWarehouse(_warehouse);

       }

       public int UpdateWarehouse(Warehouses _warehouse)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           return _DAL.UpdateWarehouse(_warehouse);

       }
       public void DeleteWarehouse(int WarehouseId)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           _DAL.DeleteWarehouse(WarehouseId);

       }

       public void UpdateWarehouseIsActiveState(int WarehouseId)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           _DAL.UpdateWarehouseIsActiveState(WarehouseId);

       }

       public Warehouses GetById(int WarehouseId)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
         
           DataTable dt = _DAL.GetById(WarehouseId);

           Warehouses _warehouse = new Warehouses();
           if (dt.Rows.Count > 0)
           {
               _warehouse.WarehouseId = Convert.ToInt32(dt.Rows[0]["WarehouseId"].ToString());
               _warehouse.Name = (dt.Rows[0]["Name"].ToString());
               _warehouse.Description = (dt.Rows[0]["Description"].ToString());
               _warehouse.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
               _warehouse.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"].ToString());
           }
           return _warehouse;
       }

       public IEnumerable<Warehouses> GetAllWarehouse(int CompanyId)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           List<Warehouses> _warehouseList = new List<Warehouses>();
           DataTable dt = _DAL.GetAllWarehouse(WarehouseId);

           
           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Warehouses _warehouse = new Warehouses();
                   _warehouse.WarehouseId = Convert.ToInt32(dt.Rows[i]["WarehouseId"].ToString());
                   _warehouse.Name = (dt.Rows[i]["Name"].ToString());
                   _warehouse.Description = (dt.Rows[i]["Description"].ToString());
                   _warehouse.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                   _warehouse.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"].ToString());
                   _warehouseList.Add(_warehouse);
               }
           }
           return _warehouseList;
       }

       public IEnumerable<Warehouses> GetAllActiveWarehouse(int CompanyId)
       {
           WarehousesDAL _DAL = new WarehousesDAL();
           List<Warehouses> _warehouseList = new List<Warehouses>();
           DataTable dt = _DAL.GetAllActiveWarehouse(WarehouseId);


           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Warehouses _warehouse = new Warehouses();
                   _warehouse.WarehouseId = Convert.ToInt32(dt.Rows[i]["WarehouseId"].ToString());
                   _warehouse.Name = (dt.Rows[i]["Name"].ToString());
                   _warehouse.Description = (dt.Rows[i]["Description"].ToString());
                   _warehouse.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                   _warehouse.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"].ToString());
                   _warehouseList.Add(_warehouse);
               }
           }
           return _warehouseList;
       }
    }
}
