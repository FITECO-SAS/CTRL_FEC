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
        public void Init()
        {
            dbConnection.Close();
            dbConnection.Open();
            new SQLiteCommand("DROP TABLE IF EXISTS Column", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("DROP TABLE IF EXISTS Content", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP TABLE Column (Position INT, Name VARCHAR(20))", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE TEMP TABLE Content (Line INT, Column INT, Content VARCHAR(100))", dbConnection).ExecuteNonQuery();
            new SQLiteCommand("CREATE INDEX AccessIndexContent ON Content (Column,Line)", dbConnection).ExecuteNonQuery();
            SQLiteFunction.RegisterFunction(typeof(IsStrictlySuperiorSQLiteFunction));
            SQLiteFunction.RegisterFunction(typeof(IsSuperiorSQLiteFunction));
            SQLiteFunction.RegisterFunction(typeof(IsEqualSQLiteFunction));
            FilterNumber = 0;
            //dbConnection.Close();
        }

        internal object GetContentFromFilter(int column, int line, int filterNumber)
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
        public List<int> FillDatabaseFromFile(String filePath)
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
            fs.Close();
            return errors;
            //dbConnection.Close();
        }

        /// <summary>
        /// Getter for Columns names in the dataBase
        /// </summary>
        /// <returns>A String array containing the columns names in the database in the same order as in the file</returns>
        public String[] GetColumnNames()
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
        public String[] GetLine(int line)
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

        public String GetContent(int column, int line)
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
            FilterNumber++;
        }

        /// <summary>
        /// Delete temporary tables created for the last final filter
        /// </summary>
        /// <param name="numberOfTables">number of tables created for the last filter (including the final one)</param>
        public void CleanTempTables(int numberOfTables)
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
                new SQLiteCommand("DROP Table Filter"+(FilterNumber-1), dbConnection).ExecuteNonQuery();
            }
        }

        internal int GetLastFilterId()
        {
            return FilterNumber-1;
        }

        public String[][] GetAllLines()
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
        public int GetNumberOfLines()
        {
            //dbConnection.Open();
            int result = Convert.ToInt32(new SQLiteCommand("SELECT count(*) FROM Content GROUP BY Column", dbConnection).ExecuteScalar());
            //dbConnection.Close();
            return result;
        }

        public int GetNumberOfLinesInFilter(int FilterNumber)
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
        public List<int> CheckRegexColumn(int column, String regex)
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

        /// <summary>
        /// Compare the consistency between the CompAuxNum and CompAuxLib columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentCompAuxNumCompAuxLib()
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

        /// <summary>
        /// Compare the consistency between the EcritureLet and DateLet columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentEcritureLetDateLet()
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

        /// <summary>
        /// Compare the consistency between the Montantdevise and Idevise columns
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentMontantdeviseIdevise()
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

        /// <summary>
        /// Research if PieceDate column is not upper than ValidDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentPieceDateValidDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int pieceDate = 0;
            int validDate = 0;
            // dbConnection.Open();
            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader readerValidDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (readerPieceDate.Read() && readerValidDate.Read())
            {
                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    pieceDate = 0;
                }
                else
                {
                    pieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
                }

                if (readerValidDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(readerValidDate.GetValue(0));
                }
                if (pieceDate <= validDate || pieceDate == 0 || validDate == 0)
                {
                    boolien = true;
                }
                else
                {
                    boolien = false;
                }
                if (!boolien)
                {
                    Line.Add(Convert.ToInt32(readerPieceDate.GetValue(1)));
                }
            }
            return Line;
        }

        /// <summary>
        /// Research if PieceDate column is not upper than EcritureDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentPieceDateEcritureDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int PieceDate = 0;
            int ecritureDate = 0;
            // dbConnection.Open();
            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerEcritureDate.Read() && readerPieceDate.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }

                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    PieceDate = 0;
                }
                else
                {
                    PieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
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
                    Line.Add(Convert.ToInt32(readerEcritureDate.GetValue(1)));
                }
            }
            return Line;
        }

        /// <summary>
        /// Research if EcritureDate column is not upper than ValidDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentEcritureDateValidDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int ecritureDate = 0;
            int validDate = 0;
            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader readerValidDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='15' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerEcritureDate.Read() && readerValidDate.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }
                if (readerValidDate.GetValue(0).ToString().Equals(""))
                {
                    validDate = 0;
                }
                else
                {
                    validDate = Convert.ToInt32(readerValidDate.GetValue(0));
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
                    Line.Add(Convert.ToInt32(readerValidDate.GetValue(1)));
                }
            }
            return Line;
        }

        /// <summary>
        /// Research if DateLet column is not lower than PieceDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentDateLetPieceDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int PieceDate = 0;
            int DateLet = 0;
            SQLiteDataReader readerPieceDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='9' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader readerDateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerPieceDate.Read() && readerDateLet.Read())
            {
                if (readerPieceDate.GetValue(0).ToString().Equals(""))
                {
                    PieceDate = 0;
                }
                else
                {
                    PieceDate = Convert.ToInt32(readerPieceDate.GetValue(0));
                }

                if (readerDateLet.GetValue(0).ToString().Equals(""))
                {
                    DateLet = 0;
                }
                else
                {
                    DateLet = Convert.ToInt32(readerDateLet.GetValue(0));
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
                    Line.Add(Convert.ToInt32(readerPieceDate.GetValue(1)));
                }
            }
            return Line;
        }

        /// <summary>
        /// Research if DateLet column is not lower than EcritureDate column
        /// </summary>
        /// <returns>The list of rows where there are errors</returns>
        public List<int> CompareContentDateLetEcritureDate()
        {
            bool boolien = false;
            List<int> Line = new List<int>();
            int ecritureDate = 0;
            int DateLet = 0;
            // dbConnection.Open();
            SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='3' ORDER BY Column ASC", dbConnection).ExecuteReader();
            SQLiteDataReader readerDateLet = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='14' ORDER BY Column ASC", dbConnection).ExecuteReader();

            while (readerEcritureDate.Read() && readerDateLet.Read())
            {
                if (readerEcritureDate.GetValue(0).ToString().Equals(""))
                {
                    ecritureDate = 0;
                }
                else
                {
                    ecritureDate = Convert.ToInt32(readerEcritureDate.GetValue(0));
                }

                if (readerDateLet.GetValue(0).ToString().Equals(""))
                {
                    DateLet = 0;
                }
                else
                {
                    DateLet = Convert.ToInt32(readerDateLet.GetValue(0));
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
                    Line.Add(Convert.ToInt32(readerDateLet.GetValue(1)));
                }
            }
            return Line;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value
        /// </summary>
        /// <returns>The list of EcritureNum where there are errors</returns>
        public List<String> EcritureNumDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerEcritureNum.Read())
            {
                SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                while (readerDebit.Read() && readerCredit.Read())
                {
                    debit += Convert.ToDouble(readerDebit.GetValue(0));
                    // Console.WriteLine(debit);
                    credit += Convert.ToDouble(readerCredit.GetValue(0));
                    //Console.WriteLine(reader_Credit.GetValue(0));
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    ListTemp.Add(readerEcritureNum["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value
        /// </summary>
        /// <returns>The list of JournalCode where there are errors</returns>
        public List<String> JournalCodeDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", dbConnection).ExecuteReader();
                while (readerDebit.Read() && readerCredit.Read())
                {
                    debit += Convert.ToDouble(readerDebit.GetValue(0));
                    // Console.WriteLine(debit);
                    credit += Convert.ToDouble(readerCredit.GetValue(0));
                    //Console.WriteLine(reader_Credit.GetValue(0));
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    ListTemp.Add(readerJournalCode["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column on the entire file
        /// </summary>
        /// <returns>True if the sum of Debit and Credit are not different</returns>
        public bool AllLinesDebitCredit()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;
            SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' ", dbConnection).ExecuteReader();
            SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
            while (readerDebit.Read() && readerCredit.Read())
            {
                debit += Convert.ToDouble(readerDebit.GetValue(0));
                // Console.WriteLine(debit);
                credit += Convert.ToDouble(readerCredit.GetValue(0));
                //Console.WriteLine(reader_Credit.GetValue(0));
            }
            if (Math.Round(debit - credit, 4) != 0)
            {
                //Console.WriteLine(debit - credit);
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column on the entire file (in a Montant-Sens file)
        /// </summary>
        /// <returns>True if the sum of Debit and Credit are not different</returns>
        public bool AllLinesMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;
            bool check = false;
            SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='11' ", dbConnection).ExecuteReader();
            SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content,Line FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
            while (readerMontant.Read() && readerSens.Read())
            {
                if (readerSens.GetValue(0).ToString().Equals("D"))
                {
                    debit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("C"))
                {
                    credit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("+1"))
                {
                    debit += Convert.ToDouble(readerMontant.GetValue(0));
                }
                else if (readerSens.GetValue(0).ToString().Equals("-1"))
                {
                    credit += Convert.ToDouble(readerMontant.GetValue(0));
                }
            }
            if (Math.Round(debit - credit, 4) != 0)
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific JournalCode value (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of JournalCode where there are errors</returns>
        public List<String> JournalCodeMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
                while (readerMontant.Read() && readerSens.Read())
                {
                    if (readerSens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    ListTemp.Add(readerJournalCode["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific EcritureNum value (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of EcritureNum where there are errors</returns>
        public List<String> EcritureNumMontantSens()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerEcritureNum.Read())
            {
                SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' ", dbConnection).ExecuteReader();
                while (readerMontant.Read() && readerSens.Read())
                {
                    if (readerSens.GetValue(0).ToString().Equals("D"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("C"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("+1"))
                    {
                        debit += Convert.ToDouble(readerMontant.GetValue(0));
                    }
                    else if (readerSens.GetValue(0).ToString().Equals("-1"))
                    {
                        credit += Convert.ToDouble(readerMontant.GetValue(0));
                    }

                }

                if (Math.Round(debit - credit, 4) != 0)
                {
                    //Console.WriteLine(debit - credit);
                    ListTemp.Add(readerEcritureNum["Content"].ToString());
                }
                debit = 0;
                credit = 0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the file is a Montant-Sens file
        /// </summary>
        /// <returns>True if the file is a Montant-Sens file</returns>
        public bool IsMontantSens()
        {
            SQLiteDataReader readerColumnName = new SQLiteCommand("SELECT DISTINCT Name FROM Column", dbConnection).ExecuteReader();
            while (readerColumnName.Read())
            {
                if (readerColumnName.GetValue(0).ToString().Equals("Montant"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode (in a Montant-Sens file)
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> CompareMontantSensByMonth()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", dbConnection).ExecuteReader();
                String month = "";
                while (readerEcritureDate.Read())
                {
                    if (readerEcritureDate.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();

                        while (readerMontant.Read() && readerSens.Read())
                        {
                            if (readerSens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }

                        }
                    }
                    else
                    {
                        if (Math.Round(debit - credit, 4) != 0)
                        {
                            ListTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                        }
                        debit = 0.0;
                        credit = 0.0;
                        month = readerEcritureDate.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader readerMontant = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader readerSens = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();

                        while (readerMontant.Read() && readerSens.Read())
                        {
                            if (readerSens.GetValue(0).ToString().Equals("D"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("C"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("+1"))
                            {
                                debit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                            else if (readerSens.GetValue(0).ToString().Equals("-1"))
                            {
                                credit += Convert.ToDouble(readerMontant.GetValue(0));
                            }
                        }
                    }    
                }
                if (Math.Round(debit - credit, 4) != 0)
                    {
                    ListTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                }
                debit = 0.0;
                credit = 0.0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the sum of the Debit column is equal to the sum the Credit column for a specific Month value for each JournalCode
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> CompareDebitCreditByMonth()
        {
            double debit = 0.0;
            double credit = 0.0;
            List<String> ListTemp = new List<string>();
            SQLiteDataReader readerJournalCode = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='0' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerJournalCode.Read())
            {
                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "')", dbConnection).ExecuteReader();
                String month = "";
                while (readerEcritureDate.Read())
                {
                    //Console.WriteLine("Reader : "+ reader_Ecriture_Date.GetValue(0).ToString());
                    //Console.WriteLine("Month : " + month);
                    if (readerEcritureDate.GetValue(0).ToString().Substring(0, 6).Equals(month))
                    {
                        SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();

                        while (readerDebit.Read() && readerCredit.Read())
                        {
                            debit += Convert.ToDouble(readerDebit.GetValue(0));
                            //Console.WriteLine("Debit : "+debit);
                            credit += Convert.ToDouble(readerCredit.GetValue(0));
                            //Console.WriteLine("Credit : "+credit);

                        }
                    }
                    else
                    {
                        //Console.WriteLine("Debit - Credit : " + Math.Round(debit - credit, 4));
                        if (Math.Round(debit - credit, 4) != 0 && !readerJournalCode["Content"].ToString().Equals(null))
                        {
                            ListTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4, "/"));
                        }
                        debit = 0.0;
                        credit = 0.0;
                        month = readerEcritureDate.GetValue(0).ToString().Substring(0, 6);

                        SQLiteDataReader readerDebit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='11' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();
                        SQLiteDataReader readerCredit = new SQLiteCommand("SELECT Content FROM Content WHERE Column='12' and Line in (SELECT Line from Content where column='0' and content='" + readerJournalCode["Content"] + "' and Line in (SELECT Line from Content where column='3' and content='" + readerEcritureDate["Content"] + "'))", dbConnection).ExecuteReader();

                        while (readerDebit.Read() && readerCredit.Read())
                        {
                            debit += Convert.ToDouble(readerDebit.GetValue(0));
                            // Console.WriteLine(debit);
                            credit += Convert.ToDouble(readerCredit.GetValue(0));
                            //Console.WriteLine(reader_Credit.GetValue(0));

                        }
                    }
                }
                if (Math.Round(debit - credit, 4) != 0)
                {
                    ListTemp.Add(readerJournalCode["Content"].ToString() + "\t Mois : " + month.Insert(4,"/"));
                }
                debit = 0.0;
                credit = 0.0;
            }
            return ListTemp;
        }

        /// <summary>
        /// Research if the EcritureDate value is unique for each JournalCode
        /// </summary>
        /// <returns>The list of JournalCode and Month where there are errors</returns>
        public List<String> IsDateUniqueForEcritureNum()
        {
            List<String> listTemp = new List<string>();
            SQLiteDataReader readerEcritureNum = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='2' ORDER BY Column ASC", dbConnection).ExecuteReader();
            while (readerEcritureNum.Read())
            {
                int count = 0;
                SQLiteDataReader readerEcritureDate = new SQLiteCommand("SELECT DISTINCT Content FROM Content WHERE Column='3' and Line in (SELECT Line from Content where column='2' and content='" + readerEcritureNum["Content"] + "')", dbConnection).ExecuteReader();
                while (readerEcritureDate.Read())
                {
                    count++;
                }
                if (count > 1)
                {
                    listTemp.Add(readerEcritureNum["Content"].ToString());
                }
            }
            return listTemp;
        }
    }
}
