using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using CSharp_LanguageCentre.DTO;

namespace BUS
{
    public class ThoiKhoaBieuBUS
    {
        ThoiKhoaBieuDAO dao;
        List<ThoiKhoaBieuDTO> ds;

        public ThoiKhoaBieuBUS()
        {
            dao = new ThoiKhoaBieuDAO();
        }

        public List<ThoiKhoaBieuDTO> getTKBHV(int maHV)
        {
            return dao.getTKBHV(maHV);
        }

        public List<ThoiKhoaBieuDTO> getTKBGV(int maGV)
        {
            return dao.getTKBGV(maGV);
        }
    }
}
