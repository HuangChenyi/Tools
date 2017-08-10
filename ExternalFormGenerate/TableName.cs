using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExternalFormGenerate
{
    public partial class TableName : Form
    {
        public string TableNames { get; set; }
        public string TableDescription { get; set; }
        public TableName()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            TableNames = txtTableName.Text;
            TableDescription = txtDescription.Text;
            this.Close();
        }
    }
}
