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
    public partial class CityForm : DataForm
    {
        CityData CityData;
        CodeLogic logc;
        public CityForm()
        {
            CityData = new CityData();
            logc = new CodeLogic();
            InitializeComponent();
        }

        protected override void LoadWindowsForm()
        {
            //CityData.ID = this.ID;
            base.LoadWindowsForm();

            this.FormId = obj.GetType().GetProperty("ID").GetValue(obj, null);
            this.FID = (int)FormId;

            this.CodeField = obj.GetType().GetProperty("CodeField").GetValue(obj, null);
            this.FCode = CodeField.ToString();

            this.IDField = obj.GetType().GetProperty("IDField").GetValue(obj, null);
            this.IDFieldName = IDField.ToString();

            this.Table = obj.GetType().GetProperty("TableName").GetValue(obj, null);
            this.Tbl = Table.ToString();

            //FndNumber.Text = CityData.ID.ToString();
        }

        protected override bool SubmitData()
        {
            CodeLogic logc = new CodeLogic();
            try
            {
                logc.CityCode(CityData);
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
            CityData.DataStatus = DataStatus.New;
            base.SaveAddNew();
        }

        public override void SaveUpdate()
        {
            CityData.DataStatus = DataStatus.Modified;
            base.SaveUpdate();
        }

        public override void Delete()
        {
            CityData.DataStatus = DataStatus.Deleted;
            //CityData.ID = Convert.ToInt32(FndNumber.Text);
            base.Delete();
        }

        protected override void CheckActiveMode()
        {
            DataTable chk = new DataTable();
            WindowsFormLogic logic = new WindowsFormLogic();
            chk = logic.GetID(this.Tbl, Convert.ToString(IDField), CityData.ID);

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
            CityData = logc.GetCityDataByID(FndNumber.Text);
            FndNumber.Text = CityData.Code;
            TXTArabicName.Text = CityData.ArabicName;
            TXTEnglishName.Text = CityData.EnglishName;
            txtCountry.Text = CityData.CountryID.ToString();
        }
        protected override void ReadData()
        {
            CityData.Code = FndNumber.Text;
            CityData.ArabicName = TXTArabicName.Text;
            CityData.EnglishName = TXTEnglishName.Text;
            CityData.CountryID = Convert.ToInt32(txtCountry.Text);
        }

        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WindowsFormLogic logic = new WindowsFormLogic();
                this.dt = logic.GetAll("Country");

                this.GridForm.dgv.DataSource = dt;
                if (this.GridForm.dgv.Rows.Count > 0)
                {
                    this.GridForm.dgv.Columns[0].Visible = false;
                }
                this.GridForm.ShowDialog();

                txtCountry.Text = GridForm.dgv.CurrentRow.Cells[0].Value.ToString();
            }
        }
    }
}
