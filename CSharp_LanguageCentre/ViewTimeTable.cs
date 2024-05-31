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
using Microsoft.Office.Interop.Excel;

namespace CSharp_LanguageCentre.GUI
{
    public partial class ViewTimeTable : UserControl
    {
        ThoiKhoaBieuBUS bus = new ThoiKhoaBieuBUS();
        HocVienBUS busHV = new HocVienBUS();
        GiangVienBUS busGV = new GiangVienBUS();
        List<ThoiKhoaBieuDTO> dsTKB;
        public ViewTimeTable()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXemTKBGV_Click(object sender, EventArgs e)
        {
            int num = -1;
            if (String.IsNullOrWhiteSpace(txtMaGV.Text))
            {
                MessageBox.Show("Không được để trống thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!int.TryParse(txtMaGV.Text, out num) || num <= 0)
            {
                MessageBox.Show("Mã giảng viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (busGV.KiemTraMaGV(Convert.ToInt32(txtMaHV.Text)))
            {
                MessageBox.Show("Mã giảng viên không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dsTKB = bus.getTKBGV(Convert.ToInt32(txtMaGV.Text));
                dgvTKB.DataSource = dsTKB;
            }
        }

        private string newFileName()
        {
            DateTime time = DateTime.Now;
            int ms = (int)time.ToUniversalTime().Subtract(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            return ms.ToString();
        }

        private void btnInTKBGV_Click(object sender, EventArgs e)
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
                for (int i = 2; i < dgvTKB.Columns.Count + 2; i++)
                {
                    xlWorkSheet.Cells[1, i] = dgvTKB.Columns[i - 2].HeaderText;
                }
                xlWorkBook.SaveAs($"thoikhoabieugv_{newFileName()}.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXemTKBHV_Click(object sender, EventArgs e)
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
                dsTKB = bus.getTKBHV(Convert.ToInt32(txtMaHV.Text));
                dgvTKB.DataSource = dsTKB;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form1.ChangeControlTo(new function_menu(Form1.TKDaDangNhap));
        }

        private bool CopyAlltoClipboard()
        {
            dgvTKB.SelectAll();
            DataObject dataObj = dgvTKB.GetClipboardContent();
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

        private void btnXuatExcelHV_Click(object sender, EventArgs e)
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
                for (int i = 2; i < dgvTKB.Columns.Count + 2; i++)
                {
                    xlWorkSheet.Cells[1, i] = dgvTKB.Columns[i - 2].HeaderText;
                }
                xlWorkBook.SaveAs($"thoikhoabieuhv_{newFileName()}.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
