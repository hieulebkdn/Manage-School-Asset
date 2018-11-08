using BaiTapLon.BLL;
using BaiTapLon.DTO;
using BaiTapLon.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace BaiTapLon
{
    public partial class Form1 : Form
    {
        public QLTS_BLL bll { get; set; }
        static string clickingButton = "TS";

        public Form1()
        {
            InitializeComponent();
            QLTSContext db = new QLTSContext();
            db.TAISANs.Select(p => p);
            bll = new QLTS_BLL();
            button4.Enabled = false;
            LoadCbb();
        }

        private void LoadCbb()
        {
            comboBox1.DataSource = bll.GetListPhong();
            List<string> listSortSX = new List<string> { "Tên tài sản", "Loại tài sản", "Số lượng", "Tỷ lệ hao mòn", "Tỷ lệ còn lại" };
            comboBoxSX.DataSource = listSortSX;
            List<string> listSortSXCTT = new List<string> { "Mã chứng từ", "Tên tài sản", "Ngày ghi tăng", "Số lượng CTT", "Thành tiền" };
            comboBoxSXCTT.DataSource = listSortSXCTT;
            List<string> listSortSXCTG = new List<string> { "Mã chứng từ", "Tên tài sản", "Ngày ghi giảm", "Số lượng", "Thành tiền" };
            comboBoxSXCTG.DataSource = listSortSXCTG;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            buttonTaiSan_Click(sender, e);
        }

        // show tab TS

        private void showTS()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabTaiSan);
            dataGridViewTS.AutoGenerateColumns = false;
            string tenPhong = comboBox1.SelectedItem.ToString();
            dataGridViewTS.DataSource = bll.GetListTaiSan(tenPhong);
            for (int i = 1; i <= dataGridViewTS.Rows.Count; i++)
            {
                dataGridViewTS.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonTaiSan_Click(object sender, EventArgs e)
        {
            showTS();
            clickingButton = "TS";
        }

        // show tab CTT

        private void showCTT()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuTang);
            dataGridViewCTT.AutoGenerateColumns = false;

            string tenPhong = comboBox1.SelectedItem.ToString();
            dataGridViewCTT.DataSource = bll.GetListCTT(tenPhong);
            for (int i = 1; i <= dataGridViewCTT.Rows.Count; i++)
            {
                dataGridViewCTT.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonCTT_Click(object sender, EventArgs e)
        {
            showCTT();
            clickingButton = "CTT";
        }

        // show tab CTG

        private void showCTG()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuGiam);
            dataGridViewCTG.AutoGenerateColumns = false;

            string tenPhong = comboBox1.SelectedItem.ToString();

            dataGridViewCTG.DataSource = bll.GetListCTG(tenPhong);
            for (int i = 1; i <= dataGridViewCTG.Rows.Count; i++)
            {
                dataGridViewCTG.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonCTG_Click(object sender, EventArgs e)
        {
            showCTG();
            clickingButton = "CTG";
        }


        //Xử lý sự kiện click Cell
        private void dataGridViewTS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTS.RowCount != 0)
            {
                string mats = dataGridViewTS.Rows[dataGridViewTS.SelectedCells[0].RowIndex].Cells["Column2"].Value.ToString();
                List<string> myList = bll.GetThongTinTaiSanTS(mats);
                string[] arrHeader = new string[] { "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Thông số kỹ thuật: ", "Giá: ", "Tỷ lệ HM: ", "Tỷ lệ CL:" };

                textBox1.Clear();
                for (int i = 0; i < myList.Count; i++)
                {
                    textBox1.AppendText(String.Format("{0}{1}", arrHeader[i], myList[i].ToString()) + "\n");
                }
            }
        }

        private void dataGridViewCTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCTT.RowCount != 0)
            {

                string mats = dataGridViewCTT.Rows[dataGridViewCTT.SelectedCells[0].RowIndex].Cells["Column17"].Value.ToString();
                List<string> myList = bll.GetThongTinTaiSanTS(mats);
                string[] arrHeader = new string[] { "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Thông số kỹ thuật: ", "Giá: ", "Tỷ lệ HM: ", "Tỷ lệ CL: " };

                textBox2.Clear();
                for (int i = 0; i < myList.Count; i++)
                {
                    textBox2.AppendText(String.Format("{0}{1}", arrHeader[i], myList[i].ToString()) + "\n");
                }
            }
        }

        private void dataGridViewCTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCTG.RowCount != 0)
            {
                string mctg = dataGridViewCTG.Rows[dataGridViewCTG.SelectedCells[0].RowIndex].Cells["Column13"].Value.ToString();
                List<string> myList = bll.GetThongTinTaiSanCTG(mctg);
                string[] arrHeader = new string[] { "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Thông số kỹ thuật: ", "Giá: ", "Tỷ lệ HM: ", "Tỷ lệ CL: " };

                textBox3.Clear();
                for (int i = 0; i < myList.Count; i++)
                {
                    textBox3.AppendText(String.Format("{0}{1}", arrHeader[i], myList[i].ToString()) + "\n");
                }
            }
        }
        // Xong xử lý click Cell


        //Xử lý TAB CTG
        private void addCTG(CHUNGTUGIAM myCTG)
        {
            bll.AddCTG(myCTG);
            showCTG();
        }

        private void buttonThemCTG_Click(object sender, EventArgs e)
        {
            FormCTG f = new FormCTG();
            f.d = new FormCTG.myDelegate(addCTG);
            f.Show();
        }

        private void editCTG(CHUNGTUGIAM myCTG, int SoLuongCu)
        {
            bll.SuaCTG(myCTG, SoLuongCu);
            showCTG();
        }

        private void buttonSuaCTG_Click(object sender, EventArgs e)
        {
            FormSuaCTG f = new FormSuaCTG();
            f.d = new FormSuaCTG.myDelegate(editCTG);
            f.Show();
        }

        private void buttonXoaCTG_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                        "Confirm Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string id = dataGridViewCTG.Rows[dataGridViewCTG.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                bll.XoaCTG(id);
                showCTG();
                MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Xử lý Tab TAISAN

        private void addTS(TAISAN myTS)
        {
            bll.AddTS(myTS);
            showTS();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            FormTS f = new FormTS();
            f.d = new FormTS.myDelegate(addTS);
            f.Show();
        }

        private void editTS(TAISAN newTS)
        {
            bll.SuaTS(newTS);
            showTS();
        }


        private void buttonSua_Click(object sender, EventArgs e)
        {
            FormSuaTS f = new FormSuaTS();
            f.d = new FormSuaTS.myDelegate(editTS);
            f.Show();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                        "Confirm Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string id = dataGridViewTS.Rows[dataGridViewTS.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                bll.XoaTS(id);
                showTS();
                MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //TAB CTT

        private void suaCTT(TAISAN newTS, int SoLuongCu)
        {
            bll.SuaCTT(newTS, SoLuongCu);
            showCTT();
        }

        private void buttonSuaCTT_Click(object sender, EventArgs e)
        {
            FormSuaCTT f = new FormSuaCTT();
            f.d = new FormSuaCTT.myDelegate(suaCTT);
            f.Show();
        }

        private void buttonXoaCTT_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                        "Confirm Delete",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string id = dataGridViewCTT.Rows[dataGridViewCTT.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                bll.XoaCTT(id);
                showCTT();
                MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void exportToExcel(string fullpath)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;

            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);


            List<string> ListMaPhong = bll.GetListMaPhong();
            ListMaPhong.RemoveAt(ListMaPhong.Count - 1);
            foreach (string maphong in ListMaPhong)
            {
                tbStatusBar.Text = "Saving... Please Wait";
                Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(Type.Missing, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], 1, XlSheetType.xlWorksheet);
                xlWorkSheet.Name = bll.getTenPhong(maphong);



                Range r = xlWorkSheet.Range["A8:A10"];
                r.Merge();
                r.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Font.Bold = true;
                r.Cells[1, 1] = "Số TT";


                Range r1 = xlWorkSheet.Range["B8:N8"];
                r1.Merge();
                r1.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r1.Font.Bold = true;
                xlWorkSheet.Cells[8, 2] = "Ghi tăng tài sản, dụng cụ, đồ gỗ";

                Range r2 = xlWorkSheet.Range["O8:S8"];
                r2.Merge();
                r2.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r2.Font.Bold = true;
                r2.Cells[1, 1] = "Ghi giảm tài sản";

                Range r3 = xlWorkSheet.Range["B9:D9"];
                r3.Merge();
                r3.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r3.Font.Bold = true;
                r3.Cells[1, 1] = "Chứng từ";

                xlWorkSheet.Cells[10, 2] = "Mã TS";
                xlWorkSheet.Cells[10, 3] = "Mã số TB";
                xlWorkSheet.Cells[10, 4] = "Mã NSD";

                Range r4 = xlWorkSheet.Range["E9:E10"];
                r4.Merge();
                r4.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r4.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r4.Font.Bold = true;
                r4.Cells[1, 1] = "Tên tài sản cố định, CC, DC  và đồ gỗ ...";

                Range r5 = xlWorkSheet.Range["F9:F10"];
                r5.Merge();
                r5.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r5.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r5.Font.Bold = true;
                r5.Cells[1, 1] = "Số hiệu, thông số kỹ thuật";

                Range r6 = xlWorkSheet.Range["G9:G10"];
                r6.Merge();
                r6.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r6.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r6.Font.Bold = true;
                r6.Cells[1, 1] = "SL";

                Range r7 = xlWorkSheet.Range["H9:H10"];
                r7.Merge();
                r7.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r7.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r7.Font.Bold = true;
                r7.Cells[1, 1] = "Thành tiền";

                Range r8 = xlWorkSheet.Range["I9:I10"];
                r8.Merge();
                r8.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r8.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r8.Font.Bold = true;
                r8.Cells[1, 1] = "Tỷ lệ %CL";

                Range r9 = xlWorkSheet.Range["J9:J10"];
                r9.Merge();
                r9.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r9.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r9.Font.Bold = true;
                r9.Cells[1, 1] = "Tỷ lệ %CL";

                Range r10 = xlWorkSheet.Range["K9:K10"];
                r10.Merge();
                r10.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r10.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r10.Font.Bold = true;
                r10.Cells[1, 1] = "Tỷ lệ %CL";

                Range r11 = xlWorkSheet.Range["L9:L10"];
                r11.Merge();
                r11.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r11.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r11.Font.Bold = true;
                r11.Cells[1, 1] = "Tỷ lệ %CL";

                Range r12 = xlWorkSheet.Range["M9:M10"];
                r12.Merge();
                r12.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r12.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r12.Font.Bold = true;
                r12.Cells[1, 1] = "Tỷ lệ %CL";

                Range r13 = xlWorkSheet.Range["N9:N10"];
                r13.Merge();
                r13.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r13.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r13.Font.Bold = true;
                r13.Cells[1, 1] = "Tỷ lệ HM";

                Range r14 = xlWorkSheet.Range["O9:P9"];
                r14.Merge();
                r14.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r14.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r14.Font.Bold = true;
                r14.Cells[1, 1] = "Chứng từ";

                Range r15 = xlWorkSheet.Range["O10:O10"];
                r15.Merge();
                r15.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r15.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r15.Font.Bold = true;
                r15.Cells[1, 1] = "Ngày";

                Range r16 = xlWorkSheet.Range["P10:P10"];
                r16.Merge();
                r16.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r16.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r16.Font.Bold = true;
                r16.Cells[1, 1] = "Lý do";

                Range r17 = xlWorkSheet.Range["Q9:Q10"];
                r17.Merge();
                r17.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r17.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r17.Font.Bold = true;
                r17.Cells[1, 1] = "Số lượng";

                Range r18 = xlWorkSheet.Range["R9:R10"];
                r18.Merge();
                r18.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r18.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r18.Font.Bold = true;
                r18.Cells[1, 1] = "Thành tiền";

                Range r19 = xlWorkSheet.Range["S9:S10"];
                r19.Merge();
                r19.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r19.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r19.Font.Bold = true;
                r19.Cells[1, 1] = "Ghi chú";

                QLTSContext db = new QLTSContext();

                var s = db.TAISANs.Where(p => p.MaPhong.Contains(maphong)).Select(p => p);
                //new { p.MaTS, p.MaPhong, p.NgayGhiTang, p.TenTS, p.ThongSoKyThuat, p.SoLuongCTT, p.TyLeCL, p.TyLeHM }
                List<TAISAN> li = s.ToList<TAISAN>();


                int begini = 12;
                int beginj = 2;
                int STT = 0;
                foreach (TAISAN ts in li)
                {
                    xlWorkSheet.Cells[begini, beginj - 1] = ++STT;
                    xlWorkSheet.Cells[begini, beginj] = ts.MaTS;
                    xlWorkSheet.Cells[begini, beginj + 1] = ts.MaLoaiTS;
                    xlWorkSheet.Cells[begini, beginj + 2] = ts.NgayGhiTang.Year.ToString();
                    xlWorkSheet.Cells[begini, beginj + 3] = ts.TenTS;
                    xlWorkSheet.Cells[begini, beginj + 4] = ts.ThongSoKyThuat;
                    xlWorkSheet.Cells[begini, beginj + 5] = ts.SoLuong;
                    xlWorkSheet.Cells[begini, beginj + 6] = ts.ThanhTien;
                    xlWorkSheet.Cells[begini, beginj + 7] = ts.TyLeCL;
                    xlWorkSheet.Cells[begini, beginj + 8].Formula = "=I" + begini + "-N" + begini;
                    xlWorkSheet.Cells[begini, beginj + 9].Formula = "=J" + begini + "-N" + begini;
                    xlWorkSheet.Cells[begini, beginj + 10].Formula = "=K" + begini + "-N" + begini;
                    xlWorkSheet.Cells[begini, beginj + 11].Formula = "=L" + begini + "-N" + begini;
                    xlWorkSheet.Cells[begini, beginj + 12] = ts.TyLeHM;


                    List<CHUNGTUGIAM> k = db.CHUNGTUGIAMs.Where(p => p.MaTS.Equals(ts.MaTS)).Select(p => p).ToList<CHUNGTUGIAM>();

                    CHUNGTUGIAM ctg = null;

                    if (k.Count > 0) ctg = k[0];
                    if (ctg != null)
                    {
                        xlWorkSheet.Cells[begini, beginj + 13] = ctg.NgayGhiGiam.Year.ToString();
                        xlWorkSheet.Cells[begini, beginj + 14] = ctg.NoiDung;
                        xlWorkSheet.Cells[begini, beginj + 15] = ctg.SoLuong.ToString();
                        xlWorkSheet.Cells[begini, beginj + 16] = ctg.ThanhTien.ToString();
                        xlWorkSheet.Cells[begini, beginj + 17] = ctg.GhiChu;
                    }
                    begini++;
                }

                Range b = xlWorkSheet.Range[xlWorkSheet.Cells[11, 1], xlWorkSheet.Cells[begini, beginj + 17]];
                b.Borders.LineStyle = XlLineStyle.xlDot;
                b.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                b.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                b.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                b.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();

                Range x = xlWorkSheet.Range["E4:E4"];
                x.Merge();
                xlWorkSheet.Cells[4, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                x.Font.Bold = true;
                x.Font.Size = 22;
                x.Cells[1, 1] = "BẢNG KIỂM KÊ, ĐÁNH GIÁ TÀI SẢN NĂM 2015";

                x = xlWorkSheet.Range["C5:C5"];
                x.Merge();
                xlWorkSheet.Cells[5, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                x.Font.Bold = true;
                x.Font.Size = 16;
                x.Cells[1, 1] = "SỔ THEO DÕI TÀI SẢN CỐ ĐỊNH VÀ CÔNG CỤ, DỤNG CỤ, VRTMH TẠI NƠI SỬ DỤNG";

                xlWorkSheet.Cells[begini + 3, 2] = "  - Gồm : */ Thiết bị : ................mục ; */ Đồ gỗ, VRTNH :.............mục ";
                xlWorkSheet.Cells[begini + 3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                xlWorkSheet.Cells[begini + 4, 2] = "  - Sổ này có ..................trang, đánh số từ trang 01 đến ...........";
                xlWorkSheet.Cells[begini + 4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                xlWorkSheet.Cells[begini + 5, 2] = "  - Ngày mở sổ:.......................";
                xlWorkSheet.Cells[begini + 5, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                xlWorkSheet.Cells[begini + 6, 3] = "Hiệu trưởng";
                xlWorkSheet.Cells[begini + 6, 3].Font.Bold = true;

                xlWorkSheet.Cells[begini + 6, 5] = "Kế toán tài sản";
                xlWorkSheet.Cells[begini + 6, 5].Font.Bold = true;
                xlWorkSheet.Cells[begini + 5, beginj + 14] = "Đà Nẵng, ngày        tháng      năm";
                xlWorkSheet.Cells[begini + 6, beginj + 14] = "Người ghi sổ";
                xlWorkSheet.Cells[begini + 6, beginj + 14].Font.Bold = true;



                Marshal.ReleaseComObject(xlWorkSheet);
            }


            xlWorkBook.SaveAs(fullpath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(0);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            tbStatusBar.Text = "Working normally";
        }


        // EXPORT EXCEL
        private void exportToXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "excel.xls";
            save.Filter = "Microsoft Excel(*.xls)|All File (*.*)";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string pat = Path.GetFullPath(save.FileName);
                exportToExcel(pat);
            }

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "p.xls"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "p.xls");
            }
            exportToExcel(AppDomain.CurrentDomain.BaseDirectory + "p.xls");

            Excel.Application ex = new Excel.Application();
            Excel.Workbook wb = ex.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "p.xls");
            ex.Visible = true;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (clickingButton == "TS") buttonTaiSan_Click(sender, e);
            else if (clickingButton == "CTT") buttonCTT_Click(sender, e);
            else buttonCTG_Click(sender, e);
        }


        //Bắt sự kiện các nút Sắp xếp
        private void buttonSapXep_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabTaiSan);
            dataGridViewTS.DataSource = bll.SortListTaiSan(comboBox1.SelectedItem.ToString(), comboBoxSX.SelectedValue.ToString(), textBoxTim.Text);
            for (int i = 1; i <= dataGridViewTS.Rows.Count; i++)
            {
                dataGridViewTS.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonSapXepCTG_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuGiam);
            dataGridViewCTG.DataSource = bll.SortListCTG(comboBox1.SelectedItem.ToString(), comboBoxSXCTG.SelectedValue.ToString(), textBoxTimCTG.Text);

            for (int i = 1; i <= dataGridViewCTG.Rows.Count; i++)
            {
                dataGridViewCTG.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonSapXepCTT_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuTang);
            dataGridViewCTT.DataSource = bll.SortListCTT(comboBox1.SelectedItem.ToString(), comboBoxSXCTT.SelectedValue.ToString(), textBoxTimCTT.Text);

            for (int i = 1; i <= dataGridViewCTT.Rows.Count; i++)
            {
                dataGridViewCTT.Rows[i - 1].Cells[0].Value = i;
            }
        }


        //Bắt sự kiện các nút Tìm
        private void buttonTim_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabTaiSan);
            dataGridViewTS.DataSource = bll.SearchListTaiSan(comboBox1.SelectedItem.ToString(), textBoxTim.Text);

            for (int i = 1; i <= dataGridViewTS.Rows.Count; i++)
            {
                dataGridViewTS.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonTimCTT_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuTang);
            dataGridViewCTT.DataSource = bll.SearchListCTT(comboBox1.SelectedItem.ToString(), textBoxTimCTT.Text);

            for (int i = 1; i <= dataGridViewCTT.Rows.Count; i++)
            {
                dataGridViewCTT.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void buttonTimCTG_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabChungTuGiam);
            dataGridViewCTG.DataSource = bll.SearchListCTG(comboBox1.SelectedItem.ToString(), textBoxTimCTG.Text);

            for (int i = 1; i <= dataGridViewCTG.Rows.Count; i++)
            {
                dataGridViewCTG.Rows[i - 1].Cells[0].Value = i;
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void importFromXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Microsoft Excel(*.xls)|*.xls";
            string filepath = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = Path.GetFullPath(ofd.FileName);
                string path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
                if (!File.Exists(path)) File.Create(path);
                TextWriter tw = new StreamWriter(path, true);

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Range range;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                int count = 0;
                foreach (Worksheet xlWorkSheet in xlWorkBook.Worksheets)
                {
                    int begini, beginj;
                    begini = 12;
                    beginj = 2;
                    while (xlWorkSheet.Cells[begini, beginj].Value2 != null)
                    {
                        TAISAN ts = new TAISAN();
                        ts.MaTS = xlWorkSheet.Cells[begini, beginj].Value2.ToString();

                        try
                        {
                            ts.MaPhong = bll.GetMaPhong(xlWorkSheet.Name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi tên phòng");
                        }
                        ts.MaLoaiTS = xlWorkSheet.Cells[begini, beginj + 1].Value2.ToString();
                        ts.NgayGhiTang = Convert.ToDateTime("1/1/" + xlWorkSheet.Cells[begini, beginj + 2].Value2.ToString());
                        ts.TenTS = xlWorkSheet.Cells[begini, beginj + 3].Value2.ToString();
                        ts.ThongSoKyThuat = xlWorkSheet.Cells[begini, beginj + 4].Value2.ToString();
                        ts.SoLuong = int.Parse(xlWorkSheet.Cells[begini, beginj + 5].Value2.ToString());
                        ts.ThanhTien = int.Parse(xlWorkSheet.Cells[begini, beginj + 6].Value2.ToString());
                        ts.TyLeCL = int.Parse(xlWorkSheet.Cells[begini, beginj + 7].Value2.ToString());
                        ts.TyLeHM = int.Parse(xlWorkSheet.Cells[begini, beginj + 12].Value2.ToString());
                        ts.MaChungTuTang = RandomString(8);
                        try
                        {
                            count++;
                            bll.AddTS(ts);
                        }
                        catch (Exception ex)
                        {
                            tw.WriteLine("**********" + DateTime.Now + "**********");
                            tw.WriteLine("Imported File: " + filepath + "Line " + begini);
                            count--;
                            begini++;
                            continue;
                        }

                        if (xlWorkSheet.Cells[begini, beginj + 13].Value2 != null)
                        {
                            CHUNGTUGIAM ctg = new CHUNGTUGIAM();
                            ctg.MaChungTuGiam = ts.MaTS + "ctg";
                            ctg.MaTS = ts.MaTS;
                            ctg.NgayGhiGiam = Convert.ToDateTime("1/1/" + xlWorkSheet.Cells[begini, beginj + 13].Value2.ToString());
                            ctg.NoiDung = xlWorkSheet.Cells[begini, beginj + 14].Value2.ToString();
                            ctg.SoLuong = int.Parse(xlWorkSheet.Cells[begini, beginj + 15].Value2.ToString());
                            ctg.ThanhTien = int.Parse(xlWorkSheet.Cells[begini, beginj + 16].Value2.ToString());
                            ctg.GhiChu = xlWorkSheet.Cells[begini, beginj + 17].Value2.ToString();
                            MessageBox.Show(ctg.MaChungTuGiam);
                            bll.AddCTG(ctg);
                        }
                        begini++;

                    }
                    tw.Close();
                }

                MessageBox.Show("Có " + count.ToString() + " hàng dữ liệu được nhập thành công!");
                MessageBox.Show("Các hàng lỗi được ghi ra ở file " + AppDomain.CurrentDomain.BaseDirectory + "log.txt");
            }

            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By An,Hieu,Duc 15TCLC2 BKDN");
        }

        private void tựĐộngThanhLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<TAISAN> liTS = bll.GetListTS();
            foreach(TAISAN ts in liTS)
            {
                List<CHUNGTUGIAM> ThongtinCtg = bll.GetThongTinCTGbyMaTS(ts.MaTS);
                if (ThongtinCtg.Count > 0) continue;

                int nsd = ts.NgayGhiTang.Year;
                int now = DateTime.Now.Year;

                if(ts.TyLeCL - ts.TyLeHM*(now-nsd) == 0)
                {
                    count++;
                    CHUNGTUGIAM ctg = new CHUNGTUGIAM();
                    ctg.MaChungTuGiam = RandomString(8);
                    ctg.MaTS = ts.MaTS;
                    ctg.NgayGhiGiam = DateTime.Now;
                    ctg.SoLuong = ts.SoLuong;
                    ctg.ThanhTien = ts.ThanhTien;
                    ctg.NoiDung = "Thanh lý hao mòn dưới 0%";
                    ctg.GhiChu = "";

                    bll.AddCTG(ctg);
                }
            }
            MessageBox.Show("Đã thanh lý " + count.ToString() + " tài sản có tỷ lệ còn lại dưới 0%!");

        }
    }
}
