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
    public partial class FieldRow : UserControl
    {
        public FieldRow()
        {
            InitializeComponent();
        }

        public void SetFieldInfo(FieldInfo info)
        {
            pnlFieldInfo.Controls.Add(info);
        }

        public int RowIndex { get; set; }

        public bool RowChecked { get { return cbRow.Checked;  } }


        private void cbRow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRow.Checked)
            {
                pnlFieldInfo.Enabled = false;
                this.BackColor = Color.Blue;


            }
            else
            {
                pnlFieldInfo.Enabled = true;
                this.BackColor = Color.FromArgb(255, 240, 240, 240);

            }
        }
    }
}
