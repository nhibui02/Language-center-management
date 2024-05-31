using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class DangKyKHDTO
    {
        int maKH;
        int nhomKH;
        int maHV;

        public DangKyKHDTO(int maKH, int nhomKH, int maHV)
        {
            this.maKH = maKH;
            this.nhomKH = nhomKH;
            this.maHV = maHV;
        }

        public int MaKH { get { return maKH; } set { maKH = value; } }

        public int NhomKH { get { return nhomKH; } set { nhomKH = value; } }
        public int MaHV { get { return maHV; } set { maHV = value; } }
    }
}
