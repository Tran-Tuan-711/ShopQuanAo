using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLL_HoaDon
    {
        DAL_HoaDon dalHD = new DAL_HoaDon();
        public BLL_HoaDon() { }
        public DataTable LoadHoaDon()
        {
            return dalHD.GetHoaDon();
        }
        public int ThemHoaDon(DTO_HoaDon hd)
        {
            return dalHD.Them(hd);
        }
    }
}
