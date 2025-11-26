using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL_DataSetTableAdapters;
using DTO;

namespace DAL
{
    public class DAL_HoaDon
    {
        HoaDonTableAdapter daHoaDon = new HoaDonTableAdapter();
        public DAL_HoaDon() { }
        public DataTable GetHoaDon()
        {
            return daHoaDon.GetData();
        }
        public bool Them(DTO_HoaDon hd)
        {
            try
            {
                daHoaDon.Insert(hd.MaKH, hd.MaNV, hd.NgayLap, hd.TongTien);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int KTKhoaChinh(int MaHD)
        {
            try
            {
                if (daHoaDon.Check_PK_ByMaHD(MaHD).Rows.Count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 2;
            }
        }
    }
}
