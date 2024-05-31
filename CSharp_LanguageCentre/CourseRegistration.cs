using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BUS;
using CSharp_LanguageCentre.DTO;
using DTO;
namespace CSharp_LanguageCentre.GUI
{
    public partial class CourseRegistration : UserControl
    {
        KhoaHocBUS busKH = new KhoaHocBUS();
        HocVienBUS busHV = new HocVienBUS();
        List<XepLichDTO> listKH;
        List<HocVienDTO> listHV;
        HoaDonBUS busHD = new HoaDonBUS();
        CTHoaDonBUS busCTHD = new CTHoaDonBUS();
        XepLichBUS busLich = new XepLichBUS();
        List<int> makhCoLich = new List<int>();
        public CourseRegistration()
        {
            InitializeComponent();
            LoadKH();
            LoadHV();
        }

        private void LoadKH()
        {
            listKH = busLich.getAll();
            dgvKH.DataSource = listKH;

            cbbMaKH.Items.Clear();
            makhCoLich = busLich.getMaKHCoLich();
            makhCoLich.ForEach(kh =>
            {
                cbbMaKH.Items.Add(kh);
            });
        }

        private void LoadHV()
        {
            listHV = busHV.getAll();
            dgvHV.DataSource = listHV;

            cbbMaHV.Items.Clear();
            listHV.ForEach(hv =>
            {
                cbbMaHV.Items.Add(hv.MaHV.ToString().Trim());
            });
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cbbMaHV.Text) || String.IsNullOrWhiteSpace(cbbMaKH.Text) || String.IsNullOrWhiteSpace(cbbNhom.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(busHD.TrungMaKH(Convert.ToInt32(cbbMaKH.SelectedItem.ToString()), Convert.ToInt32(cbbMaHV.SelectedItem.ToString())))
            {
                MessageBox.Show("Khóa học đã được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CTHoaDonDTO cthd = new CTHoaDonDTO(-1, int.Parse(cbbMaKH.SelectedItem.ToString()), 0);
                busCTHD.Insert(cthd, Convert.ToInt32(cbbNhom.SelectedItem.ToString()), Convert.ToInt32(cbbMaHV.SelectedItem.ToString()));
                HoaDonDTO hoaDon = new HoaDonDTO(cthd.MaHD, DateTime.Today, cthd.Gia, false, int.Parse(cbbMaHV.SelectedItem.ToString()));
                MessageBox.Show(busHD.Insert(hoaDon), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadKH();
                LoadHV();
                cbbNhom.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnXacNhan.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new Student());

        }

        private void cbbNhom_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbbMaKH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<XepLichDTO> nhomKH = new List<XepLichDTO>();
            cbbNhom.Enabled = true;
            nhomKH = busLich.getLichKhoaHoc(Convert.ToInt32(cbbMaKH.SelectedItem.ToString()));
            cbbNhom.Items.Clear();
            nhomKH.ForEach(kh =>
            {
                cbbNhom.Items.Add(kh.NhomKH);
            });
        }
    }
}
