using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        BLL_SanPham BLL_SP = new BLL_SanPham();
        BLL_HoaDon BLL_HD = new BLL_HoaDon();
        BLL_ChiTietHoaDon BLL_CTHD = new BLL_ChiTietHoaDon();

        DataTable dtCTHD = new DataTable();

        DTO_HoaDon dto_hd = new DTO_HoaDon();
        DTO_ChiTietHoaDon dto_cthd = new DTO_ChiTietHoaDon();
        public frmHoaDon()
        {
            InitializeComponent();
            this.Load += FrmHoaDon_Load;
            this.btn_Them.Click += Btn_Them_Click;
            this.btn_Sua.Click += Btn_Sua_Click;
            this.btn_Luu.Click += Btn_Luu_Click;
            this.dgv_HoaDon.SelectionChanged += Dgv_HoaDon_SelectionChanged;
            this.btnThemSP.Click += BtnThemSP_Click;
            this.btn_Xoa.Click += Btn_Xoa_Click;
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_HoaDon.CurrentRow != null && !dgv_HoaDon.CurrentRow.IsNewRow)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgv_HoaDon.Rows.Remove(dgv_HoaDon.CurrentRow);

                    // Cập nhật lại tổng tiền
                    decimal tongTien = dtCTHD.AsEnumerable()
                        .Sum(r => r.Field<int>("SoLuong") * r.Field<decimal>("Gia"));
                    txtThanhTien.Text = tongTien.ToString();
                }
            }
        }
        private void BtnThemSP_Click(object sender, EventArgs e)
        {
            if(cbo_NhanVien.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtSL.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm và số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int MaSP = int.Parse(txtMaSP.Text);
            int SoLuong = int.Parse(txtSL.Text);
            decimal Gia = BLL_SP.LayGiaSP(int.Parse(txtMaSP.Text));

            DataRow newRow = dtCTHD.NewRow();
            // MaHD để trống (DBNull.Value) vì chưa có ID
            newRow["MaHD"] = DBNull.Value;
            newRow["MaSP"] = MaSP;
            newRow["SoLuong"] = SoLuong;
            newRow["Gia"] = Gia;

            dtCTHD.Rows.Add(newRow);
            dgv_HoaDon.DataSource = dtCTHD;

            decimal tongTien = dtCTHD.AsEnumerable().Sum(r => r.Field<int>("SoLuong") * r.Field<decimal>("Gia"));

            txtThanhTien.Text = tongTien.ToString();

            txtMaSP.Clear();
            txtSL.Clear();
        }
        private void Dgv_HoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_HoaDon.CurrentRow != null && !dgv_HoaDon.CurrentRow.IsNewRow)
            {
                txtMaSP.Text = dgv_HoaDon.CurrentRow.Cells[1].Value.ToString();
                txtSL.Text = dgv_HoaDon.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                txtMaSP.Text = string.Empty;
                txtSL.Text = string.Empty;
            }

            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }
        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            //dto_hd.NgayLap = DateTime.Now;
            //dto_hd.MaNV = (int)cbo_NhanVien.SelectedValue;
            //dto_hd.MaKH = (int)cbo_KhachHang.SelectedValue;
            //dto_hd.TongTien = decimal.Parse(txtThanhTien.Text);

            //int MaHD = BLL_HD.ThemHoaDon(dto_hd);

            //foreach(DataGridViewRow row in dgv_HoaDon.Rows)
            //{
            //    if(row.IsNewRow) continue;
            //    dto_cthd.MaHD = MaHD;
            //    dto_cthd.MaSP = (int)row.Cells[1].Value;
            //    dto_cthd.SoLuong = (int)row.Cells[2].Value;
            //    dto_cthd.Gia = (decimal)row.Cells[3].Value;
            //    BLL_CTHD.ThemCTHD(dto_cthd);
            //}

            //MessageBox.Show("Lưu hóa đơn thành công! Mã HD: " + MaHD, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cbo_NhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dto_hd.NgayLap = DateTime.Now;
            dto_hd.MaNV = (int)cbo_NhanVien.SelectedValue;
            dto_hd.MaKH = cbo_KhachHang.SelectedIndex != -1 ? (int)cbo_KhachHang.SelectedValue : 0; // Khách lẻ = 0
            dto_hd.TongTien = decimal.Parse(txtThanhTien.Text);

            int MaHD = BLL_HD.ThemHoaDon(dto_hd);

            foreach (DataRow row in dtCTHD.Rows)
            {
                dto_cthd.MaHD = MaHD;
                dto_cthd.MaSP = (int)row["MaSP"];
                dto_cthd.SoLuong = (int)row["SoLuong"];
                dto_cthd.Gia = (decimal)row["Gia"];
                BLL_CTHD.ThemCTHD(dto_cthd);
            }

           
            MessageBox.Show("Lưu hóa đơn thành công! Mã HD: " + MaHD, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa bảng tạm để bắt đầu hóa đơn mới
            dtCTHD.Clear();
            dgv_HoaDon.DataSource = dtCTHD;
            txtThanhTien.Text = "0";
            txtMaSP.Clear();
            txtSL.Clear();
        }
        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            btn_Luu.Enabled = true;

            if (dgv_HoaDon.CurrentRow != null && !dgv_HoaDon.CurrentRow.IsNewRow)
            {
                int index = dgv_HoaDon.CurrentRow.Index;
                int newMaSP;
                int newSL;

                if (!int.TryParse(txtMaSP.Text, out newMaSP) || !int.TryParse(txtSL.Text, out newSL))
                {
                    MessageBox.Show("Mã sản phẩm và số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal newGia = BLL_SP.LayGiaSP(newMaSP);

                // Cập nhật vào dtCTHD
                dtCTHD.Rows[index]["MaSP"] = newMaSP;
                dtCTHD.Rows[index]["SoLuong"] = newSL;
                dtCTHD.Rows[index]["Gia"] = newGia;

                dgv_HoaDon.Refresh();

                // Cập nhật tổng tiền
                decimal tongTien = dtCTHD.AsEnumerable()
                    .Sum(r => r.Field<int>("SoLuong") * r.Field<decimal>("Gia"));
                txtThanhTien.Text = tongTien.ToString();
            }
        }
        private void Btn_Them_Click(object sender, EventArgs e)
        {
            cbo_NhanVien.Enabled = true;
            cbo_KhachHang.Enabled = true;

            btn_Luu.Enabled = true;
            btnThemSP.Enabled = true;

            lblMaSP.Enabled = true;
            lblSL.Enabled = true;

            txtSL.Enabled = true;
            txtMaSP.Enabled = true;

            dgv_HoaDon.AllowUserToAddRows = true;
            dgv_HoaDon.ReadOnly = false;

            //Không cho sửa các dòng đã có
            for (int i = 0; i < dgv_HoaDon.Rows.Count - 1; i++)
            {
                dgv_HoaDon.Rows[i].ReadOnly = true;
            }
            dgv_HoaDon.FirstDisplayedScrollingRowIndex = dgv_HoaDon.Rows.Count - 1;
        }
        private void LoadChiTietHoaDon()
        {
            cbo_NhanVien.DataSource = BLL_NV.LoadNhanVien();
            cbo_NhanVien.DisplayMember = "HoTen";
            cbo_NhanVien.ValueMember = "MaNV";

            cbo_NhanVien.SelectedIndex = -1;

            cbo_KhachHang.DataSource = BLL_KH.LoadKhachHang();
            cbo_KhachHang.DisplayMember = "HoTen";
            cbo_KhachHang.ValueMember = "MaKH";
            //Khách lẻ
            cbo_KhachHang.SelectedIndex = -1;
            //Ẩn mã hóa đơn
            dgv_HoaDon.Columns[0].Visible = false;
        }
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            //Tạo bảng tạm
            if (dtCTHD.Columns.Count == 0)
            {
                dtCTHD.Columns.Add("MaHD", typeof(int));
                dtCTHD.Columns.Add("MaSP", typeof(int));
                dtCTHD.Columns.Add("SoLuong", typeof(int));
                dtCTHD.Columns.Add("Gia", typeof(decimal));
            }

            LoadChiTietHoaDon();

            dgv_HoaDon.ReadOnly = true;
            dgv_HoaDon.AllowUserToAddRows = false;

            btn_Luu.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Sua.Enabled = false;
            btnThemSP.Enabled = false;

            cbo_NhanVien.Enabled = false;
            cbo_KhachHang.Enabled = false;

            txtMaSP.Enabled = false;

            lblSL.Enabled = false;
            lblThanhTien.Enabled = false;
            lblMaSP.Enabled = false;

            txtSL.Enabled = false;
            txtThanhTien.Enabled = false;
            txtThanhTien.Text = "0";


        }
    }
}
