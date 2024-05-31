using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_LanguageCentre.DTO
{
	public class StaffDTO
	{
		int maNV;
		string hoTen;
		string soDienThoai;
		int maLuong;
		string tenTK;
		
		public StaffDTO() 
		{ }

		public StaffDTO(int maNV, string hoTen, string soDienThoai, int maLuong, string tenTK)
		{
			this.maNV = maNV;
			this.hoTen = hoTen;
			this.soDienThoai = soDienThoai;
			this.maLuong = maLuong;
			this.tenTK = tenTK;
		}

		public int MaNV
		{ 
			get { return maNV; } 
			set { maNV = value; }
		}
        public string HoTen	
		{ 
			get { return hoTen; } 
			set { hoTen = value; } 
		}

		public string SoDienThoai
		{ 
			get { return soDienThoai; } 
			set { soDienThoai = value; } 
		}

		public int MaLuong
		{ 
			get { return maLuong; } 
			set { maLuong = value; } 
		}

		public string TenTK 
		{ 
			get {	return tenTK; } 
			set { tenTK = value; } 
		}


    }
}
