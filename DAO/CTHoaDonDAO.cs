using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSharp_LanguageCentre.DTO;
using DTO;
namespace DAO
{
    public class CTHoaDonDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public CTHoaDonDAO()
        {

        }

        public List<CTHoaDonDTO> getAll()
        {
            List<CTHoaDonDTO> list = new List<CTHoaDonDTO>();
            string sql = "SELECT * FROM chi_tiet_hoa_don WHERE ma_hd !=0";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            CTHoaDonDTO cthd;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cthd = new CTHoaDonDTO();
                cthd.MaHD = (int)dataTable.Rows[i]["ma_hd"];
                cthd.MaKH = (int)dataTable.Rows[i]["ma_kh"];
                cthd.Gia = (int)dataTable.Rows[i]["gia"];
                list.Add(cthd);
            }
            return list;
        }

        public bool Insert(CTHoaDonDTO cthd, int nhomKH, int maHV)
        {
            string sql = "SELECT * FROM chi_tiet_hoa_don";
            dataTable = dataServices.RunQuery(sql);
            DataRow row = dataTable.NewRow();
            row["ma_hd"] = cthd.MaHD;
            row["ma_kh"] = cthd.MaKH;
            row["gia"] = cthd.Gia;
            dataTable.Rows.Add(row);
            dataServices.Update(dataTable);
            sql = $"INSERT INTO dang_ky_khoa_hoc(ma_kh,nhom_kh,ma_hv) Values({cthd.MaKH},{nhomKH},{maHV})";
            dataServices.ExecuteNonQuery(sql);
            return true;
        }

        public bool Delete(int maHD)
        {
            try
            {
                string sql = $"DELETE FROM chi_tiet_hoa_don WHERE ma_hd = {maHD}";
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(CTHoaDonDTO cthd)
        {
            string sql = "SELECT * FROM chi_tiet_hoa_don";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_hd"] };
            DataRow row = dataTable.Rows.Find(cthd.MaHD);
            row["ma_hd"] = cthd.MaHD;
            row["ma_kh"] = cthd.MaKH;
            row["gia"] = cthd.Gia;
            dataServices.Update(dataTable);
            return true;
        }
        public int GetFee(int maKH)
        {
            string sql = $"SELECT gia FROM khoa_hoc Where ma_kh = {maKH}";
            dataTable = dataServices.RunQuery(sql);
            int fee = (int)dataTable.Rows[0]["gia"];
            return fee;
        }
        public int NextID()
        {
            string sql = "SELECT MAX(ma_hd) as 'max' FROM hoa_don";
            dataTable = dataServices.RunQuery(sql);
            int num = -1;
            if (!int.TryParse(dataTable.Rows[0]["max"].ToString(), out num)) return 1;
            int curId = (int)dataTable.Rows[0]["max"];
            return curId + 1;
        }

    }

}
