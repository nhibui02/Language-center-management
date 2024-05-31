using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChucNangDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public ChucNangDAO()
        {

        }

        public List<ChucNangDTO> getAll()
        {
            List<ChucNangDTO> list = new List<ChucNangDTO>();
            string sql = "SELECT * FROM chuc_nang";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            ChucNangDTO chucNang;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                chucNang = new ChucNangDTO();
                chucNang.MaCN = (int)dataTable.Rows[i]["ma_cn"];
                chucNang.TenCN = dataTable.Rows[i]["ten_cn"].ToString();
                list.Add(chucNang);
            }

            return list;
        }

        public List<ChucNangDTO> getChucNang(int maQuyen)
        {
            List<ChucNangDTO> list = new List<ChucNangDTO>();
            string sql = $"SELECT cn.ma_cn, cn.ten_cn FROM chuc_nang cn, chi_tiet_phan_quyen q WHERE q.ma_cn = cn.ma_cn AND q.ma_quyen = {maQuyen}";
            dataTable = dataServices.RunQuery(sql);
            ChucNangDTO chucNang;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                chucNang = new ChucNangDTO();
                chucNang.MaCN = (int)dataTable.Rows[i]["ma_cn"];
                chucNang.TenCN = dataTable.Rows[i]["ten_cn"].ToString();
                list.Add(chucNang);
            }

            return list;
        }
    }
}
