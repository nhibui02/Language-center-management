using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class ThoiKhoaBieuDTO
    {
        int maKH;
        string tenKH;
        int thu;
        int tietBD;
        int soTiet;
        DateTime ngayBD;
        DateTime ngayKT;

        public ThoiKhoaBieuDTO()
        {

        }

        public ThoiKhoaBieuDTO(int maKH, string tenKH, int thu, int tietBD, int soTiet, DateTime ngayBD, DateTime ngayKT)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.thu = thu;
            this.tietBD = tietBD;
            this.soTiet = soTiet;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public int MaKH { get { return maKH; } set { maKH = value; } }
        public string TenKH { get { return tenKH; } set { tenKH = value; } }
        public int Thu { get { return thu; } set { thu = value; } }
        public int TietBD { get { return tietBD; } set { tietBD = value; } }
        public int SoTiet { get { return soTiet; } set { soTiet = value; } }
        public DateTime NgayBD { get { return ngayBD; } set { ngayBD = value; } }
        public DateTime NgayKT { get { return ngayKT; } set { ngayKT = value; } }
    }
}
