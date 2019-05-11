using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
//using iCore;

namespace Try.Data
{
    public static class GlobalFunctions
    {
        public enum EnumMessage
        {
            ValidateMessage = 0,
            SaveMessage = 1,
            DeleteMessage = 2,
            CannotDeleteMessage = 3,
            BalanceVoucher = 4
        }

        public static string CurrentUILanguage
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "ar-EG" ? "ar-EG" : "en-US";
            }
        }

        public static DialogResult Message(EnumMessage MsgType, string Caption, string Text)
        {
            switch (MsgType)
            {
                case EnumMessage.DeleteMessage:
                    return MessageBox.Show(CurrentUILanguage == "ar-EG" ? "هل تريد حذف هذا السجل؟" : "Do You want to Delete this Record?", Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                case EnumMessage.CannotDeleteMessage:
                    return MessageBox.Show(CurrentUILanguage == "ar-EG" ? "لا يمكنك حذف هذا السجل لانه مرتبط ببعض البيانات الاخرى" : "Cannot Delete This Record AS it it Attached with other Data!", Caption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                case EnumMessage.SaveMessage:
                    return MessageBox.Show(CurrentUILanguage == "ar-EG" ? "هل تريد حفظ بيانات هذا السجل؟" : "Do You want To Save this Record?", Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                case EnumMessage.BalanceVoucher:
                    return MessageBox.Show(CurrentUILanguage == "ar-EG" ? "القيد غير متوازن" : "Journal is UnBalanced", Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                case EnumMessage.ValidateMessage:
                    return MessageBox.Show("Does not let " + Text + " Empty ", Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                default:
                    return DialogResult.Cancel;
            }
        }

        public static void WriteLog(string FormName, string FunctionName, Exception Err)
        {
            FileStream FS;
            FS = new FileStream(System.Windows.Forms.Application.StartupPath + "\\BackofficeLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter SW;
            SW = new StreamWriter(FS);
            SW.WriteLine("Form Name :" + FormName + " Function Name :" + FunctionName + " Message : " + Err.Message + " Source : " + Err.Source + Err.GetBaseException().Message);
            SW.Close();
            FS.Close();
            Console.Beep();
            //iCore.iMain.HandleException(Err);
        }


    }
}
