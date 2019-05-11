namespace Try
{
    partial class CountryForm
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
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.SuspendLayout();
            // 
            // GridForm
            // 
            this.GridForm.Location = new System.Drawing.Point(25, 25);
            // 
            // FndNumber
            // 
            this.FndNumber.Text = "0";
            // 
            // TXTEnglishName
            // 
            this.TXTEnglishName.Location = new System.Drawing.Point(149, 142);
            this.TXTEnglishName.Name = "TXTEnglishName";
            this.TXTEnglishName.Size = new System.Drawing.Size(231, 20);
            this.TXTEnglishName.TabIndex = 36;
            // 
            // TXTArabicName
            // 
            this.TXTArabicName.Location = new System.Drawing.Point(149, 104);
            this.TXTArabicName.Name = "TXTArabicName";
            this.TXTArabicName.Size = new System.Drawing.Size(231, 20);
            this.TXTArabicName.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "English Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Arabic Name";
            // 
            // CountryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 216);
            this.Controls.Add(this.TXTEnglishName);
            this.Controls.Add(this.TXTArabicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IDFieldName = "0";
            this.Name = "CountryForm";
            this.NCode = "0";
            this.TableName = "Country";
            this.Text = "CountryForm";
            this.Controls.SetChildIndex(this.FndNumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TXTArabicName, 0);
            this.Controls.SetChildIndex(this.TXTEnglishName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTEnglishName;
        private System.Windows.Forms.TextBox TXTArabicName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}