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
    public partial class frmReport : Form
    {
        BLL_HoaDon BLL_HD = new BLL_HoaDon();
        BLL_ChiTietHoaDon BLL_CTHD = new BLL_ChiTietHoaDon();

        DTO_ChiTietHoaDon dto_cthd = new DTO_ChiTietHoaDon();
        public frmReport()
        {
            InitializeComponent();
            this.btnXemHD.Click += BtnXemHD_Click;
            this.Load += FrmReport_Load;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            cbo_MaHD.DataSource = BLL_HD.LoadHoaDon();
            cbo_MaHD.DisplayMember = "MaHD";
            cbo_MaHD.ValueMember = "MaHD";

            cbo_MaHD.SelectedIndex = -1;
        }

        private void BtnXemHD_Click(object sender, EventArgs e)
        {
            dto_cthd.MaHD = Convert.ToInt32(cbo_MaHD.Text);

            Report report = new Report();
            report.SetDatabaseLogon("sa", "123456", ".", "ShopBanAoKhoac");
            report.SetDataSource(BLL_CTHD.LoadCTHD_Report(dto_cthd));
            CrsReportHoaDon.ReportSource = report;


            decimal TongTien = BLL_CTHD.TinhTongTien(dto_cthd);

            report.SetParameterValue("TongTien", TongTien);

            CrsReportHoaDon.DisplayToolbar = false;
            CrsReportHoaDon.DisplayStatusBar = false;
            CrsReportHoaDon.Refresh();
        }

    }
}
