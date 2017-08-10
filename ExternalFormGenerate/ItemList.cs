using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalFormGenerate
{
    public class ItemList
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ItemList(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
