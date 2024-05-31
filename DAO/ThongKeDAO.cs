using CSharp_LanguageCentre.DTO;
using System;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class ThongKeDAO
	{
		DataServices dataServices;
		DataTable dataTable;

		public ThongKeDAO()
		{
			dataServices = new DataServices();
		}

		public List<HoaDonDTO> GetHoaDon(DateTime ngayTK)
		{
			List<HoaDonDTO> list = new List<HoaDonDTO>();
			int thang = ngayTK.Month;
			int nam = ngayTK.Year;
			string sql = $"SELECT * FROM hoa_don where month(ngay) = '{thang}' and year(ngay) = '{nam}'";
			if (!dataServices.OpenDB()) return null;
			dataTable = dataServices.RunQuery(sql);
			HoaDonDTO hoadon;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				hoadon = new HoaDonDTO();
				hoadon.MaHD = (int)dataTable.Rows[i]["ma_hd"];
				hoadon.NgayHD = (DateTime)dataTable.Rows[i]["ngay"];
				hoadon.HocPhi = (int)dataTable.Rows[i]["hoc_phi"];
				hoadon.TinhTrangThanhToan = Convert.ToBoolean(dataTable.Rows[i]["tinh_trang_thanh_toan"]); 
				hoadon.MaHV = (int)dataTable.Rows[i]["ma_hv"];
				list.Add(hoadon);
			}

			return list;
		}

		public List<KhoaHocDTO> GetKhoaHoc(DateTime ngayTK)
		{
			int thang = ngayTK.Month;
			int nam = ngayTK.Year;
			List<KhoaHocDTO> list = new List<KhoaHocDTO>();
			string sql = $"SELECT * FROM khoa_hoc WHERE ma_kh !=0 and month(ngay_bat_dau) = '{thang}' and year(ngay_bat_dau) = '{nam}'";
			if (!dataServices.OpenDB()) return null;
			dataTable = dataServices.RunQuery(sql);
			KhoaHocDTO khoaHoc;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				khoaHoc = new KhoaHocDTO();
				khoaHoc.MaKH = (int)dataTable.Rows[i]["ma_kh"];
				khoaHoc.TenKH = dataTable.Rows[i]["ten_kh"].ToString();
				khoaHoc.Gia = (int)dataTable.Rows[i]["gia"];
				khoaHoc.CapBac = dataTable.Rows[i]["cap_bac"].ToString();
				khoaHoc.NgayBD = (DateTime)dataTable.Rows[i]["ngay_bat_dau"];
				khoaHoc.NgayKT = (DateTime)dataTable.Rows[i]["ngay_ket_thuc"];
				list.Add(khoaHoc);
			}
			return list;
		}

		public List<ThongKeDTO> getHocVienTK(DateTime ngayTK)
		{
			int thang = ngayTK.Month;
			int nam = ngayTK.Year;
			List<ThongKeDTO> list = new List<ThongKeDTO>();
			string sql = $"SELECT hv.ma_hv, hv.ho_ten, kh.ma_kh, kh.ngay_bat_dau, cthd.gia FROM hoc_vien hv, khoa_hoc kh, hoa_don hd, chi_tiet_hoa_don cthd WHERE kh.ma_kh = cthd.ma_kh AND cthd.ma_hd = hd.ma_hd AND hd.ma_hv != 0 AND hd.ma_hv = hv.ma_hv AND month(kh.ngay_bat_dau) = '{thang}' AND year(kh.ngay_bat_dau) = '{nam}'";
			if (!dataServices.OpenDB()) return null;
			dataTable = dataServices.RunQuery(sql);
			ThongKeDTO hocvienTK;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				hocvienTK = new ThongKeDTO();
				hocvienTK.MaHV = (int)dataTable.Rows[i]["ma_hv"];
				hocvienTK.HoTen = dataTable.Rows[i]["ho_ten"].ToString();
				hocvienTK.MaKH = (int)dataTable.Rows[i]["ma_kh"];
				hocvienTK.NgayBD = (DateTime)dataTable.Rows[i]["ngay_bat_dau"];
				hocvienTK.Gia = (int)dataTable.Rows[i]["gia"];
				list.Add(hocvienTK);
			}

			return list;
		}

		public int getSoHocVien(DateTime ngayTK)
		{
			int thang = ngayTK.Month;
			int nam = ngayTK.Year;
			string sql = $"SELECT count(distinct hv.ma_hv) count_hv FROM hoc_vien hv, khoa_hoc kh, hoa_don hd, chi_tiet_hoa_don cthd WHERE kh.ma_kh = cthd.ma_kh AND cthd.ma_hd = hd.ma_hd AND hd.ma_hv != 0 AND hd.ma_hv = hv.ma_hv AND month(kh.ngay_bat_dau) = '{thang}' AND year(kh.ngay_bat_dau) = '{nam}'";
			dataTable = dataServices.RunQuery(sql);
			if (dataTable.Rows.Count == 0) return 0;
			else 
			{ 
				return Convert.ToInt32(dataTable.Rows[0]["count_hv"]); 
			}
			
		}

		
	}
}
