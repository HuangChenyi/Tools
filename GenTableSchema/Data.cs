using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GenTableSchema
{
    public class Data
    {
        string m_ConnectionString = "";

        public Data()
        {
            m_ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        public SchemaDataSet GetAllTables()
        {
            SqlConnection conn = new SqlConnection(m_ConnectionString);
            SchemaDataSet ds = new SchemaDataSet();
            conn.Open();

            string cmdTxt = @"SELECT *
,(SELECT value FROM ::fn_listextendedproperty (NULL, 'user', 'dbo', 'table',  TABLE_NAME, NULL, NULL)  ) AS 'SUMMARY'
 FROM INFORMATION_SCHEMA.TABLES 
 WHERE TABLE_TYPE='BASE TABLE'
AND (TABLE_NAME !='__RefactorLog' AND TABLE_NAME!='sysdiagrams')
 ORDER BY TABLE_NAME

";

            SqlCommand comm = new SqlCommand(cmdTxt, conn);

            ds.Load(comm.ExecuteReader(), LoadOption.OverwriteChanges,ds.TableSchema);

            cmdTxt = @"
 
SELECT   TABLE_NAME,

CASE ( SELECT count(1)
								FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
								INNER JOIN  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
								      ON c.TABLE_NAME = pk.TABLE_NAME 
									AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
								WHERE  pk.TABLE_NAME = a.TABLE_NAME  AND
	 								 c.COLUMN_NAME =  a.COLUMN_NAME
	 								AND CONSTRAINT_TYPE = 'PRIMARY KEY' )
					WHEN 0 THEN 'NO'
					 ELSE   'YES'
					 END AS IS_PK

 ,COLUMN_NAME, 
 DATA_TYPE,
  IS_NULLABLE,
ISNULL( CHARACTER_MAXIMUM_LENGTH ,0) CHARACTER_MAXIMUM_LENGTH,
ISNULL( NUMERIC_PRECISION ,0) NUMERIC_PRECISION,
ISNULL( NUMERIC_SCALE ,0) NUMERIC_SCALE,
ISNULL( COLUMN_DEFAULT ,'') COLUMN_DEFAULT,
  (SELECT [value] FROM ::fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'table', TABLE_NAME, 'column', COLUMN_NAME))  AS SUMMARY
 FROM INFORMATION_SCHEMA.COLUMNS as a
 ORDER BY TABLE_NAME
";

            comm = new SqlCommand(cmdTxt, conn);

            ds.Load(comm.ExecuteReader(), LoadOption.OverwriteChanges, ds.ColumnSchema);




            conn.Close();

            return ds;


        }

        public DataTable GetAllColumns()
        {
            SqlConnection conn = new SqlConnection(m_ConnectionString);

            conn.Open();

            string cmdTxt = @"S
 
SELECT   TABLE_NAME,

CASE ( SELECT count(1)
								FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
								INNER JOIN  INFORMATION_SCHEMA.KEY_COLUMN_USAGE c
								      ON c.TABLE_NAME = pk.TABLE_NAME 
									AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
								WHERE  pk.TABLE_NAME = a.TABLE_NAME  AND
	 								 c.COLUMN_NAME =  a.COLUMN_NAME
	 								AND CONSTRAINT_TYPE = 'PRIMARY KEY' )
					WHEN 0 THEN 'NO'
					 ELSE   'YES'
					 END AS IS_PK

 ,COLUMN_NAME, 
 DATA_TYPE,
  IS_NULLABLE,
ISNULL( CHARACTER_MAXIMUM_LENGTH ,0) CHARACTER_MAXIMUM_LENGTH,
ISNULL( NUMERIC_PRECISION ,0) NUMERIC_PRECISION,
ISNULL( NUMERIC_SCALE ,0) NUMERIC_SCALE,
ISNULL( COLUMN_DEFAULT ,'') COLUMN_DEFAULT,
  (SELECT [value] FROM ::fn_listextendedproperty (NULL, 'SCHEMA', 'dbo', 'table', TABLE_NAME, 'column', COLUMN_NAME))  AS SUMMARY
 FROM INFORMATION_SCHEMA.COLUMNS as a
 ORDER BY TABLE_NAME
";

            SqlCommand comm = new SqlCommand(cmdTxt, conn);
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader(), LoadOption.OverwriteChanges);
            conn.Close();

            return dt;


        }
    }
}
