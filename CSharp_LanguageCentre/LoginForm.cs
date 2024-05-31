using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using CSharp_LanguageCentre.DTO;

namespace CSharp_LanguageCentre
{
    public partial class LoginForm : Form
    {
        List<TaiKhoanDTO> danhSach;
        TaiKhoanBUS bus;
        public LoginForm()
        {
            InitializeComponent();
            bus = new TaiKhoanBUS();
            danhSach = bus.getAll();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private bool KiemTraInput()
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Không được để trống thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (KiemTraInput())
            {
                MessageBox.Show(bus.ThongBaoDangNhap(txtUsername.Text,txtPassword.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (bus.KTTaiKhoanHopLe(txtUsername.Text, txtPassword.Text))
                {
                    TaiKhoanDTO loggedIn = bus.TimTaiKhoan(txtUsername.Text, txtPassword.Text);
                    Form1.TKDaDangNhap = loggedIn;
                    Form1.ChangeControlTo(new function_menu(loggedIn));
                    this.Close();
                }
            }
        }
    }
}
