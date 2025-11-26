using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SanPham
    {
        SanPhamTableAdapter daSP = new SanPhamTableAdapter();
        public DAL_SanPham() { }
        public DataTable GetSanPham()
        {
            return daSP.GetData();
        }
    }
}
