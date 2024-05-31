using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using CSharp_LanguageCentre.DTO;
namespace BUS
{
    public class CTHoaDonBUS
    {
        static CTHoaDonDAO dao;
        static List<CTHoaDonDTO> danhSach;


        public CTHoaDonBUS()
        {
            dao = new CTHoaDonDAO();
            danhSach = dao.getAll();
        }

        public List<CTHoaDonDTO> getAll()
        {
            return dao.getAll();
        }

        public void Insert(CTHoaDonDTO cthd, int nhomKH, int maHV)
        {
            cthd.MaHD = NextID();
            cthd.Gia = GetFee(cthd.MaKH);
            if (dao.Insert(cthd, nhomKH, maHV))
            {
                danhSach = dao.getAll();
            }
        }

        public string Delete(int maHD)
        {
            if (dao.Delete(maHD))
            {
                danhSach = dao.getAll();
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra";
        }

        public string Update(CTHoaDonDTO cthd)
        {
            if (dao.Update(cthd))
            {
                danhSach = dao.getAll();
                return "Cập nhật thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public int GetFee(int maKH)
        {
            return dao.GetFee(maKH);
        }

        public int NextID()
        {
            return dao.NextID();
        }
    }
}
