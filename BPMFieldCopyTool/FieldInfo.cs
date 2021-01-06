using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPMFieldCopyTool
{
    public partial class FieldInfo : UserControl
    {
        public FieldInfo()
        {
            InitializeComponent();
        }

        public void SetFieldInfo(string info)
        {
            lblFieldInfo.Text = info;

            if (info == "EmptyField")
                cbField.Visible = false;

        }

        private void cbField_CheckedChanged(object sender, EventArgs e)
        {
            if (cbField.Checked)
            {
               
                this.BackColor = Color.Yellow;
            }
            else
            {
            
                this.BackColor = Color.FromArgb(255, 240, 240, 240);
            }
        }
    }
}
