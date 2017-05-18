using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using AnalyseEtControleFEC.Controller;

namespace AnalyseEtControleFEC.Controller
{
    [SQLiteFunction(Name = "REGEXP", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class RegExSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(args[1]), Convert.ToString(args[0]));
        }
    }

    [SQLiteFunction(Name = "ISSTRICTLYSUPERIOR", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsStrictlySuperiorSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;
            try
            {
                result = Double.Parse(Convert.ToString(args[0])) > Double.Parse(Convert.ToString(args[1]));
            }
            catch(Exception e)
            {
                return false;
            }
            return result;
        }
    }

    [SQLiteFunction(Name = "ISSUPERIOR", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsSuperiorSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;
            try
            {
                result = Double.Parse(Convert.ToString(args[0])) >= Double.Parse(Convert.ToString(args[1]));
            }
            catch (Exception e)
            {
                return false;
            }
            return result;
        }
    }

    [SQLiteFunction(Name = "ISEQUAL", Arguments = 2, FuncType = FunctionType.Scalar)]
    public class IsEqualSQLiteFunction : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            bool result;
            try
            {
                result = Double.Parse(Convert.ToString(args[0])) == Double.Parse(Convert.ToString(args[1]));
            }
            catch (Exception e)
            {
                return false;
            }
            return result;
        }
    }

    /// <summary>
    /// This Class is the controller for database reading and writing
    /// </summary>
    public class DataBaseController
    {
        SQLiteConnection dbConnection;
        MainController mainController;
        private int FilterNumber;

        /// <summary>
        /// Constructor for DataBaseController
        /// </summary>
        /// <param name="fileName">Name of the database file where we want to store the database</param>
        /// <param name="mainController">The main Controller for this program</param>
        public DataBaseController(String fileName, MainController mainController)
        {
            if (!File.Exists(fileName))
            {
                SQLiteConnection.CreateFile(fileName);
            }
            dbConnection = new SQLiteConnection("Data Source="+fileName+ ";Version=3;");
            //dbConnection = new SQLiteConnection("Data Source=:memory:;Version=3;");
        }

        /// <summary>
        /// Initialyse the database by dropping existing tables if exists and create empty ones
        /// </summary>
        public void init()
        {
            dbConnection.Close();
            dbConnection.Open();
            new SQLiteCommand("DROP TABLE IF EXISTS Column", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("DROP TABLE IF EXISTS Content", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP TABLE Column (Position INT, Name VARCHAR(20))", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP TABLE Content (Line INT, Column INT, Content VARCHAR(100))", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP VIEW FinalFilter AS Select * FROM Content",dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE INDEX AccessIndexContent ON Content (Column,Line)", dbConnection).ExecuteNonQuery();
            SQLiteFunction.RegisterFunction(typeof(IsStrictlySuperiorSQLiteFunction));
            SQLiteFunction.RegisterFunction(typeof(IsSuperiorSQLiteFunction));
            SQLiteFunction.RegisterFunction(typeof(IsEqualSQLiteFunction));
            FilterNumber = 0;
            //dbConnection.Close();
        }

        public void close()
        {
            dbConnection.Close();
        }

        internal object getContentFromFilter(int column, int line, int filterNumber)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Content FROM Filter"+filterNumber+" WHERE Column = @column AND Line = @line", dbConnection);
            command.Parameters.Add(new SQLiteParameter("@line", line));
            command.Parameters.Add(new SQLiteParameter("@column", column));
            return (String)command.ExecuteScalar();
        }


        /// <summary>
        /// Fill the dataBase by reading an Accounting Entry File
        /// </summary>
        /// <param name="filePath">Path of the file to read</param>
        public List<int> fillDatabaseFromFile(String filePath)
        {
            Char[] separators = { '|', '\t' };
            List<int> errors = new List<int>();
            FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs = new BufferedStream(fs);
            StreamReader reader = new StreamReader(bs);
            //File.OpenText(filePath);
            String readLine = reader.ReadLine();
            String[] splitLine = readLine.Split(separators);
            int nbColumns = splitLine.Length;
            //dbConnection.Open();
            for (int i = 0; i < splitLine.Length; i++)
            {
                new SQLiteCommand("INSERT INTO Column (Position, Name) VALUES (" + i + ",'" + splitLine[i] + "')", dbConnection).ExecuteNonQuery();
            }
            int line = 1;
            SQLiteCommand beginTrans = new SQLiteCommand("BEGIN TRANSACTION", dbConnection);
            SQLiteCommand commitTrans = new SQLiteCommand("COMMIT TRANSACTION", dbConnection);
            SQLiteCommand insertCmd = new SQLiteCommand("INSERT INTO Content (Line, Column, Content) VALUES (@line,@column,@content)", dbConnection);
            while (!reader.EndOfStream)
            {
                beginTrans.ExecuteNonQuery();
                int curCount = 0;
                while (!reader.EndOfStream && curCount < 10000)
                {
                    readLine = reader.ReadLine();
                    splitLine = readLine.Split(separators);
                    for (int column = 0; column < Math.Min(splitLine.Length, nbColumns); column++)
                    {
                        insertCmd.Parameters.Add(new SQLiteParameter("@line", line));
                        insertCmd.Parameters.Add(new SQLiteParameter("@column", column));
                        insertCmd.Parameters.Add(new SQLiteParameter("@content", splitLine[column]));
                        insertCmd.ExecuteNonQuery();
                    }
                    if (splitLine.Length != nbColumns)
                    {
                        errors.Add(line);
                    }
                    line++;
                    curCount++;
                }
                commitTrans.ExecuteNonQuery();
            }
            return errors;
            //dbConnection.Close();
        }

        /// <summary>
        /// Getter for Columns names in the dataBase
        /// </summary>
        /// <returns>A String array containing the columns names in the database in the same order as in the file</returns>
        public String[] getColumnNames()
        {
            //dbConnection.Open();
            SQLiteDataReader reader = new SQLiteCommand("SELECT Name FROM Column ORDER BY Position ASC",dbConnection).ExecuteReader();
            List<String> result = new List<String>();
            while(reader.Read())
            {
                result.Add((String)reader["Name"]);
            }
            //dbConnection.Close();
            return result.ToArray();
        }

        /// <summary>
        /// Return a line in the file
        /// </summary>
        /// <param name="line">Line of the file to read</param>
        /// <returns>A String array containing the contents for the different columns (in the same order than the getColumnNames function) of the specified line</returns>
        public String[] getLine(int line)
        {
            //dbConnection.Open();
            SQLiteDataReader reader = new SQLiteCommand("SELECT Content FROM Content WHERE Line = "+line+" ORDER BY Column ASC", dbConnection).ExecuteReader();
            List<String> result = new List<String>();
            while (reader.Read())
            {
                result.Add((String)reader["Content"]);
            }
            //dbConnection.Close();
            return result.ToArray();
        }

        /// <summary>
        /// Return the content of specified column and line in the final filter view
        /// </summary>
        /// <param name="column">the column number</param>
        /// <param name="line">the line number</param>
        /// <returns>the content of the specified cell as a String</returns>
        public String getContentFromFilter (int column, int line)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Content FROM FinalFilter WHERE Column = @column AND Line = @line", dbConnection);
            command.Parameters.Add(new SQLiteParameter("@line", line));
            command.Parameters.Add(new SQLiteParameter("@column", column));
            return (String)command.ExecuteScalar();
        }

        public String getContent(int column, int line)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT Content FROM Content WHERE Column = @column AND Line = @line", dbConnection);
            command.Parameters.Add(new SQLiteParameter("@line", line));
            command.Parameters.Add(new SQLiteParameter("@column", column));
            return (String)command.ExecuteScalar();
        }

        /// <summary>
        /// Add a filter using the restriction parameter for adding ORDER BY or WHERE clause
        /// </summary>
        /// <param name="restriction">String representing the clauses for the filter, must contains ORDER BY and/or WHERE clause</param>
        public void AddFilterAdd (String restriction, int lastFilterId)
        {
            SQLiteCommand filter;
            SQLiteCommand columnNum;
            if (lastFilterId == -1)
            {
                columnNum = new SQLiteCommand("CREATE TEMP TABLE ColumnNum" + FilterNumber + " AS SELECT DISTINCT Line FROM Content base " + restriction, dbConnection);
                columnNum.ExecuteNonQuery();
                filter = new SQLiteCommand("CREATE TEMP TABLE Filter" + FilterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM Content base INNER JOIN ColumnNum" + FilterNumber + " colNum ON base.Line = colNum.Line",dbConnection);
            }
            else
            {
                columnNum = new SQLiteCommand("CREATE TEMP TABLE ColumnNum" + FilterNumber + " AS SELECT DISTINCT Line FROM Filter"+(lastFilterId)+" base " + restriction, dbConnection);
                columnNum.ExecuteNonQuery();
                filter = new SQLiteCommand("CREATE TEMP TABLE Filter" + FilterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM Filter" + lastFilterId + " base INNER JOIN ColumnNum" + FilterNumber + " colNum ON base.Line = colNum.Line", dbConnection);
            }
            filter.ExecuteNonQuery();
            new SQLiteCommand("CREATE INDEX AccessIndexFilter" + FilterNumber + " ON Filter" + FilterNumber + " (Column,Line)", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("DROP VIEW FinalFilter", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP VIEW FinalFilter AS SELECT * FROM Filter" + FilterNumber, dbConnection).ExecuteNonQuery();
            FilterNumber++;
        }

        public void AddFilterOr(String restriction, int lastTabId)
        {
            SQLiteCommand filter;
            SQLiteCommand columnNum;
            String lastTab;
            if(lastTabId == -1)
            {
                lastTab = "Content";
            }
            else
            {
                lastTab = "Filter" + lastTabId;
            }
            columnNum = new SQLiteCommand("CREATE TEMP TABLE ColumnNum" + FilterNumber + " AS SELECT DISTINCT Line FROM "+ lastTab +" base " + restriction + " OR Line IN (SELECT Line FROM ColumnNum" + (FilterNumber-1) + ")", dbConnection);
            columnNum.ExecuteNonQuery();
            filter = new SQLiteCommand("CREATE TEMP TABLE Filter" + FilterNumber + " AS SELECT base.Line AS 'BaseLine', Column, Content, colNum.rowid AS 'Line' FROM " + lastTab + " base INNER JOIN ColumnNum" + FilterNumber + " colNum ON base.Line = colNum.Line", dbConnection);
            filter.ExecuteNonQuery();
            new SQLiteCommand("CREATE INDEX AccessIndexFilter" + FilterNumber + " ON Filter" + FilterNumber + " (Column,Line)", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("DROP VIEW FinalFilter", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP VIEW FinalFilter AS SELECT * FROM Filter" + FilterNumber, dbConnection).ExecuteNonQuery();
            FilterNumber++;
        }

        /// <summary>
        /// Delete temporary tables created for the last final filter
        /// </summary>
        /// <param name="numberOfTables">number of tables created for the last filter (including the final one)</param>
        public void cleanTempTables(int numberOfTables)
        {
            SQLiteCommand dropColumnNumCommand = new SQLiteCommand(dbConnection);
            SQLiteCommand dropFilterCommand = new SQLiteCommand(dbConnection);
            if (numberOfTables > 1)
            {
                for (int i = FilterNumber - 1; i > FilterNumber - numberOfTables; i--)
                {
                    dropColumnNumCommand.CommandText = "DROP TABLE ColumnNum" + i;
                    dropFilterCommand.CommandText = "DROP TABLE Filter" + i;
                    dropColumnNumCommand.ExecuteNonQuery();
                    dropFilterCommand.ExecuteNonQuery();
                }
            }
            dropColumnNumCommand.CommandText = "DROP TABLE ColumnNum" + FilterNumber;
            dropColumnNumCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete all filters created with the AddFilter function
        /// </summary>
        public void DeleteAllFilters()
        {
            for(;FilterNumber > 0; FilterNumber--)
            {
                new SQLiteCommand("DROP VIEW Filter"+(FilterNumber-1), dbConnection).ExecuteNonQuery();
            }
            new SQLiteCommand("DROP VIEW FinalFilter", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP VIEW FinalFilter AS Select * FROM Content", dbConnection).ExecuteNonQuery();
        }

        internal int getLastFilterId()
        {
            return FilterNumber-1;
        }

        public String[][] getAllLines()
        {
            List<String[]> result = new List<String[]>();
            SQLiteDataReader reader = new SQLiteCommand("SELECT * FROM Content ORDER BY Line,Column ASC", dbConnection).ExecuteReader();
            List<String> lineContent = null;
            int line = 0;
            while (reader.Read())
            {
                if(line != (int)reader["Line"])
                {
                    if(lineContent != null)
                    {
                        result.Add(lineContent.ToArray());
                    }
                    line = (int)reader["Line"];
                    lineContent = new List<String>();
                }
                lineContent.Add((String)reader["Content"]);
            }
            result.Add(lineContent.ToArray());
            return result.ToArray();
        }

        /// <summary>
        /// Return the number of lines in the file
        /// </summary>
        /// <returns>An integer that represent the number of different lines in the file</returns>
        public int getNumberOfLines()
        {
            //dbConnection.Open();
            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM Content GROUP BY Column", dbConnection).ExecuteScalar());
            //dbConnection.Close();
            return result;
        }

        public int getNumberOfLinesInFilter()
        {
            //dbConnection.Open();
            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM FinalFilter GROUP BY Column", dbConnection).ExecuteScalar());
            //dbConnection.Close();
            return result;
        }

        public int getNumberOfLinesInFilter(int FilterNumber)
        {
            //dbConnection.Open();
            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM Filter"+FilterNumber+" GROUP BY Column", dbConnection).ExecuteScalar());
            //dbConnection.Close();
            return result;
        }

        /// <summary>
        /// this method is used for regex verification using REGEXP for each content member of the specified column
        /// </summary>
        /// <param name="column">the  column number we want to check</param>
        /// <param name="regex">the regex we want to use</param>
        /// <returns></returns>
        public List<int> checkRegexColumn(int column, String regex)
        {
            List<int> errorLines = new List<int>();
            //dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Line FROM Content WHERE Column = @col AND Content NOT REGEXP @regex ORDER BY Line ASC", dbConnection);
            command.Parameters.Add(new SQLiteParameter("@col", column));
            command.Parameters.Add(new SQLiteParameter("@regex", regex));
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                errorLines.Add((int)reader["Line"]);
            }
            //dbConnection.Close();
            return errorLines;
        }

        public List<int> CompareContent_CompAuxNum_CompAuxLib()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            // dbConnection.Open();
            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='6' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='7' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }
            return Line;
        }

        public List<int> CompareContent_EcritureLet_DateLet()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            // dbConnection.Open();
            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='13' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }
            return Line;
        }

        public List<int> CompareContent_Montantdevise_Idevise()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            // dbConnection.Open();
            SQLiteDataReader reader = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='16' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader1 = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='17' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (reader.Read() && reader1.Read())
            {
                if (reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = true;
                }
                else if (!reader.GetValue(0).ToString().Equals("") && reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                else if (reader.GetValue(0).ToString().Equals("") && !reader1.GetValue(0).ToString().Equals(""))
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader1.GetValue(1)));
                }
            }
            return Line;
        }
        public List<int> CompareContent_PieceDate_ValidDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int PieceDate = 0;
            int validDate = 0;
            // dbConnection.Open();
            SQLiteDataReader reader_PieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader_validDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (reader_PieceDate.Read() && reader_validDate.Read())
            {
                if (reader_PieceDate.GetValue(0).ToString().Equals(""))
                {
                    PieceDate = 0;
                }
                else
                {
                    PieceDate = Convert.ToInt32(reader_PieceDate.GetValue(0));
                }

                if (reader_validDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(reader_validDate.GetValue(0));
                }
                if (PieceDate <= validDate || PieceDate == 0 || validDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader_PieceDate.GetValue(1)));
                }
            }
            return Line;
        }
        public List<int> CompareContent_PieceDate_EcritureDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int PieceDate = 0;
            int ecritureDate = 0;
            // dbConnection.Open();
            SQLiteDataReader reader_EcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader_PieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_EcritureDate.Read() && reader_PieceDate.Read())
            {
                if (reader_EcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(reader_EcritureDate.GetValue(0));
                }

                if (reader_PieceDate.GetValue(0).ToString().Equals(""))
                {
                    PieceDate = 0;
                }
                else
                {
                    PieceDate = Convert.ToInt32(reader_PieceDate.GetValue(0));
                }
                if (PieceDate <= ecritureDate || PieceDate == 0 || ecritureDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader_EcritureDate.GetValue(1)));
                }
            }
            return Line;
        }
        public List<int> CompareContent_EcritureDate_ValidDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int ecritureDate = 0;
            int validDate = 0;
            SQLiteDataReader reader_EcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader_validDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_EcritureDate.Read() && reader_validDate.Read())
            {
                if (reader_EcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(reader_EcritureDate.GetValue(0));
                }
                if (reader_validDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(reader_validDate.GetValue(0));
                }
                if (ecritureDate <= validDate || ecritureDate == 0 || validDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader_validDate.GetValue(1)));
                }
            }
            return Line;
        }
        public List<int> CompareContent_DateLet_PieceDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int PieceDate = 0;
            int DateLet = 0;
            SQLiteDataReader reader_PieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader_DateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_PieceDate.Read() && reader_DateLet.Read())
            {
                if (reader_PieceDate.GetValue(0).ToString().Equals(""))
                {
                    PieceDate = 0;
                }
                else
                {
                    PieceDate = Convert.ToInt32(reader_PieceDate.GetValue(0));
                }

                if (reader_DateLet.GetValue(0).ToString().Equals(""))
                {
                    DateLet = 0;
                }
                else
                {
                    DateLet = Convert.ToInt32(reader_DateLet.GetValue(0));
                }

                if (DateLet >= PieceDate || PieceDate == 0 || DateLet == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader_PieceDate.GetValue(1)));
                }
            }
            return Line;
        }

        public List<int> CompareContent_DateLet_EcritureDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int ecritureDate = 0;
            int DateLet = 0;
            // dbConnection.Open();
            SQLiteDataReader reader_EcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader reader_DateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (reader_EcritureDate.Read() && reader_DateLet.Read())
            {
                if (reader_EcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(reader_EcritureDate.GetValue(0));
                }

                if (reader_DateLet.GetValue(0).ToString().Equals(""))
                {
                    DateLet = 0;
                }
                else
                {
                    DateLet = Convert.ToInt32(reader_DateLet.GetValue(0));
                }

                if (DateLet >= ecritureDate || DateLet == 0 || ecritureDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(reader_DateLet.GetValue(1)));
                }
            }
            return Line;
        }

        public List<String> EcritureNum_Debit_Credit()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_EcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_EcritureNum.Read())
            {
                SQLiteDataReader reader_Debit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + reader_EcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader reader_Credit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='2' and content='" + reader_EcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                while (reader_Debit.Read() && reader_Credit.Read())
                {
                    debit += Convert.ToDouble(reader_Debit.GetValue(0));
                    // Console.WriteLine(debit);
                    credit += Convert.ToDouble(reader_Credit.GetValue(0));
                    //Console.WriteLine(reader_Credit.GetValue(0));
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    List_Temp.Add(reader_EcritureNum["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return List_Temp;
        }

        public List<String> JournalCode_Debit_Credit()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_JournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_JournalCode.Read())
            {
                SQLiteDataReader reader_Debit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader reader_Credit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "')", dbConnection).ExecuteReader();
                while (reader_Debit.Read() && reader_Credit.Read())
                {
                    debit += Convert.ToDouble(reader_Debit.GetValue(0));
                    // Console.WriteLine(debit);
                    credit += Convert.ToDouble(reader_Credit.GetValue(0));
                    //Console.WriteLine(reader_Credit.GetValue(0));
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    List_Temp.Add(reader_JournalCode["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return List_Temp;
        }

        public bool AllLines_Debit_Credit()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;
            SQLiteDataReader reader_Debit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' ", dbConnection).ExecuteReader();
            SQLiteDataReader reader_Credit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
            while (reader_Debit.Read() && reader_Credit.Read())
            {
                debit += Convert.ToDouble(reader_Debit.GetValue(0));
                // Console.WriteLine(debit);
                credit += Convert.ToDouble(reader_Credit.GetValue(0));
                //Console.WriteLine(reader_Credit.GetValue(0));
            }
            if (Math.Round(debit - credit, 4) != 0)
            {
                //Console.WriteLine(debit - credit);
                check = true;
            }
            return check;
        }

        public bool AllLines_Montant_Sens()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;
            SQLiteDataReader reader_Montant = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='11' ", dbConnection).ExecuteReader();
            SQLiteDataReader reader_Sens = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
            while (reader_Montant.Read() && reader_Sens.Read())
            {
                if (reader_Sens.GetValue(0).ToString().Equals("D"))
                {
                    debit += Convert.ToDouble(reader_Montant.GetValue(0));
                }
                else if (reader_Sens.GetValue(0).ToString().Equals("C"))
                {
                    credit += Convert.ToDouble(reader_Montant.GetValue(0));
                }
                else if (reader_Sens.GetValue(0).ToString().Equals("+1"))
                {
                    debit += Convert.ToDouble(reader_Montant.GetValue(0));
                }
                else if (reader_Sens.GetValue(0).ToString().Equals("-1"))
                {
                    credit += Convert.ToDouble(reader_Montant.GetValue(0));
                }
            }
            if (Math.Round(debit - credit, 4) != 0)
            {
                check = true;
            }
            return check;
        }

        public List<String> JournalCode_Montant_Sens()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_JournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_JournalCode.Read())
            {
                SQLiteDataReader reader_Montant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader reader_Sens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
                while (reader_Montant.Read() && reader_Sens.Read())
                {
                    if (reader_Sens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    List_Temp.Add(reader_JournalCode["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return List_Temp;
        }

        public List<String> EcritureNum_Montant_Sens()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_EcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_EcritureNum.Read())
            {
                SQLiteDataReader reader_Montant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + reader_EcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader reader_Sens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
                while (reader_Montant.Read() && reader_Sens.Read())
                {
                    if (reader_Sens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }
                    else if (reader_Sens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(reader_Montant.GetValue(0));
                    }

                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    List_Temp.Add(reader_EcritureNum["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return List_Temp;
        }

        public bool Is_Montant_Sens()
        {
            SQLiteDataReader reader_ColumnName = new SQLiteCommand("SELECT DISTINCT Name FROM Column", dbConnection).ExecuteReader();
            while (reader_ColumnName.Read())
            {
                if (reader_ColumnName.GetValue(0).ToString().Equals("Montant"))
                {
                    return true;
                }
            }
            return false;
        }

        public List<String> Compare_Montant_Sens_By_Month()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_JournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_JournalCode.Read())
            {
                SQLiteDataReader reader_Ecriture_Date = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "')", dbConnection).ExecuteReader();
                String month = "";
                while (reader_Ecriture_Date.Read())
                {
                    if (reader_Ecriture_Date.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader reader_Montant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader reader_Sens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();

                        while (reader_Montant.Read() && reader_Sens.Read())
                        {
                            if (reader_Sens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }

                        }
                    }
                    else
                    {
                        if (Math.Round(debit - credit, 4) != 0)
                        {
                            List_Temp.Add("Journal : " + reader_JournalCode["Content"].ToString() + " Date : " + month);
                        }
                        debit = 0.0;
                        credit = 0.0;
                        month = reader_Ecriture_Date.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader reader_Montant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader reader_Sens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();

                        while (reader_Montant.Read() && reader_Sens.Read())
                        {
                            if (reader_Sens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                            else if (reader_Sens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(reader_Montant.GetValue(0));
                            }
                        }
                    }    
                }
                if (Math.Round(debit - credit, 4) != 0)
                    {
                        List_Temp.Add("Journal : " + reader_JournalCode["Content"].ToString() + " Date : " + month);
                    }
            }
            return List_Temp;
        }

        public List<String> Compare_Debit_Credit_By_Month()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_JournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_JournalCode.Read())
            {
                SQLiteDataReader reader_Ecriture_Date = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "')", dbConnection).ExecuteReader();
                String month = "";
                while (reader_Ecriture_Date.Read())
                {
                    //Console.WriteLine("Reader : "+ reader_Ecriture_Date.GetValue(0).ToString());
                    //Console.WriteLine("Month : " + month);
                    if (reader_Ecriture_Date.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader reader_Debit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader reader_Credit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();

                        while (reader_Debit.Read() && reader_Credit.Read())
                        {
                            debit += Convert.ToDouble(reader_Debit.GetValue(0));
                            Console.WriteLine("Debit : "+debit);
                            credit += Convert.ToDouble(reader_Credit.GetValue(0));
                            Console.WriteLine("Credit : "+credit);

                        }
                    }
                    else
                    {
                        //Console.WriteLine("Debit - Credit : " + Math.Round(debit - credit, 4));
                        if (Math.Round(debit - credit, 4) != 0)
                        {
                            List_Temp.Add("Journal : " + reader_JournalCode["Content"].ToString() + " Date : " + month);
                        }
                        debit = 0.0;
                        credit = 0.0;
                        month = reader_Ecriture_Date.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader reader_Debit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader reader_Credit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + reader_JournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + reader_Ecriture_Date["Content"] + "'))", dbConnection).ExecuteReader();

                        while (reader_Debit.Read() && reader_Credit.Read())
                        {
                            debit += Convert.ToDouble(reader_Debit.GetValue(0));
                            // Console.WriteLine(debit);
                            credit += Convert.ToDouble(reader_Credit.GetValue(0));
                            //Console.WriteLine(reader_Credit.GetValue(0));

                        }
                    }
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    List_Temp.Add("Journal : " + reader_JournalCode["Content"].ToString() + " Date : " + month);
                }
            }
            return List_Temp;
        }

        public List<String> Is_Date_Unique_For_EcritureNum()
        {
            List<String> List_Temp = new List<string>();
            SQLiteDataReader reader_EcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (reader_EcritureNum.Read())
            {
                int count = 0;
                SQLiteDataReader reader_Ecriture_Date = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='2' and content='" + reader_EcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                while (reader_Ecriture_Date.Read())
                {
                    count++;
                }
                if (count > 1)
                {
                    List_Temp.Add("EcritureNum : " + reader_EcritureNum["Content"].ToString());
                }
            }
            return List_Temp;
        }
    }
}
