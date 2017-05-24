using AnalyseEtControleFEC.Controller;
using ProCol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace AnalyseEtControleFEC
{
    public partial class Start : Form
    {
        bool fileLoaded = false;
        bool isLine1OK = false;
        bool isLine2OK = false;
        bool isLine3OK = false;
        bool isLine4OK = false;
        bool isLine5OK = false;
        bool isLine6OK = false;
        bool isLine7OK = false;
        bool isLine8OK = false;

        public Start()
        {
            /*init*/
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
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            label6.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ouvrirFECToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile openFile = new OpenFile();
            openFile.ShowDialog();

            /*if the user has't chosen any file or the table is empty, he can't click other button*/
            if (openFile.DialogResult == DialogResult.OK)
            {
                fileLoaded = true;
                button1.Enabled = true;
                button7.Enabled = true;
            }
        }

        /*After click the item, this application will be closed*/
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            MainController controller = MainController.Get();

            if (sender is DataGridViewBDD)
            {
                e.Value = controller.dataBaseController.GetContentFromFilter(e.ColumnIndex, e.RowIndex + 1, ((DataGridViewBDD)sender).numGridView);
            }
            else
            {
                e.Value = controller.dataBaseController.GetContent(e.ColumnIndex, e.RowIndex + 1);
            }
        }

        internal DataGridView getDataGridView()
        {
            return dataGridView1;
        }

        /*after double click the tab, this tabpages will be closed*/
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
            field5ComboBox.Items.Clear();
            field6ComboBox.Items.Clear();
            field7ComboBox.Items.Clear();
            field8ComboBox.Items.Clear();

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                field1ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field2ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field3ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field4ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field5ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field6ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field7ComboBox.Items.Add(dataGridView1.Columns[i].Name);
                field8ComboBox.Items.Add(dataGridView1.Columns[i].Name);
            }
        }

        /*this is used to update the selected node*/
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            }
        }

        /*after select different node, different panel will show*/
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

        private void button3_Click(object sender, EventArgs e)
        {
            ExportFile exportFile = new ExportFile();
            exportFile.ExportToCsv(dataGridView1);
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

        private void field2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field2ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field2ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
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
            if (field3ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field3ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
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
            if (field4ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field4ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
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

        private void field5ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field5ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field5ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
                field5ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field5ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition5ComboBox.Items.Clear();
                condition5ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition5ComboBox.SelectedItem = condition5ComboBox.Items[0];
            }
            else
            {
                condition5ComboBox.Items.Clear();
                condition5ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition5ComboBox.SelectedItem = condition5ComboBox.Items[0];
            }
        }

        private void field6ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field6ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field6ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
                field6ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field6ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition6ComboBox.Items.Clear();
                condition6ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition6ComboBox.SelectedItem = condition6ComboBox.Items[0];
            }
            else
            {
                condition6ComboBox.Items.Clear();
                condition6ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition6ComboBox.SelectedItem = condition6ComboBox.Items[0];
            }
        }

        private void field7ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field7ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field7ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
                field7ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field7ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition7ComboBox.Items.Clear();
                condition7ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition7ComboBox.SelectedItem = condition7ComboBox.Items[0];
            }
            else
            {
                condition7ComboBox.Items.Clear();
                condition7ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition7ComboBox.SelectedItem = condition7ComboBox.Items[0];
            }
        }

        private void field8ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field8ComboBox.SelectedItem.ToString().ToUpper().Contains("DATE") || field8ComboBox.SelectedItem.ToString().ToUpper().Contains("MONTANT") ||
                field8ComboBox.SelectedItem.ToString().ToUpper().Contains("DEBIT") || field8ComboBox.SelectedItem.ToString().ToUpper().Contains("CREDIT"))
            {
                condition8ComboBox.Items.Clear();
                condition8ComboBox.Items.AddRange(new object[] {"", "Est supérieur à", "Est supérieur ou égal à",
                    "Est inférieur à","Est inférieur ou égal à","Est égal à","Est différent de" });
                condition8ComboBox.SelectedItem = condition8ComboBox.Items[0];
            }
            else
            {
                condition8ComboBox.Items.Clear();
                condition8ComboBox.Items.AddRange(new object[] {"", "Contient", "Ne contient pas","Commence par",
                "Ne commence pas par","Se termine par","Ne se termine pas par","Est égal à","Est différent de" });
                condition8ComboBox.SelectedItem = condition8ComboBox.Items[0];
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
            MainController controller = MainController.Get();
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

            int numberOfFilters = ShowValidLineSimpleFilter();

            Tuple<String, String, String> filter1 = new Tuple<string, string, string>(field1ComboBox.SelectedItem.ToString(), condition1ComboBox.SelectedItem.ToString(), value1TextBox.Text);
            Tuple<bool, String, String, String> filter2 = null;
            Tuple<bool, String, String, String> filter3 = null;
            Tuple<bool, String, String, String> filter4 = null;
            Tuple<bool, String, String, String> filter5 = null;
            Tuple<bool, String, String, String> filter6 = null;
            Tuple<bool, String, String, String> filter7 = null;
            Tuple<bool, String, String, String> filter8 = null;

            if (andRadioButton1.Checked)
            {
                filter2 = new Tuple<bool, string, string, string>(false, field2ComboBox.SelectedItem.ToString(), condition2ComboBox.SelectedItem.ToString(), value2TextBox.Text);
            }
            else if (orRadioButton1.Checked)
            {
                filter2 = new Tuple<bool, string, string, string>(true, field2ComboBox.SelectedItem.ToString(), condition2ComboBox.SelectedItem.ToString(), value2TextBox.Text);
            }

            if (andRadioButton1.Checked || orRadioButton1.Checked)
            {
                if (andRadioButton2.Checked)
                {
                    filter3 = new Tuple<bool, string, string, string>(false, field3ComboBox.SelectedItem.ToString(), condition3ComboBox.SelectedItem.ToString(), value3TextBox.Text);
                }
                else if (orRadioButton2.Checked)
                {
                    filter3 = new Tuple<bool, string, string, string>(true, field3ComboBox.SelectedItem.ToString(), condition3ComboBox.SelectedItem.ToString(), value3TextBox.Text);
                }

                if (andRadioButton2.Checked || orRadioButton2.Checked)
                {
                    if (andRadioButton3.Checked)
                    {
                        filter4 = new Tuple<bool, string, string, string>(false, field4ComboBox.SelectedItem.ToString(), condition4ComboBox.SelectedItem.ToString(), value4TextBox.Text);
                    }
                    else if (orRadioButton3.Checked)
                    {
                        filter4 = new Tuple<bool, string, string, string>(true, field4ComboBox.SelectedItem.ToString(), condition4ComboBox.SelectedItem.ToString(), value4TextBox.Text);
                    }

                    if (andRadioButton3.Checked || orRadioButton3.Checked)
                    {
                        if (andRadioButton4.Checked)
                        {
                            filter5 = new Tuple<bool, string, string, string>(false, field5ComboBox.SelectedItem.ToString(), condition5ComboBox.SelectedItem.ToString(), value5TextBox.Text);
                        }
                        else if (orRadioButton4.Checked)
                        {
                            filter5 = new Tuple<bool, string, string, string>(true, field5ComboBox.SelectedItem.ToString(), condition5ComboBox.SelectedItem.ToString(), value5TextBox.Text);
                        }

                        if (andRadioButton4.Checked || orRadioButton4.Checked)
                        {
                            if (andRadioButton5.Checked)
                            {
                                filter6 = new Tuple<bool, string, string, string>(false, field6ComboBox.SelectedItem.ToString(), condition6ComboBox.SelectedItem.ToString(), value6TextBox.Text);
                            }
                            else if (orRadioButton5.Checked)
                            {
                                filter6 = new Tuple<bool, string, string, string>(true, field6ComboBox.SelectedItem.ToString(), condition6ComboBox.SelectedItem.ToString(), value6TextBox.Text);
                            }

                            if (andRadioButton5.Checked || orRadioButton5.Checked)
                            {
                                if (andRadioButton6.Checked)
                                {
                                    filter7 = new Tuple<bool, string, string, string>(false, field7ComboBox.SelectedItem.ToString(), condition7ComboBox.SelectedItem.ToString(), value7TextBox.Text);
                                }
                                else if (orRadioButton6.Checked)
                                {
                                    filter7 = new Tuple<bool, string, string, string>(true, field7ComboBox.SelectedItem.ToString(), condition7ComboBox.SelectedItem.ToString(), value7TextBox.Text);
                                }

                                if (andRadioButton6.Checked || orRadioButton6.Checked)
                                {
                                    if (andRadioButton7.Checked)
                                    {
                                        filter8 = new Tuple<bool, string, string, string>(false, field8ComboBox.SelectedItem.ToString(), condition8ComboBox.SelectedItem.ToString(), value8TextBox.Text);
                                    }
                                    else if (orRadioButton7.Checked)
                                    {
                                        filter8 = new Tuple<bool, string, string, string>(true, field8ComboBox.SelectedItem.ToString(), condition8ComboBox.SelectedItem.ToString(), value8TextBox.Text);
                                    }
                                }
                            }
                        }
                    }
                }
            }

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
            panel1.Visible = false;
            controller.addFilters(new
                Tuple<int, int,
                    Tuple<String, String, String>,
                    Tuple<Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>,
                    Tuple<bool, String, String, String>>,
                    Start>(filterIdOfLastTab, numberOfFilters, filter1, new Tuple<Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>,
                        Tuple<bool, String, String, String>>(filter2, filter3, filter4, filter5, filter6, filter7, filter8), this));
        }

        /*hide the panel1*/
        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        /*hide the panel2*/
        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        /*to show the line number of the table*/
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /*show the panel7*/
        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        /*hide the panel23*/
        private void button18_Click(object sender, EventArgs e)
        {
            panel23.Visible = false;
        }

        /*display the corresponding item in comboBox2*/
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

        /*this function is used to determine the condition will show in which textBox*/
        private void button8_Click(object sender, EventArgs e)
        {
            if (panel19.Visible == true && panel21.Visible == false)
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

            if (panel8.Visible == true && panel9.Visible == false)
            {
                panel9.Visible = true;
                textBox4.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }

            if (panel8.Visible == false)
            {
                panel8.Visible = true;
                textBox3.Text = comboBox1.Text + " " + comboBox2.Text + " " + textBox2.Text;
            }

        }

        /*this fuction is used to delete a condition*/
        private void button16_Click(object sender, EventArgs e)
        {
            panel21.Visible = false;
        }

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this fuction is used to delete a condition*/
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

        /*this function is used to exchange the positions of two conditions*/
        private void button20_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox10.Text;
            textBox10.Text = textBox9.Text;
            textBox9.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button27_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox9.Text;
            textBox9.Text = textBox8.Text;
            textBox8.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button26_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox8.Text;
            textBox8.Text = textBox7.Text;
            textBox7.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button25_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox7.Text;
            textBox7.Text = textBox6.Text;
            textBox6.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button24_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox6.Text;
            textBox6.Text = textBox5.Text;
            textBox5.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button23_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox5.Text;
            textBox5.Text = textBox4.Text;
            textBox4.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
        private void button22_Click(object sender, EventArgs e)
        {
            string text = null;
            text = textBox4.Text;
            textBox4.Text = textBox3.Text;
            textBox3.Text = text;
        }

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to exchange the positions of two conditions*/
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

        /*this function is used to determine the selected line number*/
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

        /*this function is used to create a new table by the line number*/
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

                for (int i = 0; i < newDataGridView.RowCount; i++)
                {
                    newDataGridView.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
                }

                string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Controls.Add(newDataGridView);
                tabControl1.TabPages.Add(myTabPage);
                tabControl1.SelectedTab = myTabPage;
            }
        }

        /*this function is used to create a new table by the column number*/
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

                for (int i = 0; i < newDataGridView.RowCount; i++)
                {
                    newDataGridView.Rows[i].HeaderCell.Value = String.Format("{0}", i + 1);
                }

                string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
                TabPage myTabPage = new TabPage(title);
                myTabPage.Controls.Add(newDataGridView);
                tabControl1.TabPages.Add(myTabPage);
                tabControl1.SelectedTab = myTabPage;
            }
        }

        /*this function is ussed to add [x] at the tab*/
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        /*this function is used to add an action when the user click the [x]*/
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);

                if (closeButton.Contains(e.Location))
                {
                    this.tabControl1.TabPages.RemoveAt(i);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && fileLoaded == true)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text != "" && fileLoaded == true)
            {
                button17.Enabled = true;
            }
            else
            {
                button17.Enabled = false;
            } 
        }

        private void value1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value1TextBox.Text != "" && field1ComboBox.Text != "" && condition1ComboBox.Text != "")
            {
                isLine1OK = true;

            }
            else
            {
                isLine1OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value2TextBox.Text != "" && field2ComboBox.Text != "" && condition2ComboBox.Text != "" && (andRadioButton1.Checked == true || orRadioButton1.Checked == true))
            {
                isLine2OK = true;
            }
            else
            {
                isLine2OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value3TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value3TextBox.Text != "" && field3ComboBox.Text != "" && condition3ComboBox.Text != "" && (andRadioButton2.Checked == true || orRadioButton2.Checked == true))
            {
                isLine3OK = true;
            }
            else
            {
                isLine3OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value4TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value4TextBox.Text != "" && field4ComboBox.Text != "" && condition4ComboBox.Text != "" && (andRadioButton3.Checked == true || orRadioButton3.Checked == true))
            {
                isLine4OK = true;
            }
            else
            {
                isLine4OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value5TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value5TextBox.Text != "" && field5ComboBox.Text != "" && condition5ComboBox.Text != "" && (andRadioButton4.Checked == true || orRadioButton4.Checked == true))
            {
                isLine5OK = true;
            }
            else
            {
                isLine5OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value6TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value6TextBox.Text != "" && field6ComboBox.Text != "" && condition6ComboBox.Text != "" && (andRadioButton5.Checked == true || orRadioButton5.Checked == true))
            {
                isLine6OK = true;
            }
            else
            {
                isLine6OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value7TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value7TextBox.Text != "" && field7ComboBox.Text != "" && condition7ComboBox.Text != "" && (andRadioButton6.Checked == true || orRadioButton6.Checked == true))
            {
                isLine7OK = true;
            }
            else
            {
                isLine7OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void value8TextBox_TextChanged(object sender, EventArgs e)
        {
            if (value8TextBox.Text != "" && field8ComboBox.Text != "" && condition8ComboBox.Text != "" && (andRadioButton7.Checked == true || orRadioButton7.Checked == true))
            {
                isLine8OK = true;
            }
            else
            {
                isLine8OK = false;
            }

            ShowValidLineSimpleFilter();
        }

        private void buttonDown1_Click(object sender, EventArgs e)
        {
            if (panelLine2.Visible == true && (value1TextBox.Text != "" && field1ComboBox.Text != "" && condition1ComboBox.Text != "") && (value2TextBox.Text != "" && field2ComboBox.Text != "" && condition2ComboBox.Text != "" && (andRadioButton1.Checked == true || orRadioButton1.Checked == true)))
            {
                String text, text1, text2;
                text = value1TextBox.Text;
                value1TextBox.Text = value2TextBox.Text;
                value2TextBox.Text = text;

                text1 = condition1ComboBox.Text;
                text2 = condition2ComboBox.Text;

                text = field1ComboBox.Text;
                field1ComboBox.Text = field2ComboBox.Text;
                field2ComboBox.Text = text;

                condition1ComboBox.Text = text2;
                condition2ComboBox.Text = text1;
            }
        }

        private void buttonDown2_Click(object sender, EventArgs e)
        {
            if (panelLine3.Visible == true && (value2TextBox.Text != "" && field2ComboBox.Text != "" && condition2ComboBox.Text != "" && (andRadioButton1.Checked == true || orRadioButton1.Checked == true)) && (value3TextBox.Text != "" && field3ComboBox.Text != "" && condition3ComboBox.Text != "" && (andRadioButton2.Checked == true || orRadioButton2.Checked == true)))
            {
                String text, text1, text2;
                text = value2TextBox.Text;
                value2TextBox.Text = value3TextBox.Text;
                value3TextBox.Text = text;

                text1 = condition2ComboBox.Text;
                text2 = condition3ComboBox.Text;

                text = field2ComboBox.Text;
                field2ComboBox.Text = field3ComboBox.Text;
                field3ComboBox.Text = text;

                condition2ComboBox.Text = text2;
                condition3ComboBox.Text = text1;

                if (andRadioButton1.Checked == true && orRadioButton2.Checked == true)
                {
                    andRadioButton2.Checked = true;
                    orRadioButton1.Checked = true;
                }
                else if (andRadioButton2.Checked == true && orRadioButton1.Checked == true)
                {
                    andRadioButton1.Checked = true;
                    orRadioButton2.Checked = true;
                }
            }
        }

        private void buttonDown3_Click(object sender, EventArgs e)
        {
            if (panelLine4.Visible == true && (value3TextBox.Text != "" && field3ComboBox.Text != "" && condition3ComboBox.Text != "" && (andRadioButton2.Checked == true || orRadioButton2.Checked == true)) && (value4TextBox.Text != "" && field4ComboBox.Text != "" && condition4ComboBox.Text != "" && (andRadioButton3.Checked == true || orRadioButton3.Checked == true)))
            {
                String text, text1, text2;
                text = value3TextBox.Text;
                value3TextBox.Text = value4TextBox.Text;
                value4TextBox.Text = text;
                text1 = condition3ComboBox.Text;
                text2 = condition4ComboBox.Text;
                text = field3ComboBox.Text;
                field3ComboBox.Text = field4ComboBox.Text;
                field4ComboBox.Text = text;
                condition3ComboBox.Text = text2;
                condition4ComboBox.Text = text1;

                if (andRadioButton2.Checked == true && orRadioButton3.Checked == true)
                {
                    andRadioButton3.Checked = true;
                    orRadioButton2.Checked = true;
                }
                else if (andRadioButton3.Checked == true && orRadioButton2.Checked == true)
                {
                    andRadioButton2.Checked = true;
                    orRadioButton3.Checked = true;
                }
            }
        }

        private void buttonDown4_Click(object sender, EventArgs e)
        {
            if (panelLine5.Visible == true && (value4TextBox.Text != "" && field4ComboBox.Text != "" && condition4ComboBox.Text != "" && (andRadioButton3.Checked == true || orRadioButton3.Checked == true)) && (value5TextBox.Text != "" && field5ComboBox.Text != "" && condition5ComboBox.Text != "" && (andRadioButton4.Checked == true || orRadioButton4.Checked == true)))
            {
                String text, text1, text2;
                text = value4TextBox.Text;
                value4TextBox.Text = value5TextBox.Text;
                value5TextBox.Text = text;
                text1 = condition4ComboBox.Text;
                text2 = condition5ComboBox.Text;
                text = field4ComboBox.Text;
                field4ComboBox.Text = field5ComboBox.Text;
                field5ComboBox.Text = text;
                condition4ComboBox.Text = text2;
                condition5ComboBox.Text = text1;

                if (andRadioButton3.Checked == true && orRadioButton4.Checked == true)
                {
                    andRadioButton4.Checked = true;
                    orRadioButton3.Checked = true;
                }
                else if (andRadioButton4.Checked == true && orRadioButton3.Checked == true)
                {
                    andRadioButton3.Checked = true;
                    orRadioButton4.Checked = true;
                }
            }
        }

        private void buttonDown5_Click(object sender, EventArgs e)
        {
            if (panelLine6.Visible == true && (value5TextBox.Text != "" && field5ComboBox.Text != "" && condition5ComboBox.Text != "" && (andRadioButton4.Checked == true || orRadioButton4.Checked == true)) && (value6TextBox.Text != "" && field6ComboBox.Text != "" && condition6ComboBox.Text != "" && (andRadioButton5.Checked == true || orRadioButton5.Checked == true)))
            {
                String text, text1, text2;
                text = value5TextBox.Text;
                value5TextBox.Text = value6TextBox.Text;
                value6TextBox.Text = text;
                text1 = condition5ComboBox.Text;
                text2 = condition6ComboBox.Text;
                text = field5ComboBox.Text;
                field5ComboBox.Text = field6ComboBox.Text;
                field6ComboBox.Text = text;
                condition5ComboBox.Text = text2;
                condition6ComboBox.Text = text1;

                if (andRadioButton4.Checked == true && orRadioButton5.Checked == true)
                {
                    andRadioButton5.Checked = true;
                    orRadioButton4.Checked = true;
                }
                else if (andRadioButton5.Checked == true && orRadioButton4.Checked == true)
                {
                    andRadioButton4.Checked = true;
                    orRadioButton5.Checked = true;
                }
            }
        }

        private void buttonDown6_Click(object sender, EventArgs e)
        {
            if (panelLine7.Visible == true && (value6TextBox.Text != "" && field6ComboBox.Text != "" && condition6ComboBox.Text != "" && (andRadioButton5.Checked == true || orRadioButton5.Checked == true)) && (value7TextBox.Text != "" && field7ComboBox.Text != "" && condition7ComboBox.Text != "" && (andRadioButton6.Checked == true || orRadioButton6.Checked == true)))
            {
                String text, text1, text2;
                text = value6TextBox.Text;
                value6TextBox.Text = value7TextBox.Text;
                value7TextBox.Text = text;
                text1 = condition6ComboBox.Text;
                text2 = condition7ComboBox.Text;
                text = field6ComboBox.Text;
                field6ComboBox.Text = field7ComboBox.Text;
                field7ComboBox.Text = text;
                condition6ComboBox.Text = text2;
                condition7ComboBox.Text = text1;

                if (andRadioButton5.Checked == true && orRadioButton6.Checked == true)
                {
                    andRadioButton6.Checked = true;
                    orRadioButton5.Checked = true;
                }
                else if (andRadioButton6.Checked == true && orRadioButton5.Checked == true)
                {
                    andRadioButton5.Checked = true;
                    orRadioButton6.Checked = true;
                }

            }
        }

        private void buttonDown7_Click(object sender, EventArgs e)
        {
            if (panelLine8.Visible == true && (value7TextBox.Text != "" && field7ComboBox.Text != "" && condition7ComboBox.Text != "" && (andRadioButton6.Checked == true || orRadioButton6.Checked == true)) && (value8TextBox.Text != "" && field8ComboBox.Text != "" && condition8ComboBox.Text != "" && (andRadioButton7.Checked == true || orRadioButton7.Checked == true)))
            {
                String text, text1, text2;
                text = value7TextBox.Text;
                value7TextBox.Text = value8TextBox.Text;
                value8TextBox.Text = text;
                text1 = condition7ComboBox.Text;
                text2 = condition8ComboBox.Text;
                text = field7ComboBox.Text;
                field7ComboBox.Text = field8ComboBox.Text;
                field8ComboBox.Text = text;
                condition7ComboBox.Text = text2;
                condition8ComboBox.Text = text1;

                if (andRadioButton6.Checked == true && orRadioButton7.Checked == true)
                {
                    andRadioButton7.Checked = true;
                    orRadioButton6.Checked = true;
                }
                else if (andRadioButton7.Checked == true && orRadioButton6.Checked == true)
                {
                    andRadioButton6.Checked = true;
                    orRadioButton7.Checked = true;
                }
            }
        }

        private void buttonUp2_Click(object sender, EventArgs e)
        {
            if ((value1TextBox.Text != "" && field1ComboBox.Text != "" && condition1ComboBox.Text != "") && (value2TextBox.Text != "" && field2ComboBox.Text != "" && condition2ComboBox.Text != "" && (andRadioButton1.Checked == true || orRadioButton1.Checked == true)))
            {
                String text, text1, text2;
                text = value1TextBox.Text;
                value1TextBox.Text = value2TextBox.Text;
                value2TextBox.Text = text;

                text1 = condition1ComboBox.Text;
                text2 = condition2ComboBox.Text;

                text = field1ComboBox.Text;
                field1ComboBox.Text = field2ComboBox.Text;
                field2ComboBox.Text = text;

                condition1ComboBox.Text = text2;
                condition2ComboBox.Text = text1;
            }
        }

        private void buttonUp3_Click(object sender, EventArgs e)
        {
            if ((value2TextBox.Text != "" && field2ComboBox.Text != "" && condition2ComboBox.Text != "" && (andRadioButton1.Checked == true || orRadioButton1.Checked == true)) && (value3TextBox.Text != "" && field3ComboBox.Text != "" && condition3ComboBox.Text != "" && (andRadioButton2.Checked == true || orRadioButton2.Checked == true)))
            {
                String text, text1, text2;
                text = value2TextBox.Text;
                value2TextBox.Text = value3TextBox.Text;
                value3TextBox.Text = text;

                text1 = condition2ComboBox.Text;
                text2 = condition3ComboBox.Text;

                text = field2ComboBox.Text;
                field2ComboBox.Text = field3ComboBox.Text;
                field3ComboBox.Text = text;

                condition2ComboBox.Text = text2;
                condition3ComboBox.Text = text1;

                if (andRadioButton1.Checked == true && orRadioButton2.Checked == true)
                {
                    andRadioButton2.Checked = true;
                    orRadioButton1.Checked = true;
                }
                else if (andRadioButton2.Checked == true && orRadioButton1.Checked == true)
                {
                    andRadioButton1.Checked = true;
                    orRadioButton2.Checked = true;
                }
            }
        }

        private void buttonUp4_Click(object sender, EventArgs e)
        {
            if ((value3TextBox.Text != "" && field3ComboBox.Text != "" && condition3ComboBox.Text != "" && (andRadioButton2.Checked == true || orRadioButton2.Checked == true)) && (value4TextBox.Text != "" && field4ComboBox.Text != "" && condition4ComboBox.Text != "" && (andRadioButton3.Checked == true || orRadioButton3.Checked == true)))
            {
                String text, text1, text2;
                text = value3TextBox.Text;
                value3TextBox.Text = value4TextBox.Text;
                value4TextBox.Text = text;
                text1 = condition3ComboBox.Text;
                text2 = condition4ComboBox.Text;
                text = field3ComboBox.Text;
                field3ComboBox.Text = field4ComboBox.Text;
                field4ComboBox.Text = text;
                condition3ComboBox.Text = text2;
                condition4ComboBox.Text = text1;

                if (andRadioButton2.Checked == true && orRadioButton3.Checked == true)
                {
                    andRadioButton3.Checked = true;
                    orRadioButton2.Checked = true;
                }
                else if (andRadioButton3.Checked == true && orRadioButton2.Checked == true)
                {
                    andRadioButton2.Checked = true;
                    orRadioButton3.Checked = true;
                }
            }
        }

        private void buttonUp5_Click(object sender, EventArgs e)
        {
            if ((value4TextBox.Text != "" && field4ComboBox.Text != "" && condition4ComboBox.Text != "" && (andRadioButton3.Checked == true || orRadioButton3.Checked == true)) && (value5TextBox.Text != "" && field5ComboBox.Text != "" && condition5ComboBox.Text != "" && (andRadioButton4.Checked == true || orRadioButton4.Checked == true)))
            {
                String text, text1, text2;
                text = value4TextBox.Text;
                value4TextBox.Text = value5TextBox.Text;
                value5TextBox.Text = text;
                text1 = condition4ComboBox.Text;
                text2 = condition5ComboBox.Text;
                text = field4ComboBox.Text;
                field4ComboBox.Text = field5ComboBox.Text;
                field5ComboBox.Text = text;
                condition4ComboBox.Text = text2;
                condition5ComboBox.Text = text1;

                if (andRadioButton3.Checked == true && orRadioButton4.Checked == true)
                {
                    andRadioButton4.Checked = true;
                    orRadioButton3.Checked = true;
                }
                else if (andRadioButton4.Checked == true && orRadioButton3.Checked == true)
                {
                    andRadioButton3.Checked = true;
                    orRadioButton4.Checked = true;
                }
            }

        }

        private void buttonUp6_Click(object sender, EventArgs e)
        {
            if ((value5TextBox.Text != "" && field5ComboBox.Text != "" && condition5ComboBox.Text != "" && (andRadioButton4.Checked == true || orRadioButton4.Checked == true)) && (value6TextBox.Text != "" && field6ComboBox.Text != "" && condition6ComboBox.Text != "" && (andRadioButton5.Checked == true || orRadioButton5.Checked == true)))
            {
                String text, text1, text2;
                text = value5TextBox.Text;
                value5TextBox.Text = value6TextBox.Text;
                value6TextBox.Text = text;
                text1 = condition5ComboBox.Text;
                text2 = condition6ComboBox.Text;
                text = field5ComboBox.Text;
                field5ComboBox.Text = field6ComboBox.Text;
                field6ComboBox.Text = text;
                condition5ComboBox.Text = text2;
                condition6ComboBox.Text = text1;

                if (andRadioButton4.Checked == true && orRadioButton5.Checked == true)
                {
                    andRadioButton5.Checked = true;
                    orRadioButton4.Checked = true;
                }
                else if (andRadioButton5.Checked == true && orRadioButton4.Checked == true)
                {
                    andRadioButton4.Checked = true;
                    orRadioButton5.Checked = true;
                }
            }

        }

        private void buttonUp7_Click(object sender, EventArgs e)
        {
            if ((value6TextBox.Text != "" && field6ComboBox.Text != "" && condition6ComboBox.Text != "" && (andRadioButton5.Checked == true || orRadioButton5.Checked == true)) && (value7TextBox.Text != "" && field7ComboBox.Text != "" && condition7ComboBox.Text != "" && (andRadioButton6.Checked == true || orRadioButton6.Checked == true)))
            {
                String text, text1, text2;
                text = value6TextBox.Text;
                value6TextBox.Text = value7TextBox.Text;
                value7TextBox.Text = text;
                text1 = condition6ComboBox.Text;
                text2 = condition7ComboBox.Text;
                text = field6ComboBox.Text;
                field6ComboBox.Text = field7ComboBox.Text;
                field7ComboBox.Text = text;
                condition6ComboBox.Text = text2;
                condition7ComboBox.Text = text1;

                if (andRadioButton5.Checked == true && orRadioButton6.Checked == true)
                {
                    andRadioButton6.Checked = true;
                    orRadioButton5.Checked = true;
                }
                else if (andRadioButton6.Checked == true && orRadioButton5.Checked == true)
                {
                    andRadioButton5.Checked = true;
                    orRadioButton6.Checked = true;
                }
            }

        }

        private void buttonUp8_Click(object sender, EventArgs e)
        {
            if ((value7TextBox.Text != "" && field7ComboBox.Text != "" && condition7ComboBox.Text != "" && (andRadioButton6.Checked == true || orRadioButton6.Checked == true)) && (value8TextBox.Text != "" && field8ComboBox.Text != "" && condition8ComboBox.Text != "" && (andRadioButton7.Checked == true || orRadioButton7.Checked == true)))
            {
                String text, text1, text2;
                text = value7TextBox.Text;
                value7TextBox.Text = value8TextBox.Text;
                value8TextBox.Text = text;
                text1 = condition7ComboBox.Text;
                text2 = condition8ComboBox.Text;
                text = field7ComboBox.Text;
                field7ComboBox.Text = field8ComboBox.Text;
                field8ComboBox.Text = text;
                condition7ComboBox.Text = text2;
                condition8ComboBox.Text = text1;

                if (andRadioButton6.Checked == true && orRadioButton7.Checked == true)
                {
                    andRadioButton7.Checked = true;
                    orRadioButton6.Checked = true;
                }
                else if (andRadioButton7.Checked == true && orRadioButton6.Checked == true)
                {
                    andRadioButton6.Checked = true;
                    orRadioButton7.Checked = true;
                }
            }

        }

        private int ShowValidLineSimpleFilter()
        {
            int nb = 0;
            if (isLine1OK)
            {
                panelLine2.Visible = true;
                if (isLine2OK)
                {
                    panelLine3.Visible = true;
                    if (isLine3OK)
                    {
                        panelLine4.Visible = true;
                        if (isLine4OK)
                        {
                            panelLine5.Visible = true;
                            if (isLine5OK)
                            {
                                panelLine6.Visible = true;
                                if (isLine6OK)
                                {
                                    panelLine7.Visible = true;
                                    if (isLine7OK)
                                    {
                                        panelLine8.Visible = true;

                                        if (isLine8OK)
                                            nb = 8;
                                        else
                                        {
                                            nb = 7;
                                        }

                                    }
                                    else
                                    {
                                        panelLine8.Visible = false;
                                        nb = 6;
                                    }
                                }
                                else
                                {
                                    panelLine7.Visible = false;
                                    panelLine8.Visible = false;
                                    nb = 5;
                                }
                            }
                            else
                            {
                                panelLine6.Visible = false;
                                panelLine7.Visible = false;
                                panelLine8.Visible = false;
                                nb = 4;
                            }
                        }
                        else
                        {
                            panelLine5.Visible = false;
                            panelLine6.Visible = false;
                            panelLine7.Visible = false;
                            panelLine8.Visible = false;
                            nb = 3;
                        }
                    }
                    else
                    {
                        panelLine4.Visible = false;
                        panelLine5.Visible = false;
                        panelLine6.Visible = false;
                        panelLine7.Visible = false;
                        panelLine8.Visible = false;

                        nb = 2;
                    }
                }
                else
                {
                    panelLine3.Visible = false;
                    panelLine4.Visible = false;
                    panelLine5.Visible = false;
                    panelLine6.Visible = false;
                    panelLine7.Visible = false;
                    panelLine8.Visible = false;
                    nb = 1;
                }
            }
            else
            {
                panelLine2.Visible = false;
                panelLine3.Visible = false;
                panelLine4.Visible = false;
                panelLine5.Visible = false;
                panelLine6.Visible = false;
                panelLine7.Visible = false;
                panelLine8.Visible = false;
                nb = 0;
            }

            return nb;
        }

        public void reinitializeTabs()
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (!page.Equals(tabControl1.TabPages[0]))
                {
                    page.Dispose();
                }
            }
        }

        public void FinalizeFilterCreation()
        {
            MainController controller = MainController.Get();
            string title = "tabPage" + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            DataGridViewBDD newDataGridView = new DataGridViewBDD(controller.GetDataBaseController().GetLastFilterId());
            newDataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            newDataGridView.Size = dataGridView1.Size;
            MainController.Get().OpenFilter(newDataGridView, newDataGridView.numGridView);
            myTabPage.Controls.Add(newDataGridView);
            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
        }

        public void ControlsStart()
        {
            progressBar1.Value = 0;
            label6.Text = "Les contrôles sont en cours";
        }

        public void ControlsUpdate(int value)
        {
            progressBar1.Invoke(new Action(() => progressBar1.Value = value));

            if (progressBar1.Value == progressBar1.Maximum)
            {
                label6.Invoke(new Action(() => label6.Text = "Les contrôles sont terminés"));
            }
        }
    }
}


