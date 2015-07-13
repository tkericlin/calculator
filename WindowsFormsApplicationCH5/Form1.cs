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
        //string[] Recorder = new string[4];          //要4個空間，要宣告4，[不是宣告3而有0,1,2,3的空間可以用]，是宣告4!!!
        List<string> RecorderList = new List<string>();   //宣告一個 不用宣告大小的動態陣列，名稱叫做 RecorderList，型別為<string>

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
            //string[] Recorder = { null, null, null, null };
            List<string> RecorderList = new List<string>();   //開一個 不用宣告大小的動態陣列 RecorderList(把它清空設為null)
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
                bEQ_OP_Click(null, null);                      //bEQ_Click代表呼叫bEQ按下去的功能, 前後兩個數值不重要, 所以給null
            }

            // First Click +                      //因為從未按過+號, 所以要當A沒有值處理
            A = double.Parse(T.Text);                           //當第一次按+號的時候, 用 A 紀錄數字看板上的數值
            //Recorder[0] = T.Text;                               //紀錄A的值為字串存入Recorder[0]
            RecorderList.Add(T.Text);                           //紀錄A的值為字串存入RecorderList[在List 裡新增string 字串]
            //T.Text = "0";                                     //不要把看板數字歸0(因為不符合人類看到計算機的直覺,而是應該要保留已輸入的數字)
            op = ((Button)sender).Tag.ToString();               //接著用op來紀錄目前點選之按鈕的Tag值(在bAdd下就是'+'了)
            //Recorder[1] = ((Button)sender).Tag.ToString();      //紀錄op的值為字串存入Recorder[1]
            RecorderList.Add(((Button)sender).Tag.ToString());  //紀錄op的符號為字串存入RecorderList[在List 裡新增string 字串]
            isStatusNew = true;                                 //輸入運算元之後,後面因為要準備承接新的數字,要把isStatusNew改成true

            //最後會到From_Load去設定其他 - * / 共用此副程式
        }

        //執行計算(=)符號
        private void bEQ_Click(object sender, EventArgs e)
        {
            //按完Clear鍵之後, 這邊進入bEQ, 產生
            B = double.Parse(T.Text);            //用 B 來紀錄輸入的第二個數字
            //Recorder[2] = T.Text;                //紀錄B的值為字串存入Recorder[2]
            RecorderList.Add(T.Text);  //紀錄B的符號為字串存入RecorderList[在List 裡新增string 字串]
                                       //我這邊在思考的是：似乎要將"="的功能分開，利用兩種不一樣的等號功能去區分最後結算用的等號功能還是連續運算用的等號功能
            C = 0;                               //宣告'變數C'準備承接計算的結果
            switch (op)                          //根據先前op的輸入結果(輸入加減乘除號的內部Tag值)來決定作何種運算
            {
                case "+": C = helper.add(A, B); break;
                case "-": C = helper.sub(A, B); break;
                case "*": C = helper.mul(A, B); break;
                case "/": C = helper.div(A, B); break;
            }
            T.Text = C.ToString();               //把 答案C 顯示在看板上
            //Recorder[3] = T.Text;                //紀錄C的值為字串存入Recorder[3]
            RecorderList.Add(" = ");
            RecorderList.Add(T.Text);            //紀錄C的符號為字串存入RecorderList[在List 裡新增string 字串]
            RecorderList.Add("N");               //因為要結算，特別在等號後的C接著再紀錄一個分隔符號，自定的，例如 N，因為簡易計算機應該不有Ｎ
            writeLog();                          //把運算過程寫入Log;
            //A = C;                               //把 答案C 設定給原來儲存在第一個計算數值A, 用來作連續運算使用(//把A = C先取消，但=後還是有問題)
            B = 0;                               //把 B歸0
            C = 0;                               //把 C歸0
            A = Double.NaN;                      //把 = 後面加入運算子再加運算子後匯出的bug解掉
        }

        private void bEQ_OP_Click(object sender, EventArgs e)
        {
            //按完Clear鍵之後, 這邊進入bEQ, 產生
            B = double.Parse(T.Text);            //用 B 來紀錄輸入的第二個數字
            //Recorder[2] = T.Text;                //紀錄B的值為字串存入Recorder[2]
            RecorderList.Add(T.Text);   //紀錄B的符號為字串存入RecorderList[在List 裡新增string 字串]
            RecorderList.Add(" === ");  //紀錄並區分前兩個運算元計算的結果
            //我這邊在思考的是：似乎要將"="的功能分開，利用兩種不一樣的等號功能去區分最後結算用的等號功能還是連續運算用的等號功能
            //所以bEQ_OP_Click的功能，是用來給加減乘除鍵連續使用的
            C = 0;                               //宣告'變數C'準備承接計算的結果
            switch (op)                          //根據先前op的輸入結果(輸入加減乘除號的內部Tag值)來決定作何種運算
            {
                case "+": C = helper.add(A, B); break;
                case "-": C = helper.sub(A, B); break;
                case "*": C = helper.mul(A, B); break;
                case "/": C = helper.div(A, B); break;
            }
            T.Text = C.ToString();               //把 答案C 顯示在看板上
            //Recorder[3] = T.Text;                //紀錄C的值為字串存入Recorder[3]
//            RecorderList.Add(T.Text);            //紀錄C的符號為字串存入RecorderList[在List 裡新增string 字串]
            //writeLog();                          //把運算過程寫入Log; 這裡是繼續相加減乘除，還不用寫檔
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

        //寫檔功能--開始
        private void writeLog()
        {
            //試著檢查calculator_log.txt是否有內容，有的話，讀取全部定重新寫入，以確保內容不會被消除==>但顯然這段語法在這裡有問題
            //[參考Ref: https://msdn.microsoft.com/zh-tw/library/3zc0w663(v=vs.110).aspx]
            StreamReader sr = new StreamReader(@"c:\calculator_log.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            //
            StreamWriter sw = new StreamWriter(@"C:\calculator_log.txt");

            sw.Write("\r\nLog Entry : ");
            sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            for (int i = 0; i < RecorderList.Count; i++)        //把RecorderList內的所有紀錄一一寫出來
            {
                if (RecorderList[i] == "N")
                {
                    sw.WriteLine(RecorderList[i]);              //遇到 N 的時候，寫入檔案最末並換行 [如：a, +, b, +, c, = , 5, N 然後換行]
                }

                sw.Write(RecorderList[i]);                      //沒遇到 N 的時候，一直在同一行寫下去 [如：a, +, b, +, c, = , 5]
            }//研究foreach的寫法，我試著寫了一次發現有點問題，再找時間研究
            sw.WriteLine("-------------------------------");

            sw.Close();                                         //關檔並紀錄 sw 用來入.txt檔案中

            //將RecorderList重設
            RecorderList.Clear();                                       //Clear 方法會用來從清單移除所有項目[Count會清空，Capacity會不變]

        }//寫檔功能--結束

        //讀檔功能
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }//讀檔功能--結束


    }
}

