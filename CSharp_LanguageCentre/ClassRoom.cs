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

namespace CSharp_LanguageCentre
{
	
	public partial class ClassRoom : UserControl
	{
		PhongHocBUS phongHocBUS = new PhongHocBUS();
		List<PhongHocDTO> listPH = new List<PhongHocDTO>();
		List<PhongHocDTO> listSearch = new List<PhongHocDTO>();
		public ClassRoom()
		{
			InitializeComponent();
			LoadPH();
		}

		private void LoadPH()
		{
			listPH = phongHocBUS.getAll();
			dataGVPH.DataSource = listPH;
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string key = txtTimKiem.Text.Trim(new char[] { ' ' });
			if (string.IsNullOrWhiteSpace(key))
			{
				MessageBox.Show("Bạn chưa nhạp thông tìm kiếm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}

			else if (!int.TryParse(key, out int result))
			{
				MessageBox.Show("Thông tin nhập sai dữ liệu (mã phòng là số) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			else
			{
				listSearch = phongHocBUS.TimKiemPH(key);
				if (listSearch.Count < 1)
				{
					MessageBox.Show("Không tìm thấy kết quả hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					dataGVPH.DataSource = listSearch;
				}
			}
		}
		private void bntLoadDS_Click(object sender, EventArgs e)
		{
			LoadPH();
		}

		static bool click_Them = false;
		static bool click_Xoa = false;
		static bool click_Sua = false;
		private void btnThem_Click(object sender, EventArgs e)
		{
				int id;
				id = phongHocBUS.AddMaPH();
				txtMaPH.Text = id.ToString();
				click_Them = true;
				btnHuy.Enabled = true;
				btnXacNhan.Enabled = true;

				btnThem.Enabled = false;
				btnSua.Enabled = false;
				btnXoa.Enabled = false;

				txtMaPH.Enabled = false;
				txtTenPH.Enabled = true;
				txtSucChua.Enabled = true;
		}

		private void btnSua_Click(object sender, EventArgs e)
		{

			click_Sua = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;


			txtMaPH.Enabled = true;
			txtTenPH.Enabled = true;
			txtSucChua.Enabled = true;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			click_Xoa = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;


			txtMaPH.Enabled = true;
			txtTenPH.Enabled = false;
			txtSucChua.Enabled = false;
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			if (click_Them)
			{
				click_Them = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaPH.Enabled = true;
				txtTenPH.Enabled = true;
				txtSucChua.Enabled = true;

			}

			else if (click_Sua)
			{
				click_Sua = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaPH.Enabled = true;
				txtTenPH.Enabled = true;
				txtSucChua.Enabled = true;

			}

			else if (click_Xoa)
			{
				click_Xoa = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaPH.Enabled = true;
				txtTenPH.Enabled = true;
				txtSucChua.Enabled = true;

			}
		}

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			if (click_Them)
			{
				if (String.IsNullOrWhiteSpace(txtMaPH.Text))
				{
					MessageBox.Show("Không được để trống Mã phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtTenPH.Text))
				{
					MessageBox.Show("Không được để trống Tên phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtSucChua.Text))
				{
					MessageBox.Show("Không được để trống sức chứa phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (!int.TryParse(txtSucChua.Text, out int result))
				{
					MessageBox.Show("Sức chứa phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					PhongHocDTO phongHocDTO = new PhongHocDTO(Convert.ToInt32(phongHocBUS.AddMaPH()), txtTenPH.Text, Convert.ToInt32(txtSucChua.Text));
					MessageBox.Show(phongHocBUS.InsertPH(phongHocDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPH();
					RefreshTxt();
					click_Them = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaPH.Enabled = true;
					txtTenPH.Enabled = true;
					txtSucChua.Enabled = true;
				}
			}

			else if (click_Sua)
			{
				if (String.IsNullOrWhiteSpace(txtMaPH.Text))
				{
					MessageBox.Show("Không được để trống Mã phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtTenPH.Text))
				{
					MessageBox.Show("Không được để trống Tên phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtSucChua.Text))
				{
					MessageBox.Show("Không được để trống sức chứa phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (!int.TryParse(txtSucChua.Text, out int result))
				{
					MessageBox.Show("Sức chứa phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (phongHocBUS.KiemTraMaPH(Convert.ToInt32(txtMaPH.Text)))
				{
					MessageBox.Show("Mã phòng học cần sửa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					PhongHocDTO phongHocDTO = new PhongHocDTO(Convert.ToInt32(txtMaPH.Text), txtTenPH.Text, Convert.ToInt32(txtSucChua.Text));
					MessageBox.Show(phongHocBUS.UpdatePH(phongHocDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPH();
					RefreshTxt();
					click_Them = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaPH.Enabled = true;
					txtTenPH.Enabled = true;
					txtSucChua.Enabled = true;
				}

			}
			else if (click_Xoa)
			{
				if (String.IsNullOrWhiteSpace(txtMaPH.Text))
				{
					MessageBox.Show("Không được để trống Mã phòng học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (phongHocBUS.KiemTraMaPH(Convert.ToInt32(txtMaPH.Text)))
				{
					MessageBox.Show("Không tìm thấy mã phòng học phải xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					MessageBox.Show(phongHocBUS.DeletePH(Convert.ToInt32(txtMaPH.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadPH();
					RefreshTxt();
					click_Xoa = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaPH.Enabled = true;
					txtTenPH.Enabled = true;
					txtSucChua.Enabled = true;
				}
			}
		}
		private void RefreshTxt()
		{
			txtMaPH.Text = "";
			txtTenPH.Text = "";
			txtSucChua.Text = "";
		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));

		}

		private void dataGVPH_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i;
			i = dataGVPH.CurrentRow.Index;
			txtMaPH.Text = dataGVPH.Rows[i].Cells[0].Value.ToString();
			txtTenPH.Text = dataGVPH.Rows[i].Cells[1].Value.ToString();
			txtSucChua.Text = dataGVPH.Rows[i].Cells[2].Value.ToString();
		}
	}
}
