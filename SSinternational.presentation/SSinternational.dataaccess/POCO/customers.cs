using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class customers
    {
        public int customerId { get; set; }
        public string customername { get; set; }
        public string customerphone { get; set; }
        public string customeraddress { get; set; }
        public int companyid { get; set; }

        public IEnumerable<customers> getCustomerList(int companyId)
        {
            customerDAL _customerDAL = new customerDAL();
            DataTable dt = _customerDAL.getCustomerList(companyId);
            List<customers> _customerlst = new List<customers>();

            if(dt.Rows.Count>0){
                foreach (DataRow row in dt.Rows){
                    
                    customers _customer = new customers();
                    _customer.customerId = Convert.ToInt32(row["id"].ToString());
                    _customer.customername = (row["customername"].ToString());
                    _customer.customerphone = (row["customerphone"].ToString());
                    if(DBNull.Value==(row["customeraddress"])){
                        _customer.customeraddress =null;
                    }else{
                        _customer.customeraddress = row["customeraddress"].ToString();
                    }
                    _customer.companyid = Convert.ToInt32(row["companyid"].ToString());
                    
                    _customerlst.Add(_customer);
                }
            
            }
            return _customerlst;
          }

        public int insertCustomer(customers customer) {
            customerDAL _customerDAL = new customerDAL();
            return _customerDAL.insertCustomer(customer);
        
        }


        public customers getCustomerById(int customerId) {

            customerDAL _customerDAL = new customerDAL();
            DataTable dt = _customerDAL.getCustomerById(customerId);
            customers _customer = new customers();

            if(dt.Rows.Count>0){
                DataRow row = dt.Rows[0];

                _customer.customerId = Convert.ToInt32(row["id"].ToString());
                _customer.customername = row["customername"].ToString();
                _customer.customerphone = row["customerphone"].ToString();
                _customer.customeraddress = row["customeraddress"].ToString();
            }

            return _customer;
        }

        public void upadateCustomer(customers customer) {
            customerDAL _customerDAL = new customerDAL();
            _customerDAL.upadateCustomer(customer);
        
        }

        public Boolean DeleteCustomer(int customerId) {
            customerDAL _customerDAL = new customerDAL();

            return _customerDAL.customerDelete(customerId);
        
        }

    }
}
