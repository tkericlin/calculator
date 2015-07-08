using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// 2015.06.26 增刪
// 1.加入連續+-*/功能 
// 2.按Clear後,問題會出現在+-*/之後
// 3.[Line: 190-199] 試圖加入 Init功能 到 bClear_Click()中
// 07/08 嘗試加入讀寫檔案的功能，利用Recorder[]紀錄A,B,C數值轉為字串並存入



namespace WindowsFormsApplicationCH5
{
    public partial class Form1 : Form
    {

        //數字鍵輸入用
        //bool isStatusNew = true;
        //輸入運算元用
        //double A = Double.NaN;                    // 把 A 設為浮點數, 但先不給予值, 而是NaN                                                    
        //String op;                                // 設 參數op 去接未來的運算子

        //bClear用
        //T.Text = "0";               //把看板歸零
        // isStatusNew = true;      //把isStatusNew 轉為新的(true)
        //double A = Double.NaN;      //把 A 指定設成 NaN                                                            
        // double B = 0;
        // double C = 0;
        //op = null;                  //把 op 改為 null

        // 利用 init 來統一初始化的工作
        bool isStatusNew;
        double A;
        double B;
        double C;
        string op;
        string[] Recorder = new string[3];
        string[] Recorder1 = new string[0];
        string[] Recorder2 = new string[0];
        string[] Recorder3 = new string[0];
        string[] Recorder4 = new string[0];

        private Helper helper;

        public Form1()  // 建構子
        {
            InitializeComponent();
            helper = new Helper();
            Init();                 //把Init初始化的動作放到這裡
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.b1.Click += new System.EventHandler(this.b0_Click);
            this.b2.Click += new System.EventHandler(this.b0_Click);
            this.b3.Click += new System.EventHandler(this.b0_Click);
            this.b4.Click += new System.EventHandler(this.b0_Click);
            this.b5.Click += new System.EventHandler(this.b0_Click);
            this.b6.Click += new System.EventHandler(this.b0_Click);
            this.b7.Click += new System.EventHandler(this.b0_Click);
            this.b8.Click += new System.EventHandler(this.b0_Click);
            this.b9.Click += new System.EventHandler(this.b0_Click);
            this.bSub.Click += new System.EventHandler(this.bAdd_Click);
            this.bMul.Click += new System.EventHandler(this.bAdd_Click);
            this.bDiv.Click += new System.EventHandler(this.bAdd_Click);
        }

        //設定呼叫初始化(把初始化功能放到前面一點，約在Form1_Load後)
        private void Init()
        {
            T.Text = "0";               //把看板歸零
            isStatusNew = true;      //把isStatusNew 轉為新的(true)
            A = Double.NaN;          //把 A 指定設成 NaN 
            B = 0;
            C = 0;
            op = null;               //把 op 改為 null
            string[] Recorder = { null, null, null, null };
            string[] Recorder1 = { null };
            string[] Recorder2 = { null };
            string[] Recorder3 = { null };
            string[] Recorder4 = { null };
        }

        // TODO: maybe have problem?
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            String S = e.KeyData.ToString();         //鍵盤名稱
            String D = S.Substring(S.Length - 1);    //最後一個字元
            String Q = S.Substring(0, S.Length - 1); //前面的其他字元
            if ((Q == "D" && S.Length == 2) || Q == "NumPad")
            {
                if (T.Text == "0")
                {
                    T.Text = "";
                }
                T.Text += D;
            }
        }//請到From_Load()去設定其他 b1~b9 , 共用此副程式

        private void b0_Click(object sender, EventArgs e)
        {
            if (isStatusNew == true)            // 設定isStatusNew的狀態,準備接新的數值
            {
                T.Text = "";                    // 把 T.Text = 0 的狀態消除變 "" 
                isStatusNew = false;            // 把 isStatusNew設為false(不是全新空的數值),讓它之後走 T.Text += ((Button)sender).Text 來接新的數值
            }

            if (T.Text == "0")                  // 如果 T.Text 是 0
            {
                T.Text = "";                    // 把 T.Text = 0 的狀態消除變 ""
            }

            T.Text += ((Button)sender).Text;    // 讓先前 紀錄的數值 接上 新的數字到尾端
        }

