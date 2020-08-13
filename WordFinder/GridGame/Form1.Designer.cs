namespace WordFinder
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLetters = new System.Windows.Forms.Panel();
            this.lettersGrid = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDL = new System.Windows.Forms.Label();
            this.lblTL = new System.Windows.Forms.Label();
            this.lblDW = new System.Windows.Forms.Label();
            this.lblTW = new System.Windows.Forms.Label();
            this.lblMI = new System.Windows.Forms.Label();
            this.lblNoSpecial = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbkSortbyScore = new System.Windows.Forms.RadioButton();
            this.cbkSortbyPath = new System.Windows.Forms.RadioButton();
            this.cbkSortbyLength = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMinScore = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWords = new System.Windows.Forms.Label();
            this.lblMaxPossibleScore = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkDictOSPD = new System.Windows.Forms.RadioButton();
            this.chkDictUKACD = new System.Windows.Forms.RadioButton();
            this.chkDictEnable = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbkSortbyScoreComplexity = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SelectedWordPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCurrentWordLetters = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCurrentWordCrossovers = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCurrentWordDirChanges = new System.Windows.Forms.Label();
            this.btnDoConsole = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkShuffle = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMonkeyRandomAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlLetters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SelectedWordPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Letters";
            // 
            // pnlLetters
            // 
            this.pnlLetters.Controls.Add(this.lettersGrid);
            this.pnlLetters.Location = new System.Drawing.Point(8, 33);
            this.pnlLetters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlLetters.Name = "pnlLetters";
            this.pnlLetters.Size = new System.Drawing.Size(392, 346);
            this.pnlLetters.TabIndex = 2;
            // 
            // lettersGrid
            // 
            this.lettersGrid.BackColor = System.Drawing.Color.White;
            this.lettersGrid.ColumnCount = 4;
            this.lettersGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lettersGrid.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lettersGrid.Location = new System.Drawing.Point(0, 0);
            this.lettersGrid.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lettersGrid.Name = "lettersGrid";
            this.lettersGrid.RowCount = 4;
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.Size = new System.Drawing.Size(392, 346);
            this.lettersGrid.TabIndex = 3;
            this.lettersGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.lettersGrid_Paint);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(8, 104);
            this.btnClear.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(278, 44);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Letters and Bonuses";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(6, 0);
            this.lblResults.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(84, 25);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 45;
            this.lstResults.Location = new System.Drawing.Point(0, 27);
            this.lstResults.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstResults.Name = "lstResults";
            this.lstResults.ScrollAlwaysVisible = true;
            this.lstResults.Size = new System.Drawing.Size(990, 1414);
            this.lstResults.TabIndex = 5;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            this.lstResults.Enter += new System.EventHandler(this.lstResults_Enter_1);
            this.lstResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstResults_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label2.Size = new System.Drawing.Size(398, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "ALL TILES BONUS:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDL
            // 
            this.lblDL.BackColor = System.Drawing.Color.Blue;
            this.lblDL.ForeColor = System.Drawing.Color.White;
            this.lblDL.Location = new System.Drawing.Point(2, 35);
            this.lblDL.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblDL.Name = "lblDL";
            this.lblDL.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDL.Size = new System.Drawing.Size(54, 31);
            this.lblDL.TabIndex = 7;
            this.lblDL.Text = "DL";
            this.lblDL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDL.Click += new System.EventHandler(this.lblDL_Click);
            // 
            // lblTL
            // 
            this.lblTL.BackColor = System.Drawing.Color.LightGreen;
            this.lblTL.ForeColor = System.Drawing.Color.White;
            this.lblTL.Location = new System.Drawing.Point(68, 35);
            this.lblTL.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblTL.Name = "lblTL";
            this.lblTL.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTL.Size = new System.Drawing.Size(54, 31);
            this.lblTL.TabIndex = 7;
            this.lblTL.Text = "TL";
            this.lblTL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTL.Click += new System.EventHandler(this.lblTL_Click);
            // 
            // lblDW
            // 
            this.lblDW.BackColor = System.Drawing.Color.Red;
            this.lblDW.ForeColor = System.Drawing.Color.White;
            this.lblDW.Location = new System.Drawing.Point(134, 35);
            this.lblDW.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblDW.Name = "lblDW";
            this.lblDW.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDW.Size = new System.Drawing.Size(54, 31);
            this.lblDW.TabIndex = 7;
            this.lblDW.Text = "DW";
            this.lblDW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDW.Click += new System.EventHandler(this.lblDW_Click);
            // 
            // lblTW
            // 
            this.lblTW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTW.ForeColor = System.Drawing.Color.White;
            this.lblTW.Location = new System.Drawing.Point(200, 35);
            this.lblTW.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblTW.Name = "lblTW";
            this.lblTW.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTW.Size = new System.Drawing.Size(54, 31);
            this.lblTW.TabIndex = 7;
            this.lblTW.Text = "TW";
            this.lblTW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTW.Click += new System.EventHandler(this.lblTW_Click);
            // 
            // lblMI
            // 
            this.lblMI.BackColor = System.Drawing.Color.DarkRed;
            this.lblMI.ForeColor = System.Drawing.Color.White;
            this.lblMI.Location = new System.Drawing.Point(266, 35);
            this.lblMI.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblMI.Name = "lblMI";
            this.lblMI.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblMI.Size = new System.Drawing.Size(54, 31);
            this.lblMI.TabIndex = 7;
            this.lblMI.Text = "**";
            this.lblMI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMI.Click += new System.EventHandler(this.lblMI_Click);
            // 
            // lblNoSpecial
            // 
            this.lblNoSpecial.BackColor = System.Drawing.Color.Black;
            this.lblNoSpecial.ForeColor = System.Drawing.Color.White;
            this.lblNoSpecial.Location = new System.Drawing.Point(332, 35);
            this.lblNoSpecial.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.lblNoSpecial.Name = "lblNoSpecial";
            this.lblNoSpecial.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNoSpecial.Size = new System.Drawing.Size(54, 31);
            this.lblNoSpecial.TabIndex = 7;
            this.lblNoSpecial.Text = "--";
            this.lblNoSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoSpecial.Click += new System.EventHandler(this.lblNoSpecial_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(2, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label3.Size = new System.Drawing.Size(398, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "(Right click to set individual tiles.)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbkSortbyScore
            // 
            this.cbkSortbyScore.AutoSize = true;
            this.cbkSortbyScore.Checked = true;
            this.cbkSortbyScore.Location = new System.Drawing.Point(8, 38);
            this.cbkSortbyScore.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbkSortbyScore.Name = "cbkSortbyScore";
            this.cbkSortbyScore.Size = new System.Drawing.Size(99, 29);
            this.cbkSortbyScore.TabIndex = 9;
            this.cbkSortbyScore.TabStop = true;
            this.cbkSortbyScore.Text = "Score";
            this.cbkSortbyScore.UseVisualStyleBackColor = true;
            this.cbkSortbyScore.CheckedChanged += new System.EventHandler(this.cbkSortbyScore_CheckedChanged_1);
            // 
            // cbkSortbyPath
            // 
            this.cbkSortbyPath.AutoSize = true;
            this.cbkSortbyPath.Location = new System.Drawing.Point(140, 83);
            this.cbkSortbyPath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbkSortbyPath.Name = "cbkSortbyPath";
            this.cbkSortbyPath.Size = new System.Drawing.Size(87, 29);
            this.cbkSortbyPath.TabIndex = 9;
            this.cbkSortbyPath.Text = "Path";
            this.cbkSortbyPath.UseVisualStyleBackColor = true;
            this.cbkSortbyPath.CheckedChanged += new System.EventHandler(this.cbkSortbyPath_CheckedChanged);
            // 
            // cbkSortbyLength
            // 
            this.cbkSortbyLength.AutoSize = true;
            this.cbkSortbyLength.Location = new System.Drawing.Point(8, 83);
            this.cbkSortbyLength.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbkSortbyLength.Name = "cbkSortbyLength";
            this.cbkSortbyLength.Size = new System.Drawing.Size(109, 29);
            this.cbkSortbyLength.TabIndex = 9;
            this.cbkSortbyLength.Text = "Length";
            this.cbkSortbyLength.UseVisualStyleBackColor = true;
            this.cbkSortbyLength.CheckedChanged += new System.EventHandler(this.cbkSortbyLength_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 121);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Min. Score:";
            // 
            // txtMinScore
            // 
            this.txtMinScore.Location = new System.Drawing.Point(272, 115);
            this.txtMinScore.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMinScore.Name = "txtMinScore";
            this.txtMinScore.Size = new System.Drawing.Size(98, 31);
            this.txtMinScore.TabIndex = 11;
            this.txtMinScore.Text = "25";
            this.txtMinScore.TextChanged += new System.EventHandler(this.txtMinScore_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Words Found:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "Max. Possible Score:";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(232, 50);
            this.lblWords.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(24, 25);
            this.lblWords.TabIndex = 10;
            this.lblWords.Text = "0";
            // 
            // lblMaxPossibleScore
            // 
            this.lblMaxPossibleScore.AutoSize = true;
            this.lblMaxPossibleScore.Location = new System.Drawing.Point(232, 98);
            this.lblMaxPossibleScore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaxPossibleScore.Name = "lblMaxPossibleScore";
            this.lblMaxPossibleScore.Size = new System.Drawing.Size(24, 25);
            this.lblMaxPossibleScore.TabIndex = 10;
            this.lblMaxPossibleScore.Text = "0";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Blue;
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(2, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label11.Size = new System.Drawing.Size(398, 31);
            this.label11.TabIndex = 7;
            this.label11.Text = "DICTIONARY";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDictOSPD);
            this.panel1.Controls.Add(this.chkDictUKACD);
            this.panel1.Controls.Add(this.chkDictEnable);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 48);
            this.panel1.TabIndex = 12;
            // 
            // chkDictOSPD
            // 
            this.chkDictOSPD.AutoSize = true;
            this.chkDictOSPD.Location = new System.Drawing.Point(154, 6);
            this.chkDictOSPD.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDictOSPD.Name = "chkDictOSPD";
            this.chkDictOSPD.Size = new System.Drawing.Size(102, 29);
            this.chkDictOSPD.TabIndex = 1;
            this.chkDictOSPD.Text = "OSPD";
            this.chkDictOSPD.UseVisualStyleBackColor = true;
            this.chkDictOSPD.CheckedChanged += new System.EventHandler(this.chkDictOSPD_CheckedChanged);
            // 
            // chkDictUKACD
            // 
            this.chkDictUKACD.AutoSize = true;
            this.chkDictUKACD.Location = new System.Drawing.Point(274, 6);
            this.chkDictUKACD.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDictUKACD.Name = "chkDictUKACD";
            this.chkDictUKACD.Size = new System.Drawing.Size(116, 29);
            this.chkDictUKACD.TabIndex = 2;
            this.chkDictUKACD.Text = "UKACD";
            this.chkDictUKACD.UseVisualStyleBackColor = true;
            this.chkDictUKACD.CheckedChanged += new System.EventHandler(this.chkDictUKACD_CheckedChanged);
            // 
            // chkDictEnable
            // 
            this.chkDictEnable.AutoSize = true;
            this.chkDictEnable.Checked = true;
            this.chkDictEnable.Location = new System.Drawing.Point(8, 6);
            this.chkDictEnable.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDictEnable.Name = "chkDictEnable";
            this.chkDictEnable.Size = new System.Drawing.Size(126, 29);
            this.chkDictEnable.TabIndex = 0;
            this.chkDictEnable.TabStop = true;
            this.chkDictEnable.Text = "ENABLE";
            this.chkDictEnable.UseVisualStyleBackColor = true;
            this.chkDictEnable.CheckedChanged += new System.EventHandler(this.chkDictEnable_CheckedChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.ForeColor = System.Drawing.Color.Yellow;
            this.label12.Location = new System.Drawing.Point(2, 2);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label12.Size = new System.Drawing.Size(398, 31);
            this.label12.TabIndex = 7;
            this.label12.Text = "SORT ORDER";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(2, 2);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label13.Size = new System.Drawing.Size(398, 31);
            this.label13.TabIndex = 7;
            this.label13.Text = "STATS";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblWords);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblMaxPossibleScore);
            this.panel2.Location = new System.Drawing.Point(0, 833);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 135);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(0, 554);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 92);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.cbkSortbyScoreComplexity);
            this.panel4.Controls.Add(this.cbkSortbyScore);
            this.panel4.Controls.Add(this.cbkSortbyPath);
            this.panel4.Controls.Add(this.txtMinScore);
            this.panel4.Controls.Add(this.cbkSortbyLength);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(0, 658);
            this.panel4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 163);
            this.panel4.TabIndex = 15;
            // 
            // cbkSortbyScoreComplexity
            // 
            this.cbkSortbyScoreComplexity.AutoSize = true;
            this.cbkSortbyScoreComplexity.Location = new System.Drawing.Point(140, 38);
            this.cbkSortbyScoreComplexity.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbkSortbyScoreComplexity.Name = "cbkSortbyScoreComplexity";
            this.cbkSortbyScoreComplexity.Size = new System.Drawing.Size(211, 29);
            this.cbkSortbyScoreComplexity.TabIndex = 9;
            this.cbkSortbyScoreComplexity.Text = "Score/Complexity";
            this.cbkSortbyScoreComplexity.UseVisualStyleBackColor = true;
            this.cbkSortbyScoreComplexity.CheckedChanged += new System.EventHandler(this.cbkSortbyScore_CheckedChanged_1);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.btnClear);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.lblDL);
            this.panel5.Controls.Add(this.lblTL);
            this.panel5.Controls.Add(this.lblDW);
            this.panel5.Controls.Add(this.lblNoSpecial);
            this.panel5.Controls.Add(this.lblTW);
            this.panel5.Controls.Add(this.lblMI);
            this.panel5.Location = new System.Drawing.Point(0, 390);
            this.panel5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 152);
            this.panel5.TabIndex = 16;
            // 
            // SelectedWordPanel
            // 
            this.SelectedWordPanel.Controls.Add(this.label14);
            this.SelectedWordPanel.Controls.Add(this.label15);
            this.SelectedWordPanel.Controls.Add(this.lblCurrentWordLetters);
            this.SelectedWordPanel.Controls.Add(this.label20);
            this.SelectedWordPanel.Controls.Add(this.lblCurrentWordCrossovers);
            this.SelectedWordPanel.Controls.Add(this.label17);
            this.SelectedWordPanel.Controls.Add(this.lblCurrentWordDirChanges);
            this.SelectedWordPanel.Location = new System.Drawing.Point(0, 979);
            this.SelectedWordPanel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SelectedWordPanel.Name = "SelectedWordPanel";
            this.SelectedWordPanel.Size = new System.Drawing.Size(400, 175);
            this.SelectedWordPanel.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Blue;
            this.label14.ForeColor = System.Drawing.Color.Yellow;
            this.label14.Location = new System.Drawing.Point(2, 2);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label14.Size = new System.Drawing.Size(398, 31);
            this.label14.TabIndex = 7;
            this.label14.Text = "Selected Word";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 50);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 25);
            this.label15.TabIndex = 10;
            this.label15.Text = "Letters:";
            // 
            // lblCurrentWordLetters
            // 
            this.lblCurrentWordLetters.AutoSize = true;
            this.lblCurrentWordLetters.Location = new System.Drawing.Point(232, 50);
            this.lblCurrentWordLetters.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentWordLetters.Name = "lblCurrentWordLetters";
            this.lblCurrentWordLetters.Size = new System.Drawing.Size(24, 25);
            this.lblCurrentWordLetters.TabIndex = 10;
            this.lblCurrentWordLetters.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 100);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(134, 25);
            this.label20.TabIndex = 10;
            this.label20.Text = "Cross-overs:";
            // 
            // lblCurrentWordCrossovers
            // 
            this.lblCurrentWordCrossovers.AutoSize = true;
            this.lblCurrentWordCrossovers.Location = new System.Drawing.Point(232, 100);
            this.lblCurrentWordCrossovers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentWordCrossovers.Name = "lblCurrentWordCrossovers";
            this.lblCurrentWordCrossovers.Size = new System.Drawing.Size(24, 25);
            this.lblCurrentWordCrossovers.TabIndex = 10;
            this.lblCurrentWordCrossovers.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 75);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(195, 25);
            this.label17.TabIndex = 10;
            this.label17.Text = "Direction Changes:";
            // 
            // lblCurrentWordDirChanges
            // 
            this.lblCurrentWordDirChanges.AutoSize = true;
            this.lblCurrentWordDirChanges.Location = new System.Drawing.Point(232, 75);
            this.lblCurrentWordDirChanges.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCurrentWordDirChanges.Name = "lblCurrentWordDirChanges";
            this.lblCurrentWordDirChanges.Size = new System.Drawing.Size(24, 25);
            this.lblCurrentWordDirChanges.TabIndex = 10;
            this.lblCurrentWordDirChanges.Text = "0";
            // 
            // btnDoConsole
            // 
            this.btnDoConsole.Location = new System.Drawing.Point(6, 38);
            this.btnDoConsole.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDoConsole.Name = "btnDoConsole";
            this.btnDoConsole.Size = new System.Drawing.Size(182, 44);
            this.btnDoConsole.TabIndex = 18;
            this.btnDoConsole.Text = "All Words";
            this.btnDoConsole.UseVisualStyleBackColor = true;
            this.btnDoConsole.Click += new System.EventHandler(this.btnDoConsole_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 44);
            this.button1.TabIndex = 19;
            this.button1.Text = "Random";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkShuffle
            // 
            this.chkShuffle.AutoSize = true;
            this.chkShuffle.Checked = true;
            this.chkShuffle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShuffle.Location = new System.Drawing.Point(206, 46);
            this.chkShuffle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkShuffle.Name = "chkShuffle";
            this.chkShuffle.Size = new System.Drawing.Size(111, 29);
            this.chkShuffle.TabIndex = 20;
            this.chkShuffle.Text = "Shuffle";
            this.chkShuffle.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtMonkeyRandomAmount);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.chkShuffle);
            this.panel6.Controls.Add(this.btnDoConsole);
            this.panel6.Location = new System.Drawing.Point(0, 1165);
            this.panel6.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(400, 148);
            this.panel6.TabIndex = 21;
            // 
            // txtMonkeyRandomAmount
            // 
            this.txtMonkeyRandomAmount.Location = new System.Drawing.Point(200, 94);
            this.txtMonkeyRandomAmount.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMonkeyRandomAmount.Name = "txtMonkeyRandomAmount";
            this.txtMonkeyRandomAmount.Size = new System.Drawing.Size(116, 31);
            this.txtMonkeyRandomAmount.TabIndex = 21;
            this.txtMonkeyRandomAmount.Text = "35%";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Blue;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 2, 6, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label4.Size = new System.Drawing.Size(398, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monkey Device";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1396, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.pnlLetters);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.SelectedWordPanel);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.panel5);
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(406, 1441);
            this.panel7.TabIndex = 23;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lstResults);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(406, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(990, 1441);
            this.panel8.TabIndex = 24;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblResults);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(990, 27);
            this.panel9.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 1463);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Word Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLetters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.SelectedWordPanel.ResumeLayout(false);
            this.SelectedWordPanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLetters;
        private System.Windows.Forms.TableLayoutPanel lettersGrid;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDL;
        private System.Windows.Forms.Label lblTL;
        private System.Windows.Forms.Label lblDW;
        private System.Windows.Forms.Label lblTW;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.Label lblNoSpecial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton cbkSortbyPath;
        private System.Windows.Forms.RadioButton cbkSortbyLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMinScore;
        private System.Windows.Forms.RadioButton cbkSortbyScore;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblWords;
        private System.Windows.Forms.Label lblMaxPossibleScore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton chkDictOSPD;
        private System.Windows.Forms.RadioButton chkDictEnable;
        private System.Windows.Forms.RadioButton chkDictUKACD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton cbkSortbyScoreComplexity;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel SelectedWordPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCurrentWordLetters;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCurrentWordCrossovers;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCurrentWordDirChanges;
        private System.Windows.Forms.Button btnDoConsole;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkShuffle;
        private System.Windows.Forms.TextBox txtMonkeyRandomAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
    }
}

