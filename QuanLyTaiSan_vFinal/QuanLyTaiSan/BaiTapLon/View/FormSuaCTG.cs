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
    public partial class FormSuaCTG : Form
    {
        public QLTS_BLL bll;
        public delegate void myDelegate(CHUNGTUGIAM myCTG, int slc);
        public myDelegate d;
        

        static int SoLuongCu= 0;

        public FormSuaCTG()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();
        }

        public void InitializeControl()
        {
            comboBoxMaCTGiam.DataSource = bll.GetListMaCTG();
        }

        private void comboBoxMaCTGiam_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> myList = bll.GetThongTinCTG(comboBoxMaCTGiam.SelectedValue.ToString());
            textBoxMaTS.Text = myList[0].ToString();
            numericUpDownSoLuong.Maximum = int.Parse(myList[1].ToString()) + bll.GetMaxSoLuong(textBoxMaTS.Text);
            numericUpDownSoLuong.Value = int.Parse(myList[1].ToString());
            dateTimePickerGhiGiam.Value = DateTime.Parse(myList[2].ToString());
            textBoxNoiDung.Text = myList[3].ToString();
            textBoxGhiChu.Text = myList[4].ToString();
            textBoxThanhTien.Text = myList[5].ToString();

            SoLuongCu = int.Parse(numericUpDownSoLuong.Value.ToString());
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CHUNGTUGIAM newCTG = new CHUNGTUGIAM();
            newCTG.MaChungTuGiam = comboBoxMaCTGiam.SelectedValue.ToString();
            newCTG.SoLuong = int.Parse(numericUpDownSoLuong.Value.ToString());
            newCTG.MaTS = textBoxMaTS.Text;
            newCTG.NgayGhiGiam = dateTimePickerGhiGiam.Value;
            newCTG.NoiDung = textBoxNoiDung.Text;
            newCTG.GhiChu = textBoxGhiChu.Text;
            int tien;
            Int32.TryParse(textBoxThanhTien.Text, out tien);
            newCTG.ThanhTien = tien;

            d.Invoke(newCTG, SoLuongCu);
            this.Close();
            MessageBox.Show("Sửa chứng từ giảm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
