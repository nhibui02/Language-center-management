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
using DTO;
using CSharp_LanguageCentre.DTO;

namespace CSharp_LanguageCentre.GUI
{
    public partial class XepLich : UserControl
    {
        KhoaHocBUS busKH = new KhoaHocBUS();
        GiangVienBUS busGV = new GiangVienBUS();
        PhongHocBUS busPH = new PhongHocBUS();
        XepLichBUS busXL;
        List<KhoaHocDTO> dsKH = new List<KhoaHocDTO>();
        List<XepLichDTO> dsXL = new List<XepLichDTO>();
        List<GiangVienDTO> dsGV = new List<GiangVienDTO>();
        List<PhongHocDTO> dsPH = new List<PhongHocDTO>();
        static bool isDeleting = false, isUpdating = false;
        public XepLich()
        {
            InitializeComponent();
            LoadKhoaHoc();
            LoadComboBoxGV();
            LoadCbbPhong();
        }
        private void LoadCbbPhong()
        {
            dsPH = busPH.getAll();
            foreach (PhongHocDTO ph in dsPH)
            {
                cbbPhong.Items.Add(ph.MaPH.ToString().Trim());
            }
        }
        private void LoadKhoaHoc()
        {
            dsKH = busKH.getAll();
            dgvKhoaHoc.DataSource = dsKH;
            LoadComboBoxKH();
        }

        private void LoadComboBoxKH()
        {
            cbbMaKH.Items.Clear();
            foreach (KhoaHocDTO kh in dsKH)
            {
                cbbMaKH.Items.Add(kh.MaKH.ToString().Trim());
            }
        }

        private void LoadComboBoxGV()
        {
            dsGV = busGV.getAll();
            foreach(GiangVienDTO gv in dsGV)
            {
                cbbGiangVien.Items.Add(gv.HoTen.ToString().Trim());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCapBac_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new Course());
        }

        private void LoadXepLich()
        {
            dsXL = busXL.getLichKhoaHoc(Convert.ToInt32(cbbMaKH.SelectedItem));
            dgvLichKH.DataSource = dsXL;

            cbbNhomKH.Items.Clear();
            foreach (XepLichDTO xl in dsXL)
            {
                cbbNhomKH.Items.Add(xl.NhomKH);
            }
        }

        private void cbbMaKH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(cbbMaKH.SelectedItem);
            busXL = new XepLichBUS(maKH);
            dsXL = busXL.getLichKhoaHoc(maKH);
            LoadXepLich();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                isDeleting = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;

                cbbNhomKH.Enabled = false;
                cbbGiangVien.Enabled = true;
                cbbThu.Enabled = true;
                cbbTietBD.Enabled = true;
                cbbSoTiet.Enabled = true;
                cbbPhong.Enabled = true;
            }
            else if (isUpdating)
            {
                isUpdating = false;

                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;

                cbbNhomKH.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdating = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;

            cbbNhomKH.Enabled = true;
        }

        private bool InputEmpty()
        {
            if (String.IsNullOrWhiteSpace(cbbMaKH.Text) || String.IsNullOrWhiteSpace(cbbThu.Text) || String.IsNullOrWhiteSpace(cbbTietBD.Text) || String.IsNullOrWhiteSpace(cbbSoTiet.Text) || String.IsNullOrWhiteSpace(cbbGiangVien.Text) || String.IsNullOrWhiteSpace(cbbPhong.Text))
            {
                return true;
            }
            return false;
        }

        private bool ThoiGianHopLe()
        {
            int tietBD = Convert.ToInt32(cbbTietBD.SelectedItem);
            int soTiet = Convert.ToInt32(cbbSoTiet.SelectedItem);

            if (tietBD <= 5)
            {
                if (tietBD + soTiet - 1 > 5) return false;
            }
            else
            {
                if (tietBD + soTiet - 1 > 10) return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (InputEmpty())
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!ThoiGianHopLe())
            {
                MessageBox.Show("Thời gian khóa học không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            XepLichDTO xepLich = new XepLichDTO(Convert.ToInt32(cbbMaKH.SelectedItem), -1, cbbThu.SelectedIndex, Convert.ToInt32(cbbTietBD.SelectedItem), Convert.ToInt32(cbbSoTiet.SelectedItem), Convert.ToInt32(cbbGiangVien.SelectedIndex) + 1, Convert.ToInt32(cbbPhong.SelectedItem));
            if (busXL.TrungLich(xepLich))
            {
                MessageBox.Show("Thời gian đã chọn bị trùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(busXL.Insert(xepLich), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadXepLich();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                if (string.IsNullOrWhiteSpace(cbbMaKH.Text) || string.IsNullOrWhiteSpace(cbbNhomKH.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!busXL.TrungMa(Convert.ToInt32(cbbMaKH.SelectedItem), Convert.ToInt32(cbbNhomKH.SelectedItem)))
                {
                    MessageBox.Show("Nhóm khóa học không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult rs = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rs == DialogResult.Yes)
                    {
                        MessageBox.Show(busXL.Delete(Convert.ToInt32(cbbMaKH.SelectedItem), Convert.ToInt32(cbbNhomKH.SelectedItem)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadXepLich();
                    }
                }
            }
            else if (isUpdating)
            {
                if (InputEmpty() && String.IsNullOrWhiteSpace(cbbNhomKH.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!busXL.TrungMa(Convert.ToInt32(cbbMaKH.SelectedItem), Convert.ToInt32(cbbNhomKH.SelectedItem)))
                {
                    MessageBox.Show("Nhóm khóa học không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XepLichDTO xepLich = new XepLichDTO(Convert.ToInt32(cbbMaKH.SelectedItem), -1, cbbThu.SelectedIndex, Convert.ToInt32(cbbTietBD.SelectedItem), Convert.ToInt32(cbbSoTiet.SelectedItem), Convert.ToInt32(cbbGiangVien.SelectedIndex) + 1, Convert.ToInt32(cbbPhong.SelectedItem));
                    MessageBox.Show(busXL.Update(xepLich), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadXepLich();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;

            cbbNhomKH.Enabled = true;
            cbbGiangVien.Enabled = false;
            cbbThu.Enabled = false;
            cbbTietBD.Enabled = false;
            cbbSoTiet.Enabled = false;
            cbbPhong.Enabled = false;
        }
    }
}
