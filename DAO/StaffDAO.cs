using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;

namespace DAO
{
	public class StaffDAO
	{
		DataServices dataServices = new DataServices();
		DataTable dataTable;

		public StaffDAO()
		{ }

		public List<StaffDTO> getAll()
		{
			List<StaffDTO> list = new List<StaffDTO>();
			string query = "select * from nhan_vien_quan_ly where ma_nv !=0";
			//Hàm kết nối đến database nếu thất bại false thì trả về null
			if (!dataServices.OpenDB())
				return null;
			//Hàm thực thi câu lệnh query truyền vào, kết quả thành công là dataTable
			else dataTable = dataServices.RunQuery(query);
			StaffDTO staff;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				staff = new StaffDTO();
				staff.MaNV = (int)dataTable.Rows[i]["ma_nv"];
				staff.HoTen = dataTable.Rows[i]["ho_ten"].ToString();
				staff.SoDienThoai = dataTable.Rows[i]["sdt"].ToString();
				staff.MaLuong = (int)dataTable.Rows[i]["ma_luong"];
				staff.TenTK = dataTable.Rows[i]["ten_tk"].ToString();
				list.Add(staff);

			}
			return list;
		}


		public bool KiemTraMaNV(int maNV)
		{
			string query = $"select * from nhan_vien_quan_ly where ma_nv = {maNV}";
			dataTable = dataServices.RunQuery(query);
			if (dataTable.Rows.Count > 0) return false;
			return true;
		}


		//kiem tra tenTK da duoc su dung va co ton tai khong
		public bool KiemTraTenTK(string tenTK, int maNV)
		{
			string queryTK = $"select * from tai_khoan where ten_tk = '{tenTK}'";
			dataTable = dataServices.RunQuery(queryTK);
			if (dataTable.Rows.Count > 0)
			{
				string queryNV = $"select * from nhan_vien_quan_ly where ten_tk = '{tenTK}' and ma_nv = {maNV}";
				dataTable = dataServices.RunQuery(queryNV);
				if (dataTable.Rows.Count > 0) return true;
				return false;
			}
			return false;
		}

		public bool KiemTraTenTK_AddNV(string tenTK)
		{
			string queryTK = $"select * from tai_khoan where ten_tk = '{tenTK}'";
			dataTable = dataServices.RunQuery(queryTK);
			if (dataTable.Rows.Count > 0)
			{
				string queryNV = $"select * from nhan_vien_quan_ly where ten_tk = '{tenTK}'";
				dataTable = dataServices.RunQuery(queryNV);
				if (dataTable.Rows.Count == 0) return true;
				return false;
			}
			return false;
		}
		public int AutoID()
		{
			int id;
			string queryNV = "select max(ma_nv) as max_manv from nhan_vien_quan_ly";
			dataTable = dataServices.RunQuery(queryNV);
			int num = -1;
			if (!int.TryParse(dataTable.Rows[0]["max_manv"].ToString(), out num)) return 1;
			id = (int)dataTable.Rows[0]["max_manv"];
			return id + 1;

		}

		public bool InsertNV(StaffDTO staff)
		{
			string query = "select * from nhan_vien_quan_ly";
			dataTable = dataServices.RunQuery(query);
			DataRow new_row = dataTable.NewRow();
			new_row["ma_nv"] = staff.MaNV;
			new_row["ho_ten"] = staff.HoTen;
			new_row["sdt"] = staff.SoDienThoai;
			new_row["ma_luong"] = staff.MaLuong;
			new_row["ten_tk"] =staff.TenTK;
			dataTable.Rows.Add(new_row);

			//Cập nhật lại dữ liệu lên database
			dataServices.Update(dataTable);
			return true;

		}

		public bool UpdateNV(StaffDTO staff)
		{
			string query = "select * from nhan_vien_quan_ly";
			dataTable = dataServices.RunQuery(query);
			//Tạo cột khóa chính trong DataTable
			dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_nv"] };
			DataRow new_row = dataTable.Rows.Find(staff.MaNV);
			new_row["ho_ten"] = staff.HoTen;
			new_row["sdt"] = staff.SoDienThoai;
			new_row["ma_luong"] = staff.MaLuong;
			new_row["ten_tk"] = staff.TenTK;

			//Cập nhật lại dữ liệu lên database
			dataServices.Update(dataTable);
			return true;
		}


		public bool DeleteNV(int maNV)
		{
			try
			{
				string query = $"delete from nhan_vien_quan_ly where ma_nv = {maNV}";
				dataServices.ExecuteNonQuery(query);
			}
			catch (Exception ex) { return false; }
			return true;

		}

	}

}

