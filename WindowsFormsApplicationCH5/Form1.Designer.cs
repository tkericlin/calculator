namespace WindowsFormsApplicationCH5
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.T = new System.Windows.Forms.Label();
            this.b0 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.b5 = new System.Windows.Forms.Button();
            this.b6 = new System.Windows.Forms.Button();
            this.b7 = new System.Windows.Forms.Button();
            this.b8 = new System.Windows.Forms.Button();
            this.b9 = new System.Windows.Forms.Button();
            this.bSign = new System.Windows.Forms.Button();
            this.bDot = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bSub = new System.Windows.Forms.Button();
            this.bMul = new System.Windows.Forms.Button();
            this.bDiv = new System.Windows.Forms.Button();
            this.bBack = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bEQ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // T
            // 
            this.T.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.T.Location = new System.Drawing.Point(245, 50);
            this.T.Name = "T";
            this.T.Size = new System.Drawing.Size(411, 49);
            this.T.TabIndex = 0;
            this.T.Text = "0";
            this.T.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // b0
            // 
            this.b0.Location = new System.Drawing.Point(245, 358);
            this.b0.Name = "b0";
            this.b0.Size = new System.Drawing.Size(64, 58);
            this.b0.TabIndex = 1;
            this.b0.Text = "0";
            this.b0.UseVisualStyleBackColor = true;
            this.b0.Click += new System.EventHandler(this.b0_Click);
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(245, 283);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(64, 58);
            this.b1.TabIndex = 2;
            this.b1.Text = "1";
            this.b1.UseVisualStyleBackColor = true;
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(330, 283);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(64, 58);
            this.b2.TabIndex = 3;
            this.b2.Text = "2";
            this.b2.UseVisualStyleBackColor = true;
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(418, 283);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(64, 58);
            this.b3.TabIndex = 4;
            this.b3.Text = "3";
            this.b3.UseVisualStyleBackColor = true;
            // 
            // b4
            // 
            this.b4.Location = new System.Drawing.Point(245, 208);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(64, 58);
            this.b4.TabIndex = 5;
            this.b4.Text = "4";
            this.b4.UseVisualStyleBackColor = true;
            // 
            // b5
            // 
            this.b5.Location = new System.Drawing.Point(330, 208);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(64, 58);
            this.b5.TabIndex = 6;
            this.b5.Text = "5";
            this.b5.UseVisualStyleBackColor = true;
            // 
            // b6
            // 
            this.b6.Location = new System.Drawing.Point(418, 208);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(64, 58);
            this.b6.TabIndex = 7;
            this.b6.Text = "6";
            this.b6.UseVisualStyleBackColor = true;
            // 
            // b7
            // 
            this.b7.Location = new System.Drawing.Point(245, 127);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(64, 58);
            this.b7.TabIndex = 8;
            this.b7.Text = "7";
            this.b7.UseVisualStyleBackColor = true;
            // 
            // b8
            // 
            this.b8.Location = new System.Drawing.Point(330, 127);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(64, 58);
            this.b8.TabIndex = 9;
            this.b8.Text = "8";
            this.b8.UseVisualStyleBackColor = true;
            // 
            // b9
            // 
            this.b9.Location = new System.Drawing.Point(418, 127);
            this.b9.Name = "b9";
            this.b9.Size = new System.Drawing.Size(64, 58);
            this.b9.TabIndex = 10;
            this.b9.Text = "9";
            this.b9.UseVisualStyleBackColor = true;
            // 
            // bSign
            // 
            this.bSign.Location = new System.Drawing.Point(330, 358);
            this.bSign.Name = "bSign";
            this.bSign.Size = new System.Drawing.Size(64, 58);
            this.bSign.TabIndex = 11;
            this.bSign.Text = "+/-";
            this.bSign.UseVisualStyleBackColor = true;
            this.bSign.Click += new System.EventHandler(this.bSign_Click);
            // 
            // bDot
            // 
            this.bDot.Location = new System.Drawing.Point(418, 358);
            this.bDot.Name = "bDot";
            this.bDot.Size = new System.Drawing.Size(64, 58);
            this.bDot.TabIndex = 12;
            this.bDot.Text = ".";
            this.bDot.UseVisualStyleBackColor = true;
            this.bDot.Click += new System.EventHandler(this.bDot_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(506, 127);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(64, 58);
            this.bAdd.TabIndex = 13;
            this.bAdd.Tag = "+";
            this.bAdd.Text = "+";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bSub
            // 
            this.bSub.Location = new System.Drawing.Point(506, 208);
            this.bSub.Name = "bSub";
            this.bSub.Size = new System.Drawing.Size(64, 58);
            this.bSub.TabIndex = 14;
            this.bSub.Tag = "-";
            this.bSub.Text = "-";
            this.bSub.UseVisualStyleBackColor = true;
            // 
            // bMul
            // 
            this.bMul.Location = new System.Drawing.Point(506, 283);
            this.bMul.Name = "bMul";
            this.bMul.Size = new System.Drawing.Size(64, 58);
            this.bMul.TabIndex = 15;
            this.bMul.Tag = "*";
            this.bMul.Text = "*";
            this.bMul.UseVisualStyleBackColor = true;
            // 
            // bDiv
            // 
            this.bDiv.Location = new System.Drawing.Point(506, 358);
            this.bDiv.Name = "bDiv";
            this.bDiv.Size = new System.Drawing.Size(64, 58);
            this.bDiv.TabIndex = 16;
            this.bDiv.Tag = "/";
            this.bDiv.Text = "/";
            this.bDiv.UseVisualStyleBackColor = true;
            // 
            // bBack
            // 
            this.bBack.Location = new System.Drawing.Point(592, 127);
            this.bBack.Name = "bBack";
            this.bBack.Size = new System.Drawing.Size(64, 58);
            this.bBack.TabIndex = 17;
            this.bBack.Text = "Back";
            this.bBack.UseVisualStyleBackColor = true;
            this.bBack.Click += new System.EventHandler(this.bBack_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(592, 208);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(64, 58);
            this.bClear.TabIndex = 18;
            this.bClear.Text = "C";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bEQ
            // 
            this.bEQ.Location = new System.Drawing.Point(592, 358);
            this.bEQ.Name = "bEQ";
            this.bEQ.Size = new System.Drawing.Size(64, 58);
            this.bEQ.TabIndex = 19;
            this.bEQ.Tag = "";
            this.bEQ.Text = "=";
            this.bEQ.UseVisualStyleBackColor = true;
            this.bEQ.Click += new System.EventHandler(this.bEQ_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 542);
            this.Controls.Add(this.bEQ);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bBack);
            this.Controls.Add(this.bDiv);
            this.Controls.Add(this.bMul);
            this.Controls.Add(this.bSub);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bDot);
            this.Controls.Add(this.bSign);
            this.Controls.Add(this.b9);
            this.Controls.Add(this.b8);
            this.Controls.Add(this.b7);
            this.Controls.Add(this.b6);
            this.Controls.Add(this.b5);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b0);
            this.Controls.Add(this.T);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label T;
        private System.Windows.Forms.Button b0;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b5;
        private System.Windows.Forms.Button b6;
        private System.Windows.Forms.Button b7;
        private System.Windows.Forms.Button b8;
        private System.Windows.Forms.Button b9;
        private System.Windows.Forms.Button bSign;
        private System.Windows.Forms.Button bDot;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bSub;
        private System.Windows.Forms.Button bMul;
        private System.Windows.Forms.Button bDiv;
        private System.Windows.Forms.Button bBack;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bEQ;
    }
}

