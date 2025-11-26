using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhaCungCap
    {
        NhaCungCapTableAdapter daNCC = new NhaCungCapTableAdapter();
        public DAL_NhaCungCap() { }
        public DataTable GetNhaCungCap()
        {
            return daNCC.GetData();
        }
    }
}
