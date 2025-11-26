using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_NhaCungCap
    {
        DAL_NhaCungCap dalNCC = new DAL_NhaCungCap();
        public BLL_NhaCungCap() { }
        public DataTable LoadNhaCungCap()
        {
            return dalNCC.GetNhaCungCap();
        }
    }
}
