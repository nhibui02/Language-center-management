using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CSharp_LanguageCentre.DTO;
using BUS;
namespace CSharp_LanguageCentre.GUI
{
    public partial class Course : UserControl
    {
        KhoaHocBUS bus = new KhoaHocBUS();
        List<KhoaHocDTO> listKhoaHoc = new List<KhoaHocDTO>();
        List<KhoaHocDTO> searchList = new List<KhoaHocDTO>();
        static bool isDeleting = false, isUpdating = false;
        public Course()
        {
            InitializeComponent();
            LoadKhoaHoc();
            cbbTimKiem.SelectedIndex = 0;
        }

        private void LoadKhoaHoc()
        {
            listKhoaHoc = bus.getAll();
            dgvKhoaHoc.DataSource = listKhoaHoc;
        }

        private bool IsValidDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) return false;
            return true;
        }
        private void CourseView_Load(object sender, EventArgs e)
        {

        }

        private void lblLoginedUser_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvKhoaHoc.CurrentRow.Index;
            txtMaKH.Text = dgvKhoaHoc.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhoaHoc.Rows[i].Cells[1].Value.ToString();
            txtGia.Text = dgvKhoaHoc.Rows[i].Cells[2].Value.ToString();
            cbbCapBac.Text = dgvKhoaHoc.Rows[i].Cells[3].Value.ToString();
            dateBatDau.Text = dgvKhoaHoc.Rows[i].Cells[4].Value.ToString();
            dateKetThuc.Text = dgvKhoaHoc.Rows[i].Cells[5].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtTenKH.Text) || String.IsNullOrWhiteSpace(txtGia.Text) || String.IsNullOrWhiteSpace(cbbCapBac.SelectedItem.ToString()))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!IsValidDate(dateBatDau.Value.Date, dateKetThuc.Value.Date))
            {
                MessageBox.Show("Hãy đảm bảo ngày kết thúc sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KhoaHocDTO khoaHoc = new KhoaHocDTO(-1, txtTenKH.Text, int.Parse(txtGia.Text), cbbCapBac.SelectedItem.ToString(), dateBatDau.Value.Date, dateKetThuc.Value.Date);
                MessageBox.Show(bus.Insert(khoaHoc), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhoaHoc();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdating = true;

            btnSua.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtGia.Enabled = true;
            cbbCapBac.Enabled = true;
            dateBatDau.Enabled = true;
            dateKetThuc.Enabled = true;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(isDeleting)
            {
                isDeleting = false;

                btnXoa.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = true;
                txtGia.Enabled = true;
                cbbCapBac.Enabled = true;
                dateBatDau.Enabled = true;
                dateKetThuc.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;

            }
            else if(isUpdating)
            {
                isUpdating = false;

                btnSua.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = true;
                txtGia.Enabled = true;
                cbbCapBac.Enabled = true;
                dateBatDau.Enabled = true;
                dateKetThuc.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(isDeleting)
            {
                if (String.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungMa(Convert.ToInt32(txtMaKH.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(bus.Delete(Convert.ToInt32(txtMaKH.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKhoaHoc();
                    }
                }
            }
            else if(isUpdating)
            {
                if (String.IsNullOrWhiteSpace(txtTenKH.Text) || String.IsNullOrWhiteSpace(txtGia.Text) || String.IsNullOrWhiteSpace(cbbCapBac.SelectedItem.ToString()))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsValidDate(dateBatDau.Value.Date, dateKetThuc.Value.Date))
                {
                    MessageBox.Show("Hãy đảm bảo ngày kết thúc sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(!bus.TrungMa(Convert.ToInt32(txtMaKH.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhoaHocDTO khoaHoc = new KhoaHocDTO(Convert.ToInt32(txtMaKH.Text), txtTenKH.Text, int.Parse(txtGia.Text), cbbCapBac.SelectedItem.ToString(), dateBatDau.Value.Date, dateKetThuc.Value.Date);
                    MessageBox.Show(bus.Update(khoaHoc), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhoaHoc();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            btnXoa.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = false;
            txtGia.Enabled = false;
            cbbCapBac.Enabled = false;
            dateBatDau.Enabled = false;
            dateKetThuc.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new XepLich());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
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
                        dgvKhoaHoc.DataSource = searchList;
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
                        dgvKhoaHoc.DataSource = searchList;
                    }
                }

            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadKhoaHoc();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }
    }
}