/*
我不太確定以下問法是否合宜或正確，我試著用文字來表達過程。
我覺得還需要一點時間來測試跟解決debug上乘是不能動的問題。


1.目前已知 List<T> 的功能是 C#提供的一個 動態陣列，不必是先宣告 List的大小<或長度>

2.我在一開始宣告變數的地方 List<string> RecorderList = new List<string>();   //宣告一個 不用宣告大小的動態陣列，名稱叫做 RecorderList，型別為<string>

3.在按 +-* / 的位置，用 RecorderList.Add(T.Text) 去接 第一個輸入數字 的字串；
4.並再接 運算子 的 字串

5.在 "=" 功能裡，用 RecorderList.Add(T.Text) 去接 第二個數字的字串
//我這邊在思考的是：似乎要將"="的功能分開，利用兩種不一樣的等號功能去區分最後結算用的等號功能還是連續運算用的等號功能

6.最後期望寫一個writeLog(); 試著把運算過程寫入Log


        private void writeLog()
        {           
            bool b = File.Exists(@"c:\calculator_log.txt");
            File.Create(@"c:\calculator_log.txt");    //這一段語法在debug過程有誤，我要再查。
 
            StreamWriter sw = new StreamWriter(@"c:\calculator_log.txt");

            
            for (int i = 0; i < RecorderList.Count; i++)        //把RecorderList內的所有紀錄一一寫出來
            {
                sw.WriteLine( RecorderList[i] );		//但這樣的作法只是將每個數字一行行列出，並未做到 等號後 直接印出整行的運算，可能會運用到Stack的功能
            }
            
            sw.Close();
         } 
*/
