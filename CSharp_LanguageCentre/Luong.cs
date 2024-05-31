using BUS;
using CSharp_LanguageCentre.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_LanguageCentre
{
	public partial class Luong : UserControl
	{

		LuongBUS luongBUS = new LuongBUS();
		List<LuongDTO> listLuong = new List<LuongDTO>();
		
		public Luong()
		{
			InitializeComponent();
			loadLuong();

		}

		public void loadLuong()
		{
			listLuong = luongBUS.GetAll();
			dataGVLuong.DataSource = listLuong;
		}

		static bool click_Them = false;

		static bool click_Sua = false;

		static bool click_Xoa = false;

		private void RefreshTxt()
		{
			txtMaLuong.Text = "";
			txtMucLuong.Text = "";
			cbbLoaiLuong.Text = string.Empty;
		}

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			if (click_Them)
			{
				int numberLuong = 0;
				//Kiểm tra thông tin nhập
				if (String.IsNullOrWhiteSpace(txtMaLuong.Text))
				{
					MessageBox.Show("Không được để trống Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbLoaiLuong.Text.Trim()))
				{
					MessageBox.Show("Không được để trống loại lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtMucLuong.Text))
				{
					MessageBox.Show("Không được để trống Mức lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (!int.TryParse(txtMucLuong.Text, out numberLuong))
				{
					MessageBox.Show("Mức lương phải là số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
	
				else if (!luongBUS.KiemTraMaLuong(Convert.ToInt32(txtMaLuong.Text)))
				{
					MessageBox.Show("Lương bị trùng mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}


				else
				{
					LuongDTO luongDTO = new LuongDTO(Convert.ToInt32(luongBUS.AutoID()), cbbLoaiLuong.SelectedItem.ToString(), Convert.ToInt32(txtMucLuong.Text));
					MessageBox.Show(luongBUS.InsertLuong(luongDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					loadLuong();
					RefreshTxt();
					click_Them = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaLuong.Enabled = true;
					txtMucLuong.Enabled = true;
					cbbLoaiLuong.Enabled = true;
				}
			}

			else if (click_Sua)
			{
				//Kiểm tra thông tin nhập

				int numberLuong = 0;
				//Kiểm tra thông tin nhập
				if (String.IsNullOrWhiteSpace(txtMaLuong.Text))
				{
					MessageBox.Show("Không được để trống Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbLoaiLuong.Text.Trim()))
				{
					MessageBox.Show("Không được để trống loại lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtMucLuong.Text))
				{
					MessageBox.Show("Không được để trống Mức lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (!int.TryParse(txtMucLuong.Text, out numberLuong))
				{
					MessageBox.Show("Mức lương phải là số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (luongBUS.KiemTraMaLuong(Convert.ToInt32(txtMaLuong.Text)))
				{
					MessageBox.Show("Lương này chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					LuongDTO luongDTO = new LuongDTO(Convert.ToInt32(txtMaLuong.Text), cbbLoaiLuong.SelectedItem.ToString(), Convert.ToInt32(txtMucLuong.Text));
					MessageBox.Show(luongBUS.UpdateLuong(luongDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					loadLuong();
					click_Sua = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
				}
			}

			else if (click_Xoa)
			{
				if (String.IsNullOrWhiteSpace(txtMaLuong.Text))
				{
					MessageBox.Show("Không được để trống Mã lương cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (luongBUS.KiemTraMaLuong(Convert.ToInt32(txtMaLuong.Text)))
				{
					MessageBox.Show("Không tìm thấy mã nhân viên phải xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					MessageBox.Show(luongBUS.DeleteLuong(Convert.ToInt32(txtMaLuong.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					loadLuong();
					RefreshTxt();
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaLuong.Enabled = true;
					txtMucLuong.Enabled = true;
					cbbLoaiLuong.Enabled = true;
				}

			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			int id;
			id = luongBUS.AutoID();
			txtMaLuong.Text = id.ToString();

			click_Them = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaLuong.Enabled = false;
			txtMucLuong.Enabled = true;
			cbbLoaiLuong.Enabled = true;
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			click_Sua = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaLuong.Enabled = true;
			txtMucLuong.Enabled = true;
			cbbLoaiLuong.Enabled = true;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			click_Xoa = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaLuong.Enabled = true;
			txtMucLuong.Enabled = false;
			cbbLoaiLuong.Enabled = false;
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

				txtMaLuong.Enabled = true;
				txtMucLuong.Enabled = true;
				cbbLoaiLuong.Enabled = true;

			}

			else if (click_Sua)
			{
				click_Sua = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaLuong.Enabled = true;
				txtMucLuong.Enabled = true;
				cbbLoaiLuong.Enabled = true;
			}

			else if (click_Xoa)
			{
				click_Xoa = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaLuong.Enabled = true;
				txtMucLuong.Enabled = true;
				cbbLoaiLuong.Enabled = true;
			}
		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));

		}

		private void dataGVLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i;
			i = dataGVLuong.CurrentRow.Index;
			txtMaLuong.Text = dataGVLuong.Rows[i].Cells[0].Value.ToString();
			cbbLoaiLuong.Text = dataGVLuong.Rows[i].Cells[1].Value.ToString();
			txtMucLuong.Text = dataGVLuong.Rows[i].Cells[2].Value.ToString();
		}
	}
}
