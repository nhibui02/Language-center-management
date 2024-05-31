using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChucNangBUS
    {
        static ChucNangDAO dao;
        static List<ChucNangDTO> danhSach;

        public ChucNangBUS()
        {
            dao = new ChucNangDAO();
            danhSach = dao.getAll();
        }

        public List<ChucNangDTO> getAll()
        {
            return dao.getAll();
        }

        public List<ChucNangDTO> getChucNang(int maQuyen)
        {
            return dao.getChucNang(maQuyen);
        }
    }
}
