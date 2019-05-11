namespace Try
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ToolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tslVersion = new System.Windows.Forms.ToolStripLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.ToolBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar1
            // 
            this.ToolBar1.AutoSize = false;
            this.ToolBar1.BackColor = System.Drawing.Color.Lavender;
            this.ToolBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnOk,
            this.toolStripSeparator3,
            this.toolStripBtnExit,
            this.toolStripSeparator4,
            this.tslVersion});
            this.ToolBar1.Location = new System.Drawing.Point(0, 355);
            this.ToolBar1.Name = "ToolBar1";
            this.ToolBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolBar1.Size = new System.Drawing.Size(311, 35);
            this.ToolBar1.TabIndex = 112;
            // 
            // toolStripBtnOk
            // 
            this.toolStripBtnOk.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOk.Image")));
            this.toolStripBtnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOk.Name = "toolStripBtnOk";
            this.toolStripBtnOk.Size = new System.Drawing.Size(42, 32);
            this.toolStripBtnOk.Text = "Ok";
            this.toolStripBtnOk.Click += new System.EventHandler(this.toolStripBtnOk_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripBtnExit
            // 
            this.toolStripBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnExit.Image")));
            this.toolStripBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExit.Name = "toolStripBtnExit";
            this.toolStripBtnExit.Size = new System.Drawing.Size(45, 32);
            this.toolStripBtnExit.Text = "Exit";
            this.toolStripBtnExit.ToolTipText = "Exit";
            this.toolStripBtnExit.Click += new System.EventHandler(this.toolStripBtnExit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // tslVersion
            // 
            this.tslVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(46, 32);
            this.tslVersion.Text = "Version";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 276);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(179, 20);
            this.txtPassword.TabIndex = 114;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 250);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(179, 20);
            this.txtUserName.TabIndex = 113;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPassword.Location = new System.Drawing.Point(14, 279);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(82, 13);
            this.lblPassword.TabIndex = 115;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserName.Location = new System.Drawing.Point(14, 253);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(82, 13);
            this.lblUserName.TabIndex = 116;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(311, 390);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.ToolBar1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ToolBar1.ResumeLayout(false);
            this.ToolBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip ToolBar1;
        public System.Windows.Forms.ToolStripButton toolStripBtnOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripBtnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tslVersion;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
    }
}