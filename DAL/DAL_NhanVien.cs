using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        NhanVienTableAdapter daNV = new NhanVienTableAdapter();
        public DAL_NhanVien() { }
        public DataTable GetNhanVien()
        {
            return daNV.GetData();
        }
    }
}
