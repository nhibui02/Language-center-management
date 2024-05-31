using CSharp_LanguageCentre.DTO;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class ThongKeBUS
	{
		static ThongKeDAO thongKeDAO;
		static List<HoaDonDTO> hdList;
		static List<KhoaHocDTO> khList;
		static List<ThongKeDTO> tkList;

		public ThongKeBUS()
		{
			thongKeDAO = new ThongKeDAO();
		}


		public List<HoaDonDTO> getHoaDon(DateTime ngayTK)
		{
			hdList = thongKeDAO.GetHoaDon(ngayTK);
			return hdList;
		}

		public List<KhoaHocDTO> getKhoaHoc(DateTime ngayTK)
		{
			khList = thongKeDAO.GetKhoaHoc(ngayTK);
			return khList;
		}

		public List<ThongKeDTO> getHocVien(DateTime ngayTK)
		{
			tkList = thongKeDAO.getHocVienTK(ngayTK);
			return tkList;

		}

		public int SoHD()
		{
			return hdList.Count; 
		}

		public  int SoKH()
		{
			return khList.Count; 
		}

		public int SoHV(DateTime ngayTK)
		{
			return thongKeDAO.getSoHocVien(ngayTK);
		}

		public int DoanhThuHD()
		{
			int tongTien = 0;
			foreach (HoaDonDTO hd in hdList)
			{
				tongTien = tongTien + hd.HocPhi;
			}
			return tongTien;
		}

		public int HD_ChuaThanhToan()
		{
			int tongTien = 0;
			foreach (HoaDonDTO hd in hdList)
			{
				if (!hd.TinhTrangThanhToan) tongTien = tongTien + hd.HocPhi;
				else tongTien = tongTien + 0;
			}
			return tongTien;
		}

		public int DoanhThuHV()
		{
			int tongTien = 0;
			foreach (ThongKeDTO tk in tkList)
			{
				tongTien += tk.Gia;
			}
			return tongTien;
		}


		
	}
}
