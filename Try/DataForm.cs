using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.IO;
using Try.DAL;

using Try.Data;

using Try.Logic;

namespace Try
{
    public delegate void OnClosing(out bool Cancel);

    public partial class DataForm : C1.Win.C1Ribbon.C1RibbonForm
    {
        public BasicData BasicData { get; set; }
        public int Code { get; set; }
        public object obj { get; set; }
        public object FormId { get; set; }
        public int FID { get; set; }
        public object Table { get; set; }
        public string Tbl { get; set; }
        public object CodeField { get; set; }
        public string FCode { get; set; }
        public object NxtCode { get; set; }
        public string NCode { get; set; }
        public object IDField { get; set; }
        public string IDFieldName { get; set; }

        public GridForm GridForm = new GridForm();

        public DataTable dt = new DataTable();
        public Form _activeForm = null;
        public bool _useMDIForms = false;
        public long CurrentID = 0;
        bool _IsSaving = false;
        public bool ShowClosingMessage = true;
        //public SaveAndPrintFormResults SaveAndPrintResult = SaveAndPrintFormResults.SaveOnly;
        public object ParentName = null;
        //CultureInfo _CultureArInfo = new CultureInfo("ar-EG");
        //CultureInfo _CultureEnInfo = new CultureInfo("en-US");
        //public bool _FromReport = false;
        //public bool _Deleting = false;
        //private PrintOrientation _PrintDefaultOrientation = PrintOrientation.Landscape;

        //public PrintOrientation PrintDefaultOrientation
        //{
        //    get { return _PrintDefaultOrientation; }
        //    set { _PrintDefaultOrientation = value; }
        //}
        public bool _printItemsAdmissionReport = false;

        public int InsertedID { get; set; }
        public bool OpenFromOtherScreen = false;
        public bool RecordSaved = false;
        public bool InExclusiveMode { get; set; }
        private bool _ReSizeByOption = true;

        public bool IsAlarmForm = false;
        public string AlarmData = string.Empty;
        //--------------------------------------------------------------

        public bool OverrideBranchSelectPrintLang = false;
        public int PrintLang;

        public string LastCode = string.Empty;

        //public ModuleData _moduleData;
        public bool _LogUserActions = true;
        //public string _actionDescription = "";

        private MainForm mdiForm;

        public MessageBoxOptions _msgOptions;

        public event OnClosing OnClosing;

        public bool ReSizeByOption
        {
            get { return _ReSizeByOption; }
            set { _ReSizeByOption = value; }
        }

        private FormType _FormType = FormType.CodeForm;
        public FormType FormType
        {
            get { return _FormType; }
            set { _FormType = value; }
        }

        bool _ByToolBar = false;
        public bool ByToolBar
        {
            get { return _ByToolBar; }
            set
            {
                _ByToolBar = value;
                grpMenu.Visible = value;
                tbMain.Visible = value;
            }
        }
        string _FormActive = string.Empty;
        public string FormActive
        {
            get { return _FormActive; }
            set { _FormActive = value; }
        }

        private string _IDColName;
        /// <summary>
        /// Data Sync Property 
        /// </summary>
        public string IDColName
        {
            get { return _IDColName; }
            set { _IDColName = value; }
        }

        private string _TableName;
        /// <summary>
        /// Data Sync Property
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }

        private bool _IsArabic;
        public bool IsArabic
        {
            get { return _IsArabic; }
        }

        private bool m_StretchHeight = false;
        public bool StretchHeight
        {
            get
            {
                return m_StretchHeight;
            }
            set
            {
                m_StretchHeight = value;
            }
        }

        private bool m_DontShowCloseMsg = false;
        public bool DontShowCloseMsg
        {
            get
            {
                return m_DontShowCloseMsg;
            }
            set
            {
                m_DontShowCloseMsg = value;
            }
        }

        private bool m_ShowSaveAndPrintOptions = false;
        public bool ShowSaveAndPrintOptions
        {
            get
            {
                return m_ShowSaveAndPrintOptions;
            }
            set
            {
                m_ShowSaveAndPrintOptions = value;
            }
        }
        //-----------------

        public bool _isNavigate = false;

        private int _DataID;
        private int _ID;
        private int _LookUpID;
        private int _ReportID;
        private int _ReportID2;
        private int _ReportID3;
        private System.Data.DataSet _LookupsDS;
        private EnumActiveMode _ActiveMode;
        private Permissions _Permissions;
        private bool _SaveButton;
        private bool _DeleteButton;
        private bool _ShowReportParamterButton;
        private bool _ReportButton;
        private bool _ReportButton2;
        private bool _ReportButton3;
        private bool _OKButton;
        private bool _CloseButton;
        private bool _ExitButton;
        private bool _StopAddNewButton;
        public bool _AddNewButton;
        private bool _MoveLastButton;
        private bool _MovePreviousButton;
        private bool _MoveNextButton;
        private bool _MoveFirstButton;
        private List<string> ReportParameterNames;
        private List<object> ReportParameterValues;

        public bool PrintReport = false;

        public bool PerformSilentSave = false;
        //public bool ViewingData = false;
        bool _printAfterSave = false;

        public bool _SilentSave = false;

