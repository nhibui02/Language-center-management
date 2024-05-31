using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharp_LanguageCentre.DTO
{
	public class GiangVienDTO
	{
		int maGV;
		string hoTen;
		string soDienThoai;
		string trinhDo;
		string chuyenMon;
		int maLuong;
		public GiangVienDTO()
		{
		}

		public GiangVienDTO(int maGV, string hoTen, string soDienThoai, string trinhDo, string chuyenMon, int maLuong)
		{
			this.maGV = maGV;
			this.hoTen = hoTen;
			this.soDienThoai = soDienThoai;
			this.trinhDo = trinhDo;
			this.chuyenMon = chuyenMon;
			this.maLuong = maLuong;
		}

		public int MaGV 
		{
			get { return maGV; }
			set { maGV = value; }
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

		
		public string TrinhDo
		{
			get { return trinhDo; }
			set { trinhDo = value; }
		}

		public string ChuyenMon
		{
			get { return chuyenMon; }
			set { chuyenMon = value; }
		}
		public int MaLuong
		{
			get { return maLuong; }
			set { maLuong = value; }
		}

	}
}
