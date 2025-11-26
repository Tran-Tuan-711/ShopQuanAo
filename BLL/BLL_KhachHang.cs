using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_KhachHang
    {
        DAL_KhachHang dalKH = new DAL_KhachHang();
        public BLL_KhachHang() { }
        public DataTable LoadKhachHang()
        {
            return dalKH.GetKhachHang();
        }
    }
}
