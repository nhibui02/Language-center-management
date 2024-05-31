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
using DTO;
using Microsoft.Office.Interop.Excel;

namespace CSharp_LanguageCentre.GUI
{
    public partial class ViewTuition : UserControl
    {
        HocPhiBUS busHP = new HocPhiBUS();
        HocVienBUS busHV = new HocVienBUS();
        List<HocPhiDTO> dsHP = new List<HocPhiDTO>();
        public ViewTuition()
        {
            InitializeComponent();
        }

        private void SetThongTinHocPhi()
        {
            txtTongKH.Text = busHP.SoKhoaHoc().ToString();
            txtTongHP.Text = busHP.TongHocPhi().ToString();
            txtTTHP.Text = busHP.getTinhTrang(Convert.ToInt32(txtMaHV.Text)) ? "Đã đóng" : "Chưa đóng";
        }

        private void btnXemHP_Click(object sender, EventArgs e)
        {
            int num = -1;
            if (String.IsNullOrWhiteSpace(txtMaHV.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!int.TryParse(txtMaHV.Text, out num) || num <= 0)
            {
                MessageBox.Show("Mã học viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!busHV.TrungMa(Convert.ToInt32(txtMaHV.Text)))
            {
                MessageBox.Show("Mã học viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dsHP = busHP.getHocPhi(Convert.ToInt32(txtMaHV.Text));
                dgvHocPhi.DataSource = dsHP;
                SetThongTinHocPhi();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private bool CopyAlltoClipboard()
        {
            dgvHocPhi.SelectAll();
            DataObject dataObj = dgvHocPhi.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
                return true;
            }
            else
            {
                return false;
            }

        }

        private string newFileName()
        {
            DateTime time = DateTime.Now;
            int ms = (int)time.ToUniversalTime().Subtract(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            return ms.ToString();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (CopyAlltoClipboard())
            {
                DialogResult result = MessageBox.Show("Xuất file?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Range CR = (Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                for (int i = 2; i < dgvHocPhi.Columns.Count + 2; i++)
                {
                    xlWorkSheet.Cells[1, i] = dgvHocPhi.Columns[i - 2].HeaderText;
                }
                xlWorkBook.SaveAs($"hocphi_{newFileName()}.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
