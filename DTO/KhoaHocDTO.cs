using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class KhoaHocDTO
    {
        int maKH;
        string tenKH;
        int gia;
        string capBac;
        DateTime ngayBD;
        DateTime ngayKT;

        public KhoaHocDTO()
        {

        }
        public KhoaHocDTO(int maKH, string tenKH, int gia, string capBac, DateTime ngayBD, DateTime ngayKT)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.gia = gia;
            this.capBac = capBac;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }
        
        public int MaKH { get { return maKH; } set { maKH = value; } }
        public string TenKH { get { return tenKH; } set { tenKH = value; } }
        public int Gia { get { return gia; } set { gia = value; } }
        public string CapBac { get { return capBac; } set { capBac = value; } }
        public DateTime NgayBD{ get { return ngayBD; } set { ngayBD = value; } }
        public DateTime NgayKT{ get { return ngayKT; } set { ngayKT = value; } }
    }
}
