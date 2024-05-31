using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HocPhiDAO
    {
        DataServices dataServices;
        DataTable dt;

        public HocPhiDAO()
        {
            dataServices = new DataServices();
        }

        public List<HocPhiDTO> getHocPhi(int maHV)
        {
            List<HocPhiDTO> ds = new List<HocPhiDTO>();
            string sql = $"SELECT kh.ma_kh, kh.ten_kh, cthd.gia FROM khoa_hoc kh, hoa_don hd, chi_tiet_hoa_don cthd WHERE kh.ma_kh = cthd.ma_kh AND cthd.ma_hd = hd.ma_hd AND hd.ma_hv = {maHV}";
            if (!dataServices.OpenDB()) return null;
            dt = dataServices.RunQuery(sql);
            HocPhiDTO hp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hp = new HocPhiDTO();
                hp.MaKH = (int)dt.Rows[i]["ma_kh"];
                hp.TenKH = dt.Rows[i]["ten_kh"].ToString();
                hp.HocPhi = (int)dt.Rows[i]["gia"];
                ds.Add(hp);
            }
            return ds;
        }

        public bool getTinhTrang(int maHV)
        {
            string sql = $"SELECT tinh_trang_thanh_toan FROM hoa_don WHERE ma_hv = {maHV}";
            dt = dataServices.RunQuery(sql);

            if (dt.Rows.Count != 0)
                return Convert.ToBoolean(dt.Rows[0]["tinh_trang_thanh_toan"]);
            else
                return false;
        }
    }
}
