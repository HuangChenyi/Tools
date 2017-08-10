using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SQLHelper
{
    public partial class SQLHelper : Form
    {

        public string ConnectString = "";
        public string DBName = "";
        private TreeNode m_dragNode;

        Utitlty m_Utitlty;

        public SQLHelper()
        {
            InitializeComponent();     
           
            Login log = new Login();
            if (log.ShowDialog() == DialogResult.OK)
            {
                ConnectString = log.ConnectString;
                DBName = log.DBName;
                m_Utitlty = new Utitlty();
                BindTree();
            }
        }

        private void BindTree()
        {
           

            treeTable.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.ImageIndex = 1;
            rootNode.SelectedImageIndex = 1;
            rootNode.Text = DBName;
            rootNode.Tag = "root";
            treeTable.Nodes.Add(rootNode);

            DataTable tableDt = m_Utitlty.GetALLTable();

            foreach (DataRow dr in tableDt.Rows)
            {
                TreeNode node = new TreeNode(  );
                node.ImageIndex =3;
                node.SelectedImageIndex = 3;
                node.Text = dr["TABLE_NAME"].ToString();
                node.Tag = dr["TABLE_NAME"].ToString();
                node.Nodes.Add("");
             
                treeTable.Nodes[0].Nodes.Add(node);
            }

            treeTable.ExpandAll();

            foreach (TreeNode node in treeTable.Nodes[0].Nodes)
            {
                node.Collapse();
            }

        }

        private void richTextBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (cbxCommandType.SelectedIndex == -1 || cbxCommandType.SelectedIndex == 0 || cbxCommandType.SelectedIndex == 5)
            {
                MessageBox.Show("請選擇輸出的語法!", "錯誤!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_dragNode.Level != 1)
            {
                return;
            }

            string tableName = m_dragNode.Text;
            string commandType = cbxCommandType.SelectedItem.ToString();
            List<string> columns = new List<string>();

            foreach (TreeNode node in m_dragNode.Nodes)
            {
                columns.Add(node.Tag.ToString());
            }

            RichTextBoxColorful ri = new RichTextBoxColorful();
            if (cbxCommandType.SelectedIndex > 0 && cbxCommandType.SelectedIndex < 5)
            {
                richTextBox1.Text = SQLCommand.GetCommandText(tableName, commandType, columns);

                ri.ColorfulText(richTextBox1, LanguageType.SQL);
            }
            else if (cbxCommandType.SelectedIndex > 5 && cbxCommandType.SelectedIndex < 10)
            {
                //UOF匯出
                richTextBox1.Text = CSharpCommand.GetCommandText(tableName, commandType.Trim(), columns);

                ri.ColorfulText(richTextBox1, LanguageType.CSharp);
            }
            else
            {
                //一般匯出
                richTextBox1.Text = CSharpCommand.GetCommandTextByCSharp(tableName, commandType.Trim(), columns,new List<string>());

                ri.ColorfulText(richTextBox1, LanguageType.CSharp);
            }

        }


        private void treeTable_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
        }

        private void treeTable_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.m_dragNode = (TreeNode)e.Item;

            //拖曳要先判斷如果Table還沒展開Column，要先展開            
            if (this.m_dragNode.Level == 1)
            {
                AddColumns(m_dragNode);
            }
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }

        /// <summary>
        /// 新增欄位
        /// </summary>
        /// <param name="node"> 請說明此參數的用途 </param>
        /// <remarks>
        /// * 新 增 者： chinyi(2010/6/15 下午 04:42 )
        /// * 修 改 者：
        /// * 修 改 者：
        /// * 修 改 者：
        /// </remarks>
        private void AddColumns(TreeNode node)
        {
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "")
            {
                node.Nodes.Clear();
                DataTable columnsDt = m_Utitlty.GetALLColumns(node.Text);

                foreach (DataRow colmunsDr in columnsDt.Rows)
                {
                    TreeNode columnNode = new TreeNode();
                    columnNode.Tag = colmunsDr["COLUMN_NAME"].ToString();


                    string tagString = colmunsDr["COLUMN_NAME"].ToString();
                    tagString += "( ";

                    if (colmunsDr["IS_PK"].ToString() == "YES")
                    {
                        tagString += "PK,";
                        columnNode.SelectedImageIndex = 2;
                        columnNode.ImageIndex = 2;
                    }
                    else
                    {
                        columnNode.SelectedImageIndex = 0;
                        columnNode.ImageIndex = 0;
                    }

                    tagString += colmunsDr["DATA_TYPE"].ToString();

                    if (int.Parse(colmunsDr["LENGTH"].ToString()) > 0)
                    {
                        tagString += "(" + colmunsDr["LENGTH"].ToString() + ")";
                    }

                    tagString += " , ";

                    if (colmunsDr["IS_NULL"].ToString() == "YES")
                    {
                        tagString += "NULL)";
                    }
                    else
                    {
                        tagString += "NOT NULL)";
                    }





                    columnNode.Text = tagString;
                    
              
                    node.Nodes.Add(columnNode);
                }
            }
        }

        private void treeTable_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //移除假節點後 新增真正的節點

            if (e.Node.Level == 1)
            {
                if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
                {
                    AddColumns(e.Node);
                }
            }
        }

        private void treeTable_DoubleClick(object sender, EventArgs e)
        {
            if (cbxCommandType.SelectedIndex == -1 || cbxCommandType.SelectedIndex == 0 || cbxCommandType.SelectedIndex == 5)
            {
                MessageBox.Show("請選擇輸出的語法!" , "錯誤!" , MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }



            if (treeTable.SelectedNode.Level == 1)
            {
                SelectCondition cond = new SelectCondition();
                cond.TableName = treeTable.SelectedNode.Tag.ToString();
                cond.CommandType = cbxCommandType.SelectedItem.ToString();
                cond.SelectedIndex = cbxCommandType.SelectedIndex;

                cond.BindData();

                if (cond.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = cond.CommandText;
                    RichTextBoxColorful ri = new RichTextBoxColorful();

                    if (cbxCommandType.SelectedIndex > 0 && cbxCommandType.SelectedIndex < 5)
                    {
                        ri.ColorfulText(richTextBox1, LanguageType.SQL);
                    }
                    else
                    {
                        ri.ColorfulText(richTextBox1, LanguageType.CSharp);
                    }
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuLogin_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (log.ShowDialog() == DialogResult.OK)
            {
                ConnectString = log.ConnectString;
                DBName = log.DBName;
                m_Utitlty = new Utitlty();

                BindTree();
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SQLHelper V1.0  By \r\n Copyright 2010 一等一科技" , "SQLHelper");
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, richTextBox1.SelectedText);
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
        }
    }
}
