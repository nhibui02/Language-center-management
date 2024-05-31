using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_LanguageCentre.GUI;
using CSharp_LanguageCentre.DTO;

namespace CSharp_LanguageCentre
{
    public partial class Form1 : Form
    {
        static TaiKhoanDTO tkDaDangNhap;
        static Form1 form;
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new MainMenu());
            form = this;
        }

        public static TaiKhoanDTO TKDaDangNhap { get { return tkDaDangNhap; } set { tkDaDangNhap = value; } }

        public static void ChangeControlTo(UserControl control)
        {
            form.Controls.Clear();
            form.Controls.Add(control);
        }

        public static void CloseForm()
        {
            form.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
