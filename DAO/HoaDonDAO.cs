using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSharp_LanguageCentre.DTO;
namespace DAO
{
    public class HoaDonDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public HoaDonDAO()
        {

        }

        public List<HoaDonDTO> getAll()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string sql = "SELECT * FROM hoa_don WHERE ma_hd !=0";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            HoaDonDTO hoaDon;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                hoaDon = new HoaDonDTO();
                hoaDon.MaHD = (int)dataTable.Rows[i]["ma_hd"];
                hoaDon.NgayHD = (DateTime)dataTable.Rows[i]["ngay"];
                hoaDon.HocPhi = (int)dataTable.Rows[i]["hoc_phi"];
                hoaDon.TinhTrangThanhToan = Convert.ToBoolean(dataTable.Rows[i]["tinh_trang_thanh_toan"]);
                hoaDon.MaHV = (int)dataTable.Rows[i]["ma_hv"];
                list.Add(hoaDon);
            }
            return list;
        }

        public bool Insert(HoaDonDTO hoaDon)
        {
            string sql = "SELECT * FROM hoa_don";
            dataTable = dataServices.RunQuery(sql);
            DataRow row = dataTable.NewRow();
            row["ma_hd"] = hoaDon.MaHD;
            row["ngay"] = hoaDon.NgayHD;
            row["hoc_phi"] = hoaDon.HocPhi;
            row["tinh_trang_thanh_toan"] = hoaDon.TinhTrangThanhToan;
            row["ma_hv"] = hoaDon.MaHV;
            dataTable.Rows.Add(row);
            dataServices.Update(dataTable);

            
            return true;
        }

        public bool Delete(int maHD, int maHV)
        {
            try
            {
                string sql = $"DELETE FROM thoi_khoa_bieu WHERE ma_hv = {maHV}";
                dataServices.ExecuteNonQuery(sql);
                sql = $"SELECT cthd.ma_kh FROM chi_tiet_hoa_don cthd, hoa_don hd WHERE hd.ma_hv = {maHV} and hd.ma_hd = cthd.ma_hd and hd.ma_hd = {maHD}";
                dataTable = dataServices.RunQuery(sql);
                List<int> makh = new List<int>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    makh.Add((int)dataTable.Rows[i]["ma_kh"]);
                }

                foreach (int makhoahoc in makh)
                {
                    sql = $"DELETE FROM dang_ky_khoa_hoc WHERE ma_kh = {makhoahoc}";
                    dataServices.ExecuteNonQuery(sql);
                }
                
                dataServices.ExecuteNonQuery(sql);
                sql = $"DELETE FROM chi_tiet_hoa_don WHERE ma_hd = {maHD}";
                dataServices.ExecuteNonQuery(sql);
                sql = $"DELETE FROM hoa_don WHERE ma_hd = {maHD}";
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(HoaDonDTO hoaDon)
        {
            string sql = "SELECT * FROM hoa_don";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_hd"] };
            DataRow row = dataTable.Rows.Find(hoaDon.MaHD);
            row["ma_hd"] = hoaDon.MaHD;
            row["ngay"] = hoaDon.NgayHD;
            row["hoc_phi"] = hoaDon.HocPhi;
            row["tinh_trang_thanh_toan"] = hoaDon.TinhTrangThanhToan;
            row["ma_hv"] = hoaDon.MaHV;
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
        

        public bool TrungMa(int maHD)
        {
            string sql = $"SELECT * FROM hoa_don WHERE ma_hd = {maHD}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }
        public bool TrungMaKH(int maKH, int maHV)
        {
            string sql = $"SELECT * FROM dang_ky_khoa_hoc WHERE ma_kh = {maKH} and ma_hv = {maHV}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }
        public int NextID()
        {
            string sql = "SELECT MAX(ma_hd) as 'max' FROM chi_tiet_hoa_don";
            dataTable = dataServices.RunQuery(sql);
            int num = -1;
            if (!int.TryParse(dataTable.Rows[0]["max"].ToString(), out num)) return 1;
            int curId = (int)dataTable.Rows[0]["max"];
            return curId + 1;
        }
    }
    
}
