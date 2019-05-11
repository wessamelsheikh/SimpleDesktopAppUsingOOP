using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Try.Logic;
using Try.Data;
using Try.DAL;

namespace Try
{
    public partial class GridForm : Form
    {
        public GridForm()
        {
            InitializeComponent();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {

            Close();
        }
    }
}
