using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class CTHoaDonDTO
    {
        int maHD;
        int maKH;
        int gia;

        public CTHoaDonDTO()
        {
        }

        public CTHoaDonDTO(int maHD, int maKH, int gia)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.gia = gia;
        }

        public int MaHD { get { return maHD; } set { maHD = value; } }
        public int MaKH { get { return maKH; } set { maKH = value; } }
        public int Gia { get { return gia; } set { gia = value; } }
    }
}
