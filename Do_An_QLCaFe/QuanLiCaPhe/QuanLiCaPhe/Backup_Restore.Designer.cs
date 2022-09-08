namespace QuanLiCaPhe
{
    partial class Backup_Restore
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup_Restore));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBackUpBrowse = new System.Windows.Forms.Button();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtRestore = new System.Windows.Forms.TextBox();
            this.btnRestoreBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnThoat = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Controls.Add(this.btnBackUpBrowse);
            this.groupBox1.Controls.Add(this.txtBackup);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Location = new System.Drawing.Point(39, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sao lưu dữ liệu";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(389, 51);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackUpBrowse
            // 
            this.btnBackUpBrowse.Location = new System.Drawing.Point(292, 52);
            this.btnBackUpBrowse.Name = "btnBackUpBrowse";
            this.btnBackUpBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBackUpBrowse.TabIndex = 2;
            this.btnBackUpBrowse.Text = "Browse";
            this.btnBackUpBrowse.UseVisualStyleBackColor = true;
            this.btnBackUpBrowse.Click += new System.EventHandler(this.btnBackUpBrowse_Click);
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(92, 53);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(179, 20);
            this.txtBackup.TabIndex = 1;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(37, 54);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar2);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.txtRestore);
            this.groupBox2.Controls.Add(this.btnRestoreBrowse);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(39, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 141);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phục hồi dữ liệu";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(389, 50);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtRestore
            // 
            this.txtRestore.Location = new System.Drawing.Point(92, 50);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.Size = new System.Drawing.Size(179, 20);
            this.txtRestore.TabIndex = 5;
            // 
            // btnRestoreBrowse
            // 
            this.btnRestoreBrowse.Location = new System.Drawing.Point(292, 50);
            this.btnRestoreBrowse.Name = "btnRestoreBrowse";
            this.btnRestoreBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreBrowse.TabIndex = 6;
            this.btnRestoreBrowse.Text = "Browse";
            this.btnRestoreBrowse.UseVisualStyleBackColor = true;
            this.btnRestoreBrowse.Click += new System.EventHandler(this.btnRestoreBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Location";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(424, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(239, 390);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 42);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(40, 90);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(424, 23);
            this.progressBar2.TabIndex = 11;
            this.progressBar2.Click += new System.EventHandler(this.progressBar2_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Backup_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 443);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Backup_Restore";
            this.Text = "Sao lưu và phục hồi dữ liệu";
            this.Load += new System.EventHandler(this.Backup_Restore_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBackUpBrowse;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtRestore;
        private System.Windows.Forms.Button btnRestoreBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Timer timer2;
    }
}