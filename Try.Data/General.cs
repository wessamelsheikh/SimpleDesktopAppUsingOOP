using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Try.Data
{
    /// <summary>
    /// Module's allowed actions
    /// </summary>
    public enum AvailableActions
    {
        None = 0
        ,
        Add = 1
            ,
        Update = 2
            ,
        Delete = 4
            , View = 8
    }
    public enum ModuleType
    {
        Search = 0
        , DataID = 1
    }
    public enum IntegTransfereType
    {
        WithoutTransfere = 1
        ,
        AutoTransfere = 2
            , ManualTransfere = 3
    }
    public enum InvoiceTerm_DocType
    {
        SalesInvoice = 1
       ,
        SalesReturnInvoice = 2
       ,
        PurchaseInvoice = 3
       ,
        PurchaseReturnInvoice = 4
    }
    public enum InvoiceTerm_Natural
    {
        AddValue = 1, SubtractValue = 2
    }
    public enum InvoiceTerm_Calc
    {
        BeforeDiscount = 1, AfterDiscount = 2
    }
    public enum InvoiceTerm_Type
    {
        Percent = 1, Value = 2, PercentValue = 3
    }


    public enum IntegJournalKind
    {
        JournalforDocument = 1
        ,
        JournalforDay = 2
            , JournalforManth = 3
    }

    public enum StockIntegDirection
    {
        Store = 1
        ,
        Group = 2
            ,
        Item = 3
            ,
        Branch = 4
            ,
        TransType = 5
            ,
        Transaction = 6
            ,
        Integration = 7
            , CostCenterAccounts = 8
    }
    public enum SalesIntegDirection
    {
        Store = 1
       ,
        Group = 2
            ,
        Item = 3
            ,
        Branch = 4
            ,
        InvoiceType = 5
            ,
        Invoice = 6
            , Integration = 7
    }
    public enum CustomerIntegDirection
    {
        Customer = 1
       ,
        PaymentMethod = 2
            , Integration = 3
    }

    public enum LangEnum
    {
        Arabic = 1,
        English = 2
    }
    public enum EnumMove
    {
        MoveNone = 0,
        MoveFrist = 1,
        MoveNext = 2,
        MovePrevious = 3,
        MoveLast = 4
    }
    public enum TransTypeEnum
    {
        None = 0, Addition = 1, Deduction = 2, TransfereOut = 3, TransfereIn = 4
    }
    public enum ExpirDateOpenModeEnum
    {
        None = 0, Addtion = 1, Select = 2, SelectReturn = 3
    }

    public enum ItemGridContainerFormEnum
    {
        None = 0,
        Transaction = 1,
        PInvoice = 2,
        Invoice = 3,
        PInvReturn = 4,
        InvReturn = 5,
        Inventory = 6,
        Transfere = 7,
        Receive = 8,
        AssemplyTrans = 9,
        DisAssemplyTrans = 10,
        Inv_Assemply = 11,
        SalesOrder = 12,
        POS = 13,
        Orders = 14,
        BranchsOrders = 15,
        PurchaseOrder = 16,
        Receipt = 17,
        Payment = 18
    }
    //=========================================================================

    public enum ReturnTypeEnum
    {
        Partial = 0,
        Total = 1,
        Normal = 2
    }

    public enum EnumActiveMode
    {
        EditMode = 0,
        AddMode = 1,
        NothingMode = 2
    }
    public enum ColDataType
    {
        Text,//0
        Number,//1
        Decimal,//2
        DateTime,//3
        Finder,//4
        Combo,//5
        CheckBox,//6
        Button,//7
        BrowseButton//8
    }
    public enum EnumFormat
    {
        DDMMYY = 0,
        MMDDYY = 1,
        YYMMDD = 2,
        DDMonYY = 3,
        HHMMSS = 4,
        HHMM = 5
    }
    public enum EnumDataType
    {
        SSText = 0,
        SSINTEGER = 1,
        SSFLOAT = 2,
        DateTime = 3
    }
    public enum EnumCharSet
    {
        Ascii = 0,
        Alpha = 1,
        AlphaNumeric = 2,
        Numeric = 3
    }
    public enum ActiveModeEnum
    {
        English = 0,
        Arabic = 1,
        other = 2
    }
    public enum Permissions
    {
        None = 0
        ,
        Add = 1
       ,
        Update = 2
       ,
        Delete = 4
       ,
        View = 8
       , Report = 16
    }

    public enum WeekDays
    {
        None = 0,
        Sat = 1,
        Sun = 2,
        Mon = 4,
        Tue = 8,
        Wed = 16,
        Thu = 32,
        Fri = 64
    }

    public enum EnumControlsType
    {
        SmartFromToControl = 1, SmartFromToDateTime = 2, BooleanControl = 3, SmartCombo = 4, Finder = 5, DateTimeControl = 6, SmartControl = 7, SmartSearchByString = 8, iRadioButtonGroup = 9
    }

    public enum DelwithType
    {
        DataReader = 1, DataSet = 2, Object = 3, SubReport = 4
    }
}
