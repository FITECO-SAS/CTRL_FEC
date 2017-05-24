using System;
using System.Windows.Forms;
using System.IO;

namespace AnalyseEtControleFEC
{
    class ExportFile
    {
        /// <summary>
        /// this function is used to export the table as a .csv file
        /// </summary>
        /// <param name="dgv"></param>
        public void ExportToCsv(DataGridView dgv)
        {
            string delimiter = ",";
            string filename = "csv.csv";

            /*the position of the file*/
            string fullFilename = Path.Combine(@"G:\", filename);

            StreamWriter csvStreamWriter = new StreamWriter(fullFilename, false, System.Text.Encoding.UTF8);

            //output header data
            string strHeader = "";

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                strHeader += dgv.Columns[i].HeaderText + delimiter;
            }
            csvStreamWriter.WriteLine(strHeader);

            //output rows data
            for (int j = 0; j < dgv.Rows.Count; j++)
            {
                string strRowValue = "";

                for (int k = 0; k < dgv.Columns.Count; k++)
                {
                    strRowValue += dgv.Rows[j].Cells[k].Value + delimiter;

                }
                csvStreamWriter.WriteLine(strRowValue);
            }

            csvStreamWriter.Close();
        }
    }
}
