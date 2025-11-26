using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ChiTietPhieuNhap
    {
        DAL_ChiTietPhieuNhap dalCTPN = new DAL_ChiTietPhieuNhap();
        public BLL_ChiTietPhieuNhap() { }
        public DataTable LoadChiTietPhieuNhap()
        {
            return dalCTPN.GetChiTietPhieuNhap();
        }
    }
}
