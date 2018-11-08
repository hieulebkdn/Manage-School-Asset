namespace BaiTapLon.View
{
    partial class FormCTG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCTG));
            this.labelMaTS = new System.Windows.Forms.Label();
            this.comboBoxMaTS = new System.Windows.Forms.ComboBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaCTG = new System.Windows.Forms.TextBox();
            this.dateTimePickerGhiGiam = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNoiDung = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxThanhTien = new System.Windows.Forms.TextBox();
            this.numericUpDownSoLuong = new System.Windows.Forms.NumericUpDown();
            this.textBoxDonGia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMaTS
            // 
            this.labelMaTS.AutoSize = true;
            this.labelMaTS.Location = new System.Drawing.Point(12, 18);
            this.labelMaTS.Name = "labelMaTS";
            this.labelMaTS.Size = new System.Drawing.Size(56, 13);
            this.labelMaTS.TabIndex = 0;
            this.labelMaTS.Text = "Mã tài sản";
            // 
            // comboBoxMaTS
            // 
            this.comboBoxMaTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaTS.FormattingEnabled = true;
            this.comboBoxMaTS.Location = new System.Drawing.Point(74, 15);
            this.comboBoxMaTS.Name = "comboBoxMaTS";
            this.comboBoxMaTS.Size = new System.Drawing.Size(177, 21);
            this.comboBoxMaTS.TabIndex = 1;
            this.comboBoxMaTS.SelectedValueChanged += new System.EventHandler(this.comboBoxMaTS_SelectedValueChanged);
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(12, 68);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(49, 13);
            this.labelSoLuong.TabIndex = 2;
            this.labelSoLuong.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã CT Giảm";
            // 
            // textBoxMaCTG
            // 
            this.textBoxMaCTG.Location = new System.Drawing.Point(352, 15);
            this.textBoxMaCTG.Name = "textBoxMaCTG";
            this.textBoxMaCTG.ReadOnly = true;
            this.textBoxMaCTG.Size = new System.Drawing.Size(200, 20);
            this.textBoxMaCTG.TabIndex = 5;
            // 
            // dateTimePickerGhiGiam
            // 
            this.dateTimePickerGhiGiam.Location = new System.Drawing.Point(352, 65);
            this.dateTimePickerGhiGiam.Name = "dateTimePickerGhiGiam";
            this.dateTimePickerGhiGiam.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerGhiGiam.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ngày ghi giảm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lý do";
            // 
            // textBoxNoiDung
            // 
            this.textBoxNoiDung.Location = new System.Drawing.Point(352, 116);
            this.textBoxNoiDung.Name = "textBoxNoiDung";
            this.textBoxNoiDung.Size = new System.Drawing.Size(200, 20);
            this.textBoxNoiDung.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(275, 161);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(93, 30);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(429, 161);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ghi chú";
            // 
            // textBoxGhiChu
            // 
            this.textBoxGhiChu.Location = new System.Drawing.Point(74, 167);
            this.textBoxGhiChu.Name = "textBoxGhiChu";
            this.textBoxGhiChu.Size = new System.Drawing.Size(177, 20);
            this.textBoxGhiChu.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Thành tiền";
            // 
            // textBoxThanhTien
            // 
            this.textBoxThanhTien.Enabled = false;
            this.textBoxThanhTien.Location = new System.Drawing.Point(74, 116);
            this.textBoxThanhTien.Name = "textBoxThanhTien";
            this.textBoxThanhTien.Size = new System.Drawing.Size(177, 20);
            this.textBoxThanhTien.TabIndex = 15;
            // 
            // numericUpDownSoLuong
            // 
            this.numericUpDownSoLuong.Location = new System.Drawing.Point(74, 66);
            this.numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            this.numericUpDownSoLuong.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownSoLuong.TabIndex = 16;
            this.numericUpDownSoLuong.ValueChanged += new System.EventHandler(this.numericUpDownSoLuong_ValueChanged);
            // 
            // textBoxDonGia
            // 
            this.textBoxDonGia.Location = new System.Drawing.Point(179, 65);
            this.textBoxDonGia.Name = "textBoxDonGia";
            this.textBoxDonGia.Size = new System.Drawing.Size(72, 20);
            this.textBoxDonGia.TabIndex = 54;
            this.textBoxDonGia.TextChanged += new System.EventHandler(this.textBoxDonGia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Đơn giá";
            // 
            // FormCTG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 212);
            this.Controls.Add(this.textBoxDonGia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDownSoLuong);
            this.Controls.Add(this.textBoxThanhTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxGhiChu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxNoiDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerGhiGiam);
            this.Controls.Add(this.textBoxMaCTG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.comboBoxMaTS);
            this.Controls.Add(this.labelMaTS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCTG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm chứng từ giảm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMaTS;
        private System.Windows.Forms.ComboBox comboBoxMaTS;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaCTG;
        private System.Windows.Forms.DateTimePicker dateTimePickerGhiGiam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNoiDung;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxThanhTien;
        private System.Windows.Forms.NumericUpDown numericUpDownSoLuong;
        private System.Windows.Forms.TextBox textBoxDonGia;
        private System.Windows.Forms.Label label12;
    }
}