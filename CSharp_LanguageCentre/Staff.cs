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
using System.Text.RegularExpressions;
using DTO;

namespace CSharp_LanguageCentre.GUI
{
	public partial class Staff : UserControl
	{
		StaffBUS staffBUS = new StaffBUS();
		List<StaffDTO> listTK = new List<StaffDTO>();
		List<StaffDTO> staffList = new List<StaffDTO>();
		LuongBUS luongBUS = new LuongBUS();
		List<LuongDTO> listLuong;
		TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
		List<TaiKhoanDTO> listTaiKhoan;


		public Staff()
		{
			InitializeComponent();
			StaffLoad();
			LoadCbbMaLuong();
			LoadCbbTenTK();
			cbbLocTimKiem.SelectedIndex = 0;
		}

		private void StaffLoad()
		{
			staffList = staffBUS.getAll();
			//Gắn Dữ Liệu Lên datagrid
			dataGVStaff.DataSource = staffList;

		}

		private void LoadCbbMaLuong()
		{
			listLuong = luongBUS.GetAll();
			cbbMaLuong.Items.Clear();
			listLuong.ForEach(LuongDTO =>
			{
				cbbMaLuong.Items.Add(LuongDTO.MaLuong.ToString().Trim());
			}
			);

		}

		private void LoadCbbTenTK()
		{
			listTaiKhoan = taiKhoanBUS.getAll();
			cbbTenTK.Items.Clear();
			listTaiKhoan.ForEach(TaiKhoanDTO =>
			{
				cbbTenTK.Items.Add(TaiKhoanDTO.TenTK.ToString().Trim());
			}
			);

		}

		private bool KiemTraSDT(string sdt)
		{
			const string regexPhoneNumber = @"^0[1-9]{1}[0-9]{8}";
			return Regex.IsMatch(sdt, regexPhoneNumber);
			//return sdt.match(regexPhoneNumber) ? true : false;
		} 

