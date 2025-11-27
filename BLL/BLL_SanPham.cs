using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_SanPham
    {
        DAL_SanPham dalSP = new DAL_SanPham();
        public BLL_SanPham() { }
        public DataTable LoadSanPham()
        {
            return dalSP.GetSanPham();
        }
        public Decimal LayGiaSP(int MaSP)
        {
            return (Decimal)dalSP.GetSanPham().AsEnumerable()
                .Where(row => row.Field<int>("MaSP") == MaSP)
                .Select(row => row.Field<Decimal>("Gia"))
                .FirstOrDefault();
        }
    }
}
