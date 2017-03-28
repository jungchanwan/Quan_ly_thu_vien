using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestThuVien.HeThong;
using TestThuVien.QLThuVienBus;
namespace TestThuVien.GiaoDien
{
    public partial class Frm_HoiVien : Form
    {
        public Frm_HoiVien()
        {
            InitializeComponent();
        }
        BUSS_HoiVien bus = new BUSS_HoiVien();
        HoiVien ec = new HoiVien();
        bool themmoi;
        void KhoaDieuKien()
        {
            txtmahoivien.Enabled = false;
            txtdiachi.Enabled = false;
            comboxgioitinh.Enabled = false;
            txtho.Enabled = false;
            txtten.Enabled = false;
            txtsodienthoai.Enabled = false;
            txtemail.Enabled = false;

            btnthemmoi.Enabled = true;
            btnluu.Enabled = false;
            buttomsua.Enabled = true;
            btnthoat.Enabled = true;
            btnxoa.Enabled = true;
        }
        void MoDieuKien()
        {
            txtmahoivien.Enabled = true;
            txtdiachi.Enabled = true;
            comboxgioitinh.Enabled = true;
            txtho.Enabled = true;
            txtten.Enabled = true;
            txtsodienthoai.Enabled = true;
            txtemail.Enabled = true;

            btnthemmoi.Enabled = false;
            btnluu.Enabled = true;
            buttomsua.Enabled = false;
            btnxoa.Enabled = false;
            btnthoat.Enabled = true;

        }
        private void Frm_HoiVien_Load(object sender, EventArgs e)
        {
            KhoaDieuKien();
            HienThi("");
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            MoDieuKien();
            SetNull();
            themmoi = true;
        }
        void SetNull()
        {
            txtmahoivien.Text="";
            comboxgioitinh.Text="Nam";
            txtdiachi.Text="";
            txtho.Text="";
            txtten.Text="";
            txtsodienthoai.Text = "";
            txtemail.Text="";
        }
        void HienThi(string where)
        {
            dataGiVHoiVien.DataSource = bus.LayDuLieu(where);
        }

        private void buttomsua_Click(object sender, EventArgs e)
        {
            MoDieuKien();
            txtmahoivien.Enabled = false;
            themmoi = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                ec.Mahoivien = txtmahoivien.Text;
                bus.XoaDuLieu(ec);
                MessageBox.Show("Đã xóa thành công");
                KhoaDieuKien();
                SetNull();
                HienThi("");
            }
            catch
            {
                MessageBox.Show("Lỗi Không thể xóa");
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txtmahoivien.Text == "" || txtdiachi.Text == "" || txtho.Text == "" || txtten.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                return;
            }
            if (themmoi == true)
            {
                try
                {
                    ec.Mahoivien = txtmahoivien.Text;
                    ec.Gioitinh = comboxgioitinh.Text;
                    ec.Diachi = txtdiachi.Text;
                    ec.Ho = txtho.Text;
                    ec.Ten = txtten.Text;
                    ec.Sodt = txtsodienthoai.Text;
                    ec.Email = txtemail.Text;
                    bus.ThemDuLieu(ec);
                    MessageBox.Show("Đã thêm dữ liệu thành công");
                }
                catch
                {
                    MessageBox.Show("lỗi");
                    return;
                }
            }
            else
            {
                try
                {
                    ec.Mahoivien = txtmahoivien.Text;
                    ec.Gioitinh = comboxgioitinh.Text;
                    ec.Diachi = txtdiachi.Text;
                    ec.Ho = txtho.Text;
                    ec.Ten = txtten.Text;
                    ec.Sodt = txtsodienthoai.Text;
                    ec.Email = txtemail.Text;
                    bus.SuaDuLieu(ec);
                    MessageBox.Show("Đã sửa dữ liệu thành công");
                 
                }
                catch
                {
                    MessageBox.Show("lỗi");
                    return;
                }
            }
            SetNull();
            KhoaDieuKien();
            HienThi("");
        }

        private void dataGiVHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                txtmahoivien.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtdiachi.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboxgioitinh.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtho.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtten.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtsodienthoai.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtemail.Text = dataGiVHoiVien.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch
            {
            }
                
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Bạn Có muốn thoát ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
           {
            this.Close();
           }
        }
    }
}
