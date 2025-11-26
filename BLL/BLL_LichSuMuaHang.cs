using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_LichSuMuaHang
    {
        DAL_LichSuMuaHang dalLSMH = new DAL_LichSuMuaHang();
        public BLL_LichSuMuaHang() { }
        public DataTable LoadLichSuMuaHang()
        {
            return dalLSMH.GetLichSuMuaHang();
        }
    }
}
