using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;

namespace DAO
{
	public class GiangVienDAO
	{
		DataServices dataServices = new DataServices();
		DataTable dataTable; 
		public GiangVienDAO()
		{
		}

		public List<GiangVienDTO> getAll()
		{
			List<GiangVienDTO> list = new List<GiangVienDTO>();
			string query = "select * from giang_vien where ma_gv !=0";
			//Hàm kết nối đến database nếu thất bại false thì trả về null
			if (!dataServices.OpenDB()) 
				return null;
			//Hàm thực thi câu lệnh query truyền vào, kết quả thành công là dataTable
			else dataTable = dataServices.RunQuery(query);
			GiangVienDTO gv;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				gv = new GiangVienDTO();
				gv.MaGV = (int)dataTable.Rows[i]["ma_gv"];
				gv.HoTen = dataTable.Rows[i]["ho_ten"].ToString();
				gv.SoDienThoai = dataTable.Rows[i]["sdt"].ToString();
				gv.TrinhDo = dataTable.Rows[i]["trinh_do"].ToString();
				gv.ChuyenMon = dataTable.Rows[i]["chuyen_mon"].ToString();
				gv.MaLuong = (int)dataTable.Rows[i]["ma_luong"];

				list.Add(gv);

			}
			return list;
		}

		public bool KiemTraMaGV(int maGV)
		{
			string query = $"select * from giang_vien where ma_gv = {maGV}";
			dataTable = dataServices.RunQuery(query);
			if (dataTable.Rows.Count > 0) return false;
			return true;
		}


		public int AutoID()
		{
			int id;
			string querygv = "select max(ma_gv) as max_magv from giang_vien";
			dataTable = dataServices.RunQuery(querygv);
			int num = -1;
			if (!int.TryParse(dataTable.Rows[0]["max_magv"].ToString(), out num)) return 1;
			id = (int)dataTable.Rows[0]["max_magv"];
			return id + 1;

		}
		public bool DeleteGV(int maGV)
		{
			string queryTKB = $"update thoi_khoa_bieu set ma_gv = 0 where ma_gv = {maGV}";
			dataTable = dataServices.RunQuery(queryTKB);
			string query = "select * from giang_vien";
			dataTable = dataServices.RunQuery(query);
			dataTable.PrimaryKey = new DataColumn[] {dataTable.Columns["ma_gv"]};
			dataTable.Rows.Find(maGV).Delete();
			dataServices.Update(dataTable);
			return true;

		}

		public bool InsertGV(GiangVienDTO gv)
		{
			string query = "select * from giang_vien";
			dataTable = dataServices.RunQuery(query);
			DataRow new_row = dataTable.NewRow();
			new_row["ma_gv"] = gv.MaGV;
			new_row["ho_ten"] = gv.HoTen;
			new_row["sdt"] = gv.SoDienThoai;
			new_row["trinh_do"] = gv.TrinhDo;
			new_row["chuyen_mon"] = gv.ChuyenMon;
			new_row["ma_luong"] = gv.MaLuong;
			
			dataTable.Rows.Add(new_row);
			dataServices.Update(dataTable);
			return true;

		}

		public bool UpdateGV(GiangVienDTO gv)
		{
			string query = "select * from giang_vien";
			dataTable = dataServices.RunQuery(query);
			//Tạo cột khóa chính trong DataTable
			dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_gv"] };
			DataRow new_row = dataTable.Rows.Find(gv.MaGV);
			new_row["ho_ten"] = gv.HoTen;
			new_row["sdt"] = gv.SoDienThoai;
			new_row["trinh_do"] = gv.TrinhDo;
			new_row["chuyen_mon"] = gv.ChuyenMon;
			new_row["ma_luong"] = gv.MaLuong;

			//Cập nhật lại dữ liệu lên database
			dataServices.Update(dataTable);
			return true;
		}

	}
}
