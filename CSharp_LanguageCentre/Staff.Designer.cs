namespace CSharp_LanguageCentre.GUI
{
	partial class Staff
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblNhanVien = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnLoadDS = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnTimKiem = new System.Windows.Forms.Button();
			this.txtTimKiem = new System.Windows.Forms.TextBox();
			this.cbbLocTimKiem = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGVStaff = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbbMaLuong = new System.Windows.Forms.ComboBox();
			this.btnXacNhan = new System.Windows.Forms.Button();
			this.btnHuy = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.txtSdt = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			this.txtTenNV = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnQuayLai = new System.Windows.Forms.Button();
			this.cbbTenTK = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGVStaff)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(218)))));
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.lblNhanVien);
			this.panel1.Location = new System.Drawing.Point(52, 45);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 106);
			this.panel1.TabIndex = 5;
			// 
			// lblNhanVien
			// 
			this.lblNhanVien.AutoSize = true;
			this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNhanVien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblNhanVien.Location = new System.Drawing.Point(28, 38);
			this.lblNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNhanVien.Name = "lblNhanVien";
			this.lblNhanVien.Size = new System.Drawing.Size(179, 40);
			this.lblNhanVien.TabIndex = 0;
			this.lblNhanVien.Text = "Nhân viên";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLoadDS);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnTimKiem);
			this.groupBox1.Controls.Add(this.txtTimKiem);
			this.groupBox1.Controls.Add(this.cbbLocTimKiem);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(102, 169);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(910, 122);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin nhân viên";
			// 
			// btnLoadDS
			// 
			this.btnLoadDS.Location = new System.Drawing.Point(795, 71);
			this.btnLoadDS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnLoadDS.Name = "btnLoadDS";
			this.btnLoadDS.Size = new System.Drawing.Size(106, 43);
			this.btnLoadDS.TabIndex = 5;
			this.btnLoadDS.Text = "Tải lại";
			this.btnLoadDS.UseVisualStyleBackColor = true;
			this.btnLoadDS.Click += new System.EventHandler(this.btnLoadDS_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(82, 83);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tìm kiếm:";
			// 
			// btnTimKiem
			// 
			this.btnTimKiem.Location = new System.Drawing.Point(681, 72);
			this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnTimKiem.Name = "btnTimKiem";
			this.btnTimKiem.Size = new System.Drawing.Size(106, 42);
			this.btnTimKiem.TabIndex = 3;
			this.btnTimKiem.Text = "Tìm kiếm";
			this.btnTimKiem.UseVisualStyleBackColor = true;
			this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
			// 
			// txtTimKiem
			// 
			this.txtTimKiem.Location = new System.Drawing.Point(226, 77);
			this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTimKiem.Name = "txtTimKiem";
			this.txtTimKiem.Size = new System.Drawing.Size(426, 32);
			this.txtTimKiem.TabIndex = 2;
			// 
			// cbbLocTimKiem
			// 
			this.cbbLocTimKiem.FormattingEnabled = true;
			this.cbbLocTimKiem.Items.AddRange(new object[] {
            "Mã nhân viên",
            "Tên nhân viên",
            "Số điện thoại",
            "Mã lương",
            "Tên tài khoản"});
			this.cbbLocTimKiem.Location = new System.Drawing.Point(226, 35);
			this.cbbLocTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbbLocTimKiem.Name = "cbbLocTimKiem";
			this.cbbLocTimKiem.Size = new System.Drawing.Size(282, 34);
			this.cbbLocTimKiem.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(82, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lọc theo:";
			// 
			// dataGVStaff
			// 
			this.dataGVStaff.AllowUserToAddRows = false;
			this.dataGVStaff.AllowUserToDeleteRows = false;
			this.dataGVStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGVStaff.Location = new System.Drawing.Point(102, 312);
			this.dataGVStaff.Name = "dataGVStaff";
			this.dataGVStaff.ReadOnly = true;
			this.dataGVStaff.RowHeadersWidth = 62;
			this.dataGVStaff.RowTemplate.Height = 28;
			this.dataGVStaff.Size = new System.Drawing.Size(910, 558);
			this.dataGVStaff.TabIndex = 7;
			this.dataGVStaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGVStaff_CellContentClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cbbTenTK);
			this.groupBox2.Controls.Add(this.cbbMaLuong);
			this.groupBox2.Controls.Add(this.btnXacNhan);
			this.groupBox2.Controls.Add(this.btnHuy);
			this.groupBox2.Controls.Add(this.btnXoa);
			this.groupBox2.Controls.Add(this.btnSua);
			this.groupBox2.Controls.Add(this.btnThem);
			this.groupBox2.Controls.Add(this.txtSdt);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtMaNV);
			this.groupBox2.Controls.Add(this.txtTenNV);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(1034, 312);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(484, 558);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thông tin chi tiết";
			// 
			// cbbMaLuong
			// 
			this.cbbMaLuong.FormattingEnabled = true;
			this.cbbMaLuong.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
			this.cbbMaLuong.Location = new System.Drawing.Point(182, 238);
			this.cbbMaLuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbbMaLuong.Name = "cbbMaLuong";
			this.cbbMaLuong.Size = new System.Drawing.Size(276, 34);
			this.cbbMaLuong.TabIndex = 18;
			// 
			// btnXacNhan
			// 
			this.btnXacNhan.Location = new System.Drawing.Point(256, 451);
			this.btnXacNhan.Name = "btnXacNhan";
			this.btnXacNhan.Size = new System.Drawing.Size(154, 46);
			this.btnXacNhan.TabIndex = 17;
			this.btnXacNhan.Text = "Xác nhận";
			this.btnXacNhan.UseVisualStyleBackColor = true;
			this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
			// 
			// btnHuy
			// 
			this.btnHuy.Location = new System.Drawing.Point(82, 451);
			this.btnHuy.Name = "btnHuy";
			this.btnHuy.Size = new System.Drawing.Size(154, 46);
			this.btnHuy.TabIndex = 16;
			this.btnHuy.Text = "Hủy";
			this.btnHuy.UseVisualStyleBackColor = true;
			this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(344, 380);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(112, 46);
			this.btnXoa.TabIndex = 15;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnSua
			// 
			this.btnSua.Location = new System.Drawing.Point(194, 380);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(112, 46);
			this.btnSua.TabIndex = 14;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnThem
			// 
			this.btnThem.Location = new System.Drawing.Point(34, 380);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(112, 46);
			this.btnThem.TabIndex = 13;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// txtSdt
			// 
			this.txtSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSdt.Location = new System.Drawing.Point(182, 191);
			this.txtSdt.Name = "txtSdt";
			this.txtSdt.Size = new System.Drawing.Size(276, 32);
			this.txtSdt.TabIndex = 8;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(32, 242);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 26);
			this.label8.TabIndex = 7;
			this.label8.Text = "Mã lương:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(32, 294);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 26);
			this.label7.TabIndex = 6;
			this.label7.Text = "Tên TK:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 191);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 26);
			this.label5.TabIndex = 4;
			this.label5.Text = "SĐT:";
			// 
			// txtMaNV
			// 
			this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaNV.Location = new System.Drawing.Point(182, 89);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.Size = new System.Drawing.Size(276, 32);
			this.txtMaNV.TabIndex = 3;
			// 
			// txtTenNV
			// 
			this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenNV.Location = new System.Drawing.Point(182, 138);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.Size = new System.Drawing.Size(276, 32);
			this.txtTenNV.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "Tên NV:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "Mã NV:";
			// 
			// btnQuayLai
			// 
			this.btnQuayLai.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuayLai.BackgroundImage")));
			this.btnQuayLai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuayLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(27)))), ((int)(((byte)(16)))));
			this.btnQuayLai.Location = new System.Drawing.Point(1280, 63);
			this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnQuayLai.Name = "btnQuayLai";
			this.btnQuayLai.Size = new System.Drawing.Size(210, 65);
			this.btnQuayLai.TabIndex = 13;
			this.btnQuayLai.Text = "Quay lại";
			this.btnQuayLai.UseVisualStyleBackColor = true;
			this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
			// 
			// cbbTenTK
			// 
			this.cbbTenTK.FormattingEnabled = true;
			this.cbbTenTK.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
			this.cbbTenTK.Location = new System.Drawing.Point(182, 286);
			this.cbbTenTK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cbbTenTK.Name = "cbbTenTK";
			this.cbbTenTK.Size = new System.Drawing.Size(276, 34);
			this.cbbTenTK.TabIndex = 19;
			// 
			// Staff
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.btnQuayLai);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dataGVStaff);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Name = "Staff";
			this.Size = new System.Drawing.Size(1536, 886);
			this.Load += new System.EventHandler(this.Staff_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGVStaff)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblNhanVien;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnTimKiem;
		private System.Windows.Forms.TextBox txtTimKiem;
		private System.Windows.Forms.ComboBox cbbLocTimKiem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGVStaff;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnXacNhan;
		private System.Windows.Forms.Button btnHuy;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.TextBox txtSdt;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMaNV;
		private System.Windows.Forms.TextBox txtTenNV;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnQuayLai;
		private System.Windows.Forms.Button btnLoadDS;
		private System.Windows.Forms.ComboBox cbbMaLuong;
		private System.Windows.Forms.ComboBox cbbTenTK;
	}
}
