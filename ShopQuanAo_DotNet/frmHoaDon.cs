using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace ShopQuanAo_DotNet
{
    public partial class frmHoaDon : Form
    {
        BLL_NhanVien BLL_NV = new BLL_NhanVien();
        BLL_KhachHang BLL_KH = new BLL_KhachHang();
        BLL_NhaCungCap BLL_NCC = new BLL_NhaCungCap();
        BLL_PhieuNhap BLL_PN = new BLL_PhieuNhap();
        BLL_ChiTietPhieuNhap BLL_CTPN = new BLL_ChiTietPhieuNhap();
        BLL_SanPham BLL_SP = new BLL_SanPham();
        BLL_HoaDon BLL_HD = new BLL_HoaDon();
        BLL_ChiTietHoaDon BLL_CTHD = new BLL_ChiTietHoaDon();
        BLL_LichSuMuaHang BLL_LSMH = new BLL_LichSuMuaHang();
        public frmHoaDon()
        {
            InitializeComponent();
            this.Load += FrmHoaDon_Load;
            this.btn_Them.Click += Btn_Them_Click;
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            btn_Xoa.Enabled = true;
            btn_Sua.Enabled = true;

        }

        private void LoadHoaDon()
        {
            DataTable dtKH = BLL_KH.LoadKhachHang();
            DataTable dtHoaDon = BLL_HD.LoadHoaDon();

            if (!dtHoaDon.Columns.Contains("HoTen"))
                dtHoaDon.Columns.Add("HoTen", typeof(string));

            foreach (DataRow row in dtHoaDon.Rows)
            {
                int maKH = row.Field<int>("MaKH");
                DataRow khRow = dtKH.AsEnumerable()
                                    .FirstOrDefault(r => r.Field<int>("MaKH") == maKH);
                if (khRow != null)
                {
                    row["HoTen"] = khRow.Field<string>("HoTen");
                }
            }
            dgv_HoaDon.DataSource = dtHoaDon;
        }
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            cbo_SanPham.DataSource = BLL_SP.LoadSanPham();
            cbo_SanPham.DisplayMember = "TenSP";
            cbo_SanPham.ValueMember = "MaSP";

            txtThanhTien.Enabled = false;

            btn_Luu.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Sua.Enabled = false;
        }
    }
}
