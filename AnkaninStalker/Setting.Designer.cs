namespace AnkaninStalker
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Thread = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Limit1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Limit2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Setting_OK = new System.Windows.Forms.Button();
            this.button_Setting_CNS = new System.Windows.Forms.Button();
            this.checkBox_topmost = new System.Windows.Forms.CheckBox();
            this.checkBox_viewname = new System.Windows.Forms.CheckBox();
            this.checkBox_viewmail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "スレURL（２ｃｈまたはしたらば）";
            // 
            // textBox_Thread
            // 
            this.textBox_Thread.Location = new System.Drawing.Point(7, 21);
            this.textBox_Thread.Name = "textBox_Thread";
            this.textBox_Thread.Size = new System.Drawing.Size(423, 19);
            this.textBox_Thread.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "安価人ID";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(7, 62);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(153, 19);
            this.textBox_ID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "制限時間１";
            // 
            // textBox_Limit1
            // 
            this.textBox_Limit1.Location = new System.Drawing.Point(23, 103);
            this.textBox_Limit1.Name = "textBox_Limit1";
            this.textBox_Limit1.Size = new System.Drawing.Size(47, 19);
            this.textBox_Limit1.TabIndex = 5;
            this.textBox_Limit1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Limit1_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "分";
            // 
            // textBox_Limit2
            // 
            this.textBox_Limit2.Location = new System.Drawing.Point(23, 141);
            this.textBox_Limit2.Name = "textBox_Limit2";
            this.textBox_Limit2.Size = new System.Drawing.Size(47, 19);
            this.textBox_Limit2.TabIndex = 7;
            this.textBox_Limit2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Limit2_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "制限時間２";
            // 
            // button_Setting_OK
            // 
            this.button_Setting_OK.Location = new System.Drawing.Point(259, 176);
            this.button_Setting_OK.Name = "button_Setting_OK";
            this.button_Setting_OK.Size = new System.Drawing.Size(75, 23);
            this.button_Setting_OK.TabIndex = 10;
            this.button_Setting_OK.Text = "OK";
            this.button_Setting_OK.UseVisualStyleBackColor = true;
            this.button_Setting_OK.Click += new System.EventHandler(this.button_Setting_OK_Click);
            // 
            // button_Setting_CNS
            // 
            this.button_Setting_CNS.Location = new System.Drawing.Point(343, 176);
            this.button_Setting_CNS.Name = "button_Setting_CNS";
            this.button_Setting_CNS.Size = new System.Drawing.Size(75, 23);
            this.button_Setting_CNS.TabIndex = 11;
            this.button_Setting_CNS.Text = "キャンセル";
            this.button_Setting_CNS.UseVisualStyleBackColor = true;
            this.button_Setting_CNS.Click += new System.EventHandler(this.button_Setting_CNS_Click);
            // 
            // checkBox_topmost
            // 
            this.checkBox_topmost.AutoSize = true;
            this.checkBox_topmost.Location = new System.Drawing.Point(235, 62);
            this.checkBox_topmost.Name = "checkBox_topmost";
            this.checkBox_topmost.Size = new System.Drawing.Size(114, 16);
            this.checkBox_topmost.TabIndex = 12;
            this.checkBox_topmost.Text = "常に最前面に表示";
            this.checkBox_topmost.UseVisualStyleBackColor = true;
            // 
            // checkBox_viewname
            // 
            this.checkBox_viewname.AutoSize = true;
            this.checkBox_viewname.Location = new System.Drawing.Point(235, 84);
            this.checkBox_viewname.Name = "checkBox_viewname";
            this.checkBox_viewname.Size = new System.Drawing.Size(100, 16);
            this.checkBox_viewname.TabIndex = 13;
            this.checkBox_viewname.Text = "名前を表示する";
            this.checkBox_viewname.UseVisualStyleBackColor = true;
            // 
            // checkBox_viewmail
            // 
            this.checkBox_viewmail.AutoSize = true;
            this.checkBox_viewmail.Location = new System.Drawing.Point(235, 105);
            this.checkBox_viewmail.Name = "checkBox_viewmail";
            this.checkBox_viewmail.Size = new System.Drawing.Size(116, 16);
            this.checkBox_viewmail.TabIndex = 14;
            this.checkBox_viewmail.Text = "メール欄を表示する";
            this.checkBox_viewmail.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 211);
            this.Controls.Add(this.checkBox_viewmail);
            this.Controls.Add(this.checkBox_viewname);
            this.Controls.Add(this.checkBox_topmost);
            this.Controls.Add(this.button_Setting_CNS);
            this.Controls.Add(this.button_Setting_OK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Limit2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Limit1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Thread);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.Text = "設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Thread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Limit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Limit2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Setting_OK;
        private System.Windows.Forms.Button button_Setting_CNS;
        private System.Windows.Forms.CheckBox checkBox_topmost;
        private System.Windows.Forms.CheckBox checkBox_viewname;
        private System.Windows.Forms.CheckBox checkBox_viewmail;
    }
}