        public static string CurrentUILanguage
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "ar-EG" ? "ar-EG" : "en-US";
            }
        }

        public Control ControlOfEnglishName { get; set; }


        #region Methods

        #region Protected
        protected void AddReportParamters(string ParameterNames, object ParameterValues)
        {
            if (ReportParameterNames == null || ReportParameterValues == null)
            {
                ReportParameterNames = new List<string>();
                ReportParameterValues = new List<object>();
            }
            ReportParameterNames.Add(ParameterNames);
            ReportParameterValues.Add(ParameterValues);
        }
        public EnumActiveMode ActiveMode
        {
            get {
                if (bttnSave.Pressed)
                {
                    //_ActiveMode = EnumActiveMode.AddMode;
                }
                    return _ActiveMode; 
                }
            set
            {
                _ActiveMode = value;
                if (bttnSave.CheckOnClick)
                {
                    _ActiveMode = EnumActiveMode.AddMode;
                }
            }
        }

        public virtual bool ValidateAddNew()
        {
            return true;
        }
        public virtual bool ValidateUpdate()
        {
            if (!ValidateData())
                return false;

            if (PerformSilentSave) return true;
            if (m_ShowSaveAndPrintOptions)
            {

                return false;

            }
            else
            {

                if (!_SilentSave)
                {
                    if (GlobalFunctions.Message(GlobalFunctions.EnumMessage.SaveMessage, this.Text, "") != DialogResult.OK)
                        return false;
                    else
                        return true;
                }
                else
                {
                    return true;
                }
            }
            //-------------------------------
        }
        public virtual bool ValidateSaveNew()
        {
            if (!ValidateData())
                return false;

            if (PerformSilentSave) return true;



            if (!_SilentSave)
            {
                if (GlobalFunctions.Message(GlobalFunctions.EnumMessage.SaveMessage, this.Text, "") != DialogResult.OK) return false;
            }
            else
            {
                return true;
            }

            return true;
        }
        public virtual bool ValidateDelete()
        {
            if (GlobalFunctions.Message(GlobalFunctions.EnumMessage.DeleteMessage, this.Text, "") != DialogResult.OK)
                return false;

            else
                return true;
        }
        public virtual bool ValidatePrint()
        {
            return true;
        }

        public virtual void PerformAfterSaveNewRecord()
        {
        }

        public virtual void SaveAddNew()
        {
            ReadData();
            if (SubmitData())
            {
                PerformAfterSaveNewRecord();


                PrintAfterSave();
                StopAddNew();
                Clear();
                GetNextCode();
               
            }
            if (OpenFromOtherScreen)
            {
                this.Close();
            }
        }

        public virtual void PrintAfterSave()
        {
            //switch (this.SaveAndPrintResult)
            //{
            //    case SaveAndPrintFormResults.SaveAndPrint:
            //        PrintReport = true;
            //        break;
            //    case SaveAndPrintFormResults.SaveAndPreview:
            //        PrintReport = false;
            //        break;
            //    case SaveAndPrintFormResults.SaveOnly:
            //        return;
            //}


            //FndNumber.NavigateTo(EnumMove.MoveNone, CurrentID);

            if (m_ShowSaveAndPrintOptions)
            {
                Print();

                //TODO: Save and Print
                //System.Threading.Thread.Sleep(2000);
            }
        }

        public virtual void SaveUpdate()
        {
            ReadData();

            if (SubmitData())
            {
                PerformAfterSaveUpdate();
                PrintAfterSave();
                DisplayData();
            }
            if (OpenFromOtherScreen)
            {
                OpenFromOtherScreen = false;
                this.Close();
            }
        }
        public virtual void PerformAfterSaveUpdate()
        {

            if (!this._SilentSave)
            {
                MessageBox.Show(CurrentUILanguage == "ar-EG" ? (" تم حفظ التعديلات") : ("Updates Saved "), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public virtual void Delete()
        {
            try
            {
                string desc = "";
                if (_LogUserActions)
                    desc = this.CreateDescription();

                ReadData();
                SubmitData();
                Clear();
                GetNextCode();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    GlobalFunctions.Message(GlobalFunctions.EnumMessage.CannotDeleteMessage, this.Text, "");
                else
                    GlobalFunctions.WriteLog(this.Name, "Delete", ex);
            }
        }

        public bool ShowOrderRecieve = false;
        public bool ShowFromSave = false;
        public int FinderValue = 0;

        public virtual void Print()
        {
            if (ReportParameterValues == null)
            {
                ReportParameterNames = new List<string>();
                ReportParameterValues = new List<object>();
            }
        }
        public virtual void Print2()
        {

        }

        #region Print3 
        public virtual void Print3()
        {





        }
        #endregion

        public string GetExportReportName(string ReportName)
        {

            return ReportName;
        }

        public virtual void Clear()
        {
            CleanForm();
        }

        protected virtual void LoadWindowsForm()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            obj = logic.GetAllByID(TableName);

            //object id2 = obj.GetType().GetField("TableName").GetValue(obj);
            //object DalClass = obj.GetType().GetProperty("DalClass").GetValue(obj, null);
        }

        protected virtual void CheckActiveMode()
        {
            
        }

        public virtual void GetNextCode()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            //int i = Convert.ToInt32(logic.GetNextCode(ID));
            object o = logic.GetNextCode(Tbl, FCode);

            //NxtCode = o.GetType().GetProperty("NextCode").GetValue(o, null);
            NCode = o.ToString();
            FndNumber.Text = NCode;
        }

        public virtual void GetNextID()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            //int i = Convert.ToInt32(logic.GetNextCode(ID));
            object o = logic.GetNextID(Tbl, IDFieldName);

            //NxtCode = o.GetType().GetProperty("NextCode").GetValue(o, null);
            IDFieldName = o.ToString();
            
        }

        public virtual void GetFirst()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            string o = logic.GetFirst(Tbl, FCode);
            NCode = o;
            FndNumber.Text = NCode;
            DisplayData();
        }

        public virtual void GetNext()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            string o = logic.GetNext(Tbl, FCode, FndNumber.Text);
            NCode = o.ToString();
            FndNumber.Text = NCode;
            DisplayData();
        }

        public virtual void GetPrevious()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            string o = logic.GetPrevious(Tbl, FCode, FndNumber.Text);
            NCode = o.ToString();
            FndNumber.Text = NCode;
            DisplayData();
        }

        public virtual void GetLast()
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            string o = logic.GetLast(Tbl, FCode);
            NCode = o;
            FndNumber.Text = NCode;
            DisplayData();
        }

        protected virtual void BindLookups()
        {
        }
        protected virtual void DisplayData()
        {
        }
        protected virtual bool ValidateData()
        {
            if (FndNumber.Text.Trim() == "")
            //if (FndNumber.Code.Trim() == "")
            {



                string msg = IsArabic ? "لا يمكن الحفظ بدون إدخال كود" : "The record cannot be saved without a valid code";
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, _msgOptions);
                //FndNumber.Code = FndNumber.NextCode();
                return false;

            }

            else
                return this.ValidateChildren();
        }
        protected virtual void ReadData()
        {
            
        }
        
        protected virtual bool SubmitData()
        {

            return true;
        }
        protected virtual void ClearData()
        {

        }

        protected virtual void PerformAfterNavigate()
        { }

        #endregion

        public DataForm()
        {
            InitializeComponent();

            _SaveButton = true;
            _DeleteButton = true;
            _ShowReportParamterButton = false;
            _ReportButton = true;
            _ReportButton2 = false;
            _OKButton = true;
            _CloseButton = true;
            _ExitButton = true;
            _StopAddNewButton = true;
            _AddNewButton = true;
            _MoveLastButton = true;
            _MovePreviousButton = true; ;
            _MoveNextButton = true;
            _MoveFirstButton = true;
        }

        public DataForm(bool exclusiveMode)
            : this()
        {
            InExclusiveMode = exclusiveMode;

            if (exclusiveMode)
            {
                bttnMoveFirst.Enabled = false;
                bttnMoveLast.Enabled = false;
                bttnMoveNext.Enabled = false;
                bttnMovePrevious.Enabled = false;
                bttnAddNew.Enabled = false;
                bttnDelete.Enabled = false;
                bttnOk.Enabled = false;
                bttnStopAddNew.Enabled = false;
                bttnSave.Enabled = false;
                bttnReport.Enabled = false;
                bttnReport2.Enabled = false;
                bttnReport3.Enabled = false;
                ShowClosingMessage = false;
                InsertedID = 0;
            }
        }

        public virtual void AddNew()
        {
            FndNumber.Text = null;
            this.ActiveMode = ActiveMode = EnumActiveMode.AddMode;
            Clear();
            FndNumber.Text = "";
            FndNumber.Focus();
            GetNextCode();
        }

        public virtual void ShowReportParamter()
        {

        }

        public void NavigateTo(EnumMove MoveType)
        {
            
        }

        public virtual void StopAddNew()
        {
            Clear();
        }

        public void Translation(List<Control> obj)
        {
            if (CurrentUILanguage == "ar-EG")
            {
                List<Control> _obj;
                if (obj == null)
                {
                    obj = new List<Control>();
                    foreach (Control var in this.Controls)
                        obj.Add(var);
                }

                if (BranchProfile.CurrentLang == 0) return;
                foreach (Control var in obj)
                {
                //    if (var is SmartControl)
                //        ((SmartControl)var).Caption = Translate(((SmartControl)var).Caption);
                //    if (var is SmartFromToControl)
                //        ((SmartFromToControl)var).Caption = Translate(((SmartFromToControl)var).Caption);
                //    else if (var is Finder)
                //        ((Finder)var).Caption = Translate(((Finder)var).Caption);
                //    else if (var is SmartCombo)
                //        ((SmartCombo)var).Caption = Translate(((SmartCombo)var).Caption);
                //    else if (var is DateTimeControl)
                //        ((DateTimeControl)var).Caption = Translate(((DateTimeControl)var).Caption);
                //    else if (var is DateTimeFromToControl)
                //        ((DateTimeFromToControl)var).Caption = Translate(((DateTimeFromToControl)var).Caption);
                //    else if (var is BooleanControl)
                //        ((BooleanControl)var).Caption = Translate(((BooleanControl)var).Caption);
                //    else if (var is Label)
                //        ((Label)var).Text = Translate(((Label)var).Text);
                //    else if (var is RadioButton)
                //        ((RadioButton)var).Text = Translate(((RadioButton)var).Text);
                //    else if (var is Button)
                //        ((Button)var).Text = Translate(((Button)var).Text);
                //    else if (var is Panel)
                //    {
                //        ((Panel)var).Text = Translate(((Panel)var).Text);
                //        _obj = new List<Control>();
                //        foreach (Control _var in ((Panel)var).Controls)
                //            _obj.Add(_var);
                //        Translation(_obj);
                //    }
                //    else if (var is GroupBox)
                //    {
                //        ((GroupBox)var).Text = Translate(((GroupBox)var).Text);
                //        _obj = new List<Control>();
                //        foreach (Control _var in ((GroupBox)var).Controls)
                //            _obj.Add(_var);
                //        Translation(_obj);
                //    }
                //    else if (var is TabControl)
                //    {
                //        ((TabControl)var).Text = Translate(((TabControl)var).Text);
                //        _obj = new List<Control>();
                //        foreach (Control _var in ((TabControl)var).Controls)
                //            _obj.Add(_var);
                //        Translation(_obj);
                //    }
                //    else if (var is TabPage)
                //    {
                //        ((TabPage)var).Text = Translate(((TabPage)var).Text);
                //        _obj = new List<Control>();
                //        foreach (Control _var in ((TabPage)var).Controls)
                //            _obj.Add(_var);
                //        Translation(_obj);
                //    }
                //    else if (var is SmartSearchByString)
                //    {
                //        ((SmartSearchByString)var).Caption = Translate(((SmartSearchByString)var).Caption);
                //    }
                }
            }
        }

        public string CreateDescription()
        {
            string cod = CurrentUILanguage == "ar-EG" ? " كود " : " Code ";
            string result = "";

            foreach (Control var in this.Controls)
            {
                //if (var is SmartControl)
                //{
                //    if (((SmartControl)var).Value.Trim() != "")
                //    {
                //        result += " " + ((SmartControl)var).Caption + ":";
                //        result += " " + ((SmartControl)var).Value + " | ";
                //    }
                //}
                //else if (var is Finder)
                //{
                //    if (((Finder)var).Value > 0)
                //    {
                //        result += " " + ((Finder)var).Caption + ":";
                //        result += " " + ((Finder)var).Description;
                //        result += (((Finder)var).Description.Trim() == "" ? "" : cod) + " " + ((Finder)var).Code + " | ";
                //    }
                //}
                //else if (var is SmartCombo)
                //{
                //    if (((SmartCombo)var).TextValue.Trim() != "")
                //    {
                //        result += " " + ((SmartCombo)var).Caption + ":";
                //        result += " " + ((SmartCombo)var).TextValue + " | ";
                //    }
                //}
                //else if (var is DateTimeControl)
                //{
                //    result += " " + ((DateTimeControl)var).Caption + ":";
                //    result += " " + ((DateTimeControl)var).Value.Date.ToString("dd/MM/yyyy") + " | ";
                //}



            }
            return result;

        }

        public void ClearControl(List<Control> obj)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);



        }

        private void CleanForm()
        {
            traverseControlsAndSetTextEmpty(this);
        }
        private void traverseControlsAndSetTextEmpty(Control control)
        {

            foreach (Control c in control.Controls)
            {
                if (c is TextBox) ((TextBox)c).Text = String.Empty;
                traverseControlsAndSetTextEmpty(c);
            }
        }

        public void ClearControls(List<Control> obj)
        {
            List<Control> _obj;
            if (obj == null)
            {
                obj = new List<Control>();
                foreach (Control var in this.Controls)
                    obj.Add(var);
            }

            foreach (Control var in obj)
            {
            //    if (var is GroupBox || var is Panel || var is TabControl || var is TabPage)
            //    {
            //        List<Control> _obj2 = new List<Control>();
            //        foreach (Control var2 in var.Controls)
            //            _obj2.Add(var2);
            //        ClearControls(_obj2);
            //    }
            //    else if (var is SmartControl)
            //    {
            //        if (!((SmartControl)var).DisabledClear)
            //        {
            //            ((SmartControl)var).Value = "";
            //            
            //            ((SmartControl)var).Txt_Text.Tag = null;
            //        }
            //    }
            //    else if (var is SmartFromToControl)
            //    {
            //        ((SmartFromToControl)var).ValueFrom = "";
            //        ((SmartFromToControl)var).ValueTo = "";
            //    }
            //    else if (var is Finder)
            //    {
            //        if (!((Finder)var).DisabledClear)
            //        {
            //            ((Finder)var).Value = 0;
            //            ((Finder)var).Code = "";
            //        }
            //    }

            //    else if (var is SmartSearchByString)
            //    {
            //        ((SmartSearchByString)var).rdoBeginsWith.Checked = true;
            //        ((SmartSearchByString)var).Value = "";
            //    }
            //    else if (var is DateTimeFromToControl)
            //    {
            //        ((DateTimeFromToControl)var).ValueFrom = ((DateTimeFromToControl)var).MinDate;
            //        ((DateTimeFromToControl)var).ValueTo = ((DateTimeFromToControl)var).MaxDate;
            //    }

            //    else if (var is SmartCombo)
            //    {
            //        if (!((SmartCombo)var).DisabledClear)
            //        {
            //            ((SmartCombo)var).Value = 0;
            //            ((SmartCombo)var).TextValue = "";
            //        }
            //    }
            //    else if (var is DateTimeControl)
            //    {
            //        if (!FndNumber.DisableReset)
            //        {

            //            ((DateTimeControl)var).Value = DateTime.Now.Date;

            //        }
            //    }
            //    else if (var is BooleanControl)
            //    {
            //        if (!((BooleanControl)var).DisabledClear)
            //            ((BooleanControl)var).Value = false;
            //    }
            //    else if (var is RadioButton)
            //        ((RadioButton)var).Checked = false;
            //    else if (var is GroupBox)
            //    {
            //        if (ConfigurationManager.AppSettings["LanguageID"] == "2")
            //        {
            //            ((GroupBox)var).Text = Translate(((GroupBox)var).Text);
            //        }
            //        _obj = new List<Control>();
            //        foreach (Control _var in ((GroupBox)var).Controls)
            //            _obj.Add(_var);
            //        ClearControls(_obj);
            //    }
            //    
            //    else if (var is C1.Win.C1Input.C1TextBox)
            //    {

            //        ((C1.Win.C1Input.C1TextBox)var).Text = string.Empty;
            //    } // end else if
            }

        }

        #endregion

        #region Properties

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                //FndNumber.ModuleID = value;
            }
        }
        public bool SaveButton
        {
            get { return _SaveButton; }
            set { _SaveButton = value; }
        }
        public bool DeleteButton
        {
            get { return _DeleteButton; }
            set { _DeleteButton = value; }
        }
        public bool ReportButton
        {
            get { return _ReportButton; }
            set { _ReportButton = value; }
        }
        public bool ReportButton2
        {
            get { return _ReportButton2; }
            set { _ReportButton2 = value; }
        }
        public bool ReportButton3
        {
            get { return _ReportButton3; }
            set { _ReportButton3 = value; }
        }
        public bool OKButton
        {
            get { return _OKButton; }
            set { _OKButton = value; }
        }
        public bool CloseButton
        {
            get { return _CloseButton; }
            set { _CloseButton = value; }
        }
        public bool ShowReportParamterButton
        {
            get { return _ShowReportParamterButton; }
            set { _ShowReportParamterButton = value; }
        }
        public bool ExitButton
        {
            get { return _ExitButton; }
            set { _ExitButton = value; }
        }
        public bool StopAddNewButton
        {
            get { return _StopAddNewButton; }
            set { _StopAddNewButton = value; }
        }
        public bool AddNewButton
        {
            get { return _AddNewButton; }
            set { _AddNewButton = value; }
        }
        public bool MoveLastButton
        {
            get { return _MoveLastButton; }
            set { _MoveLastButton = value; }
        }
        public bool MovePreviousButton
        {
            get { return _MovePreviousButton; }
            set { _MovePreviousButton = value; }
        }
        public bool MoveNextButton
        {
            get { return _MoveNextButton; }
            set { _MoveNextButton = value; }
        }
        public bool MoveFirstButton
        {
            get { return _MoveFirstButton; }
            set { _MoveFirstButton = value; }
        }
        [Browsable(false)]
        public int DataID
        {
            get { return _DataID; }
            set { _DataID = value; }
        }
        public int LookUpID
        {
            get { return _LookUpID; }
            set
            {
                //_LookUpID = value;
                //if (_LookUpID > 0)
                //    FndNumber.LookUpID = _LookUpID;
            }
        }
        [Browsable(false)]
        public System.Data.DataSet LookupsDataSet
        {
            get { return _LookupsDS; }
            set { _LookupsDS = value; }
        }
        public int ReportID
        {
            get { return _ReportID; }
            set
            {
                _ReportID = value;
                _ReportButton = (value > 0);
            }
        }
        public int ReportID2
        {
            get { return _ReportID2; }
            set
            {
                _ReportID2 = value;
                _ReportButton2 = (value > 0);
            }
        }
        public int ReportID3
        {
            get { return _ReportID3; }
            set { _ReportID3 = value; }
        }
        public Permissions Permissions
        {
            get { return _Permissions; }
            set { _Permissions = value; }
        }
        #endregion

        #region Events

        private void DataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Name == "Alarm") goto _finally;

            if (this.Owner != null && this.Owner is MainForm)
                //((MainForm)this.Owner).ActiveChiled = false;

                //if (_ReSizeByOption && this.WindowState != FormWindowState.Minimized)
                //UI.SaveUserDefaultFormSettings(BranchProfile.CurrentUserData.ID, this.ID, this.DataID, this.WindowState == FormWindowState.Maximized ? true : false, this.Width, this.Height, this.Top, this.Left);

                //if (this.Tag != null)
                //{
                //    if (((ModuleData)this.Tag).ModuleType == "RPT") goto _finally;
                //}

                if (!m_DontShowCloseMsg)
                {


                    //if (ShowClosingMessage)
                    //{
                    //    if (MessageBox.Show(CurrentUILanguage == "ar-EG" ? "هل تريد الخروج؟" : "Are You Sure You Want To Exit?", CurrentUILanguage == "ar-EG" ? "خروج؟" : "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    //    {
                    //        errorProvider = null;
                    //        e.Cancel = false;
                    //    }
                    //    else
                    //    {
                    //        e.Cancel = true;
                    //        return;
                    //    }
                    //}
                    //else
                    //    errorProvider = null;
                }

        _finally:

            if (mdiForm != null)
                ResetToolBar(_ActiveMode, true);



        }


        private void DataForm_Activated(object sender, EventArgs e)
        {

            setActiveForm();




        }

        private void setActiveForm()
        {
            //if (this.Owner != null && this.Owner is MainForm && mdiForm != null)
            //{
            //    _activeForm = this;
            //    ((MainForm)this.Owner).FormActive = this.Name;
            //    //((MainForm)this.Owner).ActiveChiled = true;

            //    ResetToolBar(_ActiveMode, false);
            //}
        }

        private void DataForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_IsSaving)
            {
                e.Handled = true;
                return;
            }


            if (mdiForm == null) return;


            switch (e.KeyCode)
            {
                case Keys.F9:
                    if (e.Shift && this.bttnStopAddNew.Enabled)
                    {
                        ToolBar_ButtonClick("bttnStopAddNew");//(StopAddNewButton)
                    }
                    else if (this.bttnAddNew.Enabled)//(AddNewButton)
                        ToolBar_ButtonClick("bttnAddNew");
                    break;
                case Keys.F7:
                    if (e.Shift)// Save & Close
                    {
                        if (this.bttnSave.Enabled)//(SaveAndCloseButton)
                            ToolBar_ButtonClick("bttnSaveClose");
                    }
                    else // Save
                    {
                        if (this.bttnSave.Enabled)//(SaveButton)
                            ToolBar_ButtonClick("bttnSave");
                    }
                    break;

                case Keys.F8:// 'Delete
                    if (this.bttnDelete.Enabled)//(DeleteButton)
                        ToolBar_ButtonClick("bttnDelete");
                    break;
                case Keys.F5://'ok
                    if (this.bttnOk.Enabled)//(OKButton)
                        ToolBar_ButtonClick("bttnOk");
                    break;
                case Keys.P://'Report1
                    if (this.bttnReport.Enabled && e.Control)//(ReportButton)
                        ToolBar_ButtonClick("bttnReport");
                    break;
                case Keys.F11://'Report2
                    if (ReportButton2 && !e.Shift)
                        ToolBar_ButtonClick("bttnReport2");
                    break;

                case Keys.F12:
                    if (ReportButton3 && !e.Shift)
                        ToolBar_ButtonClick("bttnReport3");
                    break;

                case Keys.Enter://validate finder code
                    //if (this.ActiveControl == FndNumber)
                    //{

                    //}
                    break;
            }
            //}
        }

        private void DataForm_Enter(object sender, EventArgs e)
        {

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            LoadedAll();

            try
            {
                foreach (Control item in this.Controls)
                {

                    if (item.Name.IndexOf("Txt_EnglishName", StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        ControlOfEnglishName = item;
                    } // end if
                } // end foreach


            } // end try
            catch (ArgumentNullException argumentNullException)
            {
                MessageBox.Show("Message:\n" + argumentNullException.Message + "\nSource:\n" + argumentNullException.Source + "\nTargetSite:\n" + argumentNullException.TargetSite + "\nStackTrace: " + argumentNullException.StackTrace,
                           "Argument Null Exception",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.ServiceNotification);
            } // end catch
            catch (ArgumentException argumentException)
            {
                MessageBox.Show("Message:\n" + argumentException.Message + "\nSource:\n" + argumentException.Source + "\nTargetSite:\n" + argumentException.TargetSite + "\nStackTrace: " + argumentException.StackTrace,
                           "Argument Exception",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.ServiceNotification);
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                    MessageBox.Show("nMessage:\n" + exception.InnerException.Message + "\nSource:\n" + exception.InnerException.Source + "\nTargetSite:\n" + exception.InnerException.TargetSite + "\nStackTrace: " + exception.StackTrace,
                        "Exception",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification);
                else
                    MessageBox.Show("nMessage:\n" + exception.Message + "\nSource:\n" + exception.Source + "\nTargetSite:\n" + exception.TargetSite + "\nStackTrace: " + exception.StackTrace,
                        "Exception",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.ServiceNotification);
            } // end catch

        }

        public void LoadedAll()
        {
            

            _IsArabic = CurrentUILanguage == "ar-EG";

            if (this.Owner != null && this.Owner is MainForm)
                mdiForm = (MainForm)Application.OpenForms["MainForm"];


            if (_IsArabic)
                _msgOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;



            setActiveForm();

            tbMain.BackColor = this.BackgroundColor;
            ActiveMode = EnumActiveMode.EditMode;
            
            LoadWindowsForm();

            GetNextCode();
            GetNextID();

            if (this.Tag != null)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            switch (FormType)
            {
                case FormType.ExceptionalForm:
                    AddNewButton = true;
                    StopAddNewButton = true;
                    SaveButton = true;
                    SaveButton = true;
                    DeleteButton = true;
                    break;
                default:
                    break;
            }
        }



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.Owner != null && this.Owner is MainForm)
            {
                this.Font = this.Owner.Font;
                this.VisualStyle = (this.Owner as MainForm).VisualStyle;
            }
        }

        public virtual void FndNumber_Change(bool UserChange)
        {
            ResetToolBar(this.ActiveMode, false);
        }

        public virtual void FndNumber_Initialize(bool ForBrowser)
        {

        }

        private void FndNumber_InitializeAddNew(bool AddNew)
        {
            this.afterLoad();
        }

        private void FndNumber_InitializeStopAddNew()
        {
            ToolBar_ButtonClick("bttnStopAddNew");
        }

        #endregion

        public virtual void afterLoad()
        {

        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType().GetField("ErrorProvider") != null)
                {
                    ctrl.GetType().GetField("ErrorProvider").SetValue(ctrl, null);
                }
            }

            
            e.Cancel = false;

            base.OnFormClosing(e);
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_IsSaving)
            {
                return true;
            }

            switch (keyData.ToString())
            {
                case "Escape":
                case "F4, Alt":
                    {
                        bool cancel = false;

                        if (OnClosing != null)
                        {
                            OnClosing(out cancel);
                        }

                        if (!cancel)
                        {
                            this.Close();
                        }

                        return true;
                    }
                default:
                    break;
            }
            if (keyData == (Keys.RButton | Keys.ShiftKey | Keys.Alt))
            {
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        public virtual void ToolBar_ButtonClick(string bttnName)
        {

            bool DecActivate = false;
            switch (bttnName)
            {
                case "bttnMoveFirst":
                    this.ActiveMode = EnumActiveMode.EditMode;
                    this.NavigateTo(EnumMove.MoveFrist);
                    GetFirst();
                    break;
                case "bttnMoveNext":
                    this.ActiveMode = EnumActiveMode.EditMode;
                    this.NavigateTo(EnumMove.MoveNext);
                    GetNext();
                    break;
                case "bttnMovePrevious":
                    this.ActiveMode = EnumActiveMode.EditMode;
                    this.NavigateTo(EnumMove.MovePrevious);
                    GetPrevious();
                    break;
                case "bttnMoveLast":
                    this.ActiveMode = EnumActiveMode.EditMode;
                    this.NavigateTo(EnumMove.MoveLast);
                    GetLast();
                    break;
                case "bttnAddNew":
                    if (this.ValidateAddNew() && this.AddNewButton)
                    {
                        this.Clear();
                        this.ActiveMode = EnumActiveMode.AddMode;
                        this.AddNew();

                        bttnAddNew.Enabled = false; ;
                        bttnDelete.Enabled = false;
                        bttnMoveFirst.Enabled = false;
                        bttnMoveLast.Enabled = false;
                        bttnMoveNext.Enabled = false;
                        bttnMovePrevious.Enabled = false;
                        bttnOk.Enabled = false;
                        bttnReport.Enabled = false;
                        bttnReport2.Enabled = false;
                        bttnReport3.Enabled = false;
                        bttnSave.Enabled = true;
                        bttnSaveClose.Enabled = true;
                        bttnStopAddNew.Enabled = this.AddNewButton;
                    }
                    else
                    {
                        //this.Clear();
                        this.ActiveMode = EnumActiveMode.EditMode;
                    }
                    break;
                case "bttnStopAddNew":
                    this.StopAddNew();
                    this.ActiveMode = EnumActiveMode.NothingMode;
                    this.Clear();
                    ActiveMode = this.ActiveMode;
                    break;
                case "bttnSave":
                    if (_IsSaving)
                        return;

                    _IsSaving = true;

                    CheckActiveMode();

                    if (ActiveMode == EnumActiveMode.EditMode)
                    {
                        if (this.ValidateUpdate())
                        {
                            this.SaveUpdate();
                            RecordSaved = true;
                        }
                        else RecordSaved = false;
                    }
                    else
                        if (this.ValidateSaveNew())
                        {
                            this.SaveAddNew();
                            RecordSaved = true;
                        }
                        else RecordSaved = false;

                    _IsSaving = false;

                    break;
                case "bttnSaveClose":

                    if (_IsSaving)
                        return;

                    _IsSaving = true;

                    if (ActiveMode == EnumActiveMode.EditMode)
                    {
                        if (this.ValidateUpdate())
                        {
                            this.SaveUpdate();
                            this.Close();
                        }
                    }
                    else
                        if (this.ValidateSaveNew())
                        {
                            this.SaveAddNew();
                            this.Close();
                        }

                    _IsSaving = false;
                    break;
                case "bttnDelete":
                    if (this.ValidateDelete()) this.Delete();
                    break;
                case "bttnOk":
                    this.NavigateTo(EnumMove.MoveNone);
                    break;
                case "bttnReport":
                    this.Refresh();
                    if (this.ValidatePrint()) this.Print();
                    break;
                case "bttnReport2":
                    this.Refresh();
                    if (this.ValidatePrint()) this.Print2();
                    break;
                case "bttnReport3":
                    this.Refresh();
                    if (this.ValidatePrint()) this.Print3();
                    break;
                case "bttnClose":
                    this.Close();
                    break;

            }

            if (bttnName != "" && !InExclusiveMode)
                ResetToolBar((EnumActiveMode)ActiveMode, DecActivate);
            this.afterLoad();
        }

        public void ResetToolBar(EnumActiveMode ActiveMode, bool DecActivate)
        {
            if (DecActivate)
            {
                bttnAddNew.Enabled = false; ;
                bttnDelete.Enabled = false;
                bttnMoveFirst.Enabled = false;
                bttnMoveLast.Enabled = false;
                bttnMoveNext.Enabled = false;
                bttnMovePrevious.Enabled = false;
                bttnOk.Enabled = false;
                bttnReport.Enabled = false;
                bttnReport2.Enabled = false;
                bttnReport3.Enabled = false;
                bttnSave.Enabled = false;
                bttnSaveClose.Enabled = false;
                bttnStopAddNew.Enabled = false;
            }

            else if (ActiveMode == EnumActiveMode.AddMode)
            {
                bttnAddNew.Enabled = false; ;
                bttnDelete.Enabled = false;
                bttnMoveFirst.Enabled = false;
                bttnMoveLast.Enabled = false;
                bttnMoveNext.Enabled = false;
                bttnMovePrevious.Enabled = false;
                bttnOk.Enabled = false;
                if (!bttnShowReportParamter.Visible)
                {
                    bttnReport.Enabled = false;
                    bttnReport2.Enabled = false;
                    bttnReport3.Enabled = false;
                }
                bttnSave.Enabled = true;
                bttnSaveClose.Enabled = true;
                bttnStopAddNew.Enabled = AddNewButton;
            }
            else
            {
                bttnAddNew.Enabled = (AddNewButton);
                bttnDelete.Enabled = (DeleteButton);
                bttnMoveFirst.Enabled = (MoveFirstButton);
                bttnMoveLast.Enabled = (MoveLastButton);
                bttnMoveNext.Enabled = (MoveNextButton);
                bttnMovePrevious.Enabled = (MovePreviousButton);
                bttnOk.Enabled = (OKButton);
                if (!bttnShowReportParamter.Visible)
                {
                    bttnReport.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton);
                    bttnReport2.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton2);
                    bttnReport3.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton3);
                }
                bttnSave.Enabled = true;
                bttnSaveClose.Enabled = true;

                if (!bttnSave.Enabled && ActiveMode == EnumActiveMode.AddMode)
                {
                    bttnOk.Enabled = false;
                    if (!bttnShowReportParamter.Visible)
                    {
                        bttnReport.Enabled = false;
                        bttnReport2.Enabled = false;
                        bttnReport3.Enabled = false; 
                    }
                    bttnMoveFirst.Enabled = false;
                    bttnMoveLast.Enabled = false;
                    bttnMoveNext.Enabled = false;
                    bttnMovePrevious.Enabled = false;
                    bttnAddNew.Enabled = false;
                    bttnStopAddNew.Enabled = AddNewButton;
                    bttnSave.Enabled = ((Permissions.Add == (_Permissions & Permissions.Add)) && AddNewButton);
                    bttnSaveClose.Enabled = ((Permissions.Add == (_Permissions & Permissions.Add)) && AddNewButton);
                }
                else
                {

                    bttnMoveFirst.Enabled = (MoveFirstButton);
                    bttnMoveLast.Enabled = (MoveLastButton);
                    bttnMoveNext.Enabled = (MoveNextButton);
                    bttnOk.Enabled = (OKButton);
                    bttnMovePrevious.Enabled = (MovePreviousButton);
                    if (!bttnShowReportParamter.Visible)
                    {
                        bttnReport.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton);
                        bttnReport2.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton2);
                        bttnReport3.Enabled = ((Permissions.Report == (_Permissions & Permissions.Report)) && ReportButton3);
                    }
                    bttnAddNew.Enabled = (AddNewButton);

                    if (ActiveMode == EnumActiveMode.NothingMode)
                    {
                        bttnSave.Enabled = false;
                        bttnSaveClose.Enabled = false;
                        bttnDelete.Enabled = false;
                        if (!bttnShowReportParamter.Visible)
                        {
                            bttnReport.Enabled = false;
                            bttnReport2.Enabled = false;
                            bttnReport3.Enabled = false; 
                        }
                    }

                    bttnStopAddNew.Enabled = false;
                }
            }

            if (ActiveMode == EnumActiveMode.EditMode)
            {
                if (bttnDelete.Enabled) bttnDelete.Enabled = (DeleteButton);
                if (bttnReport.Enabled) bttnReport.Enabled = (ReportButton);
                if (bttnReport2.Enabled) bttnReport2.Enabled = (ReportButton2);
                if (bttnReport3.Enabled) bttnReport3.Enabled = (ReportButton3);
            }
        }

        public void SaveOnly()
        {
            bttnAddNew.Visible = false;
            bttnDelete.Visible = false;
            bttnMoveFirst.Visible = false;
            bttnMoveLast.Visible = false;
            bttnMoveNext.Visible = false;
            bttnMovePrevious.Visible = false;
            bttnOk.Visible = false;
            bttnStopAddNew.Visible = false;
            bttnShowReportParamter.Visible = false;
            bttnReport.Visible = false;
            bttnReport2.Visible = false;
            bttnReport3.Visible = false;

            toolStripSeparator1.Visible = false;
            toolStripSeparator8.Visible = false;
            toolStripSeparator5.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator6.Visible = false;
            toolStripSeparator7.Visible = false;
        }

        public void ReportType()
        {
            bttnShowReportParamter.Visible = true;
            bttnShowReportParamter.Enabled = true;
            bttnReport2.Enabled = true;
            bttnReport3.Enabled = true;
            bttnAddNew.Visible = false;
            bttnDelete.Visible = false;
            bttnMoveFirst.Visible = false;
            bttnMoveLast.Visible = false;
            bttnMoveNext.Visible = false;
            bttnMovePrevious.Visible = false;
            bttnOk.Visible = false;
            bttnSave.Visible = false;
            bttnReport2.Visible = false;
            bttnReport3.Visible = false;
            bttnSaveClose.Visible = false;
            bttnStopAddNew.Visible = false;
            toolStripSeparator1.Visible = false;
            toolStripSeparator8.Visible = false;
            toolStripSeparator5.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator7.Visible = false;
        }

        public virtual void bttn_Click(object sender, EventArgs e)
        {
            ToolBar_ButtonClick(((ToolStripButton)sender).Name);
        }

        private void DataForm_BackColorChanged(object sender, EventArgs e)
        {
            tbMain.BackColor = this.BackgroundColor;
        }

        

        private void DataForm_Deactivate(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner is MainForm)
            {
                //((MainForm)this.Owner).ActiveChiled = false;
            }
        }

        private void bttnReport3_Click(object sender, EventArgs e)
        {
            ToolBar_ButtonClick(((ToolStripButton)sender).Name);
        }

        private void FndNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WindowsFormLogic logic = new WindowsFormLogic();
                dt = logic.GetAll(TableName);
                Code = Convert.ToInt32(FndNumber.Text);
                DataRow[] row = dt.Select("" + FCode + " = " + FndNumber.Text);
                ID = Convert.ToInt32(row[0].ItemArray[0]);

                DisplayData();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowsFormLogic logic = new WindowsFormLogic();
            dt = logic.GetAll(TableName);

            GridForm.dgv.DataSource = dt;
            if (GridForm.dgv.Rows.Count > 0)
            {
                GridForm.dgv.Columns[0].Visible = false;
            }
            GridForm.ShowDialog();
            this.ID = Convert.ToInt32(GridForm.dgv.CurrentRow.Cells[0].Value.ToString());
            Code = Convert.ToInt32(GridForm.dgv.CurrentRow.Cells[1].Value.ToString());
            DisplayData();
        }

        public void Item()
        {
           Type t = Type.GetType("Try.DAL.UsersDAL");
            Assembly encryptionAssembly = Assembly.LoadFrom("Try.DAL.DLL");
            foreach (Type item in encryptionAssembly.GetTypes())
            {
                if (item.Name == "UsersDAL")
                {
                    t = item;
                }
            }
            MethodInfo method = t.GetMethod("gett", BindingFlags.Static | BindingFlags.Public);
            object[] arguments = new object[1];
            arguments[0] = ID;
            try
            {
                object mm = method.Invoke(null, arguments);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Test(string methodName)
        {
            Assembly assembly = Assembly.LoadFile("...Assembly1.dll");
            Type type = assembly.GetType("Try.DAL");

            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(methodName);

                if (methodInfo != null)
                {
                    object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);

                    if (parameters.Length == 0)
                    {
                        // This works fine
                        result = methodInfo.Invoke(classInstance, null);
                    }
                    else
                    {
                        object[] parametersArray = new object[] { "Hello" };

                        // The invoke does NOT work;
                        // it throws "Object does not match target type"             
                        result = methodInfo.Invoke(methodInfo, parametersArray);
                    }
                }
            }
        }

    }

    public enum FormType
    {
        CodeForm,
        TransactionForm,
        ExceptionalForm
    }
}
