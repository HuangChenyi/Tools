using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTFormCreate
{
    public class FormJsonObj
    {
        public List<FieldJsonObj> HiddenColumns { get; set; }
        public List<ColumnsJsonObj> Rows { get; set; }

        public FormJsonObj()
        {
            HiddenColumns = new List<FieldJsonObj>();
            Rows = new List<ColumnsJsonObj>();
        }
    }

    public class ColumnsJsonObj
    {
        public List<FieldJsonObj> Columns { get; set; }

        public ColumnsJsonObj()
        {
            Columns = new List<FieldJsonObj>();
        }
    }

    public class FieldJsonObj
    {
        public string VersionField { get; set; }
        public string FieldID { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

    }
}
