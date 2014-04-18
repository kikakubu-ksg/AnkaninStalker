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
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_threadname = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_linenum = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_line = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_wrap = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_talker_last = new System.Windows.Forms.Button();
            this.button_talker_next = new System.Windows.Forms.Button();
            this.button_talker_replay = new System.Windows.Forms.Button();
            this.button_talker_prev = new System.Windows.Forms.Button();
            this.button_talker_first = new System.Windows.Forms.Button();
            this.button_talker_playctl = new System.Windows.Forms.Button();
            this.groupBox_talker = new System.Windows.Forms.GroupBox();
            this.button_talker_go = new System.Windows.Forms.Button();
            this.label_talker_max = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_talker_num = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel_info.SuspendLayout();
            this.panel_error.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_talker.SuspendLayout();
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
            this.buttonSwitch.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonSwitch.Location = new System.Drawing.Point(179, 0);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(48, 45);
            this.buttonSwitch.TabIndex = 1;
            this.buttonSwitch.Text = "追跡\r\n開始";
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
            this.button_reset.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.label_m2.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_m2.Location = new System.Drawing.Point(7, 49);
            this.label_m2.Name = "label_m2";
            this.label_m2.Size = new System.Drawing.Size(140, 44);
            this.label_m2.TabIndex = 4;
            this.label_m2.Text = "--分 --秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(210, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "経過";
            // 
            // label_m1
            // 
            this.label_m1.AutoSize = true;
            this.label_m1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_m1.Location = new System.Drawing.Point(10, 9);
            this.label_m1.Name = "label_m1";
            this.label_m1.Size = new System.Drawing.Size(126, 28);
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
            this.textBox1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 129);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "";
            this.textBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBox1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID：";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(106, 3);
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
            this.label_threadname.Location = new System.Drawing.Point(3, 232);
            this.label_threadname.Name = "label_threadname";
            this.label_threadname.Size = new System.Drawing.Size(51, 12);
            this.label_threadname.TabIndex = 8;
            this.label_threadname.Text = "スレッド名";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 18);
            this.tabControl1.Location = new System.Drawing.Point(1, 247);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 176);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 9;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label_ID);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(272, 150);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "安価人レス";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_linenum);
            this.tabPage2.Controls.Add(this.button_save);
            this.tabPage2.Controls.Add(this.button_load);
            this.tabPage2.Controls.Add(this.button_line);
            this.tabPage2.Controls.Add(this.button_clear);
            this.tabPage2.Controls.Add(this.button_wrap);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 161);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "メモ帳";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_linenum
            // 
            this.label_linenum.AutoSize = true;
            this.label_linenum.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_linenum.Location = new System.Drawing.Point(7, 10);
            this.label_linenum.Name = "label_linenum";
            this.label_linenum.Size = new System.Drawing.Size(35, 12);
            this.label_linenum.TabIndex = 6;
            this.label_linenum.Text = "0行目";
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.BackgroundImage = global::AnkaninStalker.Properties.Resources.save;
            this.button_save.Location = new System.Drawing.Point(152, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(24, 24);
            this.button_save.TabIndex = 5;
            this.toolTip1.SetToolTip(this.button_save, "メモを保存します（Ctrl+S）");
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_load.BackgroundImage = global::AnkaninStalker.Properties.Resources.load;
            this.button_load.Location = new System.Drawing.Point(176, 3);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(24, 24);
            this.button_load.TabIndex = 4;
            this.toolTip1.SetToolTip(this.button_load, "メモをロードします（Ctrl+L）");
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_line
            // 
            this.button_line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_line.BackgroundImage = global::AnkaninStalker.Properties.Resources.line;
            this.button_line.Location = new System.Drawing.Point(224, 3);
            this.button_line.Name = "button_line";
            this.button_line.Size = new System.Drawing.Size(24, 24);
            this.button_line.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button_line, "水平線を追加します（Ctrl+-）");
            this.button_line.UseVisualStyleBackColor = true;
            this.button_line.Click += new System.EventHandler(this.button_line_Click);
            // 
            // button_clear
            // 
            this.button_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_clear.BackgroundImage = global::AnkaninStalker.Properties.Resources.clear;
            this.button_clear.Location = new System.Drawing.Point(248, 3);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(24, 24);
            this.button_clear.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button_clear, "メモをクリアします（Ctrl+Del）");
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_wrap
            // 
            this.button_wrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_wrap.BackgroundImage = global::AnkaninStalker.Properties.Resources.wrap;
            this.button_wrap.Location = new System.Drawing.Point(200, 3);
            this.button_wrap.Name = "button_wrap";
            this.button_wrap.Size = new System.Drawing.Size(24, 24);
            this.button_wrap.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_wrap, "折り返しモード切替\r\n（Ctrl＋U）");
            this.button_wrap.UseVisualStyleBackColor = true;
            this.button_wrap.Click += new System.EventHandler(this.button_wrap_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(272, 107);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // button_talker_last
            // 
            this.button_talker_last.Location = new System.Drawing.Point(147, 18);
            this.button_talker_last.Name = "button_talker_last";
            this.button_talker_last.Size = new System.Drawing.Size(24, 24);
            this.button_talker_last.TabIndex = 10;
            this.button_talker_last.Text = "≫";
            this.button_talker_last.UseVisualStyleBackColor = true;
            this.button_talker_last.Click += new System.EventHandler(this.button_talker_last_Click);
            // 
            // button_talker_next
            // 
            this.button_talker_next.Location = new System.Drawing.Point(123, 18);
            this.button_talker_next.Name = "button_talker_next";
            this.button_talker_next.Size = new System.Drawing.Size(24, 24);
            this.button_talker_next.TabIndex = 11;
            this.button_talker_next.Text = ">";
            this.button_talker_next.UseVisualStyleBackColor = true;
            this.button_talker_next.Click += new System.EventHandler(this.button_talker_next_Click);
            // 
            // button_talker_replay
            // 
            this.button_talker_replay.Location = new System.Drawing.Point(99, 18);
            this.button_talker_replay.Name = "button_talker_replay";
            this.button_talker_replay.Size = new System.Drawing.Size(24, 24);
            this.button_talker_replay.TabIndex = 12;
            this.button_talker_replay.Text = "○";
            this.button_talker_replay.UseVisualStyleBackColor = true;
            this.button_talker_replay.Click += new System.EventHandler(this.button_talker_replay_Click);
            // 
            // button_talker_prev
            // 
            this.button_talker_prev.Location = new System.Drawing.Point(75, 18);
            this.button_talker_prev.Name = "button_talker_prev";
            this.button_talker_prev.Size = new System.Drawing.Size(24, 24);
            this.button_talker_prev.TabIndex = 13;
            this.button_talker_prev.Text = "<";
            this.button_talker_prev.UseVisualStyleBackColor = true;
            this.button_talker_prev.Click += new System.EventHandler(this.button_talker_prev_Click);
            // 
            // button_talker_first
            // 
            this.button_talker_first.Location = new System.Drawing.Point(51, 18);
            this.button_talker_first.Name = "button_talker_first";
            this.button_talker_first.Size = new System.Drawing.Size(24, 24);
            this.button_talker_first.TabIndex = 14;
            this.button_talker_first.Text = "≪";
            this.button_talker_first.UseVisualStyleBackColor = true;
            this.button_talker_first.Click += new System.EventHandler(this.button_talker_first_Click);
            // 
            // button_talker_playctl
            // 
            this.button_talker_playctl.Location = new System.Drawing.Point(7, 18);
            this.button_talker_playctl.Name = "button_talker_playctl";
            this.button_talker_playctl.Size = new System.Drawing.Size(41, 41);
            this.button_talker_playctl.TabIndex = 15;
            this.button_talker_playctl.Text = "再生";
            this.button_talker_playctl.UseVisualStyleBackColor = true;
            this.button_talker_playctl.Click += new System.EventHandler(this.button_talker_playctl_Click);
            // 
            // groupBox_talker
            // 
            this.groupBox_talker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_talker.Controls.Add(this.button_talker_go);
            this.groupBox_talker.Controls.Add(this.label_talker_max);
            this.groupBox_talker.Controls.Add(this.label3);
            this.groupBox_talker.Controls.Add(this.textBox_talker_num);
            this.groupBox_talker.Controls.Add(this.button_talker_next);
            this.groupBox_talker.Controls.Add(this.button_talker_playctl);
            this.groupBox_talker.Controls.Add(this.button_talker_last);
            this.groupBox_talker.Controls.Add(this.button_talker_first);
            this.groupBox_talker.Controls.Add(this.button_talker_replay);
            this.groupBox_talker.Controls.Add(this.button_talker_prev);
            this.groupBox_talker.Location = new System.Drawing.Point(1, 158);
            this.groupBox_talker.Name = "groupBox_talker";
            this.groupBox_talker.Size = new System.Drawing.Size(280, 71);
            this.groupBox_talker.TabIndex = 16;
            this.groupBox_talker.TabStop = false;
            this.groupBox_talker.Text = "読み上げ";
            // 
            // button_talker_go
            // 
            this.button_talker_go.Location = new System.Drawing.Point(177, 42);
            this.button_talker_go.Name = "button_talker_go";
            this.button_talker_go.Size = new System.Drawing.Size(42, 23);
            this.button_talker_go.TabIndex = 19;
            this.button_talker_go.Text = "GO";
            this.button_talker_go.UseVisualStyleBackColor = true;
            this.button_talker_go.Click += new System.EventHandler(this.button_talker_go_Click);
            // 
            // label_talker_max
            // 
            this.label_talker_max.AutoSize = true;
            this.label_talker_max.Location = new System.Drawing.Point(107, 45);
            this.label_talker_max.Name = "label_talker_max";
            this.label_talker_max.Size = new System.Drawing.Size(11, 12);
            this.label_talker_max.TabIndex = 18;
            this.label_talker_max.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(93, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 11);
            this.label3.TabIndex = 17;
            this.label3.Text = "/";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_talker_num
            // 
            this.textBox_talker_num.Location = new System.Drawing.Point(51, 42);
            this.textBox_talker_num.Name = "textBox_talker_num";
            this.textBox_talker_num.Size = new System.Drawing.Size(39, 19);
            this.textBox_talker_num.TabIndex = 16;
            this.textBox_talker_num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_talker_num_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 422);
            this.Controls.Add(this.groupBox_talker);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_threadname);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox_talker.ResumeLayout(false);
            this.groupBox_talker.PerformLayout();
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
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_m1;
        private System.Windows.Forms.Label label_m2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label_threadname;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_wrap;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_line;
        private System.Windows.Forms.Label label_linenum;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_talker_last;
        private System.Windows.Forms.Button button_talker_next;
        private System.Windows.Forms.Button button_talker_replay;
        private System.Windows.Forms.Button button_talker_prev;
        private System.Windows.Forms.Button button_talker_first;
        private System.Windows.Forms.Button button_talker_playctl;
        private System.Windows.Forms.GroupBox groupBox_talker;
        private System.Windows.Forms.Button button_talker_go;
        private System.Windows.Forms.Label label_talker_max;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_talker_num;
    }
}

