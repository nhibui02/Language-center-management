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
using CSharp_LanguageCentre.DTO;
using BUS;

namespace CSharp_LanguageCentre.GUI
{
    public partial class Student : UserControl
    {
        HocVienBUS bus = new HocVienBUS();
        List<HocVienDTO> listHocVien = new List<HocVienDTO>();
        List<HocVienDTO> searchList = new List<HocVienDTO>();
        static bool isDeleting = false, isUpdating = false;
        public Student()
        {
            InitializeComponent();
            LoadHocVien();
            cbbTimKiem.SelectedIndex = 0;
        }

        private void LoadHocVien()
        {
            listHocVien = bus.getAll();
            dgvHocVien.DataSource = listHocVien;
        }

        private bool IsPhoneNumber(string phoneNum)
        {
            const string REGEX = @"^0[0-9]{9}";
            return Regex.IsMatch(phoneNum, REGEX);
        }
        private void lblLoginedUser_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //BUTTON TIM KIEM
        private void button1_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.TrimStart(new char[] { ' ' }).TrimEnd(new char[] { ' ' });

            if (String.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbbTimKiem.SelectedIndex == 0 && !int.TryParse(key, out int result))
            {
                MessageBox.Show("Thông tin đã nhập không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cbbTimKiem.SelectedIndex == 0)
                {
                    searchList = bus.Search(key, 0);
                    if (searchList.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvHocVien.DataSource = searchList;
                    }
                }
                else if (cbbTimKiem.SelectedIndex == 1)
                {
                    searchList = bus.Search(key, 1);
                    if (searchList.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvHocVien.DataSource = searchList;
                    }
                }

            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            btnXoa.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            txtMaHV.Enabled = true;
            txtTenHV.Enabled = false;
            txtSDT.Enabled = false;
            cbbTrinhDo.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                isDeleting = false;

                btnXoa.ForeColor = Color.Black;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                txtMaHV.Enabled = false;
                txtTenHV.Enabled = true;
                txtSDT.Enabled = true;
                cbbTrinhDo.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;
            }
            else if (isUpdating)
            {
                isUpdating = false;

                btnSua.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHV.Enabled = false;
                txtTenHV.Enabled = true;
                txtSDT.Enabled = true;
                cbbTrinhDo.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdating = true;

            btnSua.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHV.Enabled = true;
            txtTenHV.Enabled = true;
            txtSDT.Enabled = true;
            cbbTrinhDo.Enabled = true;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTenHV.Text) || String.IsNullOrWhiteSpace(txtSDT.Text) || String.IsNullOrWhiteSpace(cbbTrinhDo.SelectedItem.ToString()))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!IsPhoneNumber(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                HocVienDTO hocVien = new HocVienDTO(-1, txtTenHV.Text, txtSDT.Text, cbbTrinhDo.SelectedItem.ToString());
                MessageBox.Show(bus.Insert(hocVien), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHocVien();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                if (String.IsNullOrWhiteSpace(txtMaHV.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungMa(Convert.ToInt32(txtMaHV.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(bus.Delete(Convert.ToInt32(txtMaHV.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHocVien();
                    }
                }
            }
            else if (isUpdating)
            {
                if (String.IsNullOrWhiteSpace(txtMaHV.Text) || String.IsNullOrWhiteSpace(txtTenHV.Text) || String.IsNullOrWhiteSpace(txtSDT.Text) || String.IsNullOrWhiteSpace(cbbTrinhDo.SelectedItem.ToString()))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungMa(Convert.ToInt32(txtMaHV.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HocVienDTO hocVien = new HocVienDTO(Convert.ToInt32(txtMaHV.Text), txtTenHV.Text, txtSDT.Text, cbbTrinhDo.SelectedItem.ToString());
                    MessageBox.Show(bus.Update(hocVien), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHocVien();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHocVien();
        }

        private void dgvHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHocVien.CurrentRow.Index;
            txtMaHV.Text = dgvHocVien.Rows[i].Cells[0].Value.ToString();
            txtTenHV.Text = dgvHocVien.Rows[i].Cells[1].Value.ToString();
            txtSDT.Text = dgvHocVien.Rows[i].Cells[2].Value.ToString();
            cbbTrinhDo.Text = dgvHocVien.Rows[i].Cells[3].Value.ToString();
           
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new CourseRegistration());
        }
    }
}
