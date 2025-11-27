using DAL.DAL_DataSetTableAdapters;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietHoaDon
    {
        ChiTietHoaDonTableAdapter daCTHD = new ChiTietHoaDonTableAdapter();
        public DAL_ChiTietHoaDon() { }
        public DataTable GetChiTietHoaDon(DTO_ChiTietHoaDon cthd)
        {
            return daCTHD.GetData(cthd.MaHD);
        }
        public void InsertChiTietHoaDon(int soHD, int maSP, int soLuong, decimal donGia)
        {
            daCTHD.Insert(soHD, maSP, soLuong, donGia);
        }
        public Decimal TinhTong(DTO_ChiTietHoaDon cthd)
        {
            var dt = daCTHD.TinhTong(cthd.MaHD);

            if(dt != null && dt.Rows.Count > 0)
                return Convert.ToDecimal( dt.Rows[0][0]);

            return 0;
        }
    }
}