        //輸入運算元
        private void bAdd_Click(object sender, EventArgs e)
        {
            if (!Double.IsNaN(A))                 // 當 A = NaN 時 ==> Double.IsNaN(A) 值為 true ==> 所以 !true ==> false ==> 就不會進去
            {
                // Not First Click +              //因為不是第一次按+號,所以按完+號後,直接先做一次按"="的運算
                bEQ_Click(null, null);                      //bEQ_Click代表呼叫bEQ按下去的功能, 前後兩個數值不重要, 所以給null
            }

            // First Click +                      //因為從未按過+號, 所以要當A沒有值處理
            A = double.Parse(T.Text);                       //當第一次按+號的時候, 用 A 紀錄數字看板上的數值
            Recorder[0] = T.Text;                         //紀錄A的值為字串存入Recorder[0]
            Recorder1[0] = T.Text;
            //T.Text = "0";                                 //不要把看板數字歸0(因為不符合人類看到計算機的直覺,而是應該要保留已輸入的數字)
            op = ((Button)sender).Tag.ToString();           //接著用op來紀錄目前點選之按鈕的Tag值(在bAdd下就是'+'了)
            Recorder[1] = ((Button)sender).Tag.ToString();  //紀錄op的值為字串存入Recorder[1]
            Recorder2[0] = T.Text;
            isStatusNew = true;                             //輸入運算元之後,後面因為要準備承接新的數字,要把isStatusNew改成true

            //最後會到From_Load去設定其他 - * / 共用此副程式
        }

        //執行計算(=)符號
        private void bEQ_Click(object sender, EventArgs e)
        {
            //按完Clear鍵之後, 這邊進入bEQ, 產生
            B = double.Parse(T.Text);            //用 B 來紀錄輸入的第二個數字
            Recorder[2] = T.Text;                ////紀錄B的值為字串存入Recorder[2]
            Recorder3[0] = T.Text;
            C = 0;                               //宣告'變數C'準備承接計算的結果
            switch (op)                          //根據先前op的輸入結果(輸入加減乘除號的內部Tag值)來決定作何種運算
            {
                case "+": C = helper.add(A, B); break;
                case "-": C = helper.sub(A, B); break;
                case "*": C = helper.mul(A, B); break;
                case "/": C = helper.div(A, B); break;
            }
            T.Text = C.ToString();               //把 答案C 顯示在看板上
            Recorder[3] = T.Text;                //紀錄C的值為字串存入Recorder[3]
            Recorder4[0] = T.Text;
            writeLog();                          //把運算過程寫入Log;
            //A = C;                               //把 答案C 設定給原來儲存在第一個計算數值A, 用來作連續運算使用(//把A = C先取消，但=後還是有問題)
            B = 0;                               //把 B歸0
            C = 0;                               //把 C歸0
            A = Double.NaN;                      //把 = 後面加入運算子再加運算子後匯出的bug解掉
        }

        //小數點
        private void bDot_Click(object sender, EventArgs e)
        {
            if (T.Text.IndexOf(".") < 0)        //沒有找到"."就是-1, 會進到T.Text加入小數點; 有小數點的話, 就不執行
            {
                T.Text = T.Text + ".";
            }
        }

        //改變數值'正負號'的功能
        private void bSign_Click(object sender, EventArgs e)
        {
            if (T.Text != "0")
            {
                if (T.Text.IndexOf("-") >= 0)
                {
                    T.Text = T.Text.Replace("-", "");  //把"-"取代成沒有負號
                }
                else
                {
                    T.Text = "-" + T.Text;
                }
            }
        }

        //清除功能鍵
        private void bClear_Click(object sender, EventArgs e)
        {
            Init();
        }


        //倒退功能鍵
        private void bBack_Click(object sender, EventArgs e)
        {
            string S = T.Text;      //用 S 來接數值看板的內容

            if (S.Length > 1)       //判斷 S 的內容是否大於1
            {
                T.Text = (double.Parse(S.Substring(0, S.Length - 1))).ToString();   //如果大於1, 作正常刪除尾端字元的動作
                //Substring是部份字串的意思,第一個參數是起始字元的索引,第二個參數是取出的字元數目 [S.Length就是整個S字串的長度]
            }
            else
            {
                T.Text = "0";                                                       //如果 S的長度只剩下一個字元, 那麼按下去不論內容為何都應該歸0
                //這樣如果看板值為0, 使用者若繼續按倒退按鈕時, 程式才部會當掉, 看板值會一直保持是0
            }
        }

        //讀寫檔案功能
        private void writeLog()
        {
            //string Recorder_WriteLog = Recorder[0] + Recorder[2] + Recorder[1] + "=" + Recorder[3];
            string Recorder_WriteLog = Recorder1[0] + Recorder2[0] + Recorder3[0] + "=" + Recorder4[0];
            
            bool b = File.Exists(@"c:\calculator_log.txt");
            
            if (b != true)
            {
                File.Create(@"c:\calculator_log.txt");
            }

            StreamWriter sw = new StreamWriter(@"c:\calculator_log.txt");
            sw.WriteLine(Recorder_WriteLog);
            sw.Close();

            //將Recorder重設
            Recorder[0] = null ;
            Recorder[1] = null ;
            Recorder[2] = null ;
            Recorder[3] = null ;
            Recorder1[0] = null;
            Recorder2[0] = null;
            Recorder3[0] = null;
            Recorder4[0] = null;
        }
    }
}
