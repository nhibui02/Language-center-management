using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class HocPhiBUS
    {
        HocPhiDAO dao;
        List<HocPhiDTO> ds;

        public HocPhiBUS()
        {
            dao = new HocPhiDAO();
        }

        public List<HocPhiDTO> getHocPhi(int maHV)
        {
            ds = dao.getHocPhi(maHV);
            return dao.getHocPhi(maHV);
        }

        public bool getTinhTrang(int maHV)
        {
            return dao.getTinhTrang(maHV);
        }

        public int SoKhoaHoc()
        {
            return ds.Count;
        }

        public int TongHocPhi()
        {
            int tong = 0;
            foreach(HocPhiDTO hp in ds)
            {
                tong += hp.HocPhi;
            }
            return tong;
        }
    }
}
