using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_PhieuNhap
    {
        DAL_PhieuNhap dalPN = new DAL_PhieuNhap();
        public BLL_PhieuNhap() { }
        public DataTable LoadPhieuNhap()
        {
            return dalPN.GetPhieuNhap();
        }
    }
}
