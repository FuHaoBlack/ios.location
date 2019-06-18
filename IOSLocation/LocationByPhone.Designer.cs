namespace IOSLocation
{
    partial class LocationByPhone
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.BtnMap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextDeviation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectPhone = new System.Windows.Forms.Button();
            this.cmbPhone = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCheckPhone = new System.Windows.Forms.Button();
            this.btnLocationDB = new System.Windows.Forms.Button();
            this.btnLocationDN = new System.Windows.Forms.Button();
            this.btnLocationXN = new System.Windows.Forms.Button();
            this.btnLocationXB = new System.Windows.Forms.Button();
            this.btnLocationN = new System.Windows.Forms.Button();
            this.btnLocationX = new System.Windows.Forms.Button();
            this.btnLocationD = new System.Windows.Forms.Button();
            this.btnLocationB = new System.Windows.Forms.Button();
            this.TextSpeed = new System.Windows.Forms.TextBox();
            this.TextLocation = new System.Windows.Forms.TextBox();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnLocationReset = new System.Windows.Forms.Button();
            this.TextLog = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(82, 11);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(215, 20);
            this.cmbLocation.TabIndex = 45;
            this.cmbLocation.SelectedValueChanged += new System.EventHandler(this.cmbLocation_SelectedValueChanged);
            // 
            // BtnMap
            // 
            this.BtnMap.Location = new System.Drawing.Point(702, 9);
            this.BtnMap.Name = "BtnMap";
            this.BtnMap.Size = new System.Drawing.Size(75, 23);
            this.BtnMap.TabIndex = 44;
            this.BtnMap.Text = "地图";
            this.BtnMap.UseVisualStyleBackColor = true;
            this.BtnMap.Click += new System.EventHandler(this.BtnMap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "修正偏移";
            this.label2.Visible = false;
            // 
            // TextDeviation
            // 
            this.TextDeviation.Location = new System.Drawing.Point(578, 219);
            this.TextDeviation.Name = "TextDeviation";
            this.TextDeviation.Size = new System.Drawing.Size(110, 21);
            this.TextDeviation.TabIndex = 42;
            this.TextDeviation.Text = "0.0114,0.0028";
            this.TextDeviation.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 41;
            this.label1.Text = "定位坐标";
            // 
            // btnSelectPhone
            // 
            this.btnSelectPhone.Location = new System.Drawing.Point(609, 38);
            this.btnSelectPhone.Name = "btnSelectPhone";
            this.btnSelectPhone.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPhone.TabIndex = 40;
            this.btnSelectPhone.Text = "连接设备";
            this.btnSelectPhone.UseVisualStyleBackColor = true;
            this.btnSelectPhone.Click += new System.EventHandler(this.btnSelectPhone_Click);
            // 
            // cmbPhone
            // 
            this.cmbPhone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhone.FormattingEnabled = true;
            this.cmbPhone.Location = new System.Drawing.Point(519, 67);
            this.cmbPhone.Name = "cmbPhone";
            this.cmbPhone.Size = new System.Drawing.Size(258, 20);
            this.cmbPhone.TabIndex = 39;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(460, 430);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 38;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "清空日志";
            // 
            // btnCheckPhone
            // 
            this.btnCheckPhone.Location = new System.Drawing.Point(519, 38);
            this.btnCheckPhone.Name = "btnCheckPhone";
            this.btnCheckPhone.Size = new System.Drawing.Size(75, 23);
            this.btnCheckPhone.TabIndex = 37;
            this.btnCheckPhone.Text = "检测设备";
            this.btnCheckPhone.UseVisualStyleBackColor = true;
            this.btnCheckPhone.Click += new System.EventHandler(this.btnCheckPhone_Click);
            // 
            // btnLocationDB
            // 
            this.btnLocationDB.Location = new System.Drawing.Point(702, 105);
            this.btnLocationDB.Name = "btnLocationDB";
            this.btnLocationDB.Size = new System.Drawing.Size(75, 23);
            this.btnLocationDB.TabIndex = 36;
            this.btnLocationDB.Text = "东北";
            this.btnLocationDB.UseVisualStyleBackColor = true;
            this.btnLocationDB.Click += new System.EventHandler(this.btnLocationDB_Click);
            // 
            // btnLocationDN
            // 
            this.btnLocationDN.Location = new System.Drawing.Point(702, 187);
            this.btnLocationDN.Name = "btnLocationDN";
            this.btnLocationDN.Size = new System.Drawing.Size(75, 23);
            this.btnLocationDN.TabIndex = 35;
            this.btnLocationDN.Text = "东南";
            this.btnLocationDN.UseVisualStyleBackColor = true;
            this.btnLocationDN.Click += new System.EventHandler(this.btnLocationDN_Click);
            // 
            // btnLocationXN
            // 
            this.btnLocationXN.Location = new System.Drawing.Point(519, 187);
            this.btnLocationXN.Name = "btnLocationXN";
            this.btnLocationXN.Size = new System.Drawing.Size(75, 23);
            this.btnLocationXN.TabIndex = 34;
            this.btnLocationXN.Text = "西南";
            this.btnLocationXN.UseVisualStyleBackColor = true;
            this.btnLocationXN.Click += new System.EventHandler(this.btnLocationXN_Click);
            // 
            // btnLocationXB
            // 
            this.btnLocationXB.Location = new System.Drawing.Point(519, 105);
            this.btnLocationXB.Name = "btnLocationXB";
            this.btnLocationXB.Size = new System.Drawing.Size(75, 23);
            this.btnLocationXB.TabIndex = 33;
            this.btnLocationXB.Text = "西北";
            this.btnLocationXB.UseVisualStyleBackColor = true;
            this.btnLocationXB.Click += new System.EventHandler(this.btnLocationXB_Click);
            // 
            // btnLocationN
            // 
            this.btnLocationN.Location = new System.Drawing.Point(609, 187);
            this.btnLocationN.Name = "btnLocationN";
            this.btnLocationN.Size = new System.Drawing.Size(75, 23);
            this.btnLocationN.TabIndex = 32;
            this.btnLocationN.Text = "南";
            this.btnLocationN.UseVisualStyleBackColor = true;
            this.btnLocationN.Click += new System.EventHandler(this.btnLocationN_Click);
            // 
            // btnLocationX
            // 
            this.btnLocationX.Location = new System.Drawing.Point(519, 146);
            this.btnLocationX.Name = "btnLocationX";
            this.btnLocationX.Size = new System.Drawing.Size(75, 23);
            this.btnLocationX.TabIndex = 31;
            this.btnLocationX.Text = "西";
            this.btnLocationX.UseVisualStyleBackColor = true;
            this.btnLocationX.Click += new System.EventHandler(this.btnLocationX_Click);
            // 
            // btnLocationD
            // 
            this.btnLocationD.Location = new System.Drawing.Point(702, 146);
            this.btnLocationD.Name = "btnLocationD";
            this.btnLocationD.Size = new System.Drawing.Size(75, 23);
            this.btnLocationD.TabIndex = 30;
            this.btnLocationD.Text = "东";
            this.btnLocationD.UseVisualStyleBackColor = true;
            this.btnLocationD.Click += new System.EventHandler(this.btnLocationD_Click);
            // 
            // btnLocationB
            // 
            this.btnLocationB.Location = new System.Drawing.Point(609, 105);
            this.btnLocationB.Name = "btnLocationB";
            this.btnLocationB.Size = new System.Drawing.Size(75, 23);
            this.btnLocationB.TabIndex = 29;
            this.btnLocationB.Text = "北";
            this.btnLocationB.UseVisualStyleBackColor = true;
            this.btnLocationB.Click += new System.EventHandler(this.btnLocationB_Click);
            // 
            // TextSpeed
            // 
            this.TextSpeed.Location = new System.Drawing.Point(609, 148);
            this.TextSpeed.Name = "TextSpeed";
            this.TextSpeed.Size = new System.Drawing.Size(75, 21);
            this.TextSpeed.TabIndex = 28;
            this.TextSpeed.Text = "0.0005";
            // 
            // TextLocation
            // 
            this.TextLocation.Location = new System.Drawing.Point(303, 11);
            this.TextLocation.Name = "TextLocation";
            this.TextLocation.Size = new System.Drawing.Size(210, 21);
            this.TextLocation.TabIndex = 27;
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(519, 9);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 26;
            this.btnLocation.Text = "定位";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnLocationReset
            // 
            this.btnLocationReset.Location = new System.Drawing.Point(609, 9);
            this.btnLocationReset.Name = "btnLocationReset";
            this.btnLocationReset.Size = new System.Drawing.Size(75, 23);
            this.btnLocationReset.TabIndex = 25;
            this.btnLocationReset.Text = "复原";
            this.btnLocationReset.UseVisualStyleBackColor = true;
            this.btnLocationReset.Click += new System.EventHandler(this.btnLocationReset_Click);
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(25, 38);
            this.TextLog.Multiline = true;
            this.TextLog.Name = "TextLog";
            this.TextLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextLog.Size = new System.Drawing.Size(488, 383);
            this.TextLog.TabIndex = 24;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(735, 430);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 46;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "联系作者";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // LocationByPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.BtnMap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextDeviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectPhone);
            this.Controls.Add(this.cmbPhone);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnCheckPhone);
            this.Controls.Add(this.btnLocationDB);
            this.Controls.Add(this.btnLocationDN);
            this.Controls.Add(this.btnLocationXN);
            this.Controls.Add(this.btnLocationXB);
            this.Controls.Add(this.btnLocationN);
            this.Controls.Add(this.btnLocationX);
            this.Controls.Add(this.btnLocationD);
            this.Controls.Add(this.btnLocationB);
            this.Controls.Add(this.TextSpeed);
            this.Controls.Add(this.TextLocation);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.btnLocationReset);
            this.Controls.Add(this.TextLog);
            this.MaximizeBox = false;
            this.Name = "LocationByPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IOS虚拟定位";
            this.Load += new System.EventHandler(this.LocationByPhone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button BtnMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextDeviation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectPhone;
        private System.Windows.Forms.ComboBox cmbPhone;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCheckPhone;
        private System.Windows.Forms.Button btnLocationDB;
        private System.Windows.Forms.Button btnLocationDN;
        private System.Windows.Forms.Button btnLocationXN;
        private System.Windows.Forms.Button btnLocationXB;
        private System.Windows.Forms.Button btnLocationN;
        private System.Windows.Forms.Button btnLocationX;
        private System.Windows.Forms.Button btnLocationD;
        private System.Windows.Forms.Button btnLocationB;
        private System.Windows.Forms.TextBox TextSpeed;
        public System.Windows.Forms.TextBox TextLocation;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnLocationReset;
        private System.Windows.Forms.TextBox TextLog;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

