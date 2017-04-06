using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TestThuVien.HeThong;
using TestThuVien.QLThuVienBus;
using TestThuVien.QLThuVienDTO;
namespace TestThuVien.GiaoDien
{
    public partial class Frm_QLTra : Form
    {
        public Frm_QLTra()
        {
            InitializeComponent();
        }
        BUSS_TraSach bus = new BUSS_TraSach();
        BUSS_Muonsach bus2 = new BUSS_Muonsach();
        KetNoiDT kn = new KetNoiDT();
        void dongdukien()
        {
            but_TraSach.Enabled = false;
            but_ThoiHan.Enabled = false;
            but_Tim.Enabled = true;
            txt_MaHV.Enabled = true;
            txt_NgayHenTra.Enabled = false;
            txt_NgayHienTai.Enabled = false;
            txt_NgayMuon.Enabled = false;
            txt_SoLuong.Enabled = false;
            txt_TenHV.Enabled = false;
            txt_TenSach.Enabled = false;
        }
        void modukien()
        {
            but_TraSach.Enabled = true;
            but_ThoiHan.Enabled = true;
            txt_SoLuong.Enabled =true;
            but_Tim.Enabled = false;
            txt_MaHV.Enabled = false;
        }
        private void Frm_QLTra_Load(object sender, EventArgs e)
        {
            txt_MaHV.Text = "MHV";
            dongdukien();
            HienThi("");
        }
        void HienThi(string where)
        {
            dataGridView_QLTraSach.DataSource = bus.LayDuLieu(where);
        }

        private void dataGridView_QLTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                txt_MaHV.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_TenHV.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_TenSach.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_SoLuong.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_NgayMuon.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_NgayHenTra.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_NgayHienTai.Text = DateTime.Now.ToString();
                modukien();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void but_Tim_Click(object sender, EventArgs e)
        {
            if(txt_MaHV.Text=="MHV")
            {
                MessageBox.Show("Hãy nhập mã hội viên muốn tìm");
            }else
            {
                SqlParameter para = new SqlParameter("@mahoivien",txt_MaHV.Text);
                dataGridView_QLTraSach.DataSource = kn.sqlLayDuLieu("timthongtintrasach", para);

            }
        }
    }
}
