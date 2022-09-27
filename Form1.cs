using Dapper;
using Microsoft.Data.SqlClient;
using System.Text;

namespace SpGenerator
{
    public partial class Form1 : Form
    {
        string connectionStringFirst = "data source=localhost; initial catalog=master; MultipleActiveResultSets=true; Trusted_Connection=true;";
        string connectionStringforSelectedDB = "";

        int totalDbCount = 0;
        int totalTableCountForSelectedDb = 0;
        int totalColumnCount = 0;

        string SelectedDb = "";
        string SelectedTable = "";

        List<string> listDatabases = new List<string>();
        List<string> listTables = new List<string>();
        List<string> listColumn = new List<string>();
        List<string> listDataType = new List<string>();
        List<string> listDataTypeSize = new List<string>();

        string fileText = "";
        string filePath = "";

        void getSystemDbsCount()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringFirst))
                {
                    var sql = @"SELECT COUNT(name) FROM sys.databases
                                WHERE name NOT LIKE 'master'
                                AND name NOT LIKE 'tempdb'
                                AND name NOT LIKE 'model'
                                AND name NOT LIKE 'msdb'";

                    totalDbCount = connection.QuerySingle<int>(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
        }
        void getAllDbsName()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringFirst))
                {
                    var sql = @"SELECT name FROM sys.databases
                                WHERE name NOT LIKE 'master' 
                                AND name NOT LIKE 'tempdb'
                                AND name NOT LIKE 'model'
                                AND name NOT LIKE 'msdb'";

                    listDatabases = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to retrieve Db names.");
            }
        }
        void addDbNametoCombobox()
        {
            comboDb.Items.Clear();
            for (int i = 0; i < totalDbCount; i++)
            {
                comboDb.Items.Add(listDatabases[i]);
            }
        }
        void getTableCountforSelectedDb()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT COUNT(*) FROM sys.tables
                                WHERE name NOT LIKE 'sysdiagrams'";

                    totalTableCountForSelectedDb = connection.QuerySingle<int>(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void getTablesforSelectedDb()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT name FROM sys.tables 
                                WHERE name NOT LIKE 'sysdiagrams'";

                    listTables = connection.Query<string>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void addTableNametoCombobox()
        {
            comboTable.Items.Clear();
            try
            {
                for (int i = 0; i < totalTableCountForSelectedDb; i++)
                {
                    comboTable.Items.Add(listTables[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void clearAllTextBox()
        {
            textBoxSelectSearch.Clear();
            textBoxSelectId.Clear();
            textBoxDelete.Clear();
            textBoxInsert.Clear();
            textBoxUpdate.Clear();
        }
        void GetColumnsCountSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT COUNT(*)
                                    FROM sys.tables AS tab
                                        LEFT JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                    WHERE tab.name = @TABLE_NAME";

                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    totalColumnCount = connection.QuerySingle<int>(sql, prms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetColumnsforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT col.name AS KolonAdi,
                                            t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME
		                                    ORDER BY col.column_id";
                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    listColumn = connection.Query<string>(sql, prms).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetDataTypesforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT t.name AS VeriTipi
                                    FROM sys.tables AS tab
                                        INNER JOIN sys.columns AS col
                                            ON tab.object_id = col.object_id
                                        LEFT JOIN sys.types AS t
                                            ON col.user_type_id = t.user_type_id
                                            WHERE tab.name = @TABLE_NAME
		                                    ORDER BY col.column_id";
                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    listDataType = connection.Query<string>(sql, prms).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetDataTypeSizeforSelectedTable()
        {
            try
            {
                using (var connection = new SqlConnection(connectionStringforSelectedDB))
                {
                    var sql = @"SELECT col.max_length AS VeriTipi
	                            FROM sys.tables AS tab
	                            	INNER JOIN sys.columns AS col
	                            ON tab.object_id = col.object_id
	                            	LEFT JOIN sys.types AS t
	                            ON col.user_type_id = t.user_type_id
	                            WHERE tab.name = @TABLE_NAME";
                    var prms = new
                    {
                        TABLE_NAME = SelectedTable
                    };
                    listDataTypeSize = connection.Query<string>(sql, prms).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Writeto_textBoxSelectSearch()
        {
            textBoxSelectSearch.AppendText("/* select_search */" + Environment.NewLine);
            textBoxSelectSearch.AppendText("CREATE OR ALTER PROCEDURE [dbo].[S_" + SelectedTable + "_BySearch" + "]" + Environment.NewLine);
            textBoxSelectSearch.AppendText("@SearchText NVARCHAR(50)" + Environment.NewLine);
            textBoxSelectSearch.AppendText("AS" + Environment.NewLine);
            textBoxSelectSearch.AppendText("BEGIN" + Environment.NewLine);
            textBoxSelectSearch.AppendText("SELECT * FROM " + SelectedTable + " WHERE " + SelectedTable + ".Name LIKE '%'+@SearchText+'%'" + Environment.NewLine);
            textBoxSelectSearch.AppendText("END");
        }
        void Writeto_textBoxSelectId()
        {
            textBoxSelectId.AppendText("/* select_id */" + Environment.NewLine);
            textBoxSelectId.AppendText("CREATE OR ALTER PROCEDURE [dbo].[S_" + SelectedTable + "_ById" + "]" + Environment.NewLine);
            textBoxSelectId.AppendText("@Id INT" + Environment.NewLine);
            textBoxSelectId.AppendText("AS" + Environment.NewLine);
            textBoxSelectId.AppendText("BEGIN" + Environment.NewLine);
            textBoxSelectId.AppendText("SELECT * FROM " + SelectedTable + " WHERE " + SelectedTable + ".Id = @Id" + Environment.NewLine);
            textBoxSelectId.AppendText("END");
        }
        void Writeto_textBoxDelete()
        {
            textBoxDelete.AppendText("/* delete */" + Environment.NewLine);
            textBoxDelete.AppendText("CREATE OR ALTER PROCEDURE [dbo].[D_" + SelectedTable + "]" + Environment.NewLine);
            textBoxDelete.AppendText("@Id INT" + Environment.NewLine);
            textBoxDelete.AppendText("AS" + Environment.NewLine);
            textBoxDelete.AppendText("BEGIN" + Environment.NewLine);
            textBoxDelete.AppendText("DELETE FROM " + SelectedTable + " WHERE " + SelectedTable + ".Id = @Id" + Environment.NewLine);
            textBoxDelete.AppendText("END");
        }
        void Writeto_textBoxUpdate()
        { // yapýlacak
            string identifyColumn = "";
            int size;

            textBoxUpdate.AppendText("/* update */" + Environment.NewLine);
            textBoxUpdate.AppendText("CREATE OR ALTER PROCEDURE [dbo].[U_" + SelectedTable + "]" + Environment.NewLine);
            textBoxUpdate.AppendText("@Id INT," + Environment.NewLine);

            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                identifyColumn = "@";
                identifyColumn += listColumn[i];
                identifyColumn += " ";
                identifyColumn += listDataType[i];

                if (Convert.ToString(listDataTypeSize[i]) == "-1")
                {
                    identifyColumn += "(";
                    identifyColumn += "MAX";
                    identifyColumn += ")";
                    if (i == totalColumnCount - 1)
                    {
                        textBoxUpdate.AppendText(identifyColumn);
                        textBoxUpdate.AppendText(Environment.NewLine);
                        break;
                    }
                    identifyColumn += ",";
                }
                else
                {
                    if (listDataType[i].Equals("nvarchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size / 2;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("varbinary"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("varchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("char"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("binary"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("nchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size / 2;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("smallint"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("smallmoney"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("time"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size - 2;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else
                    {
                        if (i == totalColumnCount - 1)
                        {
                            textBoxUpdate.AppendText(identifyColumn);
                            textBoxUpdate.AppendText(Environment.NewLine);
                            break;
                        }
                        identifyColumn += ",";
                    }
                }
                textBoxUpdate.AppendText(identifyColumn);
                textBoxUpdate.AppendText(Environment.NewLine);
            }
            textBoxUpdate.AppendText("AS" + Environment.NewLine);
            textBoxUpdate.AppendText("BEGIN" + Environment.NewLine);
            textBoxUpdate.AppendText("UPDATE " + SelectedTable);
            textBoxUpdate.AppendText(" SET" + Environment.NewLine);

            string setColumn = "";
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                setColumn = SelectedTable + "." + listColumn[i];
                setColumn += " = @";
                setColumn += listColumn[i];

                if (i == totalColumnCount - 1)
                {
                    textBoxUpdate.AppendText(setColumn);
                    break;
                }
                setColumn += "," + Environment.NewLine;
                textBoxUpdate.AppendText(setColumn);
            }
            textBoxUpdate.AppendText(Environment.NewLine + "WHERE " + SelectedTable + ".Id = @Id");

            textBoxUpdate.AppendText(Environment.NewLine + "END");


        }
        void Writeto_textBoxInsert()
        {
            string identifyColumn = "";
            int size;

            textBoxInsert.AppendText("/* insert */" + Environment.NewLine);
            textBoxInsert.AppendText("CREATE OR ALTER PROCEDURE [dbo].[I_" + SelectedTable + "]" + Environment.NewLine);
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                identifyColumn = "@";
                identifyColumn += listColumn[i];
                identifyColumn += " ";
                identifyColumn += listDataType[i];

                if (Convert.ToString(listDataTypeSize[i]) == "-1")
                {
                    identifyColumn += "(";
                    identifyColumn += "MAX";
                    identifyColumn += ")";

                    if (i == totalColumnCount - 1)
                    {
                        textBoxInsert.AppendText(identifyColumn);
                        break;
                    }
                    identifyColumn += ",";
                }
                else
                {
                    if (listDataType[i].Equals("nvarchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size / 2;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("varbinary"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("varchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";

                    }
                    else if (listDataType[i].Equals("char"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("binary"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        identifyColumn += ")";

                        if (i == totalColumnCount - 1)
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";
                    }
                    else if (listDataType[i].Equals("nchar"))
                    {
                        identifyColumn += "(";
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size / 2;
                        if (i == totalColumnCount - 1)
                        {
                            identifyColumn += ")";
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                            identifyColumn += ",";
                        }
                    }
                    else if (listDataType[i].Equals("smallint"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        if (i == totalColumnCount - 1)
                        {
                            identifyColumn += ")";
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                            identifyColumn += ",";
                        }
                    }
                    else if (listDataType[i].Equals("smallmoney"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size;
                        if (i == totalColumnCount - 1)
                        {
                            identifyColumn += ")";
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                            identifyColumn += ",";
                        }
                    }
                    else if (listDataType[i].Equals("time"))
                    {
                        size = Convert.ToInt32(listDataTypeSize[i]);
                        identifyColumn += size - 2;
                        if (i == totalColumnCount - 1)
                        {
                            identifyColumn += ")";
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                            identifyColumn += ",";
                        }
                    }
                    else
                    {
                        if (i == (totalColumnCount - 1))
                        {
                            textBoxInsert.AppendText(identifyColumn);
                            break;
                        }
                        identifyColumn += ",";
                    }
                }
                textBoxInsert.AppendText(identifyColumn);
                textBoxInsert.AppendText(Environment.NewLine);
            }
            textBoxInsert.AppendText(Environment.NewLine + "AS" + Environment.NewLine);
            textBoxInsert.AppendText("BEGIN" + Environment.NewLine);
            textBoxInsert.AppendText("INSERT INTO [dbo].[" + SelectedTable + "]");
            textBoxInsert.AppendText("(" + Environment.NewLine);

            string setColumn = "";
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                //setColumn = "[";
                setColumn = listColumn[i];
                //setColumn += "]";

                if (i == totalColumnCount - 1)
                {
                    textBoxInsert.AppendText(setColumn);
                    textBoxInsert.AppendText(")");
                    break;
                }

                setColumn += ",";
                textBoxInsert.AppendText(setColumn);
                textBoxInsert.AppendText(Environment.NewLine);
            }
            textBoxInsert.AppendText(Environment.NewLine + "VALUES(" + Environment.NewLine);
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                identifyColumn = "@";
                identifyColumn += listColumn[i];
                if (i == totalColumnCount - 1)
                {
                    textBoxInsert.AppendText(identifyColumn);
                    break;
                }
                identifyColumn += ",";

                textBoxInsert.AppendText(identifyColumn);
                textBoxInsert.AppendText(Environment.NewLine);
            }
            textBoxInsert.AppendText(")");
            textBoxInsert.AppendText(Environment.NewLine + "END");
        }
        void Writeto_textBoxExecuteSp()
        {
            textBoxExecuteSp.Clear();

            string exec_selectSearch = "EXEC [dbo].[S_" + SelectedTable + "_BySearch" + "]" + Environment.NewLine + "@SearchText = ''" + Environment.NewLine + "GO";
            string exec_selectId = "EXEC [dbo].[S_" + SelectedTable + "_ById" + "]" + Environment.NewLine + "@Id = ''" + Environment.NewLine + "GO";
            string exec_delete = "EXEC [dbo].[D_" + SelectedTable + "]" + Environment.NewLine + "@Id = ''" + Environment.NewLine + "GO";
            string exec_update = "EXEC [dbo].[U_" + SelectedTable + "]" + Environment.NewLine + "@Id =''," + Environment.NewLine;
            string exec_insert = "EXEC [dbo].[I_" + SelectedTable + "]" + Environment.NewLine;

            //  SelectSearch
            textBoxExecuteSp.AppendText(exec_selectSearch + Environment.NewLine + Environment.NewLine);

            //  SelectId
            textBoxExecuteSp.AppendText(exec_selectId + Environment.NewLine + Environment.NewLine);

            //  Delete
            textBoxExecuteSp.AppendText(exec_delete + Environment.NewLine + Environment.NewLine);

            //  Update
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                exec_update += "@" + listColumn[i] + " = ";
                exec_update += "''";

                if (i == totalColumnCount - 1)
                {
                    break;
                }
                exec_update += "," + Environment.NewLine;
            }
            exec_update += Environment.NewLine + "GO";
            textBoxExecuteSp.AppendText(exec_update + Environment.NewLine + Environment.NewLine);

            //  Insert
            for (int i = 0; i < totalColumnCount; i++)
            {
                if (listColumn[i] == "Id")
                    continue;

                exec_insert += "@" + listColumn[i] + " = ";
                exec_insert += "''";

                if (i == totalColumnCount - 1)
                {
                    break;
                }
                exec_insert += "," + Environment.NewLine;
            }
            exec_insert += Environment.NewLine + "GO";
            textBoxExecuteSp.AppendText(exec_insert);
        }
        void WriteTheFileStoredProcedure()
        {
            try
            {
                fileText = "";
                filePath = "C:\\Users\\" + Environment.MachineName + "\\Desktop";

                filePath += "\\" + SelectedTable + ".sql";

                fileText += "USE [" + SelectedDb + "]" + Environment.NewLine;
                fileText += textBoxSelectId.Text;
                fileText += Environment.NewLine + Environment.NewLine;

                fileText += textBoxSelectSearch.Text;
                fileText += Environment.NewLine + Environment.NewLine;

                fileText += textBoxDelete.Text;
                fileText += Environment.NewLine + Environment.NewLine;

                fileText += textBoxInsert.Text;
                fileText += Environment.NewLine + Environment.NewLine;

                fileText += textBoxUpdate.Text;

                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void WriteTheFileExecuteProcedure()
        {
            try
            {
                fileText = "";
                filePath = "C:\\Users\\" + Environment.MachineName + "\\Desktop";

                filePath += "\\" + "Exec" + SelectedTable + ".sql";

                fileText += "USE [" + SelectedDb + Environment.NewLine;

                fileText += textBoxExecuteSp.Text;

                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(fileText);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getSystemDbsCount();
            getAllDbsName();
            addDbNametoCombobox();
        }
        private void comboDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboTable.Text = "";
                pictureTable.Visible = false;
                comboTable.Items.Clear();

                clearAllTextBox();

                if (comboDb.SelectedItem != null)
                {
                    SelectedDb = comboDb.SelectedItem.ToString();
                    connectionStringforSelectedDB = "data source=localhost; initial catalog=" + SelectedDb + "; MultipleActiveResultSets=true; Trusted_Connection=true;";

                    getTableCountforSelectedDb();
                    getTablesforSelectedDb();
                    addTableNametoCombobox();

                    pictureDb.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please select database.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tables could not be retrieved.  " + ex.Message);
            }
        }
        private void comboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearAllTextBox();

            if (comboTable.SelectedItem != null)
            {
                SelectedTable = comboTable.SelectedItem.ToString();
                GetColumnsCountSelectedTable();
                GetColumnsforSelectedTable();
                GetDataTypesforSelectedTable();
                GetDataTypeSizeforSelectedTable();
                Writeto_textBoxSelectSearch();
                Writeto_textBoxSelectId();
                Writeto_textBoxUpdate();
                Writeto_textBoxDelete();
                Writeto_textBoxInsert();
                Writeto_textBoxExecuteSp();
                pictureTable.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select table.");
            }
        }
        private void btnForSelectedTable_Click(object sender, EventArgs e)
        {
            WriteTheFileStoredProcedure();
            WriteTheFileExecuteProcedure();
        }
        private void btnForSelectedDatabase_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < totalTableCountForSelectedDb; i++)
            {

            }

            WriteTheFileStoredProcedure();
            WriteTheFileExecuteProcedure();
        }
    }
}