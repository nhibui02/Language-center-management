using CSharp_LanguageCentre.DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class PhongHocBUS
	{
		static PhongHocDAO phDAO;
		static List<PhongHocDTO> phList;

		public PhongHocBUS()
		{
			phDAO = new PhongHocDAO();
			phList = phDAO.getAll();
		}

		public List<PhongHocDTO> getAll()
		{
			return phDAO.getAll();
		}

		public int AddMaPH()
		{
			return phDAO.AutoID();
		}

		public bool KiemTraMaPH(int maPH)
		{
			return phDAO.KiemTraMaPH(maPH);
		}

		public string InsertPH(PhongHocDTO ph)
		{
			ph.MaPH = AddMaPH();
			if (phDAO.InsertPH(ph))
			{
				phList = phDAO.getAll();
				return "Đã thêm thành công !";
			}
			return "Đã xảy ra lỗi !";
		}

		public string UpdatePH(PhongHocDTO ph)
		{
			if (phDAO.UpdatePH(ph))
			{
				phList = phDAO.getAll();
				return "Đã sửa thành công !";
			}
			return "Đã xảy ra lỗi !";

		}

		public string DeletePH(int maPH)
		{
			if (phDAO.DeletePH(maPH))
			{
				phList = phDAO.getAll();
				return "Đã xóa thành công !";
			}
			return "Đã xảy ra lỗi !";

		}

		public List<PhongHocDTO> TimKiemPH(string key)
		{
			List<PhongHocDTO> list = new List<PhongHocDTO>();
			foreach (PhongHocDTO ph in phList)
			{
				if (ph.MaPH == Convert.ToInt32(key))
				{
					list.Add(ph);
				}
			}
			return list;
		}
	}

}
