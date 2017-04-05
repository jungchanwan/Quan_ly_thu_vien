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
        KetNoiDT dt = new KetNoiDT();
        public Frm_QLMuon()
        {
            InitializeComponent();
        }
        BUSS_Muonsach bus = new BUSS_Muonsach();
        void khoadieukhien()
        {
            txt_MaHoiVien.Enabled = false;
            txt_MaSach.Enabled = true;
            txt_NgayHenTra.Enabled = false;
            txt_NgayMuon.Enabled = false;
            txt_SoLuong.Enabled = false;
            txt_TenHoiVien.Enabled = false;
            txt_TenSach.Enabled =false;
            but_kiemtratinhtrang.Enabled = true;
            butluu.Enabled = false;
            but_Xoa.Enabled = false;
            but_Sua.Enabled = false;
        }
        void modieukhien()
        {
            txt_MaHoiVien.Enabled = true;
            txt_MaSach.Enabled = true;
            txt_NgayHenTra.Enabled = true;
            txt_NgayMuon.Enabled = true;
            txt_SoLuong.Enabled = true;
            txt_TenHoiVien.Enabled = true;
            txt_TenSach.Enabled = false;
            but_kiemtratinhtrang.Enabled = true;
            butluu.Enabled = true;
            but_Xoa.Enabled = false;
            but_Sua.Enabled = false;
        }
        private void Frm_QLMuon_Load(object sender, EventArgs e)
        {
            txt_MaSach.Text = "MS";
            khoadieukhien();
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
                modieukhien();
                but_kiemtratinhtrang.Enabled = false;
                butluu.Enabled = false;
                but_Xoa.Enabled = true;
                but_Sua.Enabled = true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
                
        }

        private void but_kiemtratinhtrang_Click(object sender, EventArgs e)
        {
            if (txt_MaSach.Text == "MS")
            {
                MessageBox.Show("Chưa nhập mã sách.");
            }
            else
            {
                SqlParameter prr = new SqlParameter("@masach", txt_MaSach.Text);
                DataTable showsls = dt.sqlLayDuLieu("sp_SachConLai", prr);
                MessageBox.Show("Số lượng sách còn lại trong kho :" + showsls.Rows[0][1].ToString());
                modieukhien();
            }
        }


        private void txt_MaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SqlParameter para1 = new SqlParameter("@masach", txt_MaSach.Text);
                    DataTable dulieu = dt.sqlLayDuLieu("sp_LayTenSach", para1);
                    txt_TenSach.Text = dulieu.Rows[dulieu.Rows.Count - 1]["TenSach"].ToString();
                }
                catch
                {
                    MessageBox.Show("Mã Sách Không Tồn Tại");
                }
            }

        }

        private void butluu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
