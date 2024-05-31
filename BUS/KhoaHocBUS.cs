using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using CSharp_LanguageCentre.DTO;
namespace BUS
{
    public class KhoaHocBUS
    {
        static KhoaHocDAO dao;
        static List<KhoaHocDTO> danhSach;
        
        public KhoaHocBUS()
        {
            dao = new KhoaHocDAO();
            danhSach = dao.getAll();
        }

        public List<KhoaHocDTO> getAll()
        {
            return dao.getAll();
        }

        public int NextID()
        {
            return dao.NextID();
        }

        public string Insert(KhoaHocDTO khoaHoc)
        {
            khoaHoc.MaKH = NextID();
            if(dao.Insert(khoaHoc))
            {
                danhSach = dao.getAll();
                return "Thêm thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Delete(int maKH)
        {
            if(dao.Delete(maKH))
            {
                danhSach = dao.getAll();
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra";
        }

        public string Update(KhoaHocDTO khoaHoc)
        {
            if(dao.Update(khoaHoc))
            {
                danhSach = dao.getAll();
                return "Cập nhật thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }
        public bool TrungMa(int maKH)
        {
            return dao.TrungMa(maKH);
        }

        public List<KhoaHocDTO> Search(string key, int option)
        {
            List<KhoaHocDTO> searchList = new List<KhoaHocDTO>();

            if (option == 0) //tim bang ma hoc vien
            {
                foreach (KhoaHocDTO khoaHoc in danhSach)
                {
                    if (khoaHoc.MaKH == Convert.ToInt32(key))
                    {
                        searchList.Add(khoaHoc);
                        break;
                    }
                }
            }
            else if (option == 1) //tim bang ten khoa hoc
            {
                foreach (KhoaHocDTO khoaHoc in danhSach)
                {
                    if (khoaHoc.TenKH.ToLower().Contains(key.ToLower()))
                    {
                        searchList.Add(khoaHoc);
                    }
                }
            }

            return searchList;
            
        }
    }
}
