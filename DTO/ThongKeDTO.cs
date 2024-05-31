using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class ThongKeDTO
	{
		int maHV;
		string hoTen;
		int maKH;
		DateTime ngayBD;
		int gia;

		public ThongKeDTO() 
		{ 

		}

		public ThongKeDTO(int maHV, string hoTen, int maKH, DateTime ngayBD, int gia)
		{
			this.maHV = maHV;
			this.hoTen = hoTen;
			this.maKH = maKH;
			this.ngayBD = ngayBD;
			this.gia = gia;
		}

        public int MaHV { get { return maHV; } set { maHV = value; } }
		public string HoTen { get { return hoTen; } set { hoTen = value; } }
		public int MaKH { get { return maKH; } set { maKH = value; } }
		public DateTime NgayBD { get { return ngayBD; } set { ngayBD = value; } }
		public int Gia { get { return gia; } set { gia = value; } }
    }
}
