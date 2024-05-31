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


namespace CSharp_LanguageCentre
{
    public partial class Invoice : UserControl
    {
        HoaDonBUS bus = new HoaDonBUS();
        List<HoaDonDTO> listHD = new List<HoaDonDTO>();
        List<HoaDonDTO> searchList = new List<HoaDonDTO>();
        static bool isDeleting = false, isUpdating = false;
        public Invoice()
        {
            InitializeComponent();
            LoadHoaDon();
            cbbTimKiem.SelectedIndex = 0;
        }

        private void LoadHoaDon()
        {
            listHD = bus.getAll();
            dgvHoaDon.DataSource = listHD;
            txtTimKiem.Enabled = true;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdating = true;

            btnSua.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.Enabled = false;
            date.Enabled = false;
            txtHocPhi.Enabled = false;
            cbbTinhTrang.Enabled = true;
            txtMaHV.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                isDeleting = false;

                btnXoa.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHD.Enabled = false;
                date.Enabled = true;
                txtHocPhi.Enabled = true;
                cbbTinhTrang.Enabled = true;
                txtMaHV.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;

            }
            else if (isUpdating)
            {
                isUpdating = false;

                btnSua.ForeColor = Color.Black;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaHD.Enabled = false;
                date.Enabled = true;
                txtHocPhi.Enabled = true;
                cbbTinhTrang.Enabled = true;
                txtMaHV.Enabled = true;

                btnXacNhan.Enabled = false;
                btnHuy.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            isDeleting = true;

            btnXoa.ForeColor = Color.FromArgb(1, 226, 91, 69);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.Enabled = true;
            date.Enabled = false;
            txtHocPhi.Enabled = false;
            cbbTinhTrang.Enabled = false;
            txtMaHV.Enabled = false;

            btnXacNhan.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (isDeleting)
            {
                if (String.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!bus.TrungMa(Convert.ToInt32(txtMaHD.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show(bus.Delete(Convert.ToInt32(txtMaHD.Text), Convert.ToInt32(txtMaHV.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHoaDon();
                    }
                }
            }
            else if (isUpdating)
            {
                if (String.IsNullOrWhiteSpace(txtMaHD.Text) || String.IsNullOrWhiteSpace(date.Text) || String.IsNullOrWhiteSpace(cbbTinhTrang.SelectedItem.ToString()) || String.IsNullOrWhiteSpace(txtHocPhi.Text))
                {
                    MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else if (!bus.TrungMa(Convert.ToInt32(txtMaHD.Text)))
                {
                    MessageBox.Show("Không tìm thấy mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HoaDonDTO hoaDon = new HoaDonDTO(Convert.ToInt32(txtMaHD.Text), date.Value.Date, int.Parse(txtHocPhi.Text), Convert.ToBoolean(cbbTinhTrang.SelectedIndex), int.Parse(txtMaHV.Text)) ;
                    MessageBox.Show(bus.Update(hoaDon), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDon();
                }
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtMaHD.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            date.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            txtHocPhi.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            cbbTinhTrang.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
            txtMaHV.Text = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.TrimStart(new char[] { ' ' }).TrimEnd(new char[] { ' ' });
            if(cbbTimKiem.SelectedIndex == 0 && String.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbbTimKiem.SelectedIndex == 0 && !int.TryParse(key, out int result))
            {
                MessageBox.Show("Thông tin đã nhập không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(cbbTimKiem.SelectedIndex == 0)
                {

                if (cbbState.SelectedIndex == 0)
                {
                    searchList = bus.Search(key, 0, DateTime.Now, true);
                }
                else if (cbbState.SelectedIndex == 1)
                {
                    searchList = bus.Search(key, 0, DateTime.Now, false);
                }
                else
                { searchList = bus.SearchStateless(key, 0, DateTime.Now); }
                    if (searchList.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvHoaDon.DataSource = searchList;
                    }
                }
            else
            {
                Console.WriteLine(dateTimePicker1.Value.Date);
                if (cbbState.SelectedIndex == 0)
                {
                    searchList = bus.Search(key, 1, dateTimePicker1.Value, true);
                }
                else if (cbbState.SelectedIndex == 1)
                {
                    searchList = bus.Search(key, 1, dateTimePicker1.Value, false);
                }
                else { searchList = bus.SearchStateless(key, 1, dateTimePicker1.Value); }


                if (searchList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvHoaDon.DataSource = searchList;
                }
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void ccbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTimKiem.SelectedIndex == 1)
            {

                dateTimePicker1.Enabled = true;
                txtTimKiem.Text = "";
                txtTimKiem.Enabled = false;
            }
            else dateTimePicker1.Enabled = false;

        }

        private void Invoice_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbbTimKiem.SelectedIndex = 0;
            cbbState.SelectedItem = null;
            cbbTinhTrang.SelectedItem = null;
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
        

    }
}
