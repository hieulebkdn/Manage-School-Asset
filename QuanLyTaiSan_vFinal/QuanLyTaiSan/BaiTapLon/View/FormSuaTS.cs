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
    public partial class FormSuaTS : Form
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

        public FormSuaTS()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();

        }

        public void InitializeControl()
        {
            comboBoxMaTS.DataSource = bll.GetListMaTS();
            comboBoxTenLoaiTS.DataSource = bll.GetListTenLoaiTS();
            List<string> myList = bll.GetListPhong();
            myList.RemoveAt(myList.Count - 1);
            List<string> myList2 = bll.GetListPhong();
            myList2.RemoveAt(myList2.Count - 1);
            comboBoxPhong.DataSource = myList;
            comboBoxPhongMoi.DataSource = myList2;
            comboBoxPhongMoi.Enabled = false;
            numericUpDown1.Enabled = false;
            
        }

        private void comboBoxMaTS_SelectedValueChanged(object sender, EventArgs e)
        {
            List<string> myList = bll.GetThongTinTS(comboBoxMaTS.SelectedValue.ToString());
            textBoxMaCTT.Text = myList[0];
            comboBoxTenLoaiTS.SelectedItem = myList[1];
            comboBoxPhong.SelectedItem = myList[2];
            textBoxTenTS.Text = myList[3];
            textBoxGhiChu.Text = myList[4];
            textBoxTSKT.Text = myList[5];
            numericUpDownTyLeHM.Value = decimal.Parse(myList[6]);
            numericUpDownTyLeCL.Value = decimal.Parse(myList[7]);
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = bll.GetMaxSoLuong(comboBoxMaTS.SelectedValue.ToString());
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            {
                TAISAN fixTS = new TAISAN();
                fixTS.MaTS = comboBoxMaTS.SelectedValue.ToString();
                fixTS.MaLoaiTS = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedValue.ToString());
                fixTS.MaPhong = bll.GetMaPhong(comboBoxPhong.SelectedValue.ToString());
                fixTS.SoLuong = bll.GetMaxSoLuong(fixTS.MaTS);
                fixTS.ThongSoKyThuat = textBoxTSKT.Text;
                fixTS.GhiChu = textBoxGhiChu.Text;
                fixTS.TenTS = textBoxTenTS.Text;
                fixTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                fixTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());

                d.Invoke(fixTS);

           }
            else
            {
                if(numericUpDown1.Value == bll.GetMaxSoLuong(comboBoxMaTS.SelectedValue.ToString()))
                {
                    TAISAN fixTS = new TAISAN();
                    fixTS.MaTS = comboBoxMaTS.SelectedValue.ToString();
                    fixTS.MaLoaiTS = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedValue.ToString());
                    fixTS.MaPhong = bll.GetMaPhong(comboBoxPhongMoi.SelectedValue.ToString());
                    fixTS.ThongSoKyThuat = textBoxTSKT.Text;
                    fixTS.GhiChu = textBoxGhiChu.Text;
                    fixTS.TenTS = textBoxTenTS.Text;
                    fixTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                    fixTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());
                    fixTS.SoLuong = int.Parse(numericUpDown1.Value.ToString());

                    d.Invoke(fixTS);
                }
                else
                {
                    TAISAN fixTS = new TAISAN();
                    fixTS.MaTS = comboBoxMaTS.SelectedValue.ToString();
                    fixTS.MaLoaiTS = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedValue.ToString());
                    fixTS.MaPhong = bll.GetMaPhong(comboBoxPhong.SelectedValue.ToString());
                    fixTS.ThongSoKyThuat = textBoxTSKT.Text;
                    fixTS.GhiChu = textBoxGhiChu.Text;
                    fixTS.TenTS = textBoxTenTS.Text;
                    fixTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                    fixTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());
                    fixTS.SoLuong = bll.GetMaxSoLuong(comboBoxMaTS.SelectedValue.ToString()) - (int)numericUpDown1.Value;


                    TAISAN newTS = new TAISAN();

                    newTS.MaLoaiTS = bll.GetMaLoaiTS(comboBoxTenLoaiTS.SelectedValue.ToString());
                    newTS.MaPhong = bll.GetMaPhong(comboBoxPhongMoi.SelectedValue.ToString());
                    newTS.ThongSoKyThuat = textBoxTSKT.Text;
                    newTS.GhiChu = textBoxGhiChu.Text;
                    newTS.TenTS = textBoxTenTS.Text;
                    newTS.NgayGhiTang = DateTime.Today;
                    newTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                    newTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());
                    newTS.SoLuong = (int)numericUpDown1.Value;
                    newTS.SoLuongCTT = newTS.SoLuong;
                    newTS.MaChungTuTang = "04-TSCĐ-" + RandomString(8);


                    string MaLoaiTaiSan = ""; MaLoaiTaiSan = newTS.MaLoaiTS;
                    string MaPhong = ""; MaPhong = newTS.MaPhong;

                    newTS.MaTS = bll.getMaTaiSan(MaLoaiTaiSan, MaPhong);
                    bll.AddTS(newTS);
                    d.Invoke(fixTS);
                }
            }
            this.Close();
            MessageBox.Show("Sửa tài sản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                comboBoxPhongMoi.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                comboBoxPhongMoi.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }
    }
}
