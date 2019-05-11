namespace Try
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton1 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonButton2 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rmOpenWindows = new C1.Win.C1Ribbon.RibbonSplitButton();
            this.ribCountry = new C1.Win.C1Ribbon.RibbonButton();
            this.ribCity = new C1.Win.C1Ribbon.RibbonButton();
            this.ribZone = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonGroup3 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton3 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonGroup4 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rbMenu = new C1.Win.C1Ribbon.RibbonMenu();
            this.ribZoneReport = new C1.Win.C1Ribbon.RibbonButton();
            this.ribCityReport = new C1.Win.C1Ribbon.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(849, 156);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Groups.Add(this.ribbonGroup2);
            this.ribbonTab1.Groups.Add(this.ribbonGroup3);
            this.ribbonTab1.Groups.Add(this.ribbonGroup4);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Main";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.ribbonButton1);
            this.ribbonGroup1.Items.Add(this.ribbonButton2);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Registry";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Tag = "SignUp";
            this.ribbonButton1.Text = "SignUp";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Tag = "UsersForm";
            this.ribbonButton2.Text = "Users";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton_Click);
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.rmOpenWindows);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Menus";
            // 
            // rmOpenWindows
            // 
            this.rmOpenWindows.Items.Add(this.ribCountry);
            this.rmOpenWindows.Items.Add(this.ribCity);
            this.rmOpenWindows.Items.Add(this.ribZone);
            this.rmOpenWindows.LargeImage = ((System.Drawing.Image)(resources.GetObject("rmOpenWindows.LargeImage")));
            this.rmOpenWindows.Name = "rmOpenWindows";
            this.rmOpenWindows.SmallImage = ((System.Drawing.Image)(resources.GetObject("rmOpenWindows.SmallImage")));
            this.rmOpenWindows.Text = "Open Windows";
            // 
            // ribCountry
            // 
            this.ribCountry.Name = "ribCountry";
            this.ribCountry.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribCountry.SmallImage")));
            this.ribCountry.Text = "Country";
            this.ribCountry.Click += new System.EventHandler(this.ribCountry_Click);
            // 
            // ribCity
            // 
            this.ribCity.Name = "ribCity";
            this.ribCity.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribCity.SmallImage")));
            this.ribCity.Text = "City";
            this.ribCity.Click += new System.EventHandler(this.ribCity_Click);
            // 
            // ribZone
            // 
            this.ribZone.Name = "ribZone";
            this.ribZone.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribZone.SmallImage")));
            this.ribZone.Text = "Zone";
            this.ribZone.Click += new System.EventHandler(this.ribZone_Click);
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Items.Add(this.ribbonButton3);
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Group";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Sales";
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
            // 
            // ribbonGroup4
            // 
            this.ribbonGroup4.Items.Add(this.rbMenu);
            this.ribbonGroup4.Name = "ribbonGroup4";
            this.ribbonGroup4.Text = "Reports";
            // 
            // rbMenu
            // 
            this.rbMenu.Items.Add(this.ribZoneReport);
            this.rbMenu.Items.Add(this.ribCityReport);
            this.rbMenu.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbMenu.LargeImage")));
            this.rbMenu.Name = "rbMenu";
            this.rbMenu.Text = "Reports";
            // 
            // ribZoneReport
            // 
            this.ribZoneReport.Name = "ribZoneReport";
            this.ribZoneReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribZoneReport.SmallImage")));
            this.ribZoneReport.Text = "ZoneReport";
            this.ribZoneReport.Click += new System.EventHandler(this.ribZoneReport_Click);
            // 
            // ribCityReport
            // 
            this.ribCityReport.Name = "ribCityReport";
            this.ribCityReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribCityReport.SmallImage")));
            this.ribCityReport.Text = "City Report";
            this.ribCityReport.Click += new System.EventHandler(this.ribCityReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 508);
            this.Controls.Add(this.c1Ribbon1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonSplitButton rmOpenWindows;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup3;
        public C1.Win.C1Ribbon.RibbonButton ribCountry;
        public C1.Win.C1Ribbon.RibbonButton ribCity;
        public C1.Win.C1Ribbon.RibbonButton ribZone;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton3;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup4;
        private C1.Win.C1Ribbon.RibbonMenu rbMenu;
        private C1.Win.C1Ribbon.RibbonButton ribZoneReport;
        private C1.Win.C1Ribbon.RibbonButton ribCityReport;
    }
}

