using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Remoting;
using System.Configuration;
using C1.Win.C1Ribbon;
using System.Threading;
using Try.ReportForm;

namespace Try
{
    public partial class MainForm : C1.Win.C1Ribbon.C1RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Form Window { get; set; }

        public static bool CheckIfFormOpened(string formName)
        {
            try
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Name == formName && item.Tag != null)
                    {
                        item.Focus();
                        return true;
                    } // end if
                } // end foreach
            } // end try
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            } // end catch

            return false;
        }

        private void ribbonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (((RibbonButton)sender).Tag != null && !String.IsNullOrEmpty(((RibbonButton)sender).Tag.ToString().Trim()))
                {
                    string nameofWindow = ((RibbonButton)sender).Tag.ToString().Trim();

                    if (nameofWindow.IndexOf("!") >= 0)
                    {
                        nameofWindow = nameofWindow.Trim().Split('!')[0];
                    }
                    ObjectHandle objHandle = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, Application.ProductName + "." + nameofWindow);
                    Window = (Form)objHandle.Unwrap();

                    if (Window == null)
                    {
                        return;
                    } // end if

                    if (((RibbonButton)sender).Tag.ToString().Trim().IndexOf("!") >= 0)
                    {
                        Window.Tag = ((RibbonButton)sender).Tag.ToString().Trim().Split('!')[1];
                    } // end if
                    else
                    {
                        Window.Tag = string.Empty;
                    } // end else

                    if (Window.Tag != null && !CheckIfFormOpened(Window.Name))
                    {
                        this.AddOwnedForm(Window);
                        Window.StartPosition = FormStartPosition.CenterScreen;

                        rmOpenWindows.Items.Clear();
                        Form[] childarray = this.OwnedForms;
                        foreach (Form child in childarray)
                        {
                            C1.Win.C1Ribbon.RibbonButton btnWindow = new C1.Win.C1Ribbon.RibbonButton(child.Text);

                            rmOpenWindows.Items.Add(btnWindow);
                        }

                        Window.BackColor = this.BackColor;
                        Window.Show(this);



                    } // end if
                    else
                    {
                        Window.Activate();
                        this.Cursor = Cursors.Default;
                    } // end else
                } // end if
            } // end try
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            } // end catch

            if (Window.GetType().BaseType == typeof(DataForm))
            {

                ////(Permissions.Delete == ((DataForm)frm).Permissions & Permissions.Add)) && ((DataForm)frm).AddNewButton 
                //if (((DataForm)Window)._AddNewButton) //&& ((DataForm)frm).Name != "CostcenterOpenBalanceForm")
                //{
                //    //ToolBar_ButtonClick(2);//add new
                //    ((DataForm)Window).ToolBar_ButtonClick("bttnAddNew");
                //}
                //else
                //{
                //    //ToolBar_ButtonClick(3);//stopAddNew
                //    ((DataForm)Window).ToolBar_ButtonClick("bttnStopAddNew");
                //}
            }

        }

        private void ribCountry_Click(object sender, EventArgs e)
        {
            CountryForm frm = new CountryForm();
            frm.ShowDialog();
        }

        private void ribCity_Click(object sender, EventArgs e)
        {
            CityForm frm = new CityForm();
            frm.ShowDialog();
        }

        private void ribZone_Click(object sender, EventArgs e)
        {
            ZoneForm frm = new ZoneForm();
            frm.ShowDialog();
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            SalesForm frm = new SalesForm();
            frm.ShowDialog();
        }

        private void ribZoneReport_Click(object sender, EventArgs e)
        {
            ZoneReport frm = new ZoneReport();
            frm.ShowDialog();
        }

        private void ribCityReport_Click(object sender, EventArgs e)
        {
            CityReport frm = new CityReport();
            frm.ShowDialog();
        }
        
        // end method rb_Click
        //----------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
