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
    public partial class FieldRowThree : UserControl
    {
        public FieldRowThree()
        {
            InitializeComponent();
        }


        public int RowIndex { get; set; }

        public bool RowChecked { get { return cbRow.Checked; } }

        private void FieldRowThree_Load(object sender, EventArgs e)
        {
         
        }

        private void FitWidth()
        {
           // pnlFieldInfoLeft.Width = (gbRow.Width - 55) / 3;
          //  pnlFieldInfoRight.Width = (gbRow.Width - 55) / 3;
        }

        public void SetFieldInfoRight(FieldInfo info)
        {
            pnlFieldInfoRight.Controls.Add(info);
        }

        public void SetFieldInfoLeft(FieldInfo info)
        {

            pnlFieldInfoLeft.Controls.Add(info);

           

        }

        public void SetFieldInfoCenter(FieldInfo info)
        {
            pnlFieldInfoCenter.Controls.Add(info);
          
        }

        private void cbRow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRow.Checked)
            {
                pnlFieldInfoLeft.Enabled = false;
                pnlFieldInfoRight.Enabled = false;
                pnlFieldInfoCenter.Enabled = false;
                this.BackColor = Color.Blue;

            }
            else
            {
                pnlFieldInfoLeft.Enabled = true;
                pnlFieldInfoRight.Enabled = true;
                pnlFieldInfoCenter.Enabled = true;
                this.BackColor = Color.FromArgb(255, 240, 240, 240);
            }
        }
    }
}
