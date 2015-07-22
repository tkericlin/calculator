using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplicationCH5
{
    class Helper
    {
        public Helper()
        {

        }

        private double add(double A, double B)
        {
            return A + B;
        }

        private double sub(double A, double B)
        {
            return A - B;
        }

        private double mul(double A, double B)
        {
            return A * B;
        }

        private double div(double A, double B)
        {
            return A / B;
        }

        public double calculate(double A, double B, string op)
        {
            double C = 0;                               //宣告'變數C'準備承接計算的結果
            switch (op)                          //根據先前op的輸入結果(輸入加減乘除號的內部Tag值)來決定作何種運算
            {
                case "+": C = add(A, B); break;
                case "-": C = sub(A, B); break;
                case "*": C = mul(A, B); break;
                case "/": C = div(A, B); break;
            }
            //T.Text = C.ToString();               //把 答案C 顯示在看板上
            return C;
        }

        private void nonsense()
        { }
    }
}
