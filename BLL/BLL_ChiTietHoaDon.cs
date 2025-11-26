using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChiTietHoaDon
    {
        DAL_ChiTietHoaDon dalCTHD = new DAL_ChiTietHoaDon();
        public BLL_ChiTietHoaDon() { }
        public DataTable LoadCTHD()
        {
            return dalCTHD.GetChiTietHoaDon();
        }
    }
}
