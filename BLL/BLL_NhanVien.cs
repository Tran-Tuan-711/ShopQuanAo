using DAL;
using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_NhanVien
    {
        DAL_NhanVien dalNV = new DAL_NhanVien();
        public BLL_NhanVien() { }
        public DataTable LoadNhanVien()
        {
            return dalNV.GetNhanVien();
        }
    }
}
