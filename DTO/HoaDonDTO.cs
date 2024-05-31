using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class HoaDonDTO
    {
        int maHD;
        DateTime ngayHD;
        int hocPhi;
        bool tinhTrangThanhToan;
        int maHV;

        public HoaDonDTO()
        {

        }

        public HoaDonDTO(int maHD, DateTime ngayHD, int hocPhi, bool tinhTrangThanhToan, int maHV)
        {
            this.maHD = maHD;
            this.ngayHD = ngayHD;
            this.hocPhi = hocPhi;
            this.tinhTrangThanhToan = tinhTrangThanhToan;
            this.maHV = maHV;
        }

        public int MaHD { get { return maHD; } set { maHD = value; } }
        public DateTime NgayHD { get { return ngayHD; } set { ngayHD = value; } }
        public int HocPhi { get { return hocPhi; } set { hocPhi = value; } }
        public bool TinhTrangThanhToan { get { return tinhTrangThanhToan; } set { tinhTrangThanhToan = value; } }
        public int MaHV { get { return maHV; } set { maHV = value; } }
    }
}
