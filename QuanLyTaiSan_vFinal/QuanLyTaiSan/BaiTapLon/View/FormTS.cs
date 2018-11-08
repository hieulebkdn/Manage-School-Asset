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
    public partial class FormTS : Form
    {

        public QLTS_BLL bll;
        public delegate void myDelegate(TAISAN myTS);
        public myDelegate d;
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public FormTS()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();
        }

        public void InitializeControl()
        {
            List<string> myPhong = bll.GetListPhong();
            myPhong.RemoveAt(myPhong.Count - 1);
            comboBox1.DataSource = myPhong;
            comboBoxTenLoaiTS.DataSource = bll.GetListTenLoaiTS();
            textBoxMaCTT.Text = "01-TSCĐ-" + RandomString(8);
            comboBox1.SelectedIndex = 0;
            comboBoxTenLoaiTS.SelectedIndex = 0;
            numericUpDownTyLeHM.Maximum = 100;
            numericUpDownTyLeCL.Maximum = 100;
            numericUpDownVAT.Maximum = 100;
            numericUpDownSoLuong.Minimum = 1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Check textBoxMaTS, textBoxMaCTT == null or duplicated ?
            bool isGoodToGo = true;
            if (String.IsNullOrEmpty(textBoxMaTS.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã tài sản", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isGoodToGo = false;
            }
            foreach (object ob in bll.GetListMaTS())
            {
                if (textBoxMaTS.Text.Equals(ob.ToString()))
                {
                    MessageBox.Show("Nhập lại mã tài sản", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    isGoodToGo = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(textBoxMaCTT.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã chứng từ tăng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isGoodToGo = false;
            }

            foreach (string ob in bll.GetListMaCTT())
            {
                if (textBoxMaCTT.Text.Equals(ob.ToString()))
                {
                    MessageBox.Show("Nhập lại mã chứng từ tăng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isGoodToGo = false;
                    break;
                }
            }

            if (isGoodToGo)
            {
                TAISAN myTS = new TAISAN();
                myTS.MaTS = textBoxMaTS.Text;
                myTS.MaLoaiTS = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedValue.ToString());
                myTS.MaPhong = bll.GetMaPhong(comboBox1.SelectedValue.ToString());
                myTS.TenTS = textBoxTenTS.Text;
                myTS.MaChungTuTang = textBoxMaCTT.Text;
                myTS.ThongSoKyThuat = textBoxTSKT.Text;
                int tien;
                Int32.TryParse(textBoxThanhTien.Text, out tien);
                myTS.ThanhTien = tien;
                myTS.SoLuong = myTS.SoLuongCTT = int.Parse(numericUpDownSoLuong.Value.ToString());
                myTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                myTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());
                myTS.GhiChu = textBoxGhiChu.Text;
                myTS.NgayGhiTang = DateTime.Parse(dateTimePickerGhiTang.Value.ToShortDateString());
                myTS.NoiDung = textBoxNoiDung.Text;
                d.Invoke(myTS);

                this.Close();
                MessageBox.Show("Thêm tài sản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowThanhTien()
        {
            float dongia;
            float.TryParse(textBoxDonGia.Text, out dongia);
            textBoxThanhTien.Text = ((int)(dongia + (dongia * int.Parse(numericUpDownVAT.Value.ToString())) / 100) * int.Parse(numericUpDownSoLuong.Value.ToString())).ToString();
        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void textBoxDonGia_TextChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }


        private void numericUpDownVAT_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void FormTS_Load(object sender, EventArgs e)
        {
            string MaLoaiTaiSan = bll.GetMaLoaiTS(comboBoxTenLoaiTS.Text);
            string MaPhong = bll.GetMaPhong(comboBox1.Text);

            textBoxMaTS.Text = bll.getMaTaiSan(MaLoaiTaiSan, MaPhong);
        }

        private void comboBoxTenLoaiTS_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MaLoaiTaiSan = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedItem.ToString());
            string MaPhong = bll.GetMaPhong(comboBox1.SelectedItem.ToString());

            textBoxMaTS.Text = bll.getMaTaiSan(MaLoaiTaiSan, MaPhong);
        }

        private void comboBoxTenLoaiTS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MaLoaiTaiSan = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedItem.ToString());
            string MaPhong = bll.GetMaPhong(comboBox1.SelectedItem.ToString());

            textBoxMaTS.Text = bll.getMaTaiSan(MaLoaiTaiSan, MaPhong);
        }
    }
}
