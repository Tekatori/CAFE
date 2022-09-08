namespace QuanLiCaPhe
{
    partial class Pay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pay));
            this.gpbBill = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.Label();
            this.txtNameTable = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbBill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbBill
            // 
            this.gpbBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gpbBill.Controls.Add(this.txtTotal);
            this.gpbBill.Controls.Add(this.txtSTT);
            this.gpbBill.Controls.Add(this.txtNameTable);
            this.gpbBill.Controls.Add(this.btnPay);
            this.gpbBill.Controls.Add(this.btnHuy);
            this.gpbBill.Controls.Add(this.label6);
            this.gpbBill.Controls.Add(this.label5);
            this.gpbBill.Controls.Add(this.pnlBill);
            this.gpbBill.Controls.Add(this.label2);
            this.gpbBill.Controls.Add(this.label1);
            this.gpbBill.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gpbBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gpbBill.Location = new System.Drawing.Point(12, 12);
            this.gpbBill.Name = "gpbBill";
            this.gpbBill.Size = new System.Drawing.Size(456, 579);
            this.gpbBill.TabIndex = 3;
            this.gpbBill.TabStop = false;
            this.gpbBill.Text = "Hóa đơn";
            // 
            // txtTotal
            // 
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTotal.Location = new System.Drawing.Point(119, 455);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(144, 31);
            this.txtTotal.TabIndex = 19;
            this.txtTotal.Click += new System.EventHandler(this.txtTotal_Click);
            // 
            // txtSTT
            // 
            this.txtSTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtSTT.Location = new System.Drawing.Point(88, 24);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(166, 27);
            this.txtSTT.TabIndex = 18;
            // 
            // txtNameTable
            // 
            this.txtNameTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtNameTable.Location = new System.Drawing.Point(99, 27);
            this.txtNameTable.Name = "txtNameTable";
            this.txtNameTable.Size = new System.Drawing.Size(141, 24);
            this.txtNameTable.TabIndex = 17;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPay.Location = new System.Drawing.Point(8, 527);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(139, 46);
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnHuy.Location = new System.Drawing.Point(153, 527);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 46);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Cancel";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(269, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "VNĐ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "STT     Món      Số lượng";
            // 
            // pnlBill
            // 
            this.pnlBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBill.AutoScroll = true;
            this.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlBill.Location = new System.Drawing.Point(6, 84);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(174, 346);
            this.pnlBill.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số bàn:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng cộng:";
            // 
            // Pay
            // 
            this.AcceptButton = this.btnPay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(560, 603);
            this.Controls.Add(this.gpbBill);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Pay_Load);
            this.gpbBill.ResumeLayout(false);
            this.gpbBill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbBill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label txtSTT;
        private System.Windows.Forms.Label txtNameTable;
        private System.Windows.Forms.Label txtTotal;
    }
}