namespace EasyGenerator.Studio
{
    partial class LoginWindowDlg
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEntity = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAccountField = new System.Windows.Forms.ComboBox();
            this.cmbPasswordField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "Master Entity:";
            // 
            // cmbEntity
            // 
            this.cmbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntity.FormattingEnabled = true;
            this.cmbEntity.Location = new System.Drawing.Point(107, 58);
            this.cmbEntity.Name = "cmbEntity";
            this.cmbEntity.Size = new System.Drawing.Size(220, 20);
            this.cmbEntity.TabIndex = 21;
            this.cmbEntity.SelectedIndexChanged += new System.EventHandler(this.cmbEntity_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 38);
            this.label4.TabIndex = 18;
            this.label4.Text = "添加窗口信息，Name只能由英文字母、数字、下划线组成，第一个符号不能为数据和下划线。";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 192);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(219, 58);
            this.txtDescription.TabIndex = 17;
            this.txtDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Description:";
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(106, 111);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(220, 21);
            this.txtCaption.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Caption:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 84);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 21);
            this.txtName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "Password Field:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "Account Field:";
            // 
            // cmbAccountField
            // 
            this.cmbAccountField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountField.FormattingEnabled = true;
            this.cmbAccountField.Location = new System.Drawing.Point(105, 138);
            this.cmbAccountField.Name = "cmbAccountField";
            this.cmbAccountField.Size = new System.Drawing.Size(220, 20);
            this.cmbAccountField.TabIndex = 26;
            // 
            // cmbPasswordField
            // 
            this.cmbPasswordField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPasswordField.FormattingEnabled = true;
            this.cmbPasswordField.Location = new System.Drawing.Point(105, 165);
            this.cmbPasswordField.Name = "cmbPasswordField";
            this.cmbPasswordField.Size = new System.Drawing.Size(220, 20);
            this.cmbPasswordField.TabIndex = 27;
            // 
            // LoginWindowDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 295);
            this.Controls.Add(this.cmbPasswordField);
            this.Controls.Add(this.cmbAccountField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbEntity);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "LoginWindowDlg";
            this.Text = "LoginWindowDlg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmbEntity;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbAccountField;
        public System.Windows.Forms.ComboBox cmbPasswordField;
    }
}