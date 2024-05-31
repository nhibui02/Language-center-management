using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietPhanQuyenDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public ChiTietPhanQuyenDAO()
        {
        }

        public List<ChiTietPhanQuyenDTO> QuyenTK(string tenTK)
        {
            List<ChiTietPhanQuyenDTO> dsQuyen = new List<ChiTietPhanQuyenDTO>();
            string sql = $"SELECT ct.ma_quyen, ct.ma_cn FROM chi_tiet_phan_quyen ct, tai_khoan tk WHERE tk.ma_quyen = ct.ma_quyen AND tk.ten_tk = '{tenTK}'";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            ChiTietPhanQuyenDTO chiTietPhanQuyen;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                chiTietPhanQuyen = new ChiTietPhanQuyenDTO();
                chiTietPhanQuyen.MaQuyen = (int)dataTable.Rows[i]["ma_quyen"];
                chiTietPhanQuyen.MaCN = (int)dataTable.Rows[i]["ma_cn"];
                dsQuyen.Add(chiTietPhanQuyen);
            }

            return dsQuyen;
        }

        public bool Insert(ChiTietPhanQuyenDTO quyen)
        {
            string sql = $"INSERT INTO chi_tiet_phan_quyen(ma_quyen, ma_cn) VALUES ({quyen.MaQuyen}, {quyen.MaCN})";
            try
            {
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ChiTietPhanQuyenDTO quyen)
        {
            string sql = $"DELETE FROM chi_tiet_phan_quyen WHERE ma_quyen = {quyen.MaQuyen} AND ma_cn = {quyen.MaCN}";
            try
            {
                dataServices.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool TrungMa(ChiTietPhanQuyenDTO quyen)
        {
            string sql = $"SELECT * FROM chi_tiet_phan_quyen WHERE ma_quyen = {quyen.MaQuyen} AND ma_cn={quyen.MaCN}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }
    }
}
