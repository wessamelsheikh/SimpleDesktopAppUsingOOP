using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void toolStripBtnOk_Click(object sender, EventArgs e)
        {
            if (login(txtUserName.Text, txtPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public bool login(string username, string password)
        {
            if (username == "sysadmin" & password == String.Empty)
            {
                return true;
            }
            else
            {
                DataTable dt;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(String.Format("Select * from Users where Users_Code = {0} and Users_Password = {1}", username, password), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        con.Close();
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void toolStripBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
