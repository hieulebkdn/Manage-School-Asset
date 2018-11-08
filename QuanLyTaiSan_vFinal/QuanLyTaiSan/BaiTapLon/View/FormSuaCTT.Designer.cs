namespace BaiTapLon.View
{
    partial class FormSuaCTT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaCTT));
            this.textBoxMaTS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMaTS = new System.Windows.Forms.Label();
            this.numericUpDownSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerGhiTang = new System.Windows.Forms.DateTimePicker();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.textBoxThanhTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxNoiDung = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMaCTT = new System.Windows.Forms.ComboBox();
            this.textBoxTenTS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDonGia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMaTS
            // 
            this.textBoxMaTS.Location = new System.Drawing.Point(92, 66);
            this.textBoxMaTS.Name = "textBoxMaTS";
            this.textBoxMaTS.ReadOnly = true;
            this.textBoxMaTS.Size = new System.Drawing.Size(230, 20);
            this.textBoxMaTS.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Mã CT Tăng";
            // 
            // labelMaTS
            // 
            this.labelMaTS.AutoSize = true;
            this.labelMaTS.Location = new System.Drawing.Point(10, 69);
            this.labelMaTS.Name = "labelMaTS";
            this.labelMaTS.Size = new System.Drawing.Size(56, 13);
            this.labelMaTS.TabIndex = 34;
            this.labelMaTS.Text = "Mã tài sản";
            // 
            // numericUpDownSoLuong
            // 
            this.numericUpDownSoLuong.Location = new System.Drawing.Point(92, 207);
            this.numericUpDownSoLuong.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            this.numericUpDownSoLuong.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownSoLuong.TabIndex = 41;
            this.numericUpDownSoLuong.ValueChanged += new System.EventHandler(this.numericUpDownSoLuong_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Ngày ghi tăng";
            // 
            // dateTimePickerGhiTang
            // 
            this.dateTimePickerGhiTang.Location = new System.Drawing.Point(93, 160);
            this.dateTimePickerGhiTang.Name = "dateTimePickerGhiTang";
            this.dateTimePickerGhiTang.Size = new System.Drawing.Size(229, 20);
            this.dateTimePickerGhiTang.TabIndex = 39;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(11, 210);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(49, 13);
            this.labelSoLuong.TabIndex = 38;
            this.labelSoLuong.Text = "Số lượng";
            // 
            // textBoxThanhTien
            // 
            this.textBoxThanhTien.Enabled = false;
            this.textBoxThanhTien.Location = new System.Drawing.Point(92, 255);
            this.textBoxThanhTien.Name = "textBoxThanhTien";
            this.textBoxThanhTien.Size = new System.Drawing.Size(230, 20);
            this.textBoxThanhTien.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Thành tiền";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(193, 350);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 30);
            this.buttonCancel.TabIndex = 45;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(77, 350);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(91, 30);
            this.buttonOK.TabIndex = 44;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxNoiDung
            // 
            this.textBoxNoiDung.Location = new System.Drawing.Point(93, 307);
            this.textBoxNoiDung.Name = "textBoxNoiDung";
            this.textBoxNoiDung.Size = new System.Drawing.Size(229, 20);
            this.textBoxNoiDung.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Nội dung";
            // 
            // comboBoxMaCTT
            // 
            this.comboBoxMaCTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaCTT.FormattingEnabled = true;
            this.comboBoxMaCTT.Location = new System.Drawing.Point(92, 17);
            this.comboBoxMaCTT.Name = "comboBoxMaCTT";
            this.comboBoxMaCTT.Size = new System.Drawing.Size(230, 21);
            this.comboBoxMaCTT.TabIndex = 48;
            this.comboBoxMaCTT.SelectedValueChanged += new System.EventHandler(this.comboBoxMaCTT_SelectedValueChanged);
            // 
            // textBoxTenTS
            // 
            this.textBoxTenTS.Location = new System.Drawing.Point(92, 115);
            this.textBoxTenTS.Name = "textBoxTenTS";
            this.textBoxTenTS.ReadOnly = true;
            this.textBoxTenTS.Size = new System.Drawing.Size(230, 20);
            this.textBoxTenTS.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Tên tài sản";
            // 
            // textBoxDonGia
            // 
            this.textBoxDonGia.Location = new System.Drawing.Point(226, 207);
            this.textBoxDonGia.Name = "textBoxDonGia";
            this.textBoxDonGia.Size = new System.Drawing.Size(96, 20);
            this.textBoxDonGia.TabIndex = 52;
            this.textBoxDonGia.TextChanged += new System.EventHandler(this.textBoxDonGia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Đơn giá";
            // 
            // FormSuaCTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 396);
            this.Controls.Add(this.textBoxDonGia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxTenTS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxMaCTT);
            this.Controls.Add(this.textBoxNoiDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxThanhTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerGhiTang);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.textBoxMaTS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMaTS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSuaCTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa chứng từ tăng";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMaTS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMaTS;
        private System.Windows.Forms.NumericUpDown numericUpDownSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerGhiTang;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.TextBox textBoxThanhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMaCTT;
        private System.Windows.Forms.TextBox textBoxTenTS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDonGia;
        private System.Windows.Forms.Label label12;
    }
}