		private void Staff_Load(object sender, EventArgs e)
		{

		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string key = txtTimKiem.Text.Trim(new char[] { ' ' });

			//thanh tim kiem trong hoac khoang trang
			if (String.IsNullOrWhiteSpace(key))
			{
				MessageBox.Show("Thanh tìm kiếm trống vui lòng nhập thông tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//maNV {0}
			else if (cbbLocTimKiem.SelectedIndex == 0 && !int.TryParse(key, out int kq) )
			{
				MessageBox.Show("Thông tin nhập sai dữ liệu (không hợp lệ) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			else
			{
				//maNV {0}
				if (cbbLocTimKiem.SelectedIndex == 0)
				{
					//timkiemnv(key,filter)
					listTK = staffBUS.TimKiemNV(key, 0);

					if (listTK.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVStaff.DataSource = listTK;
					}
				}

				//hotenNV {1}
				else if (cbbLocTimKiem.SelectedIndex == 1)
				{
					listTK = staffBUS.TimKiemNV(key, 1);

					if (listTK.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVStaff.DataSource = listTK;
					}
				}

				//sdt {2}
				else if (cbbLocTimKiem.SelectedIndex == 2)
				{
					listTK = staffBUS.TimKiemNV(key, 2);

					if (listTK.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVStaff.DataSource = listTK;
					}
				}

				//maluong {3}
				else if (cbbLocTimKiem.SelectedIndex == 3)
				{
					listTK = staffBUS.TimKiemNV(key, 3);

					if (listTK.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVStaff.DataSource = listTK;
					}
				}

				//tenTK
				else if (cbbLocTimKiem.SelectedIndex == 4)
				{
					listTK = staffBUS.TimKiemNV(key, 4);

					if (listTK.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVStaff.DataSource = listTK;
					}
				}
			}
		}

		private void btnLoadDS_Click(object sender, EventArgs e)
		{
			StaffLoad();
		}
		

		static bool click_Them = false;
		private void btnThem_Click(object sender, EventArgs e)
		{
			int id;
			id = staffBUS.AddMaNV();
			txtMaNV.Text = id.ToString();
			click_Them = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaNV.Enabled = false;
			txtTenNV.Enabled = true;
			txtSdt.Enabled = true;
			cbbMaLuong.Enabled = true;
			cbbTenTK.Enabled = true;

		}

		static bool click_Sua = false;

		static bool click_Xoa = false;


		
		private void RefreshTxt()
		{
			txtTenNV.Text = "";		
			txtSdt.Text = "";
			cbbTenTK.Text = "";
			cbbMaLuong.Text = string.Empty;
			txtMaNV.Text = "";

		}

		
		private void btnSua_Click(object sender, EventArgs e)
		{
			click_Sua = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaNV.Enabled = true;
			txtTenNV.Enabled = true;
			txtSdt.Enabled = true;
			cbbMaLuong.Enabled = true;
			cbbTenTK.Enabled = true;
		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));

		}

		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			if (click_Them)
			{
				//Kiểm tra thông tin nhập
				if (!staffBUS.KiemTraMaNV(Convert.ToInt32(txtMaNV.Text)))
				{
					MessageBox.Show("Nhân viên bị trùng mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtTenNV.Text))
				{
					MessageBox.Show("Không được để trống Tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (int.TryParse(txtTenNV.Text, out int kq))
				{
					MessageBox.Show("Tên nhân viên là chữ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}

				else if (String.IsNullOrWhiteSpace(txtMaNV.Text))
				{
					MessageBox.Show("Không được để trống mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbMaLuong.Text.Trim()))
				{
					MessageBox.Show("Không được để trống Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtSdt.Text))
				{
					MessageBox.Show("Không được để trống Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbTenTK.Text.Trim()))
				{
					MessageBox.Show("Không được để trống tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				//kiemtra sdt dung khong, tentk co ton tai va co trung voi nv nao khong
				else if (!KiemTraSDT(txtSdt.Text))
				{
					MessageBox.Show("Số điện thoại đã nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (!staffBUS.KiemTraTenTK_Add(cbbTenTK.Text.ToString()))
				{
					MessageBox.Show("Tên tài khoản đã nhập không hợp lệ (trùng hoặc không tồn tại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					StaffDTO staffDTO = new StaffDTO(Convert.ToInt32(staffBUS.AddMaNV()), txtTenNV.Text, txtSdt.Text, Convert.ToInt32(cbbMaLuong.SelectedItem), cbbTenTK.SelectedItem.ToString());
					MessageBox.Show(staffBUS.InsertNV(staffDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					StaffLoad();
					RefreshTxt();
					click_Them = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaNV.Enabled = true;
					txtTenNV.Enabled = true;
					txtSdt.Enabled = true;
					cbbMaLuong.Enabled = true;
					cbbTenTK.Enabled = true;
				}
			}

			else if (click_Sua)
			{
				//Kiểm tra thông tin nhập
				if (String.IsNullOrWhiteSpace(txtMaNV.Text))
				{
					MessageBox.Show("Không được để trống mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (staffBUS.KiemTraMaNV(Convert.ToInt32(txtMaNV.Text)))
				{
					MessageBox.Show("Mã hân viên cần sửa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtTenNV.Text))
				{
					MessageBox.Show("Không được để trống Tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (int.TryParse(txtTenNV.Text, out int kq))
				{
					MessageBox.Show("Tên nhân viên là chữ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				}
				else if (String.IsNullOrWhiteSpace(cbbTenTK.Text.Trim()))
				{
					MessageBox.Show("Không được để trống Tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbMaLuong.Text.Trim()))
				{
					MessageBox.Show("Không được để trống Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (String.IsNullOrWhiteSpace(txtSdt.Text))
				{
					MessageBox.Show("Không được để trống Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				if (!staffBUS.KiemTraTenTK(cbbTenTK.Text, Convert.ToInt32(txtMaNV.Text)))
				{
					MessageBox.Show("Tên tài khoản đã nhập không hợp lệ ( bị trùng hoặc không tồn tại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// Kiemtra sdt và ten tk
				else if (!KiemTraSDT(txtSdt.Text))
				{
					MessageBox.Show("Số điện thoại đã nhập không hợp lệ(trùng hoặc không tồn tại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
						StaffDTO staffDTO = new StaffDTO(Convert.ToInt32(txtMaNV.Text), txtTenNV.Text, txtSdt.Text, Convert.ToInt32(cbbMaLuong.SelectedItem), cbbTenTK.SelectedItem.ToString());
						MessageBox.Show(staffBUS.UpdateNV(staffDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						StaffLoad();
						RefreshTxt();
						click_Sua = false;
						btnThem.Enabled = true;
						btnSua.Enabled = true;
						btnXoa.Enabled = true;
				}
			}

			else if (click_Xoa)
			{
				// Truyền vào mà nv để xóa nv deleteNV(maNV)
				if (String.IsNullOrWhiteSpace(txtMaNV.Text))
				{
					MessageBox.Show("Không được để trống Mã nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (staffBUS.KiemTraMaNV(Convert.ToInt32(txtMaNV.Text)))
				{
					MessageBox.Show("Không tìm thấy mã nhân viên phải xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					MessageBox.Show(staffBUS.DeleteNV(Convert.ToInt32(txtMaNV.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					StaffLoad();
					RefreshTxt();
					click_Xoa = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaNV.Enabled = true;
					txtTenNV.Enabled = true;
					txtSdt.Enabled = true;
					cbbMaLuong.Enabled = true;
					cbbTenTK.Enabled = true;

				}

			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			click_Xoa = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaNV.Enabled = true;
			txtTenNV.Enabled = false;
			txtSdt.Enabled = false;
			cbbMaLuong.Enabled = false;
			cbbTenTK.Enabled = false;
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

				txtMaNV.Enabled = true;
				txtTenNV.Enabled = true;
				txtSdt.Enabled = true;
				cbbMaLuong.Enabled = true;
				cbbTenTK.Enabled = true;

			}

			else if (click_Sua)
			{
				click_Sua = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaNV.Enabled = true;
				txtTenNV.Enabled = true;
				txtSdt.Enabled = true;
				cbbMaLuong.Enabled = true;
				cbbTenTK.Enabled = true;
			}

			else if (click_Xoa)
			{
				click_Xoa = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaNV.Enabled = true;
				txtTenNV.Enabled = true;
				txtSdt.Enabled = true;
				cbbMaLuong.Enabled = true;
				cbbTenTK.Enabled = true;
			}
		}

		private void dataGVStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i;
			i = dataGVStaff.CurrentRow.Index;
			txtMaNV.Text = dataGVStaff.Rows[i].Cells[0].Value.ToString();
			txtTenNV.Text = dataGVStaff.Rows[i].Cells[1].Value.ToString();
			txtSdt.Text = dataGVStaff.Rows[i].Cells[2].Value.ToString();
			cbbMaLuong.Text = dataGVStaff.Rows[i].Cells[3].Value.ToString();
			cbbTenTK.Text = dataGVStaff.Rows[i].Cells[4].Value.ToString();
		}
	}
}
