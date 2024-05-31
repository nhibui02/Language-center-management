using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using CSharp_LanguageCentre.DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        static TaiKhoanDAO dao;
        static List<TaiKhoanDTO> danhSach;

        public TaiKhoanBUS()
        {
            dao = new TaiKhoanDAO();
            danhSach = dao.getAll();
            //danhSach.ForEach(taiKhoan => {
            //    Console.WriteLine($"{taiKhoan.TenTK}, {taiKhoan.MatKhau}, {taiKhoan.MaQuyen}");
            //});
        }

        public List<TaiKhoanDTO> getAll()
        {
            return dao.getAll();
        }

        //public bool KTThongTinTaiKhoan(string tenTK)
        //{
        //    bool flag = false;
        //    TaiKhoanDTO taiKhoan = dao.TimTaiKhoan(tenTK);
        //    danhSach.ForEach(tk =>
        //    {
        //        if (tk.TenTK == taiKhoan.TenTK && tk.MatKhau == taiKhoan.MatKhau && tk.MaQuyen == taiKhoan.MaQuyen)
        //            flag = true;
        //    });
        //    return flag;
        //}

        public bool KTTaiKhoanHopLe(string tenTK, string matKhau)
        {
            TaiKhoanDTO taiKhoan = dao.TimTaiKhoan(tenTK, matKhau);
            if (taiKhoan == null)
                return false;
            return true;
        }

        public string ThongBaoDangNhap(string tenTK, string matKhau)
        {
            if (KTTaiKhoanHopLe(tenTK, matKhau))
                return "Đăng nhập thành công!";
            return "Sai thông tin đăng nhập!";
        }

        public TaiKhoanDTO TimTaiKhoan(string tenTK, string matKhau)
        {
            return dao.TimTaiKhoan(tenTK, matKhau);
        }

        public string Insert(TaiKhoanDTO taiKhoan)
        {
            
            if (dao.Insert(taiKhoan))
            {
                danhSach = dao.getAll();
                return "Thêm thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public string Delete(string tenTK)
        {
            if (dao.Delete(tenTK))
            {
                danhSach = dao.getAll();
                return "Xóa thành công!";
            }
            return "Đã có lỗi xảy ra";
        }

        public string Update(TaiKhoanDTO taiKhoan)
        {
            if (dao.Update(taiKhoan))
            {
                danhSach = dao.getAll();
                return "Cập nhật thành công!";
            }
            return "Đã có lỗi xảy ra!";
        }

        public bool TrungTenTK(string tenTK)
        {
            return dao.TrungTenTK(tenTK);
        }

        public List<TaiKhoanDTO> Search(string key)
        {
            List<TaiKhoanDTO> searchList = new List<TaiKhoanDTO>();

            foreach (TaiKhoanDTO tk in danhSach)
            {
                if (tk.TenTK.ToLower().Contains(key.ToLower()))
                {
                    searchList.Add(tk);
                    break;
                }
            }
            return searchList;

        }

    }
}
