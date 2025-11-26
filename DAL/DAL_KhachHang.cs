using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachHang
    {
        KhachHangTableAdapter daKH = new KhachHangTableAdapter();
        public DAL_KhachHang() { }
        public DataTable GetKhachHang()
        {
            return daKH.GetData();
        }
    }
}
