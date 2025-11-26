using DAL.DAL_DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChiTietPhieuNhap
    {
        ChiTietPhieuNhapTableAdapter daCTPN = new ChiTietPhieuNhapTableAdapter();
        public DAL_ChiTietPhieuNhap() { }
        public DataTable GetChiTietPhieuNhap()
        {
            return daCTPN.GetData();
        }
    }
}
