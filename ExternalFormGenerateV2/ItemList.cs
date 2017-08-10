namespace ExternalFormGenerateV2
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