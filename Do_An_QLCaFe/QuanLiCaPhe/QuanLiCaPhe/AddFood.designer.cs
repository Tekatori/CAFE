namespace QuanLiCaPhe
{
    partial class AddFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFood));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSTT = new System.Windows.Forms.Label();
            this.txtBan = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cbbCount = new System.Windows.Forms.NumericUpDown();
            this.lblCount = new System.Windows.Forms.Label();
            this.cbbFood = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.txtSTT);
            this.groupBox1.Controls.Add(this.txtBan);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.cbbCount);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.cbbFood);
            this.groupBox1.Controls.Add(this.lblMon);
            this.groupBox1.Controls.Add(this.lblTable);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtSTT
            // 
            this.txtSTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.txtSTT, "txtSTT");
            this.txtSTT.Name = "txtSTT";
            // 
            // txtBan
            // 
            resources.ApplyResources(this.txtBan, "txtBan");
            this.txtBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtBan.Name = "txtBan";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbl1
            // 
            resources.ApplyResources(this.lbl1, "lbl1");
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl1.Name = "lbl1";
            // 
            // cbbCount
            // 
            this.cbbCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbbCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.cbbCount, "cbbCount");
            this.cbbCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cbbCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cbbCount.Name = "cbbCount";
            this.cbbCount.ReadOnly = true;
            this.cbbCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCount
            // 
            resources.ApplyResources(this.lblCount, "lblCount");
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCount.Name = "lblCount";
            // 
            // cbbFood
            // 
            this.cbbFood.BackColor = System.Drawing.Color.White;
            this.cbbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cbbFood.FormattingEnabled = true;
            resources.ApplyResources(this.cbbFood, "cbbFood");
            this.cbbFood.Name = "cbbFood";
            // 
            // lblMon
            // 
            resources.ApplyResources(this.lblMon, "lblMon");
            this.lblMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblMon.Name = "lblMon";
            // 
            // lblTable
            // 
            resources.ApplyResources(this.lblTable, "lblTable");
            this.lblTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTable.Name = "lblTable";
            // 
            // AddFood
            // 
            this.AcceptButton = this.btnAdd;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFood";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAddFood_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.NumericUpDown cbbCount;
        private System.Windows.Forms.Label lblCount;
        public System.Windows.Forms.ComboBox cbbFood;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label txtSTT;
        private System.Windows.Forms.Label txtBan;
    }
}