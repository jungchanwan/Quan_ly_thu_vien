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
    public partial class Frm_QLMuon : Form
    {
        public Frm_QLMuon()
        {
            InitializeComponent();
        }
        BUSS_Muonsach bus = new BUSS_Muonsach();
        private void Frm_QLMuon_Load(object sender, EventArgs e)
        {
            HienThi("");
        }
        /*-----------------------------------------*/

        /*-----------------------------------------*/
        void HienThi(string where)
        {
            dataGridView_QLMuonSach.DataSource = bus.LayDuLieu(where);
        }

        private void dataGridView_QLMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_MaHoiVien.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_TenHoiVien.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_MaSach.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_TenSach.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_SoLuong.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_NgayMuon.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_NgayHenTra.Text = dataGridView_QLMuonSach.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
                
        }

   
      
    }
}
