using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class PhongHocDTO
    {
        int maPH;
        string tenPH;
        int sucChua;
        public PhongHocDTO()
        {
        }

        public PhongHocDTO(int maPH, string tenPH, int sucChua)
        {
            this.maPH = maPH;
            this.tenPH = tenPH;
            this.sucChua = sucChua;
        }

        public int MaPH
        {
            get { return maPH; }
            set { maPH = value; }
        }
        public string TenPH 
        {
            get { return tenPH; }
            set {tenPH = value; } 
        }
        public int SucChua 
        {
            get { return sucChua; }

            set {sucChua = value; } 
        }
    }
}
