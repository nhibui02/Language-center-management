using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhanQuyenDTO
    {
        int maQuyen;
        int maCN;

        public ChiTietPhanQuyenDTO()
        {

        }

        public ChiTietPhanQuyenDTO(int maQuyen, int maCN)
        {
            this.maQuyen = maQuyen;
            this.maCN = maCN;
        }

        public int MaQuyen { get { return maQuyen; } set { maQuyen = value; } }
        public int MaCN { get { return maCN; } set { maCN = value; } }
    }
}
