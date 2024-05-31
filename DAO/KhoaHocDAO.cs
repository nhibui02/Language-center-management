using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_LanguageCentre.DTO;

namespace DAO
{
    public class KhoaHocDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public KhoaHocDAO()
        {

        }
        
        public List<KhoaHocDTO> getAll()
        {
            List<KhoaHocDTO> list = new List<KhoaHocDTO>();
            string sql = "SELECT * FROM khoa_hoc WHERE ma_kh !=0";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            KhoaHocDTO khoaHoc;

            for(int i = 0; i<dataTable.Rows.Count; i++)
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

        public bool Insert(KhoaHocDTO khoaHoc)
        {
            string sql = "SELECT * FROM khoa_hoc";
            dataTable = dataServices.RunQuery(sql);
            DataRow row = dataTable.NewRow();
            row["ma_kh"] = khoaHoc.MaKH;
            row["ten_kh"] = khoaHoc.TenKH;
            row["gia"] = khoaHoc.Gia;
            row["cap_bac"] = khoaHoc.CapBac;
            row["ngay_bat_dau"] = khoaHoc.NgayBD;
            row["ngay_ket_thuc"] = khoaHoc.NgayKT;
            dataTable.Rows.Add(row);
            dataServices.Update(dataTable);
            return true;
        }

        public bool Delete(int maKH)
        {
            try
            {
                string sql = $"DELETE FROM thoi_khoa_bieu WHERE ma_kh = {maKH}";
                dataServices.ExecuteNonQuery(sql);
                sql = $"DELETE FROM dang_ky_khoa_hoc WHERE ma_kh = {maKH}";
                dataServices.ExecuteNonQuery(sql);
                sql = $"UPDATE FROM chi_tiet_hoa_don WHERE ma_kh = {maKH} SET ma_kh=0";
                dataServices.ExecuteNonQuery(sql);
                sql = $"DELETE FROM khoa_hoc WHERE ma_kh = {maKH}";
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(KhoaHocDTO khoaHoc)
        {
            string sql = "SELECT * FROM khoa_hoc";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_kh"] };
            DataRow row = dataTable.Rows.Find(khoaHoc.MaKH);
            row["ma_kh"] = khoaHoc.MaKH;
            row["ten_kh"] = khoaHoc.TenKH;
            row["gia"] = khoaHoc.Gia;
            row["cap_bac"] = khoaHoc.CapBac;
            row["ngay_bat_dau"] = khoaHoc.NgayBD;
            row["ngay_ket_thuc"] = khoaHoc.NgayKT;
            dataServices.Update(dataTable);
            return true;
        }

        public bool TrungMa(int maKH)
        {
            string sql = $"SELECT * FROM khoa_hoc WHERE ma_kh = {maKH}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }

        public int NextID()
        {
            string sql = "SELECT MAX(ma_kh) as 'max' FROM khoa_hoc";
            dataTable = dataServices.RunQuery(sql);
            int num = -1;
            if (!int.TryParse(dataTable.Rows[0]["max"].ToString(), out num)) return 1;
            int curId = (int)dataTable.Rows[0]["max"];
            return curId + 1;
        }
    }
}
