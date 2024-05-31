using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucNangDTO
    {
        int maCN;
        string tenCN;

        public ChucNangDTO()
        {

        }

        public ChucNangDTO(int maCN, string tenCN)
        {
            this.maCN = maCN;
            this.tenCN = tenCN;
        }

        public int MaCN { get; set; }
        public string TenCN { get; set; }
    }
}
