using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class XepLichBUS
    {
        static XepLichDAO dao = new XepLichDAO();
        static List<XepLichDTO> danhSach;

        public XepLichBUS()
        {

        }
        public XepLichBUS(int maKH)
        {
            dao = new XepLichDAO();
            danhSach = dao.getLichKhoaHoc(maKH);
        }

        public List<XepLichDTO> getAll()
        {
            return dao.getAll();
        }
        public List<int> getMaKHCoLich()
        {
            return dao.getMaKHCoLich();
        }


        public List<XepLichDTO> getLichKhoaHoc(int maKH)
        {
            return dao.getLichKhoaHoc(maKH);
        }

        public bool TrungLich(XepLichDTO xepLich)
        {
            return dao.TrungLich(xepLich);
        }

        public bool TrungMa(int maKH, int nhomKH)
        {
            return dao.TrungMa(maKH, nhomKH);
        }

        public int NextNhomKH(int maKH)
        {
            return dao.NextNhomKH(maKH);
        }

        public string Insert(XepLichDTO xepLich)
        {
            xepLich.NhomKH = NextNhomKH(xepLich.MaKH);
            if (dao.Insert(xepLich))
            {
                danhSach = dao.getLichKhoaHoc(xepLich.MaKH);
                return "Thêm thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Delete(int maKH, int nhomKH)
        {
            if (dao.Delete(maKH, nhomKH))
            {
                danhSach = dao.getLichKhoaHoc(maKH);
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Update(XepLichDTO xepLich)
        {
            if (dao.Update(xepLich))
            {
                danhSach = dao.getLichKhoaHoc(xepLich.MaKH);
                return "Cập nhật thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }
    }
}
