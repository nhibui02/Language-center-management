using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XepLichDTO
    {
        int maKH;
        int nhomKH;
        int thu;
        int tietBD;
        int soTiet;
        int maGV;
        int maPH;

        public XepLichDTO()
        {

        }

        public XepLichDTO(int maKH, int nhomKH, int thu, int tietBD, int soTiet, int maGV, int maPH)
        {
            this.maKH = maKH;
            this.nhomKH = nhomKH;
            this.thu = thu;
            this.tietBD = tietBD;
            this.soTiet = soTiet;
            this.maGV = maGV;
            this.maPH = maPH;
        }

        public int MaKH { get { return maKH; } set { maKH = value; } }
        public int NhomKH { get { return nhomKH; } set { nhomKH = value; } }
        public int Thu { get { return thu; } set { thu = value; } }
        public int TietBD { get { return tietBD; } set { tietBD = value; } }
        public int SoTiet { get { return soTiet; } set { soTiet = value; } }
        public int MaGV { get { return maGV; } set { maGV = value; } }
        public int MaPH { get { return maPH; } set { maPH = value; } }
    }
}
