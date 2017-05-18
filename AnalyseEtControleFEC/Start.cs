using AnalyseEtControleFEC.Controller;
using ProCol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AnalyseEtControleFEC
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Visible = false;
            panel13.Visible = false;
            panel15.Visible = false;
            panel17.Visible = false;
            panel19.Visible = false;
            panel21.Visible = false;
            panel23.Visible = false;
            panel1.BringToFront();
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            dataGridView1.MultiSelect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void analyserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MainController.get().analyzeData();
        }

        private void ouvrirFECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile openFile = new OpenFile();
            openFile.ShowDialog();
            //this.Hide();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sauvegarderLeFiltreSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SauFormFiltreSimple formFiltreSimple = new SauFormFiltreSimple();
            formFiltreSimple.ShowDialog();
        }

        private void sauvegarderLeFiltreÉlaboréToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            MainController controller = MainController.get();
            if(sender is DataGridViewBDD)
            {
                e.Value = controller.dataBaseController.getContentFromFilter(e.ColumnIndex, e.RowIndex+1, ((DataGridViewBDD)sender).numGridView);
            }
            else
            {
                e.Value = controller.dataBaseController.getContent(e.ColumnIndex, e.RowIndex+1);
            }       
        }

        internal DataGridView getDataGridView()
        {
            return dataGridView1;
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panel1.Visible = false;
            field1ComboBox.Items.Clear();
            field2ComboBox.Items.Clear();
            field3ComboBox.Items.Clear();
            field4ComboBox.Items.Clear();
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                field1ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field2ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field3ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field4ComboBox.Items.Add(dataGridView1.Columns[i].Name);
            }
            if (treeView1.SelectedNode.Text == "Simple")
            {
                panel1.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Par Ligne")
            {
                panel2.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Par Colonne")
            {
                panel23.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Élaboré")
            {
                panel6.Visible = true;
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Simple")
            {
                panel1.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Par Ligne")
            {
                panel2.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Par Colonne")
            {
                panel23.Visible = true;
            }
            if (treeView1.SelectedNode.Text == "Élaboré")
            {
                panel6.Visible = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field1ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field1ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
                field1ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field1ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition1ComboBox.Items.Clear();
                condition1ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition1ComboBox.SelectedItem = condition1ComboBox.Items[0];
            }
            else
            {
                condition1ComboBox.Items.Clear();
                condition1ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition1ComboBox.SelectedItem = condition1ComboBox.Items[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportFile exportFile = new ExportFile();
            //exportFile.ExportDataGridviewToWord(dataGridView1, true);
            //exportFile.ExportDataGridviewToExcel(dataGridView1, true);
            exportFile.ExportToCsv(dataGridView1);
        }

        private void field2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field2ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field2ComboBox.SelectedItem.ToString().ToUpper().Contains("NUM") ||
                field2ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field2ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition2ComboBox.Items.Clear();
                condition2ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition2ComboBox.SelectedItem = condition2ComboBox.Items[0];
            }
            else
            {
                condition2ComboBox.Items.Clear();
                condition2ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition2ComboBox.SelectedItem = condition2ComboBox.Items[0];
            }
        }

        private void field3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field3ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field3ComboBox.SelectedItem.ToString().ToUpper().Contains("NUM") ||
                field3ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field3ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition3ComboBox.Items.Clear();
                condition3ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition3ComboBox.SelectedItem = condition3ComboBox.Items[0];
            }
            else
            {
                condition3ComboBox.Items.Clear();
                condition3ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition3ComboBox.SelectedItem = condition3ComboBox.Items[0];
            }
        }

        private void field4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field4ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field4ComboBox.SelectedItem.ToString().ToUpper().Contains("NUM") ||
                field4ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field4ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition4ComboBox.Items.Clear();
                condition4ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition4ComboBox.SelectedItem = condition4ComboBox.Items[0];
            }
            else
            {
                condition4ComboBox.Items.Clear();
                condition4ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition4ComboBox.SelectedItem = condition4ComboBox.Items[0];
            }
        }

        private void addFilter(int lastTabId, bool isOr, String field, String condition, String value)
        {
            MainController controller = MainController.get();
            string finalWhereClause = "";
            if (field.ToUpper().Contains("DATE") || field.ToUpper().Contains("MONTANT") ||
                field.ToUpper().Contains("DEBIT") || field.ToUpper().Contains("CREDIT"))
            {
                finalWhereClause = controller.simpleFilterController.NumericOrDateSimpleFilter(field, condition, value);
            }
            else
            {
                finalWhereClause = controller.simpleFilterController.TextSimpleFilter(field, condition, value);
            }
            if (isOr)
            {
                controller.dataBaseController.AddFilterOr(finalWhereClause, lastTabId);
            }
            else
            {
                controller.dataBaseController.AddFilterAdd(finalWhereClause, lastTabId);
            }
        }

        private void reinitializeFilterForm()
        {
            andRadioButton1.Checked = false;
            orRadioButton1.Checked = false;
            andRadioButton2.Checked = false;
            orRadioButton2.Checked = false;
            andRadioButton3.Checked = false;
            orRadioButton3.Checked = false;
            field1ComboBox.Text = "";
            condition1ComboBox.Text = "";
            value1TextBox.Text = "";
            field2ComboBox.Text = "";
            condition2ComboBox.Text = "";
            value2TextBox.Text = "";
            field3ComboBox.Text = "";
            condition3ComboBox.Text = "";
            value3TextBox.Text = "";
            field4ComboBox.Text = "";
            condition4ComboBox.Text = "";
            value4TextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainController controller = MainController.get();
            DataGridView lastTabView = (DataGridView)tabControl1.SelectedTab.Controls[0];
            int filterIdOfLastTab;
            if (lastTabView is DataGridViewBDD)
            {
                filterIdOfLastTab = ((DataGridViewBDD)tabControl1.SelectedTab.Controls[0]).numGridView;
            }
            else
            {
                filterIdOfLastTab = -1;
            }
            addFilter(filterIdOfLastTab, false, field1ComboBox.SelectedItem.ToString(), condition1ComboBox.SelectedItem.ToString(), value1TextBox.Text);
            if (andRadioButton1.Checked)
            {
                addFilter(controller.getDataBaseController().getLastFilterId(), false, field2ComboBox.SelectedItem.ToString(), condition2ComboBox.SelectedItem.ToString(), value2TextBox.Text);
            }
            else if (orRadioButton1.Checked)
            {
                addFilter(filterIdOfLastTab, true, field2ComboBox.SelectedItem.ToString(), condition2ComboBox.SelectedItem.ToString(), value2TextBox.Text);
            }
            if (andRadioButton2.Checked)
            {
                addFilter(controller.getDataBaseController().getLastFilterId(), false, field3ComboBox.SelectedItem.ToString(), condition3ComboBox.SelectedItem.ToString(), value3TextBox.Text);
            }
            else if (orRadioButton2.Checked)
            {
                addFilter(filterIdOfLastTab, true, field3ComboBox.SelectedItem.ToString(), condition3ComboBox.SelectedItem.ToString(), value3TextBox.Text);
            }
            if (andRadioButton3.Checked)
            {
                addFilter(controller.getDataBaseController().getLastFilterId(), false, field4ComboBox.SelectedItem.ToString(), condition4ComboBox.SelectedItem.ToString(), value4TextBox.Text);
            }
            else if (orRadioButton3.Checked)
            {
                addFilter(filterIdOfLastTab, true, field4ComboBox.SelectedItem.ToString(), condition4ComboBox.SelectedItem.ToString(), value4TextBox.Text);
            }
            reinitializeFilterForm();
            string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            DataGridViewBDD newDataGridView = new DataGridViewBDD(controller.getDataBaseController().getLastFilterId());
            newDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            newDataGridView.Size = dataGridView1.Size;
            MainController.get().openFilter(newDataGridView, newDataGridView.numGridView);
            myTabPage.Controls.Add(newDataGridView);
            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
            panel1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel23.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Journal")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Dans le Journal");
                comboBox2.Items.Add("Dans un Journal différent de");
            }
            if (comboBox1.Text == "CompteNum")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Contenant au moins une ligne dont le numéro de compte commence par");
                comboBox2.Items.Add("Ne contenant aucune ligne dont le numéro de compte commence par");
                comboBox2.Items.Add("Contenant au moins une ligne avec un montant non nul au débit dont le numéro de compte commence par");
                comboBox2.Items.Add("Contenant au moins une ligne avec un montant non nul au crédit dont le numéro de compte commence par");
            }
            if (comboBox1.Text == "Montant")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Contenant une ligne de produit dont le montant est supérieur à");
                comboBox2.Items.Add("Contenant une ligne de charge dont le montant est inférieur à");
                comboBox2.Items.Add("Contenant une ligne de TVA collectée dont le montant est supérieur à");
                comboBox2.Items.Add("Contenant une ligne de TVA déductible dont le montant est supérieur à");
                comboBox2.Items.Add("Contenant une ligne de TVA collectée dont le montant est inférieur à");
                comboBox2.Items.Add("Contenant une ligne de TVA déductible dont le montant est inférieur à");
            }
            if (comboBox1.Text == "EcritureDate")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Dont la date d’écriture est antérieure au");
                comboBox2.Items.Add("Dont la date d’écriture est postérieure au");
                comboBox2.Items.Add("Toutes les écritures en date du mois de");

            }
            if (comboBox1.Text == "PieceDate")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Dont la date de la pièce est antérieure au");
                comboBox2.Items.Add("Dont la date de la pièce est postérieure au");
                comboBox2.Items.Add("Toutes les pièces en date du mois de");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ( panel19.Visible == true && panel21.Visible == false)
            {
                panel21.Visible = true;
                textBox10.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel17.Visible == true && panel19.Visible == false)
            {
                panel19.Visible = true;
                textBox9.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel15.Visible == true && panel17.Visible == false)
            {
                panel17.Visible = true;
                textBox8.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel13.Visible == true && panel15.Visible == false)
            {
                panel15.Visible = true;
                textBox7.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel11.Visible == true && panel13.Visible == false)
            {
                panel13.Visible = true;
                textBox6.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel9.Visible == true && panel11.Visible == false)
            {
                panel11.Visible = true;
                textBox5.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel8.Visible == true && panel9.Visible == false )
            {
                panel9.Visible = true;
                textBox4.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }
            if (panel8.Visible == false)
            {
                panel8.Visible = true;
                textBox3.Text = comboBox1.Text + " " +comboBox2.Text + " " + textBox2.Text;
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel21.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else
            {
                panel19.Visible = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else
            {
                panel17.Visible = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else if (panel17.Visible == true)
            {
                textBox7.Text = textBox8.Text;
                panel17.Visible = false;
            }
            else
            {
                panel15.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else if (panel17.Visible == true)
            {
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                panel17.Visible = false;
            }
            else if (panel15.Visible == true)
            {
                textBox6.Text = textBox7.Text;
                panel15.Visible = false;
            }
            else
            {
                panel13.Visible = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else if (panel17.Visible == true)
            {
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                panel17.Visible = false;
            }
            else if (panel15.Visible == true)
            {
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                panel15.Visible = false;
            }
            else if (panel13.Visible == true)
            {
                textBox5.Text = textBox6.Text;
                panel13.Visible = false;
            }
            else
            {
                panel11.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else if (panel17.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                panel17.Visible = false;
            }
            else if (panel15.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                panel15.Visible = false;
            }
            else if (panel13.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                panel13.Visible = false;
            }
            else if (panel11.Visible == true)
            {
                textBox4.Text = textBox5.Text;
                panel11.Visible = false;
            }
            else
            {
                panel9.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (panel21.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = textBox10.Text;
                panel21.Visible = false;
            }
            else if (panel19.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                panel19.Visible = false;
            }
            else if (panel17.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                panel17.Visible = false;
            }
            else if (panel15.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                panel15.Visible = false;
            }
            else if (panel13.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                panel13.Visible = false;
            }
            else if (panel11.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                panel11.Visible = false;
            }
            else if (panel9.Visible == true)
            {
                textBox3.Text = textBox4.Text;
                panel9.Visible = false;
            }
            else
            {
                panel8.Visible = false;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox10.Text;
            textBox10.Text = textBox9.Text;
            textBox9.Text = text;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox9.Text;
            textBox9.Text = textBox8.Text;
            textBox8.Text = text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox8.Text;
            textBox8.Text = textBox7.Text;
            textBox7.Text = text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox7.Text;
            textBox7.Text = textBox6.Text;
            textBox6.Text = text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox6.Text;
            textBox6.Text = textBox5.Text;
            textBox5.Text = text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox5.Text;
            textBox5.Text = textBox4.Text;
            textBox4.Text = text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox4.Text;
            textBox4.Text = textBox3.Text;
            textBox3.Text = text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                string text = null;
                text = textBox3.Text;
                textBox3.Text = textBox4.Text;
                textBox4.Text = text;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (panel11.Visible == true)
            {
                string text = null;
                text = textBox4.Text;
                textBox4.Text = textBox5.Text;
                textBox5.Text = text;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (panel13.Visible == true)
            {
                string text = null;
                text = textBox5.Text;
                textBox5.Text = textBox6.Text;
                textBox6.Text = text;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (panel15.Visible == true)
            {
                string text = null;
                text = textBox6.Text;
                textBox6.Text = textBox7.Text;
                textBox7.Text = text;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (panel17.Visible == true)
            {
                string text = null;
                text = textBox7.Text;
                textBox7.Text = textBox8.Text;
                textBox8.Text = text;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (panel19.Visible == true)
            {
                string text = null;
                text = textBox8.Text;
                textBox8.Text = textBox9.Text;
                textBox9.Text = text;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 0)
            {
                List<int> list = new List<int>();
                string result = null;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    result += dataGridView1.SelectedRows[i].Index + 1;
                    if (i < dataGridView1.SelectedRows.Count)
                    {
                        result += ",";
                    }
                }
                if (result != null)
                {
                    string[] array = result.Split(',');
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        list.Add(int.Parse(array[i]));
                    }
                    list.Sort();
                    string text = null;
                    text += Convert.ToString(list[0]);
                    int count = list.Count;
                    if (count > 1)
                    {
                        for (int i = 1; i < count; i++)
                        {
                            if ((list[i - 1] + 1 != list[i]))
                            {
                                if (text.EndsWith("-"))
                                {
                                    text += list[i - 1];
                                }
                                text += "," + list[i];
                            }
                            else if (list[i - 1] + 1 == list[i])
                            {
                                if (!text.EndsWith("-"))
                                {
                                    text += "-";
                                }
                            }
                        }
                        if (text.EndsWith("-"))
                        {
                            text += list[list.Count - 1];
                        }
                    }
                    textBox1.Text = text;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            string text = textBox1.Text;
            if (text != "")
            {
                if (text.Contains(",") || text.Contains("-"))
                {
                    string[] arrayComma = text.Split(',');
                    for (int i = 0; i < arrayComma.Length; i++)
                    {
                        if (!arrayComma[i].Contains("-"))
                        {
                            list.Add(int.Parse(arrayComma[i]) - 1);
                        }
                    }
                    for (int i = 0; i < arrayComma.Length; i++)
                    {
                        if (arrayComma[i].Contains("-"))
                        {
                            string[] arrayHyphen = arrayComma[i].Split('-');
                            int first = int.Parse(arrayHyphen[0]);
                            int last = int.Parse(arrayHyphen[1]);
                            for (int j = first; j <= last; j++)
                            {
                                list.Add(j - 1);
                            }
                        }
                    }
                }
                else
                {
                    list.Add(int.Parse(text) - 1);
                }
                list.Sort();
                int count = list.Count;
                DataGridView newDataGridView = new DataGridView();
                newDataGridView.Size = dataGridView1.Size;
                newDataGridView.ColumnCount = dataGridView1.ColumnCount;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    newDataGridView.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText;
                    for (int j = 0; j < count; j++)
                    {
                        newDataGridView.Rows.Add();
                        newDataGridView.Rows[j].Cells[i].Value = dataGridView1.Rows[list[j]].Cells[i].Value;
                    }
                }
                string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Controls.Add(newDataGridView);
                tabControl1.TabPages.Add(myTabPage);
                tabControl1.SelectedTab = myTabPage;
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            string text = textBox11.Text;
            if (text != "")
            {
                if (text.Contains(",") || text.Contains("-"))
                {
                    string[] arrayComma = text.Split(',');
                    for (int i = 0; i < arrayComma.Length; i++)
                    {
                        if (!arrayComma[i].Contains("-"))
                        {
                            list.Add(int.Parse(arrayComma[i]) - 1);
                        }
                    }
                    for (int i = 0; (i < arrayComma.Length); i++)
                    {
                        if (arrayComma[i].Contains("-"))
                        {
                            string[] arrayHyphen = arrayComma[i].Split('-');
                            int first = int.Parse(arrayHyphen[0]);
                            int last = int.Parse(arrayHyphen[1]);
                            for (int j = first; j <= last && j <= dataGridView1.ColumnCount; j++)
                            {
                                list.Add(j - 1);
                            }
                        }
                    }
                }
                else
                {
                    list.Add(int.Parse(text) - 1);
                }
                list.Sort();
                DataGridView newDataGridView = new DataGridView();
                newDataGridView.Size = dataGridView1.Size;
                newDataGridView.RowCount = dataGridView1.RowCount;
                newDataGridView.ColumnCount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    newDataGridView.Columns[i].HeaderText = dataGridView1.Columns[list[i]].HeaderText;
                    for (int j = 0; j < newDataGridView.RowCount; j++)
                    {
                        newDataGridView.Rows[j].Cells[i].Value = dataGridView1.Rows[j].Cells[list[i]].Value;
                    }
                }
                string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Controls.Add(newDataGridView);
                tabControl1.TabPages.Add(myTabPage);
                tabControl1.SelectedTab = myTabPage;
            }
        }
    }
}
