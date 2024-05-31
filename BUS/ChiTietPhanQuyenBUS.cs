using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class ChiTietPhanQuyenBUS
    {
        static ChiTietPhanQuyenDAO dao = new ChiTietPhanQuyenDAO();

        public ChiTietPhanQuyenBUS()
        {

        }

        public List<ChiTietPhanQuyenDTO> QuyenTK(string tenTK )
        {
            return dao.QuyenTK(tenTK);
        }

        public string Insert(ChiTietPhanQuyenDTO quyen)
        {
            if (dao.Insert(quyen))
            {
                return "Thêm thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Delete(ChiTietPhanQuyenDTO quyen)
        {
            if (dao.Delete(quyen))
            {
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public bool TrungMa(ChiTietPhanQuyenDTO quyen)
        {
            return dao.TrungMa(quyen);
        }
    }
}
