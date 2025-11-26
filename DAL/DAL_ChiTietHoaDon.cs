using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietHoaDon
    {
        ChiTietHoaDonTableAdapter daCTHD = new ChiTietHoaDonTableAdapter();
        public DAL_ChiTietHoaDon() { }
        public DataTable GetChiTietHoaDon()
        {
            return daCTHD.GetData();
        }
    }
}
