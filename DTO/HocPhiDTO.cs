using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocPhiDTO
    {
        int maKH;
        string tenKH;
        int hocPhi;

        public HocPhiDTO()
        {

        }

        public HocPhiDTO(int maKH, string tenKH, int hocPhi)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.hocPhi = hocPhi;
        }

        public int MaKH { get { return maKH; } set { maKH = value; } }
        public string TenKH { get { return tenKH; } set { tenKH = value; } }
        public int HocPhi { get { return hocPhi; } set { hocPhi = value; } }
    }
}
