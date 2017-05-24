using System;
using System.Windows.Forms;
using System.IO;

namespace AnalyseEtControleFEC
{
    /// <summary>
    /// Manage csv exportation
    /// </summary>
    class ExportFile
    {
        /// <summary>
        /// This function is used to export the table as a .csv file
        /// </summary>
        /// <param name="dgv"></param>
        public void ExportToCsv(DataGridView dgv)
        {
            string delimiter = ",";
            string filename = "csv.csv";

            // The position of the file
            string fullFilename = Path.Combine(@".\CSV", filename);

            StreamWriter csvStreamWriter = new StreamWriter(fullFilename, false, System.Text.Encoding.UTF8);

            // Output header data
            string strHeader = "";

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                strHeader += dgv.Columns[i].HeaderText + delimiter;
            }
            csvStreamWriter.WriteLine(strHeader);

            // Output rows data
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
