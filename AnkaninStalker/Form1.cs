using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Configuration;
using SpeechLib;
using System.Runtime.InteropServices;
using System.Collections.Generic; //for ver11

namespace AnkaninStalker
{
    public partial class Form1 : Form
    {

        public Version VersionInstanse; // バージョン情報フォーム
        public Setting SettingInstanse; // 設定フォーム
        public Thread th = null;        // 本スレ取得スレッド
        public Thread th_h = null;      // 避難所スレ取得スレッド
        static readonly object syncObject = new object(); // 同期オブジェクト

        public Boolean boolStartFlag;   // 追跡開始フラグ
        public Boolean boolResExist;    // レス存在フラグ
        public Int64 timersec = 0;      // 経過時間
        public Int64 basetime = 0;      // 基準時刻
        public Int64 timerdiff = 0;     // タイマー差分
        public int httptimersec = 0;    // データ取得処理クロック

        public Int32 resnum = 0;        // 読み込み済みレス数
        public Int32 resnum_h = 0;      // 読み込み済みレス数（避難所）
        public Boolean boolThreadDup = false;    //スレッド重複防止
        public Boolean boolThreadDup_h = false;  //スレッド重複防止（避難所）

        // タブ色用 
        public Boolean boolResAdded = false;     // 新着フラグ

        // default font（戻し用）
        public System.Drawing.Font basefont;

        //合成音声ライブラリの読み込み
        private SpeechLib.SpVoice VoiceSpeech = null;
        public Boolean boolTalkable = false;    // 音声合成が使えるかどうか
        private List<String> speechList = new List<String>(); // 読み上げリスト
        private int speechNum = 0; // 読み上げ番号現在値
        private Boolean boolSpeechPlayFlag = false; // 再生フラグ
        private Boolean boolSkipFlag = false; // スキップフラグ スキップしたら立てる／Voice開始時に下げる

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            // 設定値割り当て
            this.SettingInstanse.strThread = Properties.Settings.Default.Thread;
            this.SettingInstanse.strID = Properties.Settings.Default.ID;
            this.SettingInstanse.strNameSpace = Properties.Settings.Default.NameSpace;
            this.SettingInstanse.strMailSpace = Properties.Settings.Default.MailSpace;
            this.SettingInstanse.strThread_haven = Properties.Settings.Default.Thread_haven;
            this.SettingInstanse.strID_haven = Properties.Settings.Default.ID_haven;
            this.SettingInstanse.strNameSpace_haven = Properties.Settings.Default.NameSpace_haven;
            this.SettingInstanse.strMailSpace_haven = Properties.Settings.Default.MailSpace_haven;
            this.SettingInstanse.intLimit1 = Properties.Settings.Default.limit_1;
            this.SettingInstanse.intLimit2 = Properties.Settings.Default.limit_2;
            this.SettingInstanse.topMost = Properties.Settings.Default.topmost;
            this.SettingInstanse.viewName = Properties.Settings.Default.view_name;
            this.SettingInstanse.viewMail = Properties.Settings.Default.view_mail;
            this.SettingInstanse.viewId = Properties.Settings.Default.view_id;
            this.SettingInstanse.viewDate = Properties.Settings.Default.view_date;
            this.SettingInstanse.viewNum = Properties.Settings.Default.view_num;
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

            // talker http://d.hatena.ne.jp/rti7743/20111215/1323965483 からコピペ
            //合成音声エンジンを初期化する.
            try
            {
                this.VoiceSpeech = new SpeechLib.SpVoice();
            }
            catch (COMException)
            {
                throw new InvalidOperationException(
                    "合成音声が利用できません。" + Environment.NewLine
                    + "Microsoft Speech Platform - Runtime (Version 11) をインストールしてください。"
                );
            }
            //合成音声エンジンで日本語を話す人を探す。(やらなくても動作はするけど、念のため)
            //boolTalkable = false;
            foreach (SpObjectToken voiceperson in this.VoiceSpeech.GetVoices())
            {
                string language = voiceperson.GetAttribute("Language");
                if (language == "411")
                {//日本語を話す人だ!
                    this.VoiceSpeech.Voice = voiceperson; //君に読みあげて欲しい
                    boolTalkable = true;
                    break;
                }
            }
            // event handler
            this.VoiceSpeech.EventInterests = SpeechVoiceEvents.SVEEndInputStream; // 終了時イベントを発生させるようになる
            this.VoiceSpeech.EndStream += new _ISpeechVoiceEvents_EndStreamEventHandler(VoiceSpeech_EndStream); // イベントハンドラ登録

