using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Try.Data;
using Try.Logic;
using Try.DAL;

namespace Try
{
    public partial class CountryForm : DataForm
    {
        CountryData CountryData;
        CodeLogic logc;
        public CountryForm()
        {
            CountryData = new CountryData();
            logc = new CodeLogic();
            InitializeComponent();
        }

        protected override void LoadWindowsForm()
        {
            //CountryData.ID = this.ID;
            base.LoadWindowsForm();

            this.FormId = obj.GetType().GetProperty("ID").GetValue(obj, null);
            this.FID = (int)FormId;

            this.CodeField = obj.GetType().GetProperty("CodeField").GetValue(obj, null);
            this.FCode = CodeField.ToString();

            this.IDField = obj.GetType().GetProperty("IDField").GetValue(obj, null);
            this.IDFieldName = IDField.ToString();

            this.Table = obj.GetType().GetProperty("TableName").GetValue(obj, null);
            this.Tbl = Table.ToString();

            //FndNumber.Text = CountryData.ID.ToString();
        }

        protected override bool SubmitData()
        {
            CodeLogic logc = new CodeLogic();
            try
            {
                logc.CountryCode(CountryData);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool ValidateUpdate()
        {
            if (!base.ValidateUpdate())
                return false;
            if (!ValidateMandatory())
                return false;
            return true;
        }
        private bool ValidateMandatory()
        {
            if (TXTArabicName.Text.Trim() == string.Empty)
            {
                string msg = CurrentUILanguage == "ar-EG" ? "يجب ادخال الأسم العربى" : "Please enter Arabic Name";
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                TXTArabicName.Focus();
                return false;
            }
            else if (TXTEnglishName.Text.Trim() == string.Empty)
            {
                string msg = CurrentUILanguage == "ar-EG" ? "يجب ادخال الأسم الانجليزى" : "Please enter English Name";
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                TXTEnglishName.Focus();
                return false;
            }
            return true;
        }

        public override bool ValidateSaveNew()
        {
            if (!base.ValidateSaveNew())
                return false;
            if (!ValidateMandatory())
                return false;
            return true;
        }
        public override bool ValidateDelete()
        {
            return base.ValidateDelete();
        }

        public override void SaveAddNew()
        {
            CountryData.DataStatus = DataStatus.New;
            base.SaveAddNew();
        }

        public override void SaveUpdate()
        {
            CountryData.DataStatus = DataStatus.Modified;
            base.SaveUpdate();
        }

        public override void Delete()
        {
            CountryData.DataStatus = DataStatus.Deleted;
            //CountryData.ID = Convert.ToInt32(FndNumber.Text);
            base.Delete();
        }

        protected override void CheckActiveMode()
        {
            DataTable chk = new DataTable();
            WindowsFormLogic logic = new WindowsFormLogic();
            chk = logic.GetID(this.Tbl, Convert.ToString(IDField), CountryData.ID);

            if (chk.Rows.Count == 1)
            {
                ActiveMode = EnumActiveMode.EditMode;
            }
            if (chk.Rows.Count == 0)
            {
                ActiveMode = EnumActiveMode.AddMode;
            }

            base.CheckActiveMode();
        }

        protected override void DisplayData()
        {
            CountryData = logc.GetCountryDataByID(FndNumber.Text);
            FndNumber.Text = CountryData.Code;
            TXTArabicName.Text = CountryData.ArabicName;
            TXTEnglishName.Text = CountryData.EnglishName;

        }
        protected override void ReadData()
        {
            CountryData.Code = FndNumber.Text;
            CountryData.ArabicName = TXTArabicName.Text;
            CountryData.EnglishName = TXTEnglishName.Text;
        }
    }
}
