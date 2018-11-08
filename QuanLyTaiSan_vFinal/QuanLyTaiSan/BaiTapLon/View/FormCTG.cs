using BaiTapLon.BLL;
using BaiTapLon.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon.View
{
    public partial class FormCTG : Form
    {
        public QLTS_BLL bll;
        public delegate void myDelegate(CHUNGTUGIAM myCTG);
        public myDelegate d;
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public FormCTG()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();

        }

        public void InitializeControl()
        {
            comboBoxMaTS.DataSource = bll.GetListMaTS();
            numericUpDownSoLuong.Minimum = 0;
            textBoxMaCTG.Text = "02-TSCĐ-" + RandomString(8);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool isGoodToGo = true;
            foreach (object ob in bll.GetListMaCTG())
            {
                if (textBoxMaCTG.Text == ob.ToString())
                {
                    MessageBox.Show("Nhập lại mã chứng từ giảm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isGoodToGo = false;
                    break;
                }
            }
            if (String.IsNullOrEmpty(textBoxMaCTG.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã chứng từ giảm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isGoodToGo = false;
            }

            if (isGoodToGo)
            {
                CHUNGTUGIAM myCTG = new CHUNGTUGIAM();
                myCTG.MaChungTuGiam = textBoxMaCTG.Text;
                myCTG.MaTS = comboBoxMaTS.SelectedValue.ToString();
                myCTG.NgayGhiGiam = DateTime.Parse(dateTimePickerGhiGiam.Value.ToShortDateString());
                myCTG.SoLuong = int.Parse(numericUpDownSoLuong.Value.ToString());
                int tien;
                Int32.TryParse(textBoxThanhTien.Text, out tien);
                myCTG.ThanhTien = tien;
                myCTG.NoiDung = textBoxNoiDung.Text;
                myCTG.GhiChu = textBoxGhiChu.Text;
                d.Invoke(myCTG);

                this.Close();
                MessageBox.Show("Thêm chứng từ giảm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxMaTS_SelectedValueChanged(object sender, EventArgs e)
        {
            numericUpDownSoLuong.Maximum = bll.GetMaxSoLuong(comboBoxMaTS.SelectedValue.ToString());
            textBoxDonGia.Text = bll.GetDonGia(comboBoxMaTS.SelectedValue.ToString()).ToString();
        }

        private void ShowThanhTien()
        {
            int dongia;
            int.TryParse(textBoxDonGia.Text, out dongia);
            textBoxThanhTien.Text = ((int)dongia * int.Parse(numericUpDownSoLuong.Value.ToString())).ToString();
        }

        private void textBoxDonGia_TextChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }
    }
}
