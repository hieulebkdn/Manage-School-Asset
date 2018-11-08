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
    public partial class FormSuaCTT : Form
    {
        public QLTS_BLL bll;
        public delegate void myDelegate(TAISAN myTS, int SoLuongCu);
        public myDelegate d;
        static int SoLuongCu = 0;

        public FormSuaCTT()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();
        }

        public void InitializeControl()
        {
            comboBoxMaCTT.DataSource = bll.GetListMaCTT();

        }

        private void comboBoxMaCTT_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> myList = bll.GetThongTinCTT(comboBoxMaCTT.SelectedValue.ToString());
            textBoxMaTS.Text = myList[0];
            textBoxTenTS.Text = myList[1];
            dateTimePickerGhiTang.Value = DateTime.Parse(myList[2]);
            numericUpDownSoLuong.Minimum = bll.GetMaxSoLuongCTT(comboBoxMaCTT.SelectedValue.ToString())-bll.GetMaxSoLuong(textBoxMaTS.Text);
            numericUpDownSoLuong.Value = int.Parse(myList[3]);
            textBoxThanhTien.Text = myList[4];
            textBoxNoiDung.Text = myList[5];
            SoLuongCu = int.Parse(myList[3]);
            //textBoxDonGia.Text = ( ( 10 * int.Parse(myList[4] ) ) / ( 11 * int.Parse(myList[3]) ) ).ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TAISAN newTS = new TAISAN();
            newTS.MaChungTuTang = comboBoxMaCTT.SelectedValue.ToString();
            newTS.NgayGhiTang = dateTimePickerGhiTang.Value;
            newTS.SoLuongCTT = int.Parse(numericUpDownSoLuong.Value.ToString());
            int tien;
            Int32.TryParse(textBoxThanhTien.Text, out tien);
            newTS.ThanhTien = tien;
            newTS.NoiDung = textBoxNoiDung.Text;

            d.Invoke(newTS,SoLuongCu);
            this.Close();
        }

        private void ShowThanhTien()
        {
            float dongia;
            float.TryParse(textBoxDonGia.Text, out dongia);
            textBoxThanhTien.Text = ((int)(dongia + dongia / 10) * int.Parse(numericUpDownSoLuong.Value.ToString())).ToString();
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
