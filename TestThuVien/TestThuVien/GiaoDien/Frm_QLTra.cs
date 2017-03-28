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
        private void Frm_QLTra_Load(object sender, EventArgs e)
        {
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
                txt_TenHV.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_TenSach.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_SoLuong.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_NgayMuon.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_NgayHenTra.Text = dataGridView_QLTraSach.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_NgayHienTai.Text = DateTime.Now.ToString();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
    }
}
