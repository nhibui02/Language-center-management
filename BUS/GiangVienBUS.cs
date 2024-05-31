 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;
using DAO;

namespace BUS
{
	public class GiangVienBUS
	{
		static GiangVienDAO gvDAO;
		static List<GiangVienDTO> gvList;
		public GiangVienBUS()
		{
			gvDAO = new GiangVienDAO();
			gvList = gvDAO.getAll();
		}

		public List<GiangVienDTO> getAll()
		{
			return gvDAO.getAll();
		}


		public int AddMaGV()
		{
			return gvDAO.AutoID();
		}

		public bool KiemTraMaGV(int maGV)
		{
			return gvDAO.KiemTraMaGV(maGV);
		}

		
		public string InsertGV(GiangVienDTO gv)
		{
			gv.MaGV = AddMaGV();
			if (gvDAO.InsertGV(gv))
			{
				gvList = gvDAO.getAll();
				return "Đã thêm thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public string UpdateGV(GiangVienDTO gv)
		{
			if (gvDAO.UpdateGV(gv))
			{
				gvList = gvDAO.getAll();
				return "Đã sửa thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public string DeleteGV(int maGV)
		{
			if (gvDAO.DeleteGV(maGV))
			{
				gvList = gvDAO.getAll();
				return "Đã xóa thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public List<GiangVienDTO> TimKiemGV(string key, int filter)
		{
			List<GiangVienDTO> list = new List<GiangVienDTO>();
			//{maGV; hoTen; soDienThoai} {0;1;2;}

			if (filter == 0)
			{
				foreach (GiangVienDTO gv in gvList)
				{
					if (gv.MaGV == Convert.ToInt32(key))
					{
						list.Add(gv);
					}
				}
			}
			else if (filter == 1)
			{
				foreach (GiangVienDTO gv in gvList)
				{
					//Kiểm tra key tồn tại trong cột họ tên gv
					if (gv.HoTen.ToLower().Contains(key.ToLower()))
					{
						list.Add(gv);
					}
				}
			}

			else if (filter == 2)
			{
				foreach (GiangVienDTO gv in gvList)
				{
					//Kiểm tra key tồn tại trong cột sdt gv
					if (gv.SoDienThoai.Contains(key))
					{
						list.Add(gv);
					}
				}
			}

			return list;
		}
	}
}


