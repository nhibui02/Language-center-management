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
	public partial class ThongKe : UserControl
	{
		ThongKeBUS thongKeBUS = new ThongKeBUS();
		List<HoaDonDTO> hoaDonList = new List<HoaDonDTO>();
		List<KhoaHocDTO> khoaHocList = new List<KhoaHocDTO>();
		List<ThongKeDTO> thongKeList = new List<ThongKeDTO>();
		public ThongKe()
		{
			InitializeComponent();
		}

		private void ThongKe_Load(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void btnQuayLai_Click(object sender, EventArgs e)
		{
			Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
		}


		private void btnThongKe_Click_1(object sender, EventArgs e)
		{
			if (cbbLocTimKiem.SelectedIndex == 0)
			{
				hoaDonList = thongKeBUS.getHoaDon(dateTimePicker1.Value);

				if (hoaDonList.Count < 1)
				{
					MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					lblDoanhThu.Visible = true;
					txtDoanhThu.Visible = true;
					lblSoLuong.Visible = false;
					lblSoLuongHD.Visible = true;
					lblSoLuongHV.Visible = false;
					lblChuaThu.Visible = true;
					txtChuaThu.Visible = true;

					dataGVTK.DataSource = hoaDonList;
					txtSoLuong.Text = thongKeBUS.SoHD().ToString();
					txtDoanhThu.Text = thongKeBUS.DoanhThuHD().ToString();
					txtChuaThu.Text = thongKeBUS.HD_ChuaThanhToan().ToString();
				}
			}
			else if (cbbLocTimKiem.SelectedIndex == 1)
			{
				khoaHocList = thongKeBUS.getKhoaHoc(dateTimePicker1.Value);

				if (khoaHocList.Count < 1)
				{
					MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					lblDoanhThu.Visible = false;
					txtDoanhThu.Visible = false;
					lblSoLuong.Visible = true;
					lblSoLuongHD.Visible = false;
					lblSoLuongHV.Visible = false;
					lblChuaThu.Visible = false;
					txtChuaThu.Visible = false;


					dataGVTK.DataSource = khoaHocList;
					txtSoLuong.Text = thongKeBUS.SoKH().ToString();

				}
			}

			else if (cbbLocTimKiem.SelectedIndex == 2)
			{
				thongKeList = thongKeBUS.getHocVien(dateTimePicker1.Value);

				if (thongKeList.Count < 1)
				{
					MessageBox.Show("Không tìm thấy kết quả tìm kiếm hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					lblDoanhThu.Visible = true;
					txtDoanhThu.Visible = true;
					lblSoLuong.Visible = false;
					lblSoLuongHD.Visible = false;
					lblSoLuongHV.Visible = true;
					lblChuaThu.Visible = false;
					txtChuaThu.Visible = false;


					dataGVTK.DataSource = thongKeList;
					txtSoLuong.Text = thongKeBUS.SoHV(dateTimePicker1.Value).ToString();
					txtDoanhThu.Text = thongKeBUS.DoanhThuHV().ToString();

				}

			}
		}
	}
}
