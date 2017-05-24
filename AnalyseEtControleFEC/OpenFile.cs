using AnalyseEtControleFEC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnalyseEtControleFEC
{
    public partial class OpenFile : Form
    {
        private String filePath;
        private String fileName;

        public OpenFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open a txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = @"c:\";
            openFile.Filter = "text files (*.txt)|*.txt";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = false;
            
            // If the user hasn't chosen a file, he can't click other button
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                filePath = openFile.FileName;
                textBox2.Text = openFile.SafeFileName;
                fileName = openFile.SafeFileName;
                button2.Enabled = true;
            }
        }

        /// <summary>
        /// Show the file in the DataGridView and start the controls procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MainController.Get().OpenFile(filePath,fileName);
            LogHelper.file = fileName;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        /// <summary>
        /// Get the address of the SQLite file
        /// </summary>
        /// <returns>The address of the SQLite file</returns>
        public string GetConnection()
        {
            return textBox1.Text;
        }
    }
}
