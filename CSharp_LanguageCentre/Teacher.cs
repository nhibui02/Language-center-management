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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_LanguageCentre.GUI
{
	public partial class Teacher : UserControl
	{
		GiangVienBUS gvBUS = new GiangVienBUS();
		List<GiangVienDTO> listSearch = new List<GiangVienDTO>();
		List<GiangVienDTO> gvList = new List<GiangVienDTO>();
		List<LuongDTO> listLuong;
		LuongBUS luongBUS = new LuongBUS();
		public Teacher()
		{
			InitializeComponent();
			gvLoad();
			cbbLocTimKiem.SelectedIndex = 0;
			LoadCbbMaLuong();
		}
		private void gvLoad()
		{
			gvList = gvBUS.getAll();
			//Gắn Dữ Liệu Lên datagrid
			dataGVgv.DataSource = gvList;

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

		private bool KiemTraSDT(string sdt)
		{
			const string regexPhoneNumber = @"^0[1-9]{1}[0-9]{8}";
			return Regex.IsMatch(sdt, regexPhoneNumber);
			//return sdt.match(regexPhoneNumber) ? true : false;
		}


		static bool click_Them = false;

		static bool click_Sua = false;

		static bool click_Xoa = false;

		private void RefreshTxt()
		{
			txtMaGV.Text = "";
			txtTenGV.Text = "";
			txtSdt.Text = "";
			cbbTrinhDo.Text = string.Empty;
			cbbChuyenMon.Text = string.Empty;
			cbbMaLuong.Text = string.Empty;
		}


		private void btnXacNhan_Click(object sender, EventArgs e)
		{
			if (click_Them)
			{
				//Kiểm tra thông tin nhập
				if (String.IsNullOrWhiteSpace(txtTenGV.Text))
				{
					MessageBox.Show("Không được để trống Tên giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtMaGV.Text))
				{
					MessageBox.Show("Không được để trống Mã giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				
				else if (String.IsNullOrWhiteSpace(txtSdt.Text))
				{
					MessageBox.Show("Không được để trống Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (string.IsNullOrWhiteSpace(cbbTrinhDo.Text.Trim()))
				{
					MessageBox.Show("Không được để trống trình độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbChuyenMon.Text.Trim()))
				{
					MessageBox.Show("Không được để trống chuyên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrEmpty(cbbMaLuong.Text.Trim()))
				{
					MessageBox.Show("Bạn chưa chọn Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//kiemtra sdt dung khong, tentk co ton tai va co trung voi nv nao khong
				else if (!KiemTraSDT(txtSdt.Text))
				{
					MessageBox.Show("Số điện thoại đã nhập không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				
				else if (!gvBUS.KiemTraMaGV(Convert.ToInt32(txtMaGV.Text)))
				{
					MessageBox.Show("Giảng viên bị trùng mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}


				else
				{
					GiangVienDTO gvDTO = new GiangVienDTO(Convert.ToInt32(gvBUS.AddMaGV()), txtTenGV.Text, txtSdt.Text, cbbTrinhDo.SelectedItem.ToString(), cbbChuyenMon.SelectedItem.ToString(), Convert.ToInt32(cbbMaLuong.SelectedItem));
					MessageBox.Show(gvBUS.InsertGV(gvDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					gvLoad();
					RefreshTxt();
					click_Them = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaGV.Enabled = true;
				}
			}

			else if (click_Sua)
			{
				//Kiểm tra thông tin nhập

				if (String.IsNullOrWhiteSpace(txtMaGV.Text)) 
				{
					MessageBox.Show("Không được để trống Mã giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (gvBUS.KiemTraMaGV(Convert.ToInt32(txtMaGV.Text)))
				{
					MessageBox.Show("Mã giảng viên cần sửa không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(txtTenGV.Text))
				{
					MessageBox.Show("Không được để trống Tên giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbTrinhDo.Text.Trim()))
				{
					MessageBox.Show("Không được để trống trình độ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbChuyenMon.Text.Trim()))
				{
					MessageBox.Show("Không được để trống chuyên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (String.IsNullOrWhiteSpace(cbbMaLuong.Text.Trim()))
				{
					MessageBox.Show("Không được để trống Mã lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else if (String.IsNullOrWhiteSpace(txtSdt.Text))
				{
					MessageBox.Show("Không được để trống Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// Kiemtra sdt
				else if (!KiemTraSDT(txtSdt.Text))
				{
					MessageBox.Show("Số điện thoại đã nhập không hợp lệ(trùng hoặc không tồn tại)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					GiangVienDTO gvDTO = new GiangVienDTO(Convert.ToInt32(txtMaGV.Text), txtTenGV.Text, txtSdt.Text, cbbTrinhDo.SelectedItem.ToString(), cbbChuyenMon.SelectedItem.ToString(), Convert.ToInt32(cbbMaLuong.SelectedItem));
					MessageBox.Show(gvBUS.UpdateGV(gvDTO), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					gvLoad();
					RefreshTxt();
					click_Sua = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaGV.Enabled = true;
				}
			}

			else if (click_Xoa)
			{
				if (String.IsNullOrWhiteSpace(txtMaGV.Text))
				{
					MessageBox.Show("Không được để trống Mã giảng viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else if (gvBUS.KiemTraMaGV(Convert.ToInt32(txtMaGV.Text)))
				{
					MessageBox.Show("Không tìm thấy mã giảng viên phải xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				else
				{
					MessageBox.Show(gvBUS.DeleteGV(Convert.ToInt32(txtMaGV.Text)), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					gvLoad();
					RefreshTxt();
					click_Xoa = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
					txtMaGV.Enabled = true;
					txtTenGV.Enabled = true;
					txtSdt.Enabled = true;
					cbbTrinhDo.Enabled = true;
					cbbChuyenMon.Enabled = true;
					cbbMaLuong.Enabled = true;
				}

			}
		}
		

		private void btnLoadList_Click(object sender, EventArgs e)
		{
			gvLoad();
		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
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

				txtMaGV.Enabled = true;
				txtTenGV.Enabled = true;
				txtSdt.Enabled = true;
				cbbTrinhDo.Enabled = true;
				cbbChuyenMon.Enabled = true;
				cbbMaLuong.Enabled = true;

			}

			else if (click_Sua)
			{
				click_Sua = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaGV.Enabled = true;
				txtTenGV.Enabled = true;
				txtSdt.Enabled = true;
				cbbTrinhDo.Enabled = true;
				cbbChuyenMon.Enabled = true;
				cbbMaLuong.Enabled = true;
			}

			else if (click_Xoa)
			{
				click_Xoa = false;
				btnHuy.Enabled = false;
				btnXacNhan.Enabled = false;

				btnThem.Enabled = true;
				btnSua.Enabled = true;
				btnXoa.Enabled = true;

				txtMaGV.Enabled = true;
				txtTenGV.Enabled = true;
				txtSdt.Enabled = true;
				cbbTrinhDo.Enabled = true;
				cbbChuyenMon.Enabled = true;
				cbbMaLuong.Enabled = true;
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

			txtMaGV.Enabled = true;
			txtTenGV.Enabled = false;
			txtSdt.Enabled = false;
			cbbTrinhDo.Enabled = false;
			cbbChuyenMon.Enabled = false;
			cbbMaLuong.Enabled = false;
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			click_Sua = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaGV.Enabled = true;
			txtTenGV.Enabled = true;
			txtSdt.Enabled = true;
			cbbTrinhDo.Enabled = true;
			cbbChuyenMon.Enabled = true;
			cbbMaLuong.Enabled = true;
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			int id;
			id = gvBUS.AddMaGV();
			txtMaGV.Text = id.ToString();
			click_Them = true;
			btnHuy.Enabled = true;
			btnXacNhan.Enabled = true;

			btnThem.Enabled = false;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;

			txtMaGV.Enabled = false;
			txtTenGV.Enabled = true;
			txtSdt.Enabled = true;
			cbbTrinhDo.Enabled = true;
			cbbChuyenMon.Enabled = true;
			cbbMaLuong.Enabled = true;
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
			else if (cbbLocTimKiem.SelectedIndex == 0 && !int.TryParse(key, out int kq))
			{
				MessageBox.Show("Thông tin nhập sai dữ liệu (không hợp lệ) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			else
			{
				//maGV {0}
				if (cbbLocTimKiem.SelectedIndex == 0)
				{
					listSearch = gvBUS.TimKiemGV(key, 0);

					if (listSearch.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVgv.DataSource = listSearch;
					}
				}

				//hotenGV {1}
				else if (cbbLocTimKiem.SelectedIndex == 1)
				{
					listSearch = gvBUS.TimKiemGV(key, 1);

					if (listSearch.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVgv.DataSource = listSearch;
					}
				}

				//sdt {2}
				else if (cbbLocTimKiem.SelectedIndex == 2)
				{
					listSearch = gvBUS.TimKiemGV(key, 2);

					if (listSearch.Count < 1)
					{
						MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						dataGVgv.DataSource = listSearch;
					}
				}
			}

		}

		private void dataGVgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i;
			i = dataGVgv.CurrentRow.Index;
			txtMaGV.Text = dataGVgv.Rows[i].Cells[0].Value.ToString();
			txtTenGV.Text = dataGVgv.Rows[i].Cells[1].Value.ToString();
			txtSdt.Text = dataGVgv.Rows[i].Cells[2].Value.ToString();
			cbbTrinhDo.Text = dataGVgv.Rows[i].Cells[3].Value.ToString();
			cbbChuyenMon.Text = dataGVgv.Rows[i].Cells[4].Value.ToString();
			cbbMaLuong.Text = dataGVgv.Rows[i].Cells[5].Value.ToString();

		}
	}
}
