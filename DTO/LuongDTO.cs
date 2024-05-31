using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class LuongDTO
	{
		int maLuong;
		string loaiLuong;
		int mucLuong;

		public LuongDTO()
		{
		}

		public LuongDTO(int maLuong, string loaiLuong, int mucLuong)
		{
			this.maLuong = maLuong;
			this.loaiLuong = loaiLuong;
			this.mucLuong = mucLuong;
		}

		public int MaLuong
		{ 
			get { return maLuong; }
			set { maLuong = value; } 
		}
		public string LoaiLuong 
		{ 
			get { return loaiLuong; } 
			set { loaiLuong = value; } 
		}
		public int MucLuong
		{ 
			get { return mucLuong; } 
			set { mucLuong = value; } 
		}
	}
}
