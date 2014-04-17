using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnkaninStalker
{
    public partial class Setting : Form
    {
        // access member
        private Form1 _parentForm;      //親フォーム
        private string _strThread;      //スレッドURL
        private string _strID;          //スレッドID
        private string _strNameSpace;
        private string _strMailSpace; 
        private string _strThread_haven; //スレッドURL（避難所）
        private string _strID_haven;     //スレッドID（避難所）
        private string _strNameSpace_haven;
        private string _strMailSpace_haven; 
        private int _intLimit1;
        private int _intLimit2;
        private bool _topMost;
        private bool _viewName;
        private bool _viewMail;
        private bool _viewId;
        private bool _viewDate;
        private bool _viewNum;
        private string _strConfig;
        private bool _talker;

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
        public string strNameSpace
        {
            get
            {

                return _strNameSpace;

            }
            set
            {
                _strNameSpace = value;
                this.textBox_NameSpace.Text = value;
            }
        }
        public string strMailSpace
        {
            get
            {

                return _strMailSpace;

            }
            set
            {
                _strMailSpace = value;
                this.textBox_MailSpace.Text = value;
            }
        }
        public string strThread_haven
        {
            get
            {

                return _strThread_haven;

            }
            set
            {
                _strThread_haven = value;
                this.textBox_Thread_haven.Text = value;
            }
        }
        public string strID_haven
        {
            get
            {

                return _strID_haven;

            }
            set
            {
                _strID_haven = value;
                this.textBox_ID_haven.Text = value;
            }
        }
        public string strNameSpace_haven
        {
            get
            {

                return _strNameSpace_haven;

            }
            set
            {
                _strNameSpace_haven = value;
                this.textBox_NameSpace_haven.Text = value;
            }
        }
        public string strMailSpace_haven
        {
            get
            {

                return _strMailSpace_haven;

            }
            set
            {
                _strMailSpace_haven = value;
                this.textBox_MailSpace_haven.Text = value;
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
        public bool viewId
        {
            get
            {

                return _viewId;

            }
            set
            {
                _viewId = value;
                this.checkBox_viewid.Checked = value;
            }
        }
        public bool viewDate
        {
            get
            {

                return _viewDate;

            }
            set
            {
                _viewDate = value;
                this.checkBox_viewdate.Checked = value;
            }
        }
        public bool viewNum
        {
            get
            {

                return _viewNum;

            }
            set
            {
                _viewNum = value;
                this.checkBox_viewnum.Checked = value;
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
        public bool talker
        {
            get
            {

                return _talker;

            }
            set
            {
                _talker = value;
                this.checkBox_talker.Checked = value;
            }
        }

        public Setting()
        {
            InitializeComponent();
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
            this._strNameSpace = this.textBox_NameSpace.Text;
            this._strMailSpace = this.textBox_MailSpace.Text;
            this._strThread_haven = this.textBox_Thread_haven.Text;
            this._strID_haven = this.textBox_ID_haven.Text;
            this._strNameSpace_haven = this.textBox_NameSpace_haven.Text;
            this._strMailSpace_haven = this.textBox_MailSpace_haven.Text;
            this._intLimit1 = int.Parse(this.textBox_Limit1.Text);
            this._intLimit2 = int.Parse(this.textBox_Limit2.Text);
            this._topMost = this.checkBox_topmost.Checked;
            this._viewName = this.checkBox_viewname.Checked;
            this._viewMail = this.checkBox_viewmail.Checked;
            this._viewId = this.checkBox_viewid.Checked;
            this._viewDate = this.checkBox_viewdate.Checked;
            this._viewNum = this.checkBox_viewnum.Checked;
            this._talker = this.checkBox_talker.Checked;

            // アプリケーションプロパティに設定
            Properties.Settings.Default.Thread = this.textBox_Thread.Text;
            Properties.Settings.Default.ID = this.textBox_ID.Text;
            Properties.Settings.Default.NameSpace = this.textBox_NameSpace.Text;
            Properties.Settings.Default.MailSpace = this.textBox_MailSpace.Text;
            Properties.Settings.Default.Thread_haven = this.textBox_Thread_haven.Text;
            Properties.Settings.Default.ID_haven = this.textBox_ID_haven.Text;
            Properties.Settings.Default.limit_1 = int.Parse(this.textBox_Limit1.Text);
            Properties.Settings.Default.limit_2 = int.Parse(this.textBox_Limit2.Text);
            Properties.Settings.Default.topmost = this.checkBox_topmost.Checked;
            Properties.Settings.Default.view_name = this.checkBox_viewname.Checked;
            Properties.Settings.Default.view_mail = this.checkBox_viewmail.Checked;
            Properties.Settings.Default.view_id = this.checkBox_viewid.Checked;
            Properties.Settings.Default.view_date = this.checkBox_viewdate.Checked;
            Properties.Settings.Default.view_num = this.checkBox_viewnum.Checked;
            Properties.Settings.Default.talker = this.checkBox_talker.Checked;
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
                SetFromValueFromInstance();
                e.Cancel = true;
            }
            this.Hide();
        }

        private void button_Setting_CNS_Click(object sender, EventArgs e)
        {
            // インスタンスから設定
            try
            {
                SetFromValueFromInstance();

                this.Hide();
            }
            catch (Exception)
            {
               
            }
        }

        /// <summary>
        /// 変更内容を取り消す
        /// </summary>
        private void SetFromValueFromInstance() {
            this.textBox_Thread.Text = this._strThread;
            this.textBox_ID.Text = this._strID;
            this.textBox_NameSpace.Text = this._strNameSpace;
            this.textBox_MailSpace.Text = this._strMailSpace;
            this.textBox_Thread_haven.Text = this._strThread_haven;
            this.textBox_ID_haven.Text = this._strID_haven;
            this.textBox_Limit1.Text = this._intLimit1.ToString();
            this.textBox_Limit2.Text = this._intLimit2.ToString();
            this.checkBox_topmost.Checked = this._topMost;
            this.checkBox_viewname.Checked = this._viewName;
            this.checkBox_viewmail.Checked = this._viewMail;
            this.checkBox_viewid.Checked = this._viewId;
            this.checkBox_viewdate.Checked = this._viewDate;
            this.checkBox_viewnum.Checked = this._viewNum;
            this.checkBox_talker.Checked = this._talker;
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

        private void checkBox_talker_CheckedChanged(object sender, EventArgs e)
        {
            // チェックボックスオン時にtalker機能が使えなかったらメッセージ
            if (checkBox_talker.Checked) {
                if (!_parentForm.boolTalkable)
                {
                    MessageBox.Show("日本語合成音声が利用できません。\r\n日本語合成音声 MSSpeech_TTS_ja-JP_Haruka をインストールしてください。\r\n");
                    checkBox_talker.Checked = false;
                }
            }
        }

    }
}
