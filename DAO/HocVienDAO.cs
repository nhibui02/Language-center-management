using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;

namespace DAO
{
    public class HocVienDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public HocVienDAO()
        {

        }

        public List<HocVienDTO> getAll()
        {
            List<HocVienDTO> list = new List<HocVienDTO>();
            string sql = "SELECT * FROM hoc_vien WHERE ma_hv != 0";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            HocVienDTO hocVien;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                hocVien = new HocVienDTO();
                hocVien.MaHV = (int)dataTable.Rows[i]["ma_hv"];
                hocVien.HoTen = dataTable.Rows[i]["ho_ten"].ToString();
                hocVien.SoDienThoai = dataTable.Rows[i]["sdt"].ToString();
                hocVien.TrinhDo = dataTable.Rows[i]["trinh_do"].ToString();
                list.Add(hocVien);
            }

            return list;
        }

        public bool Insert(HocVienDTO hocVien)
        {
            string sql = "SELECT * FROM hoc_vien";
            dataTable = dataServices.RunQuery(sql);
            DataRow row = dataTable.NewRow();
            row["ma_hv"] = hocVien.MaHV;
            row["ho_ten"] = hocVien.HoTen;
            row["sdt"] = hocVien.SoDienThoai;
            row["trinh_do"] = hocVien.TrinhDo;
            dataTable.Rows.Add(row);
            dataServices.Update(dataTable);
            return true;

        }

        public bool Delete(int maHV)
        {
            try
            {
                string sql = $"DELETE FROM dang_ky_khoa_hoc WHERE ma_hv = {maHV}";
                dataServices.ExecuteNonQuery(sql);
                sql = $"UPDATE hoa_don WHERE ma_hv = {maHV} SET ma_hv = 0";
                dataServices.ExecuteNonQuery(sql);
                sql = $"DELETE FROM hoc_vien WHERE ma_hv = {maHV}";
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(HocVienDTO hocVien)
        {
            string sql = "SELECT * FROM hoc_vien";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_hv"] };
            DataRow row = dataTable.Rows.Find(hocVien.MaHV);
            row["ho_ten"] = hocVien.HoTen;
            row["sdt"] = hocVien.SoDienThoai;
            row["trinh_do"] = hocVien.TrinhDo;
            dataServices.Update(dataTable);
            return true;
        }

        public bool TrungMa(int maHV)
        {
            string sql = $"SELECT * FROM hoc_vien WHERE ma_hv = {maHV}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }

        public int NextID()
        {
            string sql = "SELECT MAX(ma_hv) as 'max' FROM hoc_vien";
            dataTable = dataServices.RunQuery(sql);
            int num = -1;
            if (!int.TryParse(dataTable.Rows[0]["max"].ToString(), out num)) return 1;
            int curId = (int)dataTable.Rows[0]["max"];
            return curId + 1;
        }
    }
}
