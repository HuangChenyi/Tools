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
        }
    }
}
