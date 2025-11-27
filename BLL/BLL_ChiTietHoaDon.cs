using DAL;
using DTO;
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
        public DataTable LoadCTHD(DTO_ChiTietHoaDon cthd)
        {
            return dalCTHD.GetChiTietHoaDon(cthd);
        }
        public bool ThemCTHD(DTO_ChiTietHoaDon cthd)
        {
            try
            {
                dalCTHD.InsertChiTietHoaDon(cthd.MaHD, cthd.MaSP, cthd.SoLuong, cthd.Gia);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Decimal TinhTongTien(DTO_ChiTietHoaDon cthd)
        {
            return dalCTHD.TinhTong(cthd);
        }
        public DataTable LoadCTHD_Report(DTO_ChiTietHoaDon cthd)
        {
            return dalCTHD.GetChiTietHoaDon_Report(cthd);
        }
    }
}
