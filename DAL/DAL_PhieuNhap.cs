using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuNhap
    {
        PhieuNhapTableAdapter daPN = new PhieuNhapTableAdapter();
        public DAL_PhieuNhap() { }
        public DataTable GetPhieuNhap()
        {
            return daPN.GetData();
        }
    }
}
