
using System.Collections.Generic;

public class DataGridFields
{
    public List<DataGridList> DataGridList { get; set; }


    public DataGridFields()
    {
        DataGridList = new List<global::DataGridList>();
    }


}

public class DataGridList
{
    public string FieldId { get; set; }
    public string TableName { get; set; }
}
