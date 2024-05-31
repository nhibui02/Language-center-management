using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;
using DAO;

namespace BUS
{
	public class StaffBUS
	{
		static StaffDAO staffDAO;
		static List<StaffDTO> staffList;

		public StaffBUS()
		{
			staffDAO = new StaffDAO();
			staffList = staffDAO.getAll();
		}

		public List<StaffDTO> getAll()
		{
			return staffDAO.getAll();
		}

		public string InsertNV(StaffDTO staff)
		{
			staff.MaNV = AddMaNV();
			if (staffDAO.InsertNV(staff))
			{
				//Thêm nhân viên vào bảng dữ liệu
				staffList = staffDAO.getAll();
				return "Đã thêm thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		// mã nhân viên kế tiếp = maNV trước +1
		public int AddMaNV()
		{
			return staffDAO.AutoID();
		}

		public string UpdateNV(StaffDTO staff)
		{
			if (staffDAO.UpdateNV(staff))
			{
				staffList = staffDAO.getAll();
				return "Đã sửa thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public bool KiemTraMaNV(int maNV)
		{
			return staffDAO.KiemTraMaNV(maNV); 
		}

		public bool KiemTraTenTK(string tenTK, int maNV)
		{
			return staffDAO.KiemTraTenTK(tenTK, maNV);
		}

		public bool KiemTraTenTK_Add(string tenTK)
		{
			return staffDAO.KiemTraTenTK_AddNV(tenTK);
		}

		public string DeleteNV(int maNV)
		{
			if (staffDAO.DeleteNV(maNV))
			{
				staffList = staffDAO.getAll();
				return "Đã xóa thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public List<StaffDTO> TimKiemNV(string key, int filter)
		{
			List<StaffDTO> list = new List<StaffDTO>();
			//{maNV; hoTen; soDienThoai; maLuong; tenTK} {0;1;2;3;4}

			if (filter == 0)
			{
				foreach (StaffDTO staff in staffList)
				{
					if (staff.MaNV == Convert.ToInt32(key))
					{
						list.Add(staff);
					}
				}
			}
			else if (filter == 1)
			{
				foreach (StaffDTO staff in staffList)
				{
					//Kiểm tra key tồn tại trong cột họ tên nv
					if (staff.HoTen.ToLower().Contains(key.ToLower()))
					{
						list.Add(staff);
					}
				}
			}

			else if (filter == 2)
			{
				foreach (StaffDTO staff in staffList)
				{
					//Kiểm tra key tồn tại trong cột sdt nv
					if (staff.SoDienThoai.Contains(key))
					{
						list.Add(staff);
					}
				}
			}

			else if (filter == 3)
			{
				foreach (StaffDTO staff in staffList)
				{
					//Kiểm tra key tồn tại trong cột MaLuong nv
					if (staff.MaLuong == Convert.ToInt32(key))
					{
						list.Add(staff);
					}
				}
			}


			else if (filter == 4)
			{
				foreach (StaffDTO staff in staffList)
				{
					//Kiểm tra key có tồn tại trong tên tk không
					if (staff.TenTK.ToLower().Contains(key.ToLower()))
					{
						list.Add(staff);
					}
				}
			}

			return list;
		}


	}
}
