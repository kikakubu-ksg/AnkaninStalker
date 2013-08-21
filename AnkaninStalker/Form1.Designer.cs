namespace AnkaninStalker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSwitch = new System.Windows.Forms.Button();
            this.panel_info = new System.Windows.Forms.Panel();
            this.button_reset = new System.Windows.Forms.Button();
            this.label_m2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_m1 = new System.Windows.Forms.Label();
            this.panel_error = new System.Windows.Forms.Panel();
            this.label_error = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.安価人レス = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_threadname = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel_info.SuspendLayout();
            this.panel_error.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.バージョン情報ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(281, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            this.設定ToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSwitch.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSwitch.Location = new System.Drawing.Point(179, 0);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(48, 45);
            this.buttonSwitch.TabIndex = 1;
            this.buttonSwitch.Text = "button1";
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.buttonSwitch_Click);
            // 
            // panel_info
            // 
            this.panel_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_info.Controls.Add(this.button_reset);
            this.panel_info.Controls.Add(this.label_m2);
            this.panel_info.Controls.Add(this.label2);
            this.panel_info.Controls.Add(this.label_m1);
            this.panel_info.Controls.Add(this.buttonSwitch);
            this.panel_info.Location = new System.Drawing.Point(1, 27);
            this.panel_info.Name = "panel_info";
            this.panel_info.Size = new System.Drawing.Size(280, 98);
            this.panel_info.TabIndex = 2;
            // 
            // button_reset
            // 
            this.button_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_reset.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_reset.Location = new System.Drawing.Point(227, 0);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(50, 45);
            this.button_reset.TabIndex = 5;
            this.button_reset.Text = "リセ\r\nット";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_m2
            // 
            this.label_m2.AutoSize = true;
            this.label_m2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_m2.Location = new System.Drawing.Point(4, 53);
            this.label_m2.Name = "label_m2";
            this.label_m2.Size = new System.Drawing.Size(149, 33);
            this.label_m2.TabIndex = 4;
            this.label_m2.Text = "--分--秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(208, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "経過";
            // 
            // label_m1
            // 
            this.label_m1.AutoSize = true;
            this.label_m1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_m1.Location = new System.Drawing.Point(10, 9);
            this.label_m1.Name = "label_m1";
            this.label_m1.Size = new System.Drawing.Size(111, 19);
            this.label_m1.TabIndex = 2;
            this.label_m1.Text = "最終レスから";
            // 
            // panel_error
            // 
            this.panel_error.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_error.Controls.Add(this.label_error);
            this.panel_error.Location = new System.Drawing.Point(1, 131);
            this.panel_error.Name = "panel_error";
            this.panel_error.Size = new System.Drawing.Size(280, 21);
            this.panel_error.TabIndex = 3;
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(1, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 12);
            this.label_error.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(0, 196);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(278, 144);
            this.textBox1.TabIndex = 4;
            // 
            // 安価人レス
            // 
            this.安価人レス.AutoSize = true;
            this.安価人レス.Location = new System.Drawing.Point(2, 181);
            this.安価人レス.Name = "安価人レス";
            this.安価人レス.Size = new System.Drawing.Size(59, 12);
            this.安価人レス.TabIndex = 5;
            this.安価人レス.Text = "安価人レス";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID：";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(184, 181);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(57, 12);
            this.label_ID.TabIndex = 7;
            this.label_ID.Text = "AnkaninID";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_threadname
            // 
            this.label_threadname.AutoSize = true;
            this.label_threadname.Location = new System.Drawing.Point(2, 163);
            this.label_threadname.Name = "label_threadname";
            this.label_threadname.Size = new System.Drawing.Size(51, 12);
            this.label_threadname.TabIndex = 8;
            this.label_threadname.Text = "スレッド名";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 339);
            this.Controls.Add(this.label_threadname);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.安価人レス);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_error);
            this.Controls.Add(this.panel_info);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AnkaninStalker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_info.ResumeLayout(false);
            this.panel_info.PerformLayout();
            this.panel_error.ResumeLayout(false);
            this.panel_error.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private System.Windows.Forms.Button buttonSwitch;
        private System.Windows.Forms.Panel panel_info;
        private System.Windows.Forms.Panel panel_error;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label 安価人レス;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_m1;
        private System.Windows.Forms.Label label_m2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label_threadname;
    }
}

