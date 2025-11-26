using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string Loai { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }

        public DTO_SanPham() { }

        public DTO_SanPham(int maSP, string tenSP, string loai, decimal gia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Loai = loai;
            Gia = gia;
            SoLuong = soLuong;
        }
    }
}
