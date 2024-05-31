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
namespace CSharp_LanguageCentre
{
    public partial class Account : UserControl
    {
        TaiKhoanBUS bus = new TaiKhoanBUS();
        QuyenBUS busQuyen = new QuyenBUS();
        List<TaiKhoanDTO> listTaiKhoan = new List<TaiKhoanDTO>();
        List<QuyenDTO> listQuyen = new List<QuyenDTO>();
        List<TaiKhoanDTO> searchList = new List<TaiKhoanDTO>();
        static bool isDeleting = false, isUpdating = false;
        public Account()
        {
            InitializeComponent();
            LoadTaiKhoan();
        }

        public void LoadCbbQuyen()
        {
            listQuyen = busQuyen.getAll();
            cbbMaQuyen.Items.Clear();
            foreach(QuyenDTO quyen in listQuyen)
            {
                cbbMaQuyen.Items.Add(quyen.MaQuyen.ToString().Trim());
            }
        }

        private void LoadTaiKhoan()
        {
            listTaiKhoan = bus.getAll();
            dgvTaiKhoan.DataSource = listTaiKhoan;
            LoadCbbQuyen();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdating = true;

            btnSua.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtUsername.Enabled = true;
            txtMatKhau.Enabled = true;
            cbbMaQuyen.Enabled = true;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                if (String.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungTenTK(txtUsername.Text))
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(bus.Delete(txtUsername.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTaiKhoan();
                    }
                }
            }
            else if (isUpdating)
            {
                if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtMatKhau.Text) || String.IsNullOrWhiteSpace(cbbMaQuyen.SelectedItem.ToString()))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungTenTK(txtUsername.Text))
                {
                    MessageBox.Show("Không tìm thấy tên tài khoản cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TaiKhoanDTO taiKhoan = new TaiKhoanDTO(txtUsername.Text, txtMatKhau.Text, int.Parse(cbbMaQuyen.Text));
                    MessageBox.Show(bus.Update(taiKhoan), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTaiKhoan();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtMatKhau.Clear();

            if (isDeleting)
            {
                isDeleting = false;

                btnXoa.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                txtUsername.Enabled = true;
                txtMatKhau.Enabled = true;
                cbbMaQuyen.Enabled = true;

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
                txtUsername.Enabled = true;
                txtMatKhau.Enabled = true;
                cbbMaQuyen.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            btnXoa.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            txtUsername.Enabled = true;
            txtMatKhau.Enabled = false;
            cbbMaQuyen.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.TrimStart(new char[] { ' ' }).TrimEnd(new char[] { ' ' });

            if (String.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                searchList = bus.Search(key);
                if (searchList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvTaiKhoan.DataSource = searchList;
                }
            }
                
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadTaiKhoan();
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTaiKhoan.CurrentRow.Index;
            txtUsername.Text = dgvTaiKhoan.Rows[i].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[i].Cells[1].Value.ToString();
            cbbMaQuyen.Text = dgvTaiKhoan.Rows[i].Cells[2].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtMatKhau.Text) || String.IsNullOrWhiteSpace(cbbMaQuyen.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (bus.TrungTenTK(txtUsername.Text))
            {
                MessageBox.Show("Tài khoản đã tồn tại! Vui lòng nhập tài khoản khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO(txtUsername.Text, txtMatKhau.Text, int.Parse(cbbMaQuyen.SelectedItem.ToString()));
                MessageBox.Show(bus.Insert(taiKhoan), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTaiKhoan();
            }
        }

        
    }
}
