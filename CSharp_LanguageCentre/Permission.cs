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

namespace CSharp_LanguageCentre
{
    public partial class Permission : UserControl
    {
        QuyenBUS busQuyen = new QuyenBUS();
        ChucNangBUS busChucNang = new ChucNangBUS();
        ChiTietPhanQuyenBUS busCTQuyen = new ChiTietPhanQuyenBUS();
        List<QuyenDTO> listQuyen;
        List<ChucNangDTO> listChucNangAll;
        List<ChucNangDTO> listChucNangQuyen;
        static bool isDeleting = false, isUpdating = false;
        public Permission()
        {
            InitializeComponent();
            LoadQuyen();
            LoadCbbChucNang();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                int number = -1;
                if (String.IsNullOrWhiteSpace(txtMaQuyen.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!int.TryParse(txtMaQuyen.Text, out number) && number <= 0)
                {
                    MessageBox.Show("Dữ liệu đã nhập không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!busQuyen.TrungMa(Convert.ToInt32(txtMaQuyen.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(busQuyen.Delete(Convert.ToInt32(txtMaQuyen.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadQuyen();
                        listChucNangAll = busChucNang.getAll();
                    }
                }
            }
            else if (isUpdating)
            {
                int number = -1;
                if (String.IsNullOrWhiteSpace(txtMaQuyen.Text) || String.IsNullOrWhiteSpace(txtTenQuyen.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!int.TryParse(txtMaQuyen.Text, out number) && number <= 0)
                {
                    MessageBox.Show("Dữ liệu đã nhập không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!busQuyen.TrungMa(Convert.ToInt32(txtMaQuyen.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    QuyenDTO quyen = new QuyenDTO(Convert.ToInt32(txtMaQuyen.Text), txtTenQuyen.Text);
                    MessageBox.Show(busQuyen.Update(quyen), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadQuyen();
                }
            }
        }
        private void LoadQuyen()
        {
            listQuyen = busQuyen.getAll();
            dgvQuyen.DataSource = listQuyen;

            cbbMaQuyen.Items.Clear();
            listQuyen.ForEach(quyen =>
            {
                cbbMaQuyen.Items.Add(quyen.MaQuyen.ToString().Trim());
            });
        }

        private void ClearInputQuyen()
        {
            txtMaQuyen.Text = "";
            txtTenQuyen.Text = "";
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTenQuyen.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                QuyenDTO quyen = new QuyenDTO(-1, txtTenQuyen.Text);
                MessageBox.Show(busQuyen.Insert(quyen), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuyen();
            }
        }

        private void ToggleButtonQuyen()
        {
            if (isDeleting || isUpdating)
            {
                btnXacNhanQuyen.Enabled = true;
                btnHuyQuyen.Enabled = true;
                btnThemQuyen.Enabled = false;
                btnSuaQuyen.Enabled = false;
                btnXoaQuyen.Enabled = false;
            }

        }

        private void btnHuyQuyen_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                isDeleting = false;
                btnXacNhanQuyen.Enabled = false;
                btnHuyQuyen.Enabled = false;
                btnThemQuyen.Enabled = true;
                btnSuaQuyen.Enabled = true;
                btnXoaQuyen.Enabled = true;

                btnXoaQuyen.ForeColor = Color.Black;
                txtMaQuyen.Enabled = false;
                txtTenQuyen.Enabled = true;
            }
            else if (isUpdating)
            {
                isUpdating = false;
                btnXacNhanQuyen.Enabled = false;
                btnHuyQuyen.Enabled = false;
                btnThemQuyen.Enabled = true;
                btnSuaQuyen.Enabled = true;
                btnXoaQuyen.Enabled = true;

                btnSuaQuyen.ForeColor = Color.Black;
                txtMaQuyen.Enabled = false;
                txtTenQuyen.Enabled = true;
            }
            ClearInputQuyen();
        }

        private void btnSuaQuyen_Click(object sender, EventArgs e)
        {
            isUpdating = true;
            btnSuaQuyen.ForeColor = Color.FromArgb(1, 226, 91, 69);
            txtMaQuyen.Enabled = true;
            txtTenQuyen.Enabled = true;
            ToggleButtonQuyen();
        }

        private void cbbMaQuyen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadChiTietQuyen();
            cbbChonCN.Enabled = true;
            btnThemCN.Enabled = true;
            btnXoaCN.Enabled = true;
        }

        private void LoadChiTietQuyen()
        {
            int selectedMaQuyen = Convert.ToInt32(cbbMaQuyen.SelectedItem);
            listChucNangQuyen = busChucNang.getChucNang(selectedMaQuyen);
            dgvChucNang.DataSource = listChucNangQuyen;
        }

        private void LoadCbbChucNang()
        {
            listChucNangAll = busChucNang.getAll();
            cbbChonCN.Items.Clear();
            listChucNangAll.ForEach(chucNang =>
            {
                cbbChonCN.Items.Add(chucNang.TenCN.ToString().Trim());
            });

        }

        private void cbbChonCN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedMaCN = cbbChonCN.SelectedIndex + 1;
            txtMaCN.Text = selectedMaCN.ToString();
        }

        private void btnXoaCN_Click(object sender, EventArgs e)
        {
            btnXoaCN.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnThemCN.Enabled = false;
            btnXacNhanCN.Enabled = true;
            btnHuyCN.Enabled = true;
            btnXoaCN.Enabled = false;
        }

        private void btnHuyCN_Click(object sender, EventArgs e)
        {
            btnXoaCN.ForeColor = Color.Black;
            btnThemCN.Enabled = true;
            btnXacNhanCN.Enabled = false;
            btnHuyCN.Enabled = false;
            btnXoaCN.Enabled = true;
        }

        private void btnThemCN_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChiTietPhanQuyenDTO quyen = new ChiTietPhanQuyenDTO(Convert.ToInt32(cbbMaQuyen.SelectedItem), Convert.ToInt32(txtMaCN.Text));
            if (busCTQuyen.TrungMa(quyen))
            {
                MessageBox.Show("Chức năng thêm vào đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(busCTQuyen.Insert(quyen), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadChiTietQuyen();

            }
        }

        private void btnXacNhanCN_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ChiTietPhanQuyenDTO quyen = new ChiTietPhanQuyenDTO(Convert.ToInt32(cbbMaQuyen.SelectedItem), Convert.ToInt32(txtMaCN.Text));
            if (!busCTQuyen.TrungMa(quyen))
            {
                MessageBox.Show("Không tìm thấy chức năng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(busCTQuyen.Delete(quyen), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChiTietQuyen();
                }
            }
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            isDeleting = true;
            btnXoaQuyen.ForeColor = Color.FromArgb(1, 226, 91, 69);
            txtMaQuyen.Enabled = true;
            txtTenQuyen.Enabled = false;
            ToggleButtonQuyen();
        }
    }
}
