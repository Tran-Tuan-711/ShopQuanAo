using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LichSuMuaHang
    {
        LichSuMuaHangTableAdapter daLSMH = new LichSuMuaHangTableAdapter();
        public DAL_LichSuMuaHang() { }
        public DataTable GetLichSuMuaHang()
        {
            return daLSMH.GetData();
        }
    }
}
