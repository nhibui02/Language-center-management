using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_LanguageCentre
{
    class ChucNang
    {
        int maCN;
        Panel pnlChucNang;

        public ChucNang()
        {

        }

        public ChucNang(int maCN, Panel pnlChucNang)
        {
            this.maCN = maCN;
            this.pnlChucNang = pnlChucNang;
        }

        public int MaCN { get; set; }
        public Panel PnlChucNang { get; set; }
    }
}
