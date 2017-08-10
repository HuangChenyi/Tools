using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SQLHelper
{
    public partial class SelectCondition : Form
    {
        public string TableName = "";
        public string CommandType = "";
        public string CommandText = "";
        public int SelectedIndex = -1;

        Utitlty m_Utitlty = new Utitlty();

        public SelectCondition()
        {
            InitializeComponent();
            
             


        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> columnList = new List<string>();
            List<string> conditionList = new List<string>();

            for (int i = 0; i < gridColumns.Rows.Count; i++)
            {
                if (gridColumns.Rows[i].Selected)
                {
                    columnList.Add(gridColumns.Rows[i].Cells[0].Value.ToString());
                }
            }

            for (int i = 0; i < gridColumns.Rows.Count; i++)
            {
                if (gridCondition.Rows[i].Selected)
                {
                    conditionList.Add(gridCondition.Rows[i].Cells[0].Value.ToString());
                }
            }

            switch (CommandType)
            { 
                case "SELECT":
                case "INSERT":
                case "UPDATE":
                    if (columnList.Count == 0)
                    {
                        MessageBox.Show("請至少選擇一個欄位!", "錯誤!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
            
            }

            if (SelectedIndex > 0 && SelectedIndex < 5)
            {
                CommandText = SQLCommand.GetCommandText(TableName, CommandType, columnList, conditionList);
            }
            else if (SelectedIndex > 5 && SelectedIndex < 10)
            {
                CommandText = CSharpCommand.GetCommandText(TableName, CommandType.Trim(), columnList, conditionList);
            }
            else
            {
                CommandText = CSharpCommand.GetCommandTextByCSharp(TableName, CommandType.Trim(), columnList, conditionList);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        internal void BindData()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("COLUMN_NAME");
            dt.Columns.Add("DATA_TYPE");

            DataTable columnsDt =   m_Utitlty.GetALLColumns(TableName).Copy();

            for (int i=0; i < columnsDt.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["COLUMN_NAME"] = columnsDt.Rows[i]["COLUMN_NAME"];
                dr["DATA_TYPE"] = columnsDt.Rows[i]["DATA_TYPE"];
                dt.Rows.Add(dr);

            }

            gridColumns.DataSource = dt.Copy();
            gridCondition.DataSource = dt.Copy();

            if (gridColumns.Rows.Count > 0)
            {
                gridColumns.Rows[0].Selected = true;
            }
         
        }

        private void menuSelectColumn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridColumns.Rows.Count; i++)
            {
                gridColumns.Rows[i].Selected = true;
            }

        }

        private void menuSelectReverseColumn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridColumns.Rows.Count; i++)
            {
                if (gridColumns.Rows[i].Selected)
                {
                    gridColumns.Rows[i].Selected = false;
                }
                else
                {
                    gridColumns.Rows[i].Selected = true;
                }
               
            }
        }

        private void menuSelectCondition_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridCondition.Rows.Count; i++)
            {
                gridCondition.Rows[i].Selected= true;
            }
        }

        private void menuSelectReverseCondition_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridCondition.Rows.Count; i++)
            {
                if (gridCondition.Rows[i].Selected)
                {
                    gridCondition.Rows[i].Selected = false;
                }
                else
                {
                    gridCondition.Rows[i].Selected = true;
                }

            }
        }


    }
}
