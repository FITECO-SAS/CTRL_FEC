using System;
using System.Windows.Forms;

namespace AnalyseEtControleFEC
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Par Ligne");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Par Colonne");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Selection", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Simple");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Élaboré");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Filtre", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirFECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerFECToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherLesÉcrituresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierLaSélectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterLaSélectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderLeFiltreSimpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesFiltresSimplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesFiltresÉlaborésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sélectionnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.declarationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compteDeRésultatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déterminationDeLaValeurAjoutéeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationUtilisateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLine8 = new System.Windows.Forms.Panel();
            this.buttonUp8 = new System.Windows.Forms.Button();
            this.panel29 = new System.Windows.Forms.Panel();
            this.orRadioButton7 = new System.Windows.Forms.RadioButton();
            this.andRadioButton7 = new System.Windows.Forms.RadioButton();
            this.field8ComboBox = new System.Windows.Forms.ComboBox();
            this.condition8ComboBox = new System.Windows.Forms.ComboBox();
            this.value8TextBox = new System.Windows.Forms.TextBox();
            this.panelLine7 = new System.Windows.Forms.Panel();
            this.buttonUp7 = new System.Windows.Forms.Button();
            this.buttonDown7 = new System.Windows.Forms.Button();
            this.panel28 = new System.Windows.Forms.Panel();
            this.orRadioButton6 = new System.Windows.Forms.RadioButton();
            this.andRadioButton6 = new System.Windows.Forms.RadioButton();
            this.field7ComboBox = new System.Windows.Forms.ComboBox();
            this.condition7ComboBox = new System.Windows.Forms.ComboBox();
            this.value7TextBox = new System.Windows.Forms.TextBox();
            this.panelLine6 = new System.Windows.Forms.Panel();
            this.buttonUp6 = new System.Windows.Forms.Button();
            this.buttonDown6 = new System.Windows.Forms.Button();
            this.panel27 = new System.Windows.Forms.Panel();
            this.orRadioButton5 = new System.Windows.Forms.RadioButton();
            this.andRadioButton5 = new System.Windows.Forms.RadioButton();
            this.field6ComboBox = new System.Windows.Forms.ComboBox();
            this.condition6ComboBox = new System.Windows.Forms.ComboBox();
            this.value6TextBox = new System.Windows.Forms.TextBox();
            this.panelLine5 = new System.Windows.Forms.Panel();
            this.buttonUp5 = new System.Windows.Forms.Button();
            this.buttonDown5 = new System.Windows.Forms.Button();
            this.panel26 = new System.Windows.Forms.Panel();
            this.orRadioButton4 = new System.Windows.Forms.RadioButton();
            this.andRadioButton4 = new System.Windows.Forms.RadioButton();
            this.field5ComboBox = new System.Windows.Forms.ComboBox();
            this.condition5ComboBox = new System.Windows.Forms.ComboBox();
            this.value5TextBox = new System.Windows.Forms.TextBox();
            this.panelLine4 = new System.Windows.Forms.Panel();
            this.buttonUp4 = new System.Windows.Forms.Button();
            this.buttonDown4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.orRadioButton3 = new System.Windows.Forms.RadioButton();
            this.andRadioButton3 = new System.Windows.Forms.RadioButton();
            this.field4ComboBox = new System.Windows.Forms.ComboBox();
            this.condition4ComboBox = new System.Windows.Forms.ComboBox();
            this.value4TextBox = new System.Windows.Forms.TextBox();
            this.panelLine3 = new System.Windows.Forms.Panel();
            this.buttonUp3 = new System.Windows.Forms.Button();
            this.buttonDown3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.orRadioButton2 = new System.Windows.Forms.RadioButton();
            this.andRadioButton2 = new System.Windows.Forms.RadioButton();
            this.field3ComboBox = new System.Windows.Forms.ComboBox();
            this.condition3ComboBox = new System.Windows.Forms.ComboBox();
            this.value3TextBox = new System.Windows.Forms.TextBox();
            this.panelLine2 = new System.Windows.Forms.Panel();
            this.buttonUp2 = new System.Windows.Forms.Button();
            this.buttonDown2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.andRadioButton1 = new System.Windows.Forms.RadioButton();
            this.orRadioButton1 = new System.Windows.Forms.RadioButton();
            this.field2ComboBox = new System.Windows.Forms.ComboBox();
            this.condition2ComboBox = new System.Windows.Forms.ComboBox();
            this.value2TextBox = new System.Windows.Forms.TextBox();
            this.panelLine1 = new System.Windows.Forms.Panel();
            this.buttonDown1 = new System.Windows.Forms.Button();
            this.field1ComboBox = new System.Windows.Forms.ComboBox();
            this.condition1ComboBox = new System.Windows.Forms.ComboBox();
            this.value1TextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button33 = new System.Windows.Forms.Button();
            this.panel21 = new System.Windows.Forms.Panel();
            this.button20 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.panel19 = new System.Windows.Forms.Panel();
            this.button32 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.panel20 = new System.Windows.Forms.Panel();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.panel17 = new System.Windows.Forms.Panel();
            this.button31 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.button30 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button29 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button28 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelLine8.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panelLine7.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panelLine6.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panelLine5.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panelLine4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelLine3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelLine2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelLine1.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.analyseToolStripMenuItem,
            this.declarationsToolStripMenuItem,
            this.parametresToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1682, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirFECToolStripMenuItem,
            this.fermerFECToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            this.fichierToolStripMenuItem.Click += new System.EventHandler(this.fichierToolStripMenuItem_Click);
            // 
            // ouvrirFECToolStripMenuItem
            // 
            this.ouvrirFECToolStripMenuItem.Name = "ouvrirFECToolStripMenuItem";
            this.ouvrirFECToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.ouvrirFECToolStripMenuItem.Text = "Ouvrir FEC";
            this.ouvrirFECToolStripMenuItem.Click += new System.EventHandler(this.ouvrirFECToolStripMenuItem_Click);
            // 
            // fermerFECToolStripMenuItem
            // 
            this.fermerFECToolStripMenuItem.Name = "fermerFECToolStripMenuItem";
            this.fermerFECToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.fermerFECToolStripMenuItem.Text = "Fermer FEC";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afficherLesÉcrituresToolStripMenuItem,
            this.copierLaSélectionToolStripMenuItem,
            this.exporterLaSélectionToolStripMenuItem,
            this.sauvegarderLeFiltreSimpleToolStripMenuItem,
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem});
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.outilsToolStripMenuItem.Text = "Outils";
            // 
            // afficherLesÉcrituresToolStripMenuItem
            // 
            this.afficherLesÉcrituresToolStripMenuItem.Name = "afficherLesÉcrituresToolStripMenuItem";
            this.afficherLesÉcrituresToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.afficherLesÉcrituresToolStripMenuItem.Text = "Afficher les écritures";
            // 
            // copierLaSélectionToolStripMenuItem
            // 
            this.copierLaSélectionToolStripMenuItem.Name = "copierLaSélectionToolStripMenuItem";
            this.copierLaSélectionToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.copierLaSélectionToolStripMenuItem.Text = "Copier la sélection";
            // 
            // exporterLaSélectionToolStripMenuItem
            // 
            this.exporterLaSélectionToolStripMenuItem.Name = "exporterLaSélectionToolStripMenuItem";
            this.exporterLaSélectionToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.exporterLaSélectionToolStripMenuItem.Text = "Exporter la sélection";
            // 
            // sauvegarderLeFiltreSimpleToolStripMenuItem
            // 
            this.sauvegarderLeFiltreSimpleToolStripMenuItem.Name = "sauvegarderLeFiltreSimpleToolStripMenuItem";
            this.sauvegarderLeFiltreSimpleToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.sauvegarderLeFiltreSimpleToolStripMenuItem.Text = "Sauvegarder le filtre simple";
            this.sauvegarderLeFiltreSimpleToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderLeFiltreSimpleToolStripMenuItem_Click);
            // 
            // sauvegarderLeFiltreÉlaboréToolStripMenuItem
            // 
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem.Name = "sauvegarderLeFiltreÉlaboréToolStripMenuItem";
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem.Text = "Sauvegarder le filtre élaboré";
            this.sauvegarderLeFiltreÉlaboréToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderLeFiltreÉlaboréToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrerToolStripMenuItem,
            this.trierToolStripMenuItem,
            this.sélectionnerToolStripMenuItem,
            this.analyserToolStripMenuItem});
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // filtrerToolStripMenuItem
            // 
            this.filtrerToolStripMenuItem.Name = "filtrerToolStripMenuItem";
            this.filtrerToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.filtrerToolStripMenuItem.Text = "Filtrer";
            // 
            // trierToolStripMenuItem
            // 
            this.trierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mesFiltresSimplesToolStripMenuItem,
            this.mesFiltresÉlaborésToolStripMenuItem});
            this.trierToolStripMenuItem.Name = "trierToolStripMenuItem";
            this.trierToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.trierToolStripMenuItem.Text = "Trier";
            // 
            // mesFiltresSimplesToolStripMenuItem
            // 
            this.mesFiltresSimplesToolStripMenuItem.Name = "mesFiltresSimplesToolStripMenuItem";
            this.mesFiltresSimplesToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.mesFiltresSimplesToolStripMenuItem.Text = "Mes filtres simples";
            // 
            // mesFiltresÉlaborésToolStripMenuItem
            // 
            this.mesFiltresÉlaborésToolStripMenuItem.Name = "mesFiltresÉlaborésToolStripMenuItem";
            this.mesFiltresÉlaborésToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.mesFiltresÉlaborésToolStripMenuItem.Text = "Mes filtres élaborés";
            // 
            // sélectionnerToolStripMenuItem
            // 
            this.sélectionnerToolStripMenuItem.Name = "sélectionnerToolStripMenuItem";
            this.sélectionnerToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.sélectionnerToolStripMenuItem.Text = "Sélectionner";
            // 
            // analyserToolStripMenuItem
            // 
            this.analyserToolStripMenuItem.Name = "analyserToolStripMenuItem";
            this.analyserToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.analyserToolStripMenuItem.Text = "Analyser";
            this.analyserToolStripMenuItem.Click += new System.EventHandler(this.analyserToolStripMenuItem_Click_1);
            // 
            // declarationsToolStripMenuItem
            // 
            this.declarationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bilanToolStripMenuItem,
            this.compteDeRésultatToolStripMenuItem,
            this.déterminationDeLaValeurAjoutéeToolStripMenuItem});
            this.declarationsToolStripMenuItem.Name = "declarationsToolStripMenuItem";
            this.declarationsToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.declarationsToolStripMenuItem.Text = "Declarations";
            // 
            // bilanToolStripMenuItem
            // 
            this.bilanToolStripMenuItem.Name = "bilanToolStripMenuItem";
            this.bilanToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.bilanToolStripMenuItem.Text = "Bilan";
            // 
            // compteDeRésultatToolStripMenuItem
            // 
            this.compteDeRésultatToolStripMenuItem.Name = "compteDeRésultatToolStripMenuItem";
            this.compteDeRésultatToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.compteDeRésultatToolStripMenuItem.Text = "Compte de résultat";
            // 
            // déterminationDeLaValeurAjoutéeToolStripMenuItem
            // 
            this.déterminationDeLaValeurAjoutéeToolStripMenuItem.Name = "déterminationDeLaValeurAjoutéeToolStripMenuItem";
            this.déterminationDeLaValeurAjoutéeToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.déterminationDeLaValeurAjoutéeToolStripMenuItem.Text = "Détermination de la Valeur Ajoutée";
            // 
            // parametresToolStripMenuItem
            // 
            this.parametresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affichageToolStripMenuItem});
            this.parametresToolStripMenuItem.Name = "parametresToolStripMenuItem";
            this.parametresToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.parametresToolStripMenuItem.Text = "Parametres";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationUtilisateurToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // documentationUtilisateurToolStripMenuItem
            // 
            this.documentationUtilisateurToolStripMenuItem.Name = "documentationUtilisateurToolStripMenuItem";
            this.documentationUtilisateurToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.documentationUtilisateurToolStripMenuItem.Text = "documentation utilisateur";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.versionToolStripMenuItem.Text = "version";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1326, 785);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Par Ligne";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Par Colonne";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Selection";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Simple";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Élaboré";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Filtre";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(324, 745);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.panelLine8);
            this.panel1.Controls.Add(this.panelLine7);
            this.panel1.Controls.Add(this.panelLine6);
            this.panel1.Controls.Add(this.panelLine5);
            this.panel1.Controls.Add(this.panelLine4);
            this.panel1.Controls.Add(this.panelLine3);
            this.panel1.Controls.Add(this.panelLine2);
            this.panel1.Controls.Add(this.panelLine1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 566);
            this.panel1.TabIndex = 5;
            // 
            // panelLine8
            // 
            this.panelLine8.Controls.Add(this.buttonUp8);
            this.panelLine8.Controls.Add(this.panel29);
            this.panelLine8.Controls.Add(this.field8ComboBox);
            this.panelLine8.Controls.Add(this.condition8ComboBox);
            this.panelLine8.Controls.Add(this.value8TextBox);
            this.panelLine8.Location = new System.Drawing.Point(8, 435);
            this.panelLine8.Name = "panelLine8";
            this.panelLine8.Size = new System.Drawing.Size(726, 46);
            this.panelLine8.TabIndex = 30;
            this.panelLine8.Visible = false;
            // 
            // buttonUp8
            // 
            this.buttonUp8.Location = new System.Drawing.Point(652, 5);
            this.buttonUp8.Name = "buttonUp8";
            this.buttonUp8.Size = new System.Drawing.Size(23, 23);
            this.buttonUp8.TabIndex = 28;
            this.buttonUp8.Text = "↑";
            this.buttonUp8.UseVisualStyleBackColor = true;
            this.buttonUp8.Click += new System.EventHandler(this.buttonUp8_Click);
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.orRadioButton7);
            this.panel29.Controls.Add(this.andRadioButton7);
            this.panel29.Location = new System.Drawing.Point(7, 3);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(103, 25);
            this.panel29.TabIndex = 18;
            // 
            // orRadioButton7
            // 
            this.orRadioButton7.AutoSize = true;
            this.orRadioButton7.Location = new System.Drawing.Point(62, 5);
            this.orRadioButton7.Name = "orRadioButton7";
            this.orRadioButton7.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton7.TabIndex = 1;
            this.orRadioButton7.TabStop = true;
            this.orRadioButton7.UseVisualStyleBackColor = true;
            // 
            // andRadioButton7
            // 
            this.andRadioButton7.AutoSize = true;
            this.andRadioButton7.Location = new System.Drawing.Point(19, 5);
            this.andRadioButton7.Name = "andRadioButton7";
            this.andRadioButton7.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton7.TabIndex = 0;
            this.andRadioButton7.TabStop = true;
            this.andRadioButton7.UseVisualStyleBackColor = true;
            // 
            // field8ComboBox
            // 
            this.field8ComboBox.FormattingEnabled = true;
            this.field8ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field8ComboBox.Location = new System.Drawing.Point(133, 5);
            this.field8ComboBox.Name = "field8ComboBox";
            this.field8ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field8ComboBox.TabIndex = 10;
            this.field8ComboBox.SelectedIndexChanged += new System.EventHandler(this.field8ComboBox_SelectedIndexChanged);
            // 
            // condition8ComboBox
            // 
            this.condition8ComboBox.FormattingEnabled = true;
            this.condition8ComboBox.Location = new System.Drawing.Point(316, 5);
            this.condition8ComboBox.Name = "condition8ComboBox";
            this.condition8ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition8ComboBox.TabIndex = 6;
            // 
            // value8TextBox
            // 
            this.value8TextBox.Location = new System.Drawing.Point(484, 5);
            this.value8TextBox.Name = "value8TextBox";
            this.value8TextBox.Size = new System.Drawing.Size(138, 22);
            this.value8TextBox.TabIndex = 14;
            this.value8TextBox.TextChanged += new System.EventHandler(this.value8TextBox_TextChanged);
            // 
            // panelLine7
            // 
            this.panelLine7.Controls.Add(this.buttonUp7);
            this.panelLine7.Controls.Add(this.buttonDown7);
            this.panelLine7.Controls.Add(this.panel28);
            this.panelLine7.Controls.Add(this.field7ComboBox);
            this.panelLine7.Controls.Add(this.condition7ComboBox);
            this.panelLine7.Controls.Add(this.value7TextBox);
            this.panelLine7.Location = new System.Drawing.Point(7, 381);
            this.panelLine7.Name = "panelLine7";
            this.panelLine7.Size = new System.Drawing.Size(727, 46);
            this.panelLine7.TabIndex = 29;
            this.panelLine7.Visible = false;
            // 
            // buttonUp7
            // 
            this.buttonUp7.Location = new System.Drawing.Point(653, 6);
            this.buttonUp7.Name = "buttonUp7";
            this.buttonUp7.Size = new System.Drawing.Size(23, 23);
            this.buttonUp7.TabIndex = 27;
            this.buttonUp7.Text = "↑";
            this.buttonUp7.UseVisualStyleBackColor = true;
            this.buttonUp7.Click += new System.EventHandler(this.buttonUp7_Click);
            // 
            // buttonDown7
            // 
            this.buttonDown7.Location = new System.Drawing.Point(682, 6);
            this.buttonDown7.Name = "buttonDown7";
            this.buttonDown7.Size = new System.Drawing.Size(23, 23);
            this.buttonDown7.TabIndex = 24;
            this.buttonDown7.Text = "↓";
            this.buttonDown7.UseVisualStyleBackColor = true;
            this.buttonDown7.Click += new System.EventHandler(this.buttonDown7_Click);
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.orRadioButton6);
            this.panel28.Controls.Add(this.andRadioButton6);
            this.panel28.Location = new System.Drawing.Point(7, 3);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(103, 25);
            this.panel28.TabIndex = 18;
            // 
            // orRadioButton6
            // 
            this.orRadioButton6.AutoSize = true;
            this.orRadioButton6.Location = new System.Drawing.Point(62, 5);
            this.orRadioButton6.Name = "orRadioButton6";
            this.orRadioButton6.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton6.TabIndex = 1;
            this.orRadioButton6.TabStop = true;
            this.orRadioButton6.UseVisualStyleBackColor = true;
            this.orRadioButton6.Click += new System.EventHandler(this.value7TextBox_TextChanged);
            // 
            // andRadioButton6
            // 
            this.andRadioButton6.AutoSize = true;
            this.andRadioButton6.Location = new System.Drawing.Point(19, 5);
            this.andRadioButton6.Name = "andRadioButton6";
            this.andRadioButton6.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton6.TabIndex = 0;
            this.andRadioButton6.TabStop = true;
            this.andRadioButton6.UseVisualStyleBackColor = true;
            this.andRadioButton6.Click += new System.EventHandler(this.value7TextBox_TextChanged);
            // 
            // field7ComboBox
            // 
            this.field7ComboBox.FormattingEnabled = true;
            this.field7ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field7ComboBox.Location = new System.Drawing.Point(133, 5);
            this.field7ComboBox.Name = "field7ComboBox";
            this.field7ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field7ComboBox.TabIndex = 10;
            this.field7ComboBox.SelectedIndexChanged += new System.EventHandler(this.field7ComboBox_SelectedIndexChanged);
            // 
            // condition7ComboBox
            // 
            this.condition7ComboBox.FormattingEnabled = true;
            this.condition7ComboBox.Location = new System.Drawing.Point(316, 5);
            this.condition7ComboBox.Name = "condition7ComboBox";
            this.condition7ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition7ComboBox.TabIndex = 6;
            // 
            // value7TextBox
            // 
            this.value7TextBox.Location = new System.Drawing.Point(484, 5);
            this.value7TextBox.Name = "value7TextBox";
            this.value7TextBox.Size = new System.Drawing.Size(138, 22);
            this.value7TextBox.TabIndex = 14;
            this.value7TextBox.TextChanged += new System.EventHandler(this.value7TextBox_TextChanged);
            // 
            // panelLine6
            // 
            this.panelLine6.Controls.Add(this.buttonUp6);
            this.panelLine6.Controls.Add(this.buttonDown6);
            this.panelLine6.Controls.Add(this.panel27);
            this.panelLine6.Controls.Add(this.field6ComboBox);
            this.panelLine6.Controls.Add(this.condition6ComboBox);
            this.panelLine6.Controls.Add(this.value6TextBox);
            this.panelLine6.Location = new System.Drawing.Point(8, 327);
            this.panelLine6.Name = "panelLine6";
            this.panelLine6.Size = new System.Drawing.Size(726, 46);
            this.panelLine6.TabIndex = 28;
            this.panelLine6.Visible = false;
            // 
            // buttonUp6
            // 
            this.buttonUp6.Location = new System.Drawing.Point(652, 4);
            this.buttonUp6.Name = "buttonUp6";
            this.buttonUp6.Size = new System.Drawing.Size(23, 23);
            this.buttonUp6.TabIndex = 26;
            this.buttonUp6.Text = "↑";
            this.buttonUp6.UseVisualStyleBackColor = true;
            this.buttonUp6.Click += new System.EventHandler(this.buttonUp6_Click);
            // 
            // buttonDown6
            // 
            this.buttonDown6.Location = new System.Drawing.Point(681, 4);
            this.buttonDown6.Name = "buttonDown6";
            this.buttonDown6.Size = new System.Drawing.Size(23, 23);
            this.buttonDown6.TabIndex = 23;
            this.buttonDown6.Text = "↓";
            this.buttonDown6.UseVisualStyleBackColor = true;
            this.buttonDown6.Click += new System.EventHandler(this.buttonDown6_Click);
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.orRadioButton5);
            this.panel27.Controls.Add(this.andRadioButton5);
            this.panel27.Location = new System.Drawing.Point(7, 3);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(103, 25);
            this.panel27.TabIndex = 18;
            // 
            // orRadioButton5
            // 
            this.orRadioButton5.AutoSize = true;
            this.orRadioButton5.Location = new System.Drawing.Point(62, 5);
            this.orRadioButton5.Name = "orRadioButton5";
            this.orRadioButton5.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton5.TabIndex = 1;
            this.orRadioButton5.TabStop = true;
            this.orRadioButton5.UseVisualStyleBackColor = true;
            this.orRadioButton5.Click += new System.EventHandler(this.value6TextBox_TextChanged);
            // 
            // andRadioButton5
            // 
            this.andRadioButton5.AutoSize = true;
            this.andRadioButton5.Location = new System.Drawing.Point(19, 5);
            this.andRadioButton5.Name = "andRadioButton5";
            this.andRadioButton5.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton5.TabIndex = 0;
            this.andRadioButton5.TabStop = true;
            this.andRadioButton5.UseVisualStyleBackColor = true;
            this.andRadioButton5.Click += new System.EventHandler(this.value6TextBox_TextChanged);
            // 
            // field6ComboBox
            // 
            this.field6ComboBox.FormattingEnabled = true;
            this.field6ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field6ComboBox.Location = new System.Drawing.Point(133, 5);
            this.field6ComboBox.Name = "field6ComboBox";
            this.field6ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field6ComboBox.TabIndex = 10;
            this.field6ComboBox.SelectedIndexChanged += new System.EventHandler(this.field6ComboBox_SelectedIndexChanged);
            // 
            // condition6ComboBox
            // 
            this.condition6ComboBox.FormattingEnabled = true;
            this.condition6ComboBox.Location = new System.Drawing.Point(316, 5);
            this.condition6ComboBox.Name = "condition6ComboBox";
            this.condition6ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition6ComboBox.TabIndex = 6;
            // 
            // value6TextBox
            // 
            this.value6TextBox.Location = new System.Drawing.Point(484, 5);
            this.value6TextBox.Name = "value6TextBox";
            this.value6TextBox.Size = new System.Drawing.Size(138, 22);
            this.value6TextBox.TabIndex = 14;
            this.value6TextBox.TextChanged += new System.EventHandler(this.value6TextBox_TextChanged);
            // 
            // panelLine5
            // 
            this.panelLine5.Controls.Add(this.buttonUp5);
            this.panelLine5.Controls.Add(this.buttonDown5);
            this.panelLine5.Controls.Add(this.panel26);
            this.panelLine5.Controls.Add(this.field5ComboBox);
            this.panelLine5.Controls.Add(this.condition5ComboBox);
            this.panelLine5.Controls.Add(this.value5TextBox);
            this.panelLine5.Location = new System.Drawing.Point(8, 273);
            this.panelLine5.Name = "panelLine5";
            this.panelLine5.Size = new System.Drawing.Size(726, 46);
            this.panelLine5.TabIndex = 27;
            this.panelLine5.Visible = false;
            // 
            // buttonUp5
            // 
            this.buttonUp5.Location = new System.Drawing.Point(652, 5);
            this.buttonUp5.Name = "buttonUp5";
            this.buttonUp5.Size = new System.Drawing.Size(23, 23);
            this.buttonUp5.TabIndex = 25;
            this.buttonUp5.Text = "↑";
            this.buttonUp5.UseVisualStyleBackColor = true;
            this.buttonUp5.Click += new System.EventHandler(this.buttonUp5_Click);
            // 
            // buttonDown5
            // 
            this.buttonDown5.Location = new System.Drawing.Point(681, 5);
            this.buttonDown5.Name = "buttonDown5";
            this.buttonDown5.Size = new System.Drawing.Size(23, 23);
            this.buttonDown5.TabIndex = 22;
            this.buttonDown5.Text = "↓";
            this.buttonDown5.UseVisualStyleBackColor = true;
            this.buttonDown5.Click += new System.EventHandler(this.buttonDown5_Click);
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.orRadioButton4);
            this.panel26.Controls.Add(this.andRadioButton4);
            this.panel26.Location = new System.Drawing.Point(7, 3);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(103, 25);
            this.panel26.TabIndex = 18;
            // 
            // orRadioButton4
            // 
            this.orRadioButton4.AutoSize = true;
            this.orRadioButton4.Location = new System.Drawing.Point(62, 5);
            this.orRadioButton4.Name = "orRadioButton4";
            this.orRadioButton4.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton4.TabIndex = 1;
            this.orRadioButton4.TabStop = true;
            this.orRadioButton4.UseVisualStyleBackColor = true;
            this.orRadioButton4.Click += new System.EventHandler(this.value5TextBox_TextChanged);
            // 
            // andRadioButton4
            // 
            this.andRadioButton4.AutoSize = true;
            this.andRadioButton4.Location = new System.Drawing.Point(19, 5);
            this.andRadioButton4.Name = "andRadioButton4";
            this.andRadioButton4.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton4.TabIndex = 0;
            this.andRadioButton4.TabStop = true;
            this.andRadioButton4.UseVisualStyleBackColor = true;
            this.andRadioButton4.Click += new System.EventHandler(this.value5TextBox_TextChanged);
            // 
            // field5ComboBox
            // 
            this.field5ComboBox.FormattingEnabled = true;
            this.field5ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field5ComboBox.Location = new System.Drawing.Point(133, 5);
            this.field5ComboBox.Name = "field5ComboBox";
            this.field5ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field5ComboBox.TabIndex = 10;
            this.field5ComboBox.SelectedIndexChanged += new System.EventHandler(this.field5ComboBox_SelectedIndexChanged);
            // 
            // condition5ComboBox
            // 
            this.condition5ComboBox.FormattingEnabled = true;
            this.condition5ComboBox.Location = new System.Drawing.Point(316, 5);
            this.condition5ComboBox.Name = "condition5ComboBox";
            this.condition5ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition5ComboBox.TabIndex = 6;
            // 
            // value5TextBox
            // 
            this.value5TextBox.Location = new System.Drawing.Point(484, 5);
            this.value5TextBox.Name = "value5TextBox";
            this.value5TextBox.Size = new System.Drawing.Size(138, 22);
            this.value5TextBox.TabIndex = 14;
            this.value5TextBox.TextChanged += new System.EventHandler(this.value5TextBox_TextChanged);
            // 
            // panelLine4
            // 
            this.panelLine4.Controls.Add(this.buttonUp4);
            this.panelLine4.Controls.Add(this.buttonDown4);
            this.panelLine4.Controls.Add(this.panel5);
            this.panelLine4.Controls.Add(this.field4ComboBox);
            this.panelLine4.Controls.Add(this.condition4ComboBox);
            this.panelLine4.Controls.Add(this.value4TextBox);
            this.panelLine4.Location = new System.Drawing.Point(8, 218);
            this.panelLine4.Name = "panelLine4";
            this.panelLine4.Size = new System.Drawing.Size(726, 46);
            this.panelLine4.TabIndex = 26;
            this.panelLine4.Visible = false;
            // 
            // buttonUp4
            // 
            this.buttonUp4.Location = new System.Drawing.Point(652, 8);
            this.buttonUp4.Name = "buttonUp4";
            this.buttonUp4.Size = new System.Drawing.Size(23, 23);
            this.buttonUp4.TabIndex = 24;
            this.buttonUp4.Text = "↑";
            this.buttonUp4.UseVisualStyleBackColor = true;
            this.buttonUp4.Click += new System.EventHandler(this.buttonUp4_Click);
            // 
            // buttonDown4
            // 
            this.buttonDown4.Location = new System.Drawing.Point(681, 8);
            this.buttonDown4.Name = "buttonDown4";
            this.buttonDown4.Size = new System.Drawing.Size(23, 23);
            this.buttonDown4.TabIndex = 21;
            this.buttonDown4.Text = "↓";
            this.buttonDown4.UseVisualStyleBackColor = true;
            this.buttonDown4.Click += new System.EventHandler(this.buttonDown4_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.orRadioButton3);
            this.panel5.Controls.Add(this.andRadioButton3);
            this.panel5.Location = new System.Drawing.Point(7, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(103, 25);
            this.panel5.TabIndex = 18;
            // 
            // orRadioButton3
            // 
            this.orRadioButton3.AutoSize = true;
            this.orRadioButton3.Location = new System.Drawing.Point(62, 5);
            this.orRadioButton3.Name = "orRadioButton3";
            this.orRadioButton3.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton3.TabIndex = 1;
            this.orRadioButton3.TabStop = true;
            this.orRadioButton3.UseVisualStyleBackColor = true;
            this.orRadioButton3.Click += new System.EventHandler(this.value4TextBox_TextChanged);
            // 
            // andRadioButton3
            // 
            this.andRadioButton3.AutoSize = true;
            this.andRadioButton3.Location = new System.Drawing.Point(19, 5);
            this.andRadioButton3.Name = "andRadioButton3";
            this.andRadioButton3.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton3.TabIndex = 0;
            this.andRadioButton3.TabStop = true;
            this.andRadioButton3.UseVisualStyleBackColor = true;
            this.andRadioButton3.Click += new System.EventHandler(this.value4TextBox_TextChanged);
            // 
            // field4ComboBox
            // 
            this.field4ComboBox.FormattingEnabled = true;
            this.field4ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field4ComboBox.Location = new System.Drawing.Point(133, 5);
            this.field4ComboBox.Name = "field4ComboBox";
            this.field4ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field4ComboBox.TabIndex = 10;
            this.field4ComboBox.SelectedIndexChanged += new System.EventHandler(this.field4ComboBox_SelectedIndexChanged);
            // 
            // condition4ComboBox
            // 
            this.condition4ComboBox.FormattingEnabled = true;
            this.condition4ComboBox.Location = new System.Drawing.Point(316, 5);
            this.condition4ComboBox.Name = "condition4ComboBox";
            this.condition4ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition4ComboBox.TabIndex = 6;
            // 
            // value4TextBox
            // 
            this.value4TextBox.Location = new System.Drawing.Point(484, 5);
            this.value4TextBox.Name = "value4TextBox";
            this.value4TextBox.Size = new System.Drawing.Size(138, 22);
            this.value4TextBox.TabIndex = 14;
            this.value4TextBox.TextChanged += new System.EventHandler(this.value4TextBox_TextChanged);
            // 
            // panelLine3
            // 
            this.panelLine3.Controls.Add(this.buttonUp3);
            this.panelLine3.Controls.Add(this.buttonDown3);
            this.panelLine3.Controls.Add(this.panel4);
            this.panelLine3.Controls.Add(this.field3ComboBox);
            this.panelLine3.Controls.Add(this.condition3ComboBox);
            this.panelLine3.Controls.Add(this.value3TextBox);
            this.panelLine3.Location = new System.Drawing.Point(8, 164);
            this.panelLine3.Name = "panelLine3";
            this.panelLine3.Size = new System.Drawing.Size(726, 47);
            this.panelLine3.TabIndex = 25;
            this.panelLine3.Visible = false;
            // 
            // buttonUp3
            // 
            this.buttonUp3.Location = new System.Drawing.Point(652, 5);
            this.buttonUp3.Name = "buttonUp3";
            this.buttonUp3.Size = new System.Drawing.Size(23, 23);
            this.buttonUp3.TabIndex = 23;
            this.buttonUp3.Text = "↑";
            this.buttonUp3.UseVisualStyleBackColor = true;
            this.buttonUp3.Click += new System.EventHandler(this.buttonUp3_Click);
            // 
            // buttonDown3
            // 
            this.buttonDown3.Location = new System.Drawing.Point(681, 5);
            this.buttonDown3.Name = "buttonDown3";
            this.buttonDown3.Size = new System.Drawing.Size(23, 23);
            this.buttonDown3.TabIndex = 20;
            this.buttonDown3.Text = "↓";
            this.buttonDown3.UseVisualStyleBackColor = true;
            this.buttonDown3.Click += new System.EventHandler(this.buttonDown3_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.orRadioButton2);
            this.panel4.Controls.Add(this.andRadioButton2);
            this.panel4.Location = new System.Drawing.Point(7, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(103, 25);
            this.panel4.TabIndex = 17;
            // 
            // orRadioButton2
            // 
            this.orRadioButton2.AutoSize = true;
            this.orRadioButton2.Location = new System.Drawing.Point(62, 4);
            this.orRadioButton2.Name = "orRadioButton2";
            this.orRadioButton2.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton2.TabIndex = 1;
            this.orRadioButton2.TabStop = true;
            this.orRadioButton2.UseVisualStyleBackColor = true;
            this.orRadioButton2.Click += new System.EventHandler(this.value3TextBox_TextChanged);
            // 
            // andRadioButton2
            // 
            this.andRadioButton2.AutoSize = true;
            this.andRadioButton2.Location = new System.Drawing.Point(19, 4);
            this.andRadioButton2.Name = "andRadioButton2";
            this.andRadioButton2.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton2.TabIndex = 0;
            this.andRadioButton2.TabStop = true;
            this.andRadioButton2.UseVisualStyleBackColor = true;
            this.andRadioButton2.Click += new System.EventHandler(this.value3TextBox_TextChanged);
            // 
            // field3ComboBox
            // 
            this.field3ComboBox.FormattingEnabled = true;
            this.field3ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field3ComboBox.Location = new System.Drawing.Point(133, 3);
            this.field3ComboBox.Name = "field3ComboBox";
            this.field3ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field3ComboBox.TabIndex = 9;
            this.field3ComboBox.SelectedIndexChanged += new System.EventHandler(this.field3ComboBox_SelectedIndexChanged);
            // 
            // condition3ComboBox
            // 
            this.condition3ComboBox.FormattingEnabled = true;
            this.condition3ComboBox.Location = new System.Drawing.Point(316, 3);
            this.condition3ComboBox.Name = "condition3ComboBox";
            this.condition3ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition3ComboBox.TabIndex = 5;
            // 
            // value3TextBox
            // 
            this.value3TextBox.Location = new System.Drawing.Point(484, 3);
            this.value3TextBox.Name = "value3TextBox";
            this.value3TextBox.Size = new System.Drawing.Size(138, 22);
            this.value3TextBox.TabIndex = 13;
            this.value3TextBox.TextChanged += new System.EventHandler(this.value3TextBox_TextChanged);
            // 
            // panelLine2
            // 
            this.panelLine2.Controls.Add(this.buttonUp2);
            this.panelLine2.Controls.Add(this.buttonDown2);
            this.panelLine2.Controls.Add(this.panel3);
            this.panelLine2.Controls.Add(this.field2ComboBox);
            this.panelLine2.Controls.Add(this.condition2ComboBox);
            this.panelLine2.Controls.Add(this.value2TextBox);
            this.panelLine2.Location = new System.Drawing.Point(7, 111);
            this.panelLine2.Name = "panelLine2";
            this.panelLine2.Size = new System.Drawing.Size(727, 46);
            this.panelLine2.TabIndex = 24;
            this.panelLine2.Visible = false;
            // 
            // buttonUp2
            // 
            this.buttonUp2.Location = new System.Drawing.Point(653, 6);
            this.buttonUp2.Name = "buttonUp2";
            this.buttonUp2.Size = new System.Drawing.Size(23, 23);
            this.buttonUp2.TabIndex = 22;
            this.buttonUp2.Text = "↑";
            this.buttonUp2.UseVisualStyleBackColor = true;
            this.buttonUp2.Click += new System.EventHandler(this.buttonUp2_Click);
            // 
            // buttonDown2
            // 
            this.buttonDown2.Location = new System.Drawing.Point(682, 5);
            this.buttonDown2.Name = "buttonDown2";
            this.buttonDown2.Size = new System.Drawing.Size(23, 23);
            this.buttonDown2.TabIndex = 19;
            this.buttonDown2.Text = "↓";
            this.buttonDown2.UseVisualStyleBackColor = true;
            this.buttonDown2.Click += new System.EventHandler(this.buttonDown2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.andRadioButton1);
            this.panel3.Controls.Add(this.orRadioButton1);
            this.panel3.Location = new System.Drawing.Point(8, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(103, 25);
            this.panel3.TabIndex = 16;
            // 
            // andRadioButton1
            // 
            this.andRadioButton1.AutoSize = true;
            this.andRadioButton1.Location = new System.Drawing.Point(19, 6);
            this.andRadioButton1.Name = "andRadioButton1";
            this.andRadioButton1.Size = new System.Drawing.Size(17, 16);
            this.andRadioButton1.TabIndex = 0;
            this.andRadioButton1.TabStop = true;
            this.andRadioButton1.UseVisualStyleBackColor = true;
            this.andRadioButton1.CheckedChanged += new System.EventHandler(this.value2TextBox_TextChanged);
            this.andRadioButton1.Click += new System.EventHandler(this.value2TextBox_TextChanged);
            // 
            // orRadioButton1
            // 
            this.orRadioButton1.AutoSize = true;
            this.orRadioButton1.Location = new System.Drawing.Point(62, 6);
            this.orRadioButton1.Name = "orRadioButton1";
            this.orRadioButton1.Size = new System.Drawing.Size(17, 16);
            this.orRadioButton1.TabIndex = 0;
            this.orRadioButton1.TabStop = true;
            this.orRadioButton1.UseVisualStyleBackColor = true;
            this.orRadioButton1.CheckedChanged += new System.EventHandler(this.value2TextBox_TextChanged);
            this.orRadioButton1.Click += new System.EventHandler(this.value2TextBox_TextChanged);
            // 
            // field2ComboBox
            // 
            this.field2ComboBox.FormattingEnabled = true;
            this.field2ComboBox.Items.AddRange(new object[] {
            "",
            "JournalCode",
            "JournalLib",
            "EcritureNum",
            "EcritureDate",
            "CompteNum",
            "CompteLib",
            "CompAuxNum",
            "CompAuxLib",
            "PieceRef",
            "PieceDate",
            "EcritureLib",
            "Debit",
            "Credit",
            "EcritureLet",
            "DateLet",
            "ValidDate",
            "Montantdevise",
            "Idevise"});
            this.field2ComboBox.Location = new System.Drawing.Point(134, 3);
            this.field2ComboBox.Name = "field2ComboBox";
            this.field2ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field2ComboBox.TabIndex = 8;
            this.field2ComboBox.SelectedIndexChanged += new System.EventHandler(this.field2ComboBox_SelectedIndexChanged);
            // 
            // condition2ComboBox
            // 
            this.condition2ComboBox.FormattingEnabled = true;
            this.condition2ComboBox.Location = new System.Drawing.Point(318, 2);
            this.condition2ComboBox.Name = "condition2ComboBox";
            this.condition2ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition2ComboBox.TabIndex = 4;
            // 
            // value2TextBox
            // 
            this.value2TextBox.Location = new System.Drawing.Point(487, 1);
            this.value2TextBox.Name = "value2TextBox";
            this.value2TextBox.Size = new System.Drawing.Size(138, 22);
            this.value2TextBox.TabIndex = 12;
            this.value2TextBox.TextChanged += new System.EventHandler(this.value2TextBox_TextChanged);
            // 
            // panelLine1
            // 
            this.panelLine1.Controls.Add(this.buttonDown1);
            this.panelLine1.Controls.Add(this.field1ComboBox);
            this.panelLine1.Controls.Add(this.condition1ComboBox);
            this.panelLine1.Controls.Add(this.value1TextBox);
            this.panelLine1.Location = new System.Drawing.Point(7, 59);
            this.panelLine1.Name = "panelLine1";
            this.panelLine1.Size = new System.Drawing.Size(727, 43);
            this.panelLine1.TabIndex = 23;
            // 
            // buttonDown1
            // 
            this.buttonDown1.Location = new System.Drawing.Point(682, 2);
            this.buttonDown1.Name = "buttonDown1";
            this.buttonDown1.Size = new System.Drawing.Size(23, 23);
            this.buttonDown1.TabIndex = 18;
            this.buttonDown1.Text = "↓";
            this.buttonDown1.UseVisualStyleBackColor = true;
            this.buttonDown1.Click += new System.EventHandler(this.buttonDown1_Click);
            // 
            // field1ComboBox
            // 
            this.field1ComboBox.FormattingEnabled = true;
            this.field1ComboBox.Location = new System.Drawing.Point(134, 3);
            this.field1ComboBox.Name = "field1ComboBox";
            this.field1ComboBox.Size = new System.Drawing.Size(138, 24);
            this.field1ComboBox.TabIndex = 7;
            this.field1ComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // condition1ComboBox
            // 
            this.condition1ComboBox.FormattingEnabled = true;
            this.condition1ComboBox.Location = new System.Drawing.Point(317, 2);
            this.condition1ComboBox.Name = "condition1ComboBox";
            this.condition1ComboBox.Size = new System.Drawing.Size(138, 24);
            this.condition1ComboBox.TabIndex = 3;
            // 
            // value1TextBox
            // 
            this.value1TextBox.Location = new System.Drawing.Point(485, 1);
            this.value1TextBox.Name = "value1TextBox";
            this.value1TextBox.Size = new System.Drawing.Size(138, 22);
            this.value1TextBox.TabIndex = 11;
            this.value1TextBox.TextChanged += new System.EventHandler(this.value1TextBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(634, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cacher";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(634, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Filtrer";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(66, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "OU";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "ET";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valeurs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Condition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Champ";
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.SystemColors.Window;
            this.panel23.Controls.Add(this.button18);
            this.panel23.Controls.Add(this.button17);
            this.panel23.Controls.Add(this.textBox11);
            this.panel23.Location = new System.Drawing.Point(0, 100);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(269, 187);
            this.panel23.TabIndex = 10;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(120, 138);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(114, 23);
            this.button18.TabIndex = 2;
            this.button18.Text = "Cacher";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button17
            // 
            this.button17.Enabled = false;
            this.button17.Location = new System.Drawing.Point(120, 103);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(114, 23);
            this.button17.TabIndex = 1;
            this.button17.Text = "Selectionner";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(26, 20);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(208, 22);
            this.textBox11.TabIndex = 0;
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 188);
            this.panel2.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(113, 135);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Cacher";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(113, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Selectionner";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 20);
            this.tabControl1.Location = new System.Drawing.Point(339, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1340, 819);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.DoubleClick += new System.EventHandler(this.tabControl1_DoubleClick);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1332, 791);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Window;
            this.panel6.Controls.Add(this.button33);
            this.panel6.Controls.Add(this.panel21);
            this.panel6.Controls.Add(this.panel19);
            this.panel6.Controls.Add(this.panel17);
            this.panel6.Controls.Add(this.panel15);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.button7);
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(683, 477);
            this.panel6.TabIndex = 3;
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(572, 21);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 23;
            this.button33.Text = "Cacher";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.button20);
            this.panel21.Controls.Add(this.button16);
            this.panel21.Controls.Add(this.textBox10);
            this.panel21.Controls.Add(this.panel22);
            this.panel21.Location = new System.Drawing.Point(4, 423);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(657, 39);
            this.panel21.TabIndex = 20;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(486, 7);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(23, 23);
            this.button20.TabIndex = 20;
            this.button20.Text = "↑";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(544, 7);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(99, 23);
            this.button16.TabIndex = 6;
            this.button16.Text = "Supprimer";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(125, 8);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(355, 22);
            this.textBox10.TabIndex = 19;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.radioButton15);
            this.panel22.Controls.Add(this.radioButton16);
            this.panel22.Location = new System.Drawing.Point(15, 8);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(103, 25);
            this.panel22.TabIndex = 18;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(62, 4);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(17, 16);
            this.radioButton15.TabIndex = 1;
            this.radioButton15.TabStop = true;
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(19, 4);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(17, 16);
            this.radioButton16.TabIndex = 0;
            this.radioButton16.TabStop = true;
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.button32);
            this.panel19.Controls.Add(this.button27);
            this.panel19.Controls.Add(this.button15);
            this.panel19.Controls.Add(this.textBox9);
            this.panel19.Controls.Add(this.panel20);
            this.panel19.Location = new System.Drawing.Point(4, 378);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(657, 39);
            this.panel19.TabIndex = 22;
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(515, 9);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(23, 23);
            this.button32.TabIndex = 6;
            this.button32.Text = "↓";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(486, 9);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(23, 23);
            this.button27.TabIndex = 26;
            this.button27.Text = "↑";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(544, 7);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(99, 23);
            this.button15.TabIndex = 6;
            this.button15.Text = "Supprimer";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(125, 8);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(355, 22);
            this.textBox9.TabIndex = 19;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.radioButton13);
            this.panel20.Controls.Add(this.radioButton14);
            this.panel20.Location = new System.Drawing.Point(15, 8);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(103, 25);
            this.panel20.TabIndex = 18;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(62, 4);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(17, 16);
            this.radioButton13.TabIndex = 1;
            this.radioButton13.TabStop = true;
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(19, 4);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(17, 16);
            this.radioButton14.TabIndex = 0;
            this.radioButton14.TabStop = true;
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.button31);
            this.panel17.Controls.Add(this.button26);
            this.panel17.Controls.Add(this.button14);
            this.panel17.Controls.Add(this.textBox8);
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Location = new System.Drawing.Point(4, 333);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(657, 39);
            this.panel17.TabIndex = 21;
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(515, 8);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(23, 23);
            this.button31.TabIndex = 6;
            this.button31.Text = "↓";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(486, 9);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(23, 23);
            this.button26.TabIndex = 25;
            this.button26.Text = "↑";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(544, 7);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(99, 23);
            this.button14.TabIndex = 6;
            this.button14.Text = "Supprimer";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(125, 8);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(355, 22);
            this.textBox8.TabIndex = 19;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.radioButton11);
            this.panel18.Controls.Add(this.radioButton12);
            this.panel18.Location = new System.Drawing.Point(15, 8);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(103, 25);
            this.panel18.TabIndex = 18;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(62, 4);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(17, 16);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.TabStop = true;
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(19, 4);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(17, 16);
            this.radioButton12.TabIndex = 0;
            this.radioButton12.TabStop = true;
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.button30);
            this.panel15.Controls.Add(this.button25);
            this.panel15.Controls.Add(this.button13);
            this.panel15.Controls.Add(this.textBox7);
            this.panel15.Controls.Add(this.panel16);
            this.panel15.Location = new System.Drawing.Point(4, 288);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(657, 39);
            this.panel15.TabIndex = 20;
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(515, 7);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(23, 23);
            this.button30.TabIndex = 24;
            this.button30.Text = "↓";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(486, 8);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(23, 23);
            this.button25.TabIndex = 24;
            this.button25.Text = "↑";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(544, 7);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(99, 23);
            this.button13.TabIndex = 6;
            this.button13.Text = "Supprimer";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(125, 8);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(355, 22);
            this.textBox7.TabIndex = 19;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.radioButton9);
            this.panel16.Controls.Add(this.radioButton10);
            this.panel16.Location = new System.Drawing.Point(15, 8);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(103, 25);
            this.panel16.TabIndex = 18;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(62, 4);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(17, 16);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.TabStop = true;
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(19, 4);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(17, 16);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.button29);
            this.panel13.Controls.Add(this.button24);
            this.panel13.Controls.Add(this.button12);
            this.panel13.Controls.Add(this.textBox6);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Location = new System.Drawing.Point(4, 243);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(657, 39);
            this.panel13.TabIndex = 7;
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(515, 8);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(23, 23);
            this.button29.TabIndex = 23;
            this.button29.Text = "↓";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(486, 9);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(23, 23);
            this.button24.TabIndex = 23;
            this.button24.Text = "↑";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(544, 7);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(99, 23);
            this.button12.TabIndex = 6;
            this.button12.Text = "Supprimer";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(125, 8);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(355, 22);
            this.textBox6.TabIndex = 19;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.radioButton7);
            this.panel14.Controls.Add(this.radioButton8);
            this.panel14.Location = new System.Drawing.Point(15, 8);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(103, 25);
            this.panel14.TabIndex = 18;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(62, 4);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(17, 16);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(19, 4);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(17, 16);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.TabStop = true;
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.button28);
            this.panel11.Controls.Add(this.button23);
            this.panel11.Controls.Add(this.button11);
            this.panel11.Controls.Add(this.textBox5);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(4, 198);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(657, 39);
            this.panel11.TabIndex = 6;
            // 
            // button28
            // 
            this.button28.Location = new System.Drawing.Point(515, 8);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(23, 23);
            this.button28.TabIndex = 22;
            this.button28.Text = "↓";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(486, 8);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(23, 23);
            this.button23.TabIndex = 22;
            this.button23.Text = "↑";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(544, 7);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(99, 23);
            this.button11.TabIndex = 6;
            this.button11.Text = "Supprimer";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(125, 8);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(355, 22);
            this.textBox5.TabIndex = 19;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.radioButton5);
            this.panel12.Controls.Add(this.radioButton6);
            this.panel12.Location = new System.Drawing.Point(15, 8);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(103, 25);
            this.panel12.TabIndex = 18;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(62, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(17, 16);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(19, 4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(17, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button22);
            this.panel9.Controls.Add(this.button21);
            this.panel9.Controls.Add(this.button10);
            this.panel9.Controls.Add(this.textBox4);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(4, 151);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(657, 39);
            this.panel9.TabIndex = 5;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(486, 8);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(23, 23);
            this.button22.TabIndex = 21;
            this.button22.Text = "↑";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(515, 7);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(23, 23);
            this.button21.TabIndex = 5;
            this.button21.Text = "↓";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(544, 7);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(99, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Supprimer";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(125, 8);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(355, 22);
            this.textBox4.TabIndex = 19;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.radioButton3);
            this.panel10.Controls.Add(this.radioButton4);
            this.panel10.Location = new System.Drawing.Point(15, 8);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(103, 25);
            this.panel10.TabIndex = 18;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(62, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(17, 16);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(19, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(17, 16);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button19);
            this.panel8.Controls.Add(this.textBox3);
            this.panel8.Controls.Add(this.button9);
            this.panel8.Location = new System.Drawing.Point(4, 108);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(657, 38);
            this.panel8.TabIndex = 4;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(515, 5);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(23, 23);
            this.button19.TabIndex = 4;
            this.button19.Text = "↓";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(125, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(355, 22);
            this.textBox3.TabIndex = 2;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(544, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(99, 23);
            this.button9.TabIndex = 3;
            this.button9.Text = "Supprimer";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button8);
            this.panel7.Controls.Add(this.textBox2);
            this.panel7.Controls.Add(this.comboBox2);
            this.panel7.Controls.Add(this.comboBox1);
            this.panel7.Location = new System.Drawing.Point(4, 64);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(657, 37);
            this.panel7.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(544, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 23);
            this.button8.TabIndex = 2;
            this.button8.Text = "Ajouter";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(325, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 22);
            this.textBox2.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(164, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(155, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Journal",
            "CompteNum",
            "Montant",
            "EcritureDate",
            "PieceDate"});
            this.comboBox1.Location = new System.Drawing.Point(3, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(19, 21);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(215, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Ajouter une condition";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1682, 865);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.progressBar1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 819);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 754);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 22);
            this.button3.TabIndex = 7;
            this.button3.Text = "output";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 782);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(324, 14);
            this.progressBar1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 799);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "label6";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1682, 893);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel23);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel6);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Start";
            this.Text = "mi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelLine8.ResumeLayout(false);
            this.panelLine8.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panelLine7.ResumeLayout(false);
            this.panelLine7.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panelLine6.ResumeLayout(false);
            this.panelLine6.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panelLine5.ResumeLayout(false);
            this.panelLine5.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panelLine4.ResumeLayout(false);
            this.panelLine4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelLine3.ResumeLayout(false);
            this.panelLine3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelLine2.ResumeLayout(false);
            this.panelLine2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelLine1.ResumeLayout(false);
            this.panelLine1.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem declarationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirFECToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerFECToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherLesÉcrituresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierLaSélectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterLaSélectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderLeFiltreSimpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderLeFiltreÉlaboréToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sélectionnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compteDeRésultatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déterminationDeLaValeurAjoutéeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationUtilisateurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesFiltresSimplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesFiltresÉlaborésToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TreeView treeView1;
        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label4;
        private Panel panel5;
        private RadioButton orRadioButton3;
        private RadioButton andRadioButton3;
        private Panel panel4;
        private RadioButton orRadioButton2;
        private RadioButton andRadioButton2;
        private Panel panel3;
        private RadioButton andRadioButton1;
        private RadioButton orRadioButton1;
        private TextBox value4TextBox;
        private TextBox value3TextBox;
        private TextBox value2TextBox;
        private TextBox value1TextBox;
        private ComboBox field4ComboBox;
        private ComboBox field3ComboBox;
        private ComboBox field2ComboBox;
        private ComboBox field1ComboBox;
        private ComboBox condition4ComboBox;
        private ComboBox condition3ComboBox;
        private ComboBox condition2ComboBox;
        private ComboBox condition1ComboBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel2;
        private Button button5;
        private Button button4;
        private TextBox textBox1;
        private Panel panel6;
        private Button button7;
        private Panel panel7;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button8;
        private Button button9;
        private Panel panel8;
        private TextBox textBox3;
        private Panel panel9;
        private Button button10;
        private TextBox textBox4;
        private Panel panel10;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Panel panel13;
        private Button button12;
        private TextBox textBox6;
        private Panel panel14;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private Panel panel11;
        private Button button11;
        private TextBox textBox5;
        private Panel panel12;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private Panel panel21;
        private Button button16;
        private TextBox textBox10;
        private Panel panel22;
        private RadioButton radioButton15;
        private RadioButton radioButton16;
        private Panel panel19;
        private Button button15;
        private TextBox textBox9;
        private Panel panel20;
        private RadioButton radioButton13;
        private RadioButton radioButton14;
        private Panel panel17;
        private Button button14;
        private TextBox textBox8;
        private Panel panel18;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private Panel panel15;
        private Button button13;
        private TextBox textBox7;
        private Panel panel16;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private Panel panel23;
        private Button button18;
        private Button button17;
        private TextBox textBox11;
        private Button button20;
        private Button button32;
        private Button button27;
        private Button button31;
        private Button button26;
        private Button button30;
        private Button button25;
        private Button button29;
        private Button button24;
        private Button button28;
        private Button button23;
        private Button button22;
        private Button button21;
        private Button button19;
        private Button button33;
        private Panel panelLine4;
        private Panel panelLine3;
        private Panel panelLine2;
        private Panel panelLine1;
        private Panel panelLine8;
        private Panel panel29;
        private RadioButton orRadioButton7;
        private RadioButton andRadioButton7;
        private ComboBox field8ComboBox;
        private ComboBox condition8ComboBox;
        private TextBox value8TextBox;
        private Panel panelLine7;
        private Panel panel28;
        private RadioButton orRadioButton6;
        private RadioButton andRadioButton6;
        private ComboBox field7ComboBox;
        private ComboBox condition7ComboBox;
        private TextBox value7TextBox;
        private Panel panelLine6;
        private Panel panel27;
        private RadioButton orRadioButton5;
        private RadioButton andRadioButton5;
        private ComboBox field6ComboBox;
        private ComboBox condition6ComboBox;
        private TextBox value6TextBox;
        private Panel panelLine5;
        private Panel panel26;
        private RadioButton orRadioButton4;
        private RadioButton andRadioButton4;
        private ComboBox field5ComboBox;
        private ComboBox condition5ComboBox;
        private TextBox value5TextBox;
        private Button buttonUp8;
        private Button buttonUp7;
        private Button buttonDown7;
        private Button buttonUp6;
        private Button buttonDown6;
        private Button buttonUp5;
        private Button buttonDown5;
        private Button buttonUp4;
        private Button buttonDown4;
        private Button buttonUp3;
        private Button buttonDown3;
        private Button buttonUp2;
        private Button buttonDown2;
        private Button buttonDown1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button3;
        private Label label6;
        private ProgressBar progressBar1;
    }
}

