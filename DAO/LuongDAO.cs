using CSharp_LanguageCentre.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class LuongDAO
	{

		DataServices dataServices = new DataServices();
		DataTable dataTable;
		public LuongDAO()
		{

		}

		public List<LuongDTO> GetAll()
		{
			List<LuongDTO> list = new List<LuongDTO>();
			string query = "select * from luong";
			if (!dataServices.OpenDB()) return null;
			dataTable = dataServices.RunQuery(query);
			LuongDTO luong;

			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				luong = new LuongDTO();
				luong.MaLuong = (int)dataTable.Rows[i]["ma_luong"];
				luong.LoaiLuong = dataTable.Rows[i]["loai_luong"].ToString();
				luong.MucLuong = (int)dataTable.Rows[i]["muc_luong"];
				list.Add(luong);
			}
			return list;
		}

		public bool KiemTraMaLuong(int maLuong)
		{
			string query = $"select * from luong where ma_luong = {maLuong}";
			dataTable = dataServices.RunQuery(query);
			if (dataTable.Rows.Count > 0) return false;
			return true;
		}


		public int AutoID()
		{
			int id ;
			string queryNV = "select max(ma_luong) as max_maluong from luong";
			dataTable = dataServices.RunQuery(queryNV);
			int num = -1;
			if (!int.TryParse(dataTable.Rows[0]["max_maluong"].ToString(), out num)) return 1;
			id = (int)dataTable.Rows[0]["max_maluong"];
			return id + 1;

		}

		public bool InsertLuong(LuongDTO luong)
		{
			string query = "select * from luong";
			dataTable = dataServices.RunQuery(query);
			DataRow new_row = dataTable.NewRow();
			new_row["ma_luong"] = luong.MaLuong;
			new_row["loai_luong"] = luong.LoaiLuong;
			new_row["muc_luong"] = luong.MucLuong;

			dataTable.Rows.Add(new_row);
			dataServices.Update(dataTable);
			return true;

		}

		public bool UpdateLuong(LuongDTO luong)
		{
			string query = "select * from luong";
			dataTable = dataServices.RunQuery(query);
			//Tạo cột khóa chính trong DataTable
			dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_luong"] };
			DataRow new_row = dataTable.Rows.Find(luong.MaLuong);
			new_row["loai_luong"] = luong.LoaiLuong;
			new_row["muc_luong"] = luong.MucLuong;

			//Cập nhật lại dữ liệu lên database
			dataServices.Update(dataTable);
			return true;
		}

		public bool DeleteLuong(int maLuong)
		{
			string query = "select * from luong";
			dataTable = dataServices.RunQuery(query);
			dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_luong"] };
			dataTable.Rows.Find(maLuong).Delete();
			dataServices.Update(dataTable);
			return true;
		}
	}
}
