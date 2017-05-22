﻿using AnalyseEtControleFEC.Controller;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"c:\";
            openFile.Filter = "text files (*.txt)|*.txt";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = false;
            /*if the user hasn't chosen a file, he can't click other button*/
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                filePath = openFile.FileName;
                textBox2.Text = openFile.SafeFileName;
                fileName = openFile.SafeFileName;
                button2.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            MainController.Get().OpenFile(filePath,fileName);
            LogHelper.file = fileName;
=======
            MainController.get().openFile(filePath,fileName);
            this.DialogResult = DialogResult.OK;        
>>>>>>> origin/Interface-Feature
            this.Dispose();

        }

        //This fonction is used to get the address of the file SQLite 
        public string getConnection()
        {
            return textBox1.Text;
        }

        private void OpenFile_Load(object sender, EventArgs e)
        {

        }
    }
}
