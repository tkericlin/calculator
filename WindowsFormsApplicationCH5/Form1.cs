using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// 2015.06.26 增刪
// 1.加入連續+-*/功能 
// 2.按Clear後,問題會出現在+-*/之後
// 3.[Line: 190-199] 試圖加入 Init功能 到 bClear_Click()中

// 問題;
// public 與 private差異? 
// 用什麼語法或函式 將 private的值傳到外面的主程式中?
// (Q1:什麼是NaN?)  (Q2: 放在這邊會變公用 )
// (Q3: 跳出private void bClear_Click外面後, 紀錄值仍是之前輸入的 A值)
// (Q4: 跳出private void bClear_Click外面後, 紀錄值仍是之前輸入的 A值)
// (Q5: 跳出private void bClear_Click外面後, 紀錄值仍是之前輸入的 A值)



namespace WindowsFormsApplicationCH5
{
    public partial class Form1 : Form
    {
        bool isStatusNew = true;

        //int isClearNew =  

        public Form1()
        {
            InitializeComponent();
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

            //請到From_Load去設定其他 b1~b9 , 共用此副程式
        }




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
        double A = Double.NaN;                    // 把 A 設為浮點數, 但先不給予值, 而是NaN                                                       (Q1:什麼是NaN?)  (Q2: 放在這邊會變公用 )
        String op;                                // 設 參數op 去接未來的運算子
        private void bAdd_Click(object sender, EventArgs e)
        {
            if (!Double.IsNaN(A))                 // 當 A = NaN 時 ==> Double.IsNaN(A) 值為 true ==> 所以 !true ==> false ==> 就不會進去
            {
                // Not First Click +              //因為不是第一次按+號,所以按完+號後,直接先做一次按"="的運算
                bEQ_Click(null, null);            //bEQ_Click代表呼叫bEQ按下去的功能, 前後兩個數值不重要, 所以給null
            }

                // First Click +                  //因為從未按過+號, 所以要當A沒有值處理
            A = double.Parse(T.Text);             //當第一次按+號的時候, 用 A 紀錄數字看板上的數值
            //T.Text = "0";                       //不要把看板數字歸0
            op = ((Button)sender).Tag.ToString(); //接著用op來紀錄目前點選之按鈕的Tag值(在bAdd下就是'+'了)
            isStatusNew = true;                   //輸入運算元之後,後面因為要準備承接新的數字,要把isStatusNew改成true

            //最後會到From_Load去設定其他 - * / 共用此副程式
        }


        //執行計算(=)符號
        private void bEQ_Click(object sender, EventArgs e)
        {
                                                //按完Clear鍵之後, 這邊進入bEQ, 產生


            double B = double.Parse(T.Text);    //用 B 來紀錄輸入的第二個數字
            double C = 0;                       //宣告'變數C'準備承接計算的結果
            switch (op)                         //根據先前op的輸入結果(輸入加減乘除號的內部Tag值)來決定作何種運算
            {
                case "+": C = A + B; break;
                case "-": C = A - B; break;
                case "*": C = A * B; break;
                case "/": C = A / B; break;
            }
            T.Text = C.ToString();              //把 答案C 顯示在看板上
            A = C;                              //把 答案C 設定給原來儲存在第一個計算數值A, 用來作連續運算使用
            B = 0;                              //把 B歸0
            C = 0;                              //把 C歸0
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
                if (T.Text.IndexOf("-") >=0)
                {
                    T.Text = T.Text.Replace("-","");  //把"-"取代成沒有負號
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
            //T.Text = "0";             //把看板歸零
            //A = 0;                    //把內部計算相關的參數也歸0
            //op = "";                  //把內部計算相關的參數也歸0

            
            T.Text = "0";               //把看板歸零
            isStatusNew = true;         //把isStatusNew 轉為新的(true)
            double A = Double.NaN;      //把 A 指定設成 NaN                                                          (Q3: 跳出private void bClear_Click外面後, 紀錄值仍是之前輸入的 A值)
            double B = 0;
            double C = 0;
            op = null;                  //把 op 改為 null
            Init();                     // 新增; 呼叫 Init
            //  InitializationEventAttribute                                                                         (Q4: 如何查詢使用方法?)
        }

        
        //設定呼叫初始化
        public void Init()
        {
            T.Text = "0";               //把看板歸零
            isStatusNew = true;         //把isStatusNew 轉為新的(true)
            double A = Double.NaN;      //把 A 指定設成 NaN                                                            (Q5: 跳出private void bClear_Click外面後, 紀錄值仍是之前輸入的 A值)
            double B = 0;
            double C = 0;
            op = null;                  //把 op 改為 null
        }

        /*
        public InitializationEventAttribute(string eventName)
        {
            
        }
        */

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

       


        
    }
}
