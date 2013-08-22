﻿using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Configuration;

namespace AnkaninStalker
{
    public partial class Form1 : Form
    {

        public Version VersionInstanse;
        public Setting SettingInstanse;
        public Thread th = null;

        public Boolean boolStartFlag;
        public Boolean boolResExist;
        public Int64 timersec = 0;
        public Int64 basetime = 0;
        public Int64 timerdiff = 0;
        public int httptimersec = 0;

        public Int32 resnum = 0;
        public Boolean boolThreadDup = false; //スレッド重複防止

        // default font
        public System.Drawing.Font basefont;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // フォーム作成
            this.VersionInstanse = new Version();
            this.SettingInstanse = new Setting();

            this.SettingInstanse.parentForm = this;

            // バージョン情報
            System.Diagnostics.FileVersionInfo ver =
                 System.Diagnostics.FileVersionInfo.GetVersionInfo(
                 System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.VersionInstanse.strVersion = ver.ProductVersion;

            // コンフィグファイルパス
            this.SettingInstanse.strConfig = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;


            // 設定値割り当て
            this.SettingInstanse.strThread = Properties.Settings.Default.Thread;
            this.SettingInstanse.strID = Properties.Settings.Default.ID;
            this.SettingInstanse.intLimit1 = Properties.Settings.Default.limit_1;
            this.SettingInstanse.intLimit2 = Properties.Settings.Default.limit_2;
            this.SettingInstanse.topMost = Properties.Settings.Default.topmost;
            this.SettingInstanse.viewName = Properties.Settings.Default.view_name;
            this.SettingInstanse.viewMail = Properties.Settings.Default.view_mail;
            this.richTextBox1.Text = Properties.Settings.Default.memo;

            // 開始フラグ
            boolStartFlag = false;

            // 開始メッセージ
            this.label_error.Enabled = false;
            this.label_error.Text = DateTime.Now.ToString() + " " + "アプリケーション開始";

            this.buttonSwitch.Text = "追跡\r\n開始";
            this.label_m2.Text = "--分 --秒";
            this.label_ID.Text = "";
            this.label_threadname.Text = "";

            this.basefont = this.label_m2.Font;

            timer1.Interval = 1000;

        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.VersionInstanse.Show();
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SettingInstanse.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.httptimersec % 15 == 0 && !boolThreadDup)
            { 
            // データ取得処理
                boolThreadDup = true;
                //Threadオブジェクトを作成する
                th =
                    new System.Threading.Thread(
                    new System.Threading.ThreadStart(HttpThread));
                //スレッドを開始する
                th.Start();
            }

            // 経過時間作成
            if (boolStartFlag && boolResExist)
            {
                timersec++;
                Int64 min = (timersec + timerdiff) / 60;
                Int64 sec = (timersec + timerdiff) % 60;
                string strmin = (min == 0) ? "" : min.ToString();
                string strtime = String.Format("{0:D}分 {1:D2}秒", min, sec);
                this.label_m2.Text = strtime;

                if ((timersec + timerdiff) >= this.SettingInstanse.intLimit2 * 60) {
                    this.label_m2.ForeColor = Color.Red;
                }
                else if ((timersec + timerdiff) >= this.SettingInstanse.intLimit1 * 60)
                {
                    this.label_m2.ForeColor = Color.Orange;
                }
                else {
                    this.label_m2.ForeColor = Color.Black;
                }

            }
                
            this.httptimersec++;
            
        }

