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

        private void FieldRowThree_Load(object sender, EventArgs e)
        {
            pnlFieldInfoLeft.Width = (gbRow.Width - 55) / 3;
            pnlFieldInfoRight.Width = (gbRow.Width - 55) / 3;
        }
    }
}