            //if (!hit)
            //{
            //    MessageBox.Show("日本語合成音声が利用できません。\r\n日本語合成音声 MSSpeech_TTS_ja-JP_Haruka をインストールしてください。\r\n");
            //}

        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.VersionInstanse.Show();
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SettingInstanse.Show();
        }
        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            // 本スレ
            if (this.httptimersec % 15 == 0 && !boolThreadDup)
            { 
            // データ取得処理
                boolThreadDup = true;
                //Threadオブジェクトを作成する
                object[] obj = new object[5]; // 引数

                obj[0] = Const.BOARD_MAIN;
                obj[1] = this.SettingInstanse.strThread; //スレURL
                obj[2] = this.SettingInstanse.strID; //スレID
                obj[3] = this.SettingInstanse.strNameSpace; //スレ名前欄
                obj[4] = this.SettingInstanse.strMailSpace; //スレメール欄

                th =
                    new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(HttpThread));
                //スレッドを開始する
                th.Start(obj);

            }
            // 避難所
            if (this.httptimersec % 15 == 0 && !boolThreadDup_h) 
            {
                // データ取得処理
                boolThreadDup_h = true;
                //Threadオブジェクトを作成する
                object[] obj = new object[5]; // 引数

                obj[0] = Const.BOARD_HAVEN;
                obj[1] = this.SettingInstanse.strThread_haven; //スレURL
                obj[2] = this.SettingInstanse.strID_haven; //スレID
                obj[3] = this.SettingInstanse.strNameSpace_haven; //スレ名前欄
                obj[4] = this.SettingInstanse.strMailSpace_haven; //スレメール欄

                th_h =
                    new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(HttpThread));
                //スレッドを開始する
                th_h.Start(obj);

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

        /// <summary>
        /// スレ情報取得
        /// </summary>
        /// <param name="args"></param>
        private void HttpThread(object args)
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

            object[] argsTmp = (object[])args;
            int bbsCode = (int)argsTmp[0]; // 本/避難所区分
            string strUrl = (string)argsTmp[1]; // スレURL
            string strID = (string)argsTmp[2]; // スレID
            string strNameSpace = (string)argsTmp[3]; // 
            string strMailSpace = (string)argsTmp[4]; // 
            string strHi = "";
            if (bbsCode == Const.BOARD_HAVEN) { 
                strHi = "[避]"; 
            }

            strID = Const.NZ(strID);
            strNameSpace = Const.NZ(strNameSpace);
            strMailSpace = Const.NZ(strMailSpace);

            try
            {
                // datURL取得
                Console.WriteLine(strUrl);
                //Regexオブジェクトを作成
                Regex r1 = new Regex(@"2ch\.net");
                Regex r2 = new Regex(@"jbbs\.livedoor\.jp");
                Regex r3 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/?");
                Regex r4 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/([0-9]*)\/?");
                Regex r5 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})\.\d{2} ID:(.*)");
                Regex r6 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})");

                if (r1.Match(strUrl).Success)
                {
                    bbstype = Const.BBS_2CH;
                    indexThreadName = 4;
                    indexDate = 2;
                    indexBody = 3;
                    indexName = 0;
                    indexMail = 1;
                    Match m = r3.Match(strUrl);
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
                else if (r2.Match(strUrl).Success)
                {
                    bbstype = Const.BBS_SHITARABA;
                    indexThreadName = 5;
                    indexDate = 3;
                    indexBody = 4;
                    indexName = 1;
                    indexMail = 2;
                    Match m = r4.Match(strUrl);
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
                    if (bbsCode == Const.BOARD_MAIN && rescnt <= this.resnum) { continue; }
                    if (bbsCode == Const.BOARD_HAVEN && rescnt <= this.resnum_h) { continue; }
                    string[] stArrayData = h.Split(new string[] { "<>" }, StringSplitOptions.None);
                    if (rescnt == 1 && bbsCode == Const.BOARD_HAVEN) // 本スレのみ
                    {
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.threadnameupdate(stArrayData[indexThreadName]); }), new object[] { "" });
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.idupdate(this.SettingInstanse.strID); }), new object[] { "" });
                    }

                    // 読み込んだレス番号を更新
                    switch (bbsCode)
                    {
                        case Const.BOARD_MAIN:
                            this.BeginInvoke(new Action<Int32>(delegate(Int32 i) { this.resnumupdate(rescnt); }), new object[] { 0 });
                            break;
                        case Const.BOARD_HAVEN:
                            this.BeginInvoke(new Action<Int32>(delegate(Int32 i) { this.resnumhupdate(rescnt); }), new object[] { 0 });
                            break;
                        default:
                            // Invalid code;
                            throw new Exception("Invalid board code.");
                    }

                    string target = "";
                    if (bbstype == Const.BBS_2CH)
                    {
                        Match m = r5.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = m.Groups[7].Value;
                        // filter
                        if (aid.Contains(strID) && stArrayData[indexName].Contains(strNameSpace) && stArrayData[indexMail].Contains(strMailSpace))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            if (this.timersec > tick / 10000000)
                            {
                                this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });
                            }
                            string body = "";
                            string patternStr = @"<.*?>";
                            body = stArrayData[indexBody];
                            body = body.Replace("<br>", "\r\n");
                            body = Regex.Replace(body, patternStr, string.Empty, RegexOptions.Singleline);

                            // レス更新
                            string name = (this.SettingInstanse.viewName) ? stArrayData[indexName] + " " : "";
                            string mail = (this.SettingInstanse.viewMail) ? "[" + stArrayData[indexMail] + "] " : "";
                            string date = "";
                            string id = "";
                            string[] arrDate = stArrayData[indexDate].Split(' ');
                            try
                            {
                                date = (this.SettingInstanse.viewDate) ? arrDate[0] + " " + arrDate[1] + " " : "";
                            }catch(Exception){}
                            try
                            {
                                id = (this.SettingInstanse.viewId) ? arrDate[2] + " " : "";
                            }
                            catch (Exception) { }
                            string num = (this.SettingInstanse.viewNum) ? rescnt.ToString() + " " : "";
                            body = WebUtility.HtmlDecode(body);
                            target = strHi + num + name + mail + date + id + "\r\n" + body;
                            speechList.Add(body);
                            startSpeech(); //読み上げ
                            news++;
                        }
                    }
                    else if (bbstype == Const.BBS_SHITARABA)
                    {
                        Match m = r6.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = stArrayData[6];
                        if (aid.Contains(strID) && stArrayData[indexName].Contains(strNameSpace) && stArrayData[indexMail].Contains(strMailSpace))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            if (this.timersec > tick / 10000000)
                            {
                                this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });
                            }
                            string body = "";
                            string patternStr = @"<.*?>";
                            body = stArrayData[indexBody];
                            body = body.Replace("<br>", "\r\n");
                            body = Regex.Replace(body, patternStr, string.Empty, RegexOptions.Singleline);

                            // レス更新
                            string name = (this.SettingInstanse.viewName) ? stArrayData[indexName] + " " : "";
                            string mail = (this.SettingInstanse.viewMail) ? "[" + stArrayData[indexMail] + "] " : "";
                            string date = (this.SettingInstanse.viewDate) ? stArrayData[indexDate] + " " : "";
                            string id = (this.SettingInstanse.viewId) ? "ID:" + aid + " " : "";
                            string num = (this.SettingInstanse.viewNum) ? rescnt.ToString() + " " : "";
                            body = WebUtility.HtmlDecode(body);
                            target = strHi + num + name + mail + date + id + "\r\n" + body;
                            speechList.Add(body);
                            startSpeech(); //読み上げ
                            news++;
                        }


                    }

                    if (target.Length != 0)
                    {
                        // 排他制御入れる
                        Monitor.Enter(syncObject);
                        try
                        {
                            this.BeginInvoke(new Action<String>(delegate(String str)
                                            {
                                                this.resoutput(target);
                                            }), new object[] { "" });
                            Console.WriteLine(target);
                        }
                        catch (Exception ex)
                        {
                            // 何もしない
                            Console.WriteLine(ex.GetType());
                        }
                        finally
                        {
                            Monitor.Exit(syncObject);
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

                    // レス表示タブが非アクティブの時にレスが追加された場合
                    boolResAdded = true;
                    this.BeginInvoke(new Action(delegate()
                    {
                        this.tabpagecolor();
                    }), new object[] { });
                        
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
            catch (InvalidOperationException ioex)
            {
                // 何もしない
                Console.WriteLine(ioex.Message);
            }
            catch (System.Threading.ThreadAbortException aex)
            {
                // 何もしない(スレッド強制終了時)
                Console.WriteLine(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
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
        
        /// <summary>
        ///  読み込みレス番号更新
        /// </summary>
        /// <param name="i"></param>
        public delegate void ResnumupdateDelegate(Int32 i);
        public void resnumupdate(Int32 i)
        {
            this.resnum = i;
        }

        /// <summary>
        ///  読み込みレス番号更新(避難所)
        /// </summary>
        /// <param name="i"></param>
        public delegate void ResnumhupdateDelegate(Int32 i);
        public void resnumhupdate(Int32 i)
        {
            this.resnum_h = i;
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
            this.boolThreadDup_h = false;
        }

        /// <summary>
        /// タブ色変更メソッド
        /// </summary>
        public delegate void TabpagecolorDelegate();
        public void tabpagecolor()
        {
            if (this.tabControl1.SelectedIndex != Const.TAB_RES)
            {
                this.tabControl1.Refresh();
            }
        }
        
        
        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            // 別スレッドでデータ取得
            //if ("".CompareTo(this.SettingInstanse.strThread) == 0)
            //{
            //    MessageBox.Show("スレッドURLが未入力です。");
            //    return;
            //}
            //if ("".CompareTo(this.SettingInstanse.strID) == 0)
            //{
            //    MessageBox.Show("安価人IDが未入力です。");
            //    return;
            //}

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
                if (th != null) { th.Abort(); th.Join(); th = null; }
                if (th_h != null) { th_h.Abort(); th_h.Join(); th_h = null; }
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
            resnum_h = 0;
            boolThreadDup = false;
            boolThreadDup_h = false;

            this.buttonSwitch.Text = "追跡\r\n開始";
            this.buttonSwitch.BackColor = SystemColors.Control;

            this.label_m2.Text = "--分 --秒";
            this.label_ID.Text = "";
            this.label_threadname.Text = "";
            this.textBox1.Text = "";

            this.label_m2.Font = this.basefont;
            this.label_m2.ForeColor = Color.Black;

            boolResAdded = false;
            this.Refresh(); // 再描画

            this.label_error.Text = DateTime.Now.ToString() + " " + "リセット完了";

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.timer1.Stop();
                if (th != null) { th.Abort(); th = null; }
                if (th_h != null) { th_h.Abort(); th_h = null; }
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

        private void textBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawTab(sender, e);
        }

        public void drawTab(object sender, DrawItemEventArgs e)
        {
            //対象のTabControlを取得
            TabControl tab = (TabControl)sender;
            //タブページのテキストを取得
            string txt = tab.TabPages[e.Index].Text;

            //タブのテキストと背景を描画するためのブラシを決定する
            Brush foreBrush, backBrush;
            if (this.tabControl1.SelectedIndex == Const.TAB_RES) { boolResAdded = false; }
            if (e.Index == Const.TAB_RES && boolResAdded)
            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                foreBrush = Brushes.Black;
                backBrush = Brushes.Orange;
            }
            else
            {
                foreBrush = Brushes.Black;
                backBrush = Brushes.White;
            }

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            //中央に表示する
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //背景の描画
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            //Textの描画
            e.Graphics.DrawString(txt, e.Font, foreBrush, e.Bounds, sf);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            boolResAdded = false;
        }
        // 読み上げ実行
        // 現在の読み上げ番号テキストを再生
        private void startSpeech()
        {
            startSpeech(speechNum);
        }
        // 指定番の読み上げ番号テキストを再生
        private void startSpeech(int num)
        {
            // 読み上げフラグが立っていない場合は何もしない
            if (!this.SettingInstanse.talker || !boolSpeechPlayFlag) { return; }

            if (VoiceSpeech.Status.RunningState == SpeechRunState.SRSEIsSpeaking)
            { return; } //使用中
            if (speechList.Count <= 0 || num > speechList.Count - 1) { return; } // なし
            if (num > 0 && speechList[num] != null && speechList[num].Length > 0)
            {
                // 読み上げ
                boolSkipFlag = false; // フラグ戻す
                speechNum = num; // 現在番号で上書き
                VoiceSpeech.Speak(speechList[num], SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
                
            }
        }
        // レス読み上げ終了時イベント
        private void VoiceSpeech_EndStream(int StreamNumber, object StreamPosition)
        {
            // skip時は何もしない
            if (boolSkipFlag) { return; }

            //次レス読み上げ開始
            startSpeech(speechNum + 1);
            
        }
        // 読み上げスキップ
        private void skipSpeech() {
            boolSkipFlag = true;
            // ボタン無効化

            VoiceSpeech.Skip("Sentence", int.MaxValue);
            // 終わるまで待つ
            if (VoiceSpeech.Status.RunningState == SpeechRunState.SRSEIsSpeaking) {
                VoiceSpeech.WaitUntilDone(1000);
            }
            // ボタン有効化
        }

        // talk用ボタン類の管理
        private void disableTalkButtons() { }
        private void enableTalkButtons() { }
    }
}

// 開発計画

//・メモ帳　OK
//　Ctrl+-で水平線（("------------------) OK
//　Ctrl+Sで保存、Ctrl+Lでロード、Ctrl+UでWrap切り替え OK
//・字幕
//・複数スレッド監視 OK
//・複数ID監視
//・次スレ追跡
//・効果音
//・talk機能
//・名前・メ欄ストーカー機能 OK
//・安価人の冒険
//・user.configファイルパス表示 OK
//・更新時間のconfig化
//・統計情報 
//・収納機能
//・アンカー表示対応　フロートボックスで表示する⇒めんどいやめやめ OK
//・安価人レス時にタブ開いてなかったら色つける（オレンジ） OK