        private void HttpThread()
        {
            string host;
            string strGet = "";
            Encoding enc = Encoding.GetEncoding("shift-jis");
            int bbstype;
            int indexThreadName;
            int indexDate;
            int indexBody;
            int indexName;
            int indexMail;
            
            try
            {
                // datURL取得
                Console.WriteLine(this.SettingInstanse.strThread);
                //Regexオブジェクトを作成
                Regex r1 = new Regex(@"2ch\.net");
                Regex r2 = new Regex(@"jbbs\.livedoor\.jp");
                Regex r3 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/?");
                Regex r4 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/([0-9]*)\/?");
                Regex r5 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})\.\d{2} ID:(.*)");
                Regex r6 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})");

                if (r1.Match(this.SettingInstanse.strThread).Success)
                {
                    bbstype = Const.BBS_2CH;
                    indexThreadName = 4;
                    indexDate = 2;
                    indexBody = 3;
                    indexName = 0;
                    indexMail = 1;
                    Match m = r3.Match(this.SettingInstanse.strThread);
                    if (!m.Success)
                    {
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("スレッドURLが不正です。"); }), new object[] { "" });
                        return;
                    }
                    host = m.Groups[1].Value;
                    string board = m.Groups[2].Value;
                    string datid = m.Groups[3].Value;
                    strGet = "http://" + host + "/" + board + "/dat/" + datid + ".dat";
                    Console.WriteLine(strGet);

                    enc = Encoding.GetEncoding("shift-jis");

                }
                else if (r2.Match(this.SettingInstanse.strThread).Success)
                {
                    bbstype = Const.BBS_SHITARABA;
                    indexThreadName = 5;
                    indexDate = 3;
                    indexBody = 4;
                    indexName = 1;
                    indexMail = 2;
                    Match m = r4.Match(this.SettingInstanse.strThread);
                    if (!m.Success)
                    {
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("スレッドURLが不正です。"); }), new object[] { "" });
                        return;
                    }
                    host = m.Groups[1].Value;
                    string bbs = m.Groups[2].Value;
                    string key1 = m.Groups[3].Value;
                    string key2 = m.Groups[4].Value;
                    strGet = @"http://jbbs.livedoor.jp/bbs/rawmode.cgi/" + bbs + "/" + key1 + "/" + key2 + "/";
                    Console.WriteLine(strGet);

                    enc = Encoding.GetEncoding("euc-jp");

                }
                else
                {
                    this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("スレッドURLが不正です。"); }), new object[] { "" });
                    return;
                }

                // サーバーソケット初期化
                this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("データを取得します。"); }), new object[] { "" });
                //HttpWebRequestの作成
                System.Net.HttpWebRequest webreq =
                    (System.Net.HttpWebRequest)
                        System.Net.WebRequest.Create(strGet);

                webreq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                webreq.Proxy = null;

                //サーバーからの応答を受信するためのHttpWebResponseを取得
                System.Net.HttpWebResponse webres =
                    (System.Net.HttpWebResponse)webreq.GetResponse();

                //System.Text.Encoding.GetEncoding("euc-jp");
                //応答データを受信するためのStreamを取得
                System.IO.Stream st = webres.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(st, enc);

                // 一行ずつパース
                Int32 rescnt = 0;
                int news = 0; //新レス数
                while (!sr.EndOfStream)
                {
                    rescnt++;
                    string h = sr.ReadLine();
                    if (rescnt <= this.resnum) { continue; }
                    string[] stArrayData = h.Split(new string[] { "<>" }, StringSplitOptions.None);
                    if (rescnt == 1)
                    {
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.threadnameupdate(stArrayData[indexThreadName]); }), new object[] { "" });
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.idupdate(this.SettingInstanse.strID); }), new object[] { "" });
                    }

                    // 読み込んだレス番号を更新
                    this.BeginInvoke(new Action<Int32>(delegate(Int32 i) { this.resnumupdate(rescnt); }), new object[] { 0 });

                    if (bbstype == Const.BBS_2CH)
                    {
                        Match m = r5.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = m.Groups[7].Value;
                        if (aid.Contains(this.SettingInstanse.strID))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });

                            // レス更新
                            string target = rescnt.ToString() + " " + stArrayData[indexDate] + "\r\n" + stArrayData[indexBody].Replace("<br>", "\r\n");
                            this.BeginInvoke(new Action<String>(delegate(String str)
                            {
                                this.resoutput(target);
                            }), new object[] { "" });

                            news++;
                        }
                    }
                    else if (bbstype == Const.BBS_SHITARABA)
                    {
                        Match m = r6.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = stArrayData[6];
                        if (aid.Contains(this.SettingInstanse.strID))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });

                            // レス更新
                            string name = (this.SettingInstanse.viewName) ? stArrayData[indexName] + " " : "";
                            string mail = (this.SettingInstanse.viewMail) ? "[" + stArrayData[indexMail] + "] " : "";
                            string target = rescnt.ToString() + " " + name + mail + stArrayData[indexDate] + " ID:" + aid + "\r\n" + stArrayData[indexBody].Replace("<br>", "\r\n");
                            this.BeginInvoke(new Action<String>(delegate(String str)
                            {
                                this.resoutput(target);
                            }), new object[] { "" });

                            news++;
                        }
                    }

                }

                if (news > 0)
                {
                    // 開始フラグ
                    this.BeginInvoke(new Action<Boolean>(delegate(Boolean str)
                    {
                        this.resexistupdate(true);
                    }), new object[] { false });

                    this.BeginInvoke(new Action(delegate()
                    {
                        this.resetbasetime();
                    }), new object[] { });
                }

                //閉じる
                //webres.Close()でもよい
                sr.Close();
                this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput(news.ToString() + "件の安価人レス取得"); }), new object[] { "" });
                this.BeginInvoke(new Action(delegate()
                {
                    this.resetthreaddup();
                }), new object[] { });
            }
            catch (InvalidOperationException ioex) { 
                // 何もしない
                Console.WriteLine(ioex.Message);
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("エラー:" + ex.Message); }), new object[] { "" });
            }
            finally { 
            
            }
        }

        //label更新
        public delegate void ThreadnameupdateDelegate(String str);
        public void threadnameupdate(String str)
        {
            this.label_threadname.Text = str;
        }

        public delegate void IdupdateDelegate(String str);
        public void idupdate(String str)
        {
            this.label_ID.Text = str;
        }

        public delegate void LogoutputDelegate(String str);
        public void logoutput(String str)
        {
            this.label_error.Text = DateTime.Now.ToString() + " " + str + "\r\n";
        }

        public delegate void ResoutputDelegate(String str);
        public void resoutput(String str) 
        {
            this.textBox1.AppendText(str + "\r\n");
            this.textBox1.AppendText("------------------\r\n");
        }

        // 読み込みレス番号更新
        public delegate void ResnumupdateDelegate(Int32 i);
        public void resnumupdate(Int32 i)
        {
            this.resnum = i;
        }

        // 経過秒更新
        public delegate void TimersecupdateDelegate(Int64 i);
        public void timersecupdate(Int64 i)
        {
            this.timersec = i;
        }

        public delegate void ResexistupdateDelegate(Boolean i);
        public void resexistupdate(Boolean i)
        {
            this.boolResExist = i;
        }

        public delegate void ResetbasetimeDelegate();
        public void resetbasetime()
        {
            this.basetime = 0;
            this.timerdiff = 0;
        }

        public delegate void ThreaddupDelegate();
        public void resetthreaddup()
        {
            this.boolThreadDup = false;
        }
        
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            // 別スレッドでデータ取得
            if ("".CompareTo(this.SettingInstanse.strThread) == 0)
            {
                MessageBox.Show("スレッドURLが未入力です。");
                return;
            }
            if ("".CompareTo(this.SettingInstanse.strID) == 0)
            {
                MessageBox.Show("安価人IDが未入力です。");
                return;
            }

            // start
            if (!boolStartFlag)
            {
                //timer
                this.timer1.Start();
                boolStartFlag = true;
                this.buttonSwitch.Text = "追跡\r\n中断";
                this.buttonSwitch.BackColor = Color.Chocolate;
                if (this.basetime != 0) {
                    this.timerdiff = (DateTime.Now.Ticks - basetime) / 10000000;
                }

            }
            else { 
                //timer
                this.timer1.Stop();
                boolStartFlag = false;
                httptimersec = 0;
                this.buttonSwitch.Text = "追跡\r\n開始";
                this.buttonSwitch.BackColor = SystemColors.Control;
                this.basetime = DateTime.Now.Ticks;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            // リセット
            try
            {
                this.timer1.Stop();
                if (th != null) { th.Abort(); th = null; }
            }
            catch (Exception ex)
            {

                this.label_error.Text = DateTime.Now.ToString() + " " + "エラー：" + ex.Message;
            }
            boolStartFlag = false;
            boolResExist = false;
            timersec = 0;
            basetime = 0;
            timerdiff = 0;
            httptimersec = 0;

            resnum = 0;
            boolThreadDup = false;

            this.buttonSwitch.Text = "追跡\r\n開始";
            this.buttonSwitch.BackColor = SystemColors.Control;

            this.label_m2.Text = "--分 --秒";
            this.label_ID.Text = "";
            this.label_threadname.Text = "";
            this.textBox1.Text = "";

            this.label_m2.Font = this.basefont;
            this.label_m2.ForeColor = Color.Black;

            this.label_error.Text = DateTime.Now.ToString() + " " + "リセット完了";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.timer1.Stop();
                if (th != null) { th.Abort(); th = null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.memo = this.richTextBox1.Text;
            Properties.Settings.Default.Save();
            this.label_error.Text = DateTime.Now.ToString() + " " + "メモを保存しました。";
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = Properties.Settings.Default.memo;
            this.label_error.Text = DateTime.Now.ToString() + " " + "メモをロードしました。";
        }

        private void button_wrap_Click(object sender, EventArgs e)
        {
            this.richTextBox1.WordWrap = !this.richTextBox1.WordWrap;
        }

        private void button_line_Click(object sender, EventArgs e)
        {
            // カーソル位置にライン追加
            if (richTextBox1.SelectedText.Length == 0)
                richTextBox1.SelectedText = "\r\n" + "------------------" + "\r\n";
            richTextBox1.Focus();

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        // コントロールのショートカット
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                this.button_save.PerformClick();
            }
            if (e.KeyData == (Keys.Control | Keys.L))
            {
                this.button_load.PerformClick();
            }
            if (e.KeyData == (Keys.Control | Keys.U))
            {
                this.button_wrap.PerformClick();
            }
            if (e.KeyData == (Keys.Control | Keys.OemMinus))
            {
                this.button_line.PerformClick();
            }
            if (e.KeyData == (Keys.Control | Keys.Delete))
            {
                this.button_clear.PerformClick();
            }

            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            if (e.KeyData == (Keys.Up))
            {
                line = (--line == 0) ? 1 : line;
            }
            if (e.KeyData == (Keys.Down))
            {
                int len = richTextBox1.Lines.Length == 0 ? 1 : richTextBox1.Lines.Length;
                line = (++line >= len) ? len : line;
            }
            label_linenum.Text = line.ToString() + "行目";

            // 右と左は対応しかねる。重くなるの勘弁

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            label_linenum.Text = line.ToString() + "行目";
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            label_linenum.Text = line.ToString() + "行目";
        }

    }
}

// 開発計画

//・メモ帳　OK
//　Ctrl+-で水平線（("------------------) OK
//　Ctrl+Sで保存、Ctrl+Lでロード、Ctrl+UでWrap切り替え OK
//・字幕
//・複数スレッド監視
//・複数ID監視
//・次スレ追跡
//・効果音
//・talk機能
//・名前・メ欄ストーカー機能
//・安価人の冒険
//・user.configファイルパス表示 OK
//・更新時間のconfig化
//・統計情報
//・収納機能