using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuyenDTO
    {
        int maQuyen;
        string tenQuyen;

        public QuyenDTO()
        {

        }

        public QuyenDTO(int maQuyen, string tenQuyen)
        {
            this.maQuyen = maQuyen;
            this.tenQuyen = tenQuyen;
        }

        public int MaQuyen { get { return maQuyen; } set { maQuyen = value; } }
        public string TenQuyen { get { return tenQuyen; } set { tenQuyen = value; } }

    }
}
