namespace Try
{
    partial class CityForm
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
            this.TXTEnglishName = new System.Windows.Forms.TextBox();
            this.TXTArabicName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.SuspendLayout();
            // 
            // GridForm
            // 
            this.GridForm.Location = new System.Drawing.Point(50, 50);
            // 
            // FndNumber
            // 
            this.FndNumber.Text = "0";
            // 
            // TXTEnglishName
            // 
            this.TXTEnglishName.Location = new System.Drawing.Point(149, 151);
            this.TXTEnglishName.Name = "TXTEnglishName";
            this.TXTEnglishName.Size = new System.Drawing.Size(231, 20);
            this.TXTEnglishName.TabIndex = 40;
            // 
            // TXTArabicName
            // 
            this.TXTArabicName.Location = new System.Drawing.Point(149, 113);
            this.TXTArabicName.Name = "TXTArabicName";
            this.TXTArabicName.Size = new System.Drawing.Size(231, 20);
            this.TXTArabicName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "English Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Arabic Name";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(149, 191);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(231, 20);
            this.txtCountry.TabIndex = 43;
            this.txtCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCountry_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Country";
            // 
            // CityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 278);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXTEnglishName);
            this.Controls.Add(this.TXTArabicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IDFieldName = "0";
            this.Name = "CityForm";
            this.NCode = "0";
            this.TableName = "City";
            this.Text = "CityForm";
            this.Controls.SetChildIndex(this.FndNumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TXTArabicName, 0);
            this.Controls.SetChildIndex(this.TXTEnglishName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCountry, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTEnglishName;
        private System.Windows.Forms.TextBox TXTArabicName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label3;
    }
}