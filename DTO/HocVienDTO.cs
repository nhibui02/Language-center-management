using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
    public class HocVienDTO
    {
        int maHV;
        string hoTen;
        string soDienThoai;
        string trinhDo;

        public HocVienDTO()
        {

        }

        public HocVienDTO(int maHV, string hoTen, string soDienThoai, string trinhDo)
        {
            this.maHV = maHV;
            this.hoTen = hoTen;
            this.soDienThoai = soDienThoai;
            this.trinhDo = trinhDo;
        }

        public int MaHV { get { return maHV; } set { maHV = value; } }
        public string HoTen { get { return hoTen; } set { hoTen = value; } }
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; } }
        public string TrinhDo { get { return trinhDo; } set { trinhDo = value; } }
    }
}
