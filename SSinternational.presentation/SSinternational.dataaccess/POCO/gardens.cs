﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class gardens
    {
        public int gardenId { get; set; }
        public string gardenname { get; set; }
        public string gardencode { get; set; }
        public int customerid { get; set; }
        public string customername { get; set; }
        public int companyid { get; set; }


        public IEnumerable<gardens> getGardenList(int companyId)
        {
            gardenDAL _gardenDAL = new gardenDAL();
            DataTable dt = _gardenDAL.getGardenList(companyId);
            List<gardens> _lstgarden = new List<gardens>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    gardens _garden = new gardens();
                    _garden.gardenId = Convert.ToInt32(row["gardenId"].ToString());
                    _garden.gardenname = (row["gardenname"].ToString());
                    
                    if (DBNull.Value == (row["gardencode"]))
                    {
                        _garden.gardencode = null;
                    }
                    else
                    {
                        _garden.gardencode = row["gardencode"].ToString();
                    }

                    if (DBNull.Value == row["customername"])
                    {
                        _garden.customername = null;
                    }
                    else {

                        _garden.customername = row["customername"].ToString();
                    }
                    _garden.companyid = Convert.ToInt32(row["companyid"].ToString());

                    _lstgarden.Add(_garden);
                }

            }
            return _lstgarden;
        }

        public int insertGarden(gardens garden)
        {
            gardenDAL _gardenDAL = new gardenDAL();
            return _gardenDAL.insertGarden(garden);

        }


        public gardens getGardenById(int gardenId)
        {

            gardenDAL _gardenDAL = new gardenDAL();
            DataTable dt = _gardenDAL.getGardenById(gardenId);
            gardens _garden = new gardens();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                _garden.gardenId = Convert.ToInt32(row["gardenId"].ToString());
                _garden.gardenname = row["gardenname"].ToString();
                if (row["gardencode"] == DBNull.Value)
                {
                    _garden.gardencode = null;
                }
                else {
                    _garden.gardencode = row["gardencode"].ToString();
                }

                if (row["customerid"] == DBNull.Value)
                {

                    _garden.customerid = 0;
                    _garden.customername = null;
                }
                else {

                    _garden.customerid = Convert.ToInt32(row["customerid"].ToString());
                    _garden.customername = row["customername"].ToString();
                }
                
            }

            return _garden;
        }


        public void upadateGarden(gardens garden)
        {
            gardenDAL _gardenDAL = new gardenDAL();
            _gardenDAL.upadateGarden(garden);

        }

        public Boolean DeleteGarden(int gardenId)
        {
            gardenDAL _gardenDAL = new gardenDAL();

            return _gardenDAL.gardenDelete(gardenId);

        }


    }
}