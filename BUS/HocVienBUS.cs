using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using CSharp_LanguageCentre.DTO;

namespace BUS
{
    public class HocVienBUS
    {
        static HocVienDAO dao;
        static List<HocVienDTO> danhSach;

        public HocVienBUS()
        {
            dao = new HocVienDAO();
            danhSach = dao.getAll();
        }

        public List<HocVienDTO> getAll()
        {
            return dao.getAll();
        }

        public int nextID()
        {
            return dao.NextID();
        }

        public string Insert(HocVienDTO hocVien)
        {
            hocVien.MaHV = nextID();
            if (dao.Insert(hocVien))
            {
                danhSach = dao.getAll();
                return "Thêm thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Delete(int maHV)
        {
            if (dao.Delete(maHV))
            {
                danhSach = dao.getAll();
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }
        public string Update(HocVienDTO hocVien)
        {
            if (dao.Update(hocVien))
            {
                danhSach = dao.getAll();
                return "Cập nhật thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public List<HocVienDTO> Search(string key, int option)
        {
            List<HocVienDTO> searchList = new List<HocVienDTO>();

            if (option == 0) //tim bang ma hoc vien
            {
                foreach (HocVienDTO hocVien in danhSach)
                {
                    if (hocVien.MaHV == Convert.ToInt32(key))
                    {
                        searchList.Add(hocVien);
                        break;
                    }
                }
            }
            else if (option == 1) //tim bang ten hoc vien
            {
                foreach (HocVienDTO hocVien in danhSach)
                {
                    if (hocVien.HoTen.ToLower().Contains(key.ToLower()))
                    {
                        searchList.Add(hocVien);
                    }
                }
            }

            return searchList;
        }

        public bool TrungMa(int maHV)
        {
            return dao.TrungMa(maHV);
        }
    }
}
