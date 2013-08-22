using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnkaninStalker
{
    public partial class Setting : Form
    {
        // access member
        private Form1 _parentForm;
        private string _strThread;
        private string _strID;
        private int _intLimit1;
        private int _intLimit2;
        private bool _topMost;
        private bool _viewName;
        private bool _viewMail;
        private string _strConfig;

        public Form1 parentForm
        {
            get
            {

                return _parentForm;

            }
            set
            {
                _parentForm = value;
            }
        }

        public string strThread
        {
            get {
        
                return _strThread;
        
            }
            set {
                _strThread = value;
                this.textBox_Thread.Text = value;
            }
        }
        public string strID
        {
            get
            {

                return _strID;

            }
            set
            {
                _strID = value;
                this.textBox_ID.Text = value;
            }
        }
        public int intLimit1
        {
            get
            {

                return _intLimit1;

            }
            set
            {
                _intLimit1 = value;
                this.textBox_Limit1.Text = value.ToString();
            }
        }
        public int intLimit2
        {
            get
            {

                return _intLimit2;

            }
            set
            {
                _intLimit2 = value;
                this.textBox_Limit2.Text = value.ToString();
            }
        }
        public bool topMost
        {
            get
            {

                return _topMost;

            }
            set
            {
                _topMost = value;
                this.checkBox_topmost.Checked = value;
            }
        }
        public bool viewName
        {
            get
            {

                return _viewName;

            }
            set
            {
                _viewName = value;
                this.checkBox_viewname.Checked = value;
            }
        }
        public bool viewMail
        {
            get
            {

                return _viewMail;

            }
            set
            {
                _viewMail = value;
                this.checkBox_viewmail.Checked = value;
            }
        }
        public string strConfig
        {
            get
            {

                return _strConfig;

            }
            set
            {
                _strConfig = value;
                this.textBox_config.Text = value;
            }
        }

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void button_Setting_OK_Click(object sender, EventArgs e)
        {
            // 更新されていたらresnumを初期化
            if (this._strThread.CompareTo(this.textBox_Thread.Text) != 0 ||
                this._strID.CompareTo(this.textBox_ID.Text) != 0)
            {
                this._parentForm.resnum = 0;
            }


            // インスタンスに設定
            this._strThread = this.textBox_Thread.Text;
            this._strID = this.textBox_ID.Text;
            this._intLimit1 = int.Parse(this.textBox_Limit1.Text);
            this._intLimit2 = int.Parse(this.textBox_Limit2.Text);
            this._topMost = this.checkBox_topmost.Checked;
            this._viewName = this.checkBox_viewname.Checked;
            this._viewMail = this.checkBox_viewmail.Checked;

            // アプリケーションプロパティに設定
            Properties.Settings.Default.Thread = this.textBox_Thread.Text;
            Properties.Settings.Default.ID = this.textBox_ID.Text;
            Properties.Settings.Default.limit_1 = int.Parse(this.textBox_Limit1.Text);
            Properties.Settings.Default.limit_2 = int.Parse(this.textBox_Limit2.Text);
            Properties.Settings.Default.topmost = this.checkBox_topmost.Checked;
            Properties.Settings.Default.view_name = this.checkBox_viewname.Checked;
            Properties.Settings.Default.view_mail = this.checkBox_viewmail.Checked;
            Properties.Settings.Default.Save();

            // 最前面表示設定
            this.TopMost = this.checkBox_topmost.Checked;
            _parentForm.TopMost = this.checkBox_topmost.Checked;

            this.Hide();
        }

        private void textBox_Limit1_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.textBox_Thread.Text = this._strThread;
                this.textBox_ID.Text = this._strID;
                this.textBox_Limit1.Text = this._intLimit1.ToString();
                this.textBox_Limit2.Text = this._intLimit2.ToString();
                this.checkBox_topmost.Checked = this._topMost;
                this.checkBox_viewname.Checked = this._viewName;
                this.checkBox_viewmail.Checked = this._viewMail;
                e.Cancel = true;
            }
            this.Hide();
        }

        private void button_Setting_CNS_Click(object sender, EventArgs e)
        {
            // インスタンスから設定
            try
            {
                this.textBox_Thread.Text = this._strThread;
                this.textBox_ID.Text = this._strID;
                this.textBox_Limit1.Text = this._intLimit1.ToString();
                this.textBox_Limit2.Text = this._intLimit2.ToString();
                this.checkBox_topmost.Checked = this._topMost;
                this.checkBox_viewname.Checked = this._viewName;
                this.checkBox_viewmail.Checked = this._viewMail;

                this.Hide();
            }
            catch (Exception)
            {
               
            }
        }

        private void textBox_Limit2_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
        }
    }
}
