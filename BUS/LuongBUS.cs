using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class LuongBUS
	{
		static LuongDAO luongDAO;
		static List<LuongDTO> luongList;

		public LuongBUS()
		{
			luongDAO = new LuongDAO();
			luongList = luongDAO.GetAll();
		}

		public List<LuongDTO> GetAll()
		{
			return luongDAO.GetAll();
		}

		public bool KiemTraMaLuong(int maLuong)
		{
			return luongDAO.KiemTraMaLuong(maLuong);
		}

		public int AutoID() 
		{ 
			return luongDAO.AutoID(); 
		}


		public string InsertLuong(LuongDTO luong)
		{
			luong.MaLuong = AutoID();
			if (luongDAO.InsertLuong(luong))
			{
				luongList = luongDAO.GetAll();
				return "Thêm lương mới thành công";
			}
			return "Đã xảy ra lỗi!";
		}

		public string UpdateLuong(LuongDTO luong)
		{
			if (luongDAO.UpdateLuong(luong))
			{
				luongList = luongDAO.GetAll();
				return "Cập nhật lương thành công";
			}
			return "Đã xảy ra lỗi!";
		}

		public string DeleteLuong(int maLuong)
		{
			if (luongDAO.DeleteLuong(maLuong))
			{
				luongList = luongDAO.GetAll();
				return "Xóa lương thành công";
			}
			return "Đã xảy ra lỗi";
		}
	}
}
