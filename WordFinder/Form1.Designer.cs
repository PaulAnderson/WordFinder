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
            this.components = new System.ComponentModel.Container();
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
            this.timerAutoAdvance = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAutoRunGo = new System.Windows.Forms.Button();
            this.btnAutoRunStop = new System.Windows.Forms.Button();
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.SelectedWordPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCurrentWordLetters = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCurrentWordCrossovers = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCurrentWordDirChanges = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlLetters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SelectedWordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Letters";
            // 
            // pnlLetters
            // 
            this.pnlLetters.Controls.Add(this.lettersGrid);
            this.pnlLetters.Location = new System.Drawing.Point(7, 24);
            this.pnlLetters.Name = "pnlLetters";
            this.pnlLetters.Size = new System.Drawing.Size(196, 180);
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
            this.lettersGrid.Name = "lettersGrid";
            this.lettersGrid.RowCount = 4;
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.lettersGrid.Size = new System.Drawing.Size(196, 180);
            this.lettersGrid.TabIndex = 3;
            this.lettersGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.lettersGrid_Paint);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(4, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Letters and Bonuses";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(209, 9);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(42, 13);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Results";
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 22;
            this.lstResults.Location = new System.Drawing.Point(209, 24);
            this.lstResults.Name = "lstResults";
            this.lstResults.ScrollAlwaysVisible = true;
            this.lstResults.Size = new System.Drawing.Size(477, 796);
            this.lstResults.TabIndex = 5;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            this.lstResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstResults_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label2.Size = new System.Drawing.Size(199, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "ALL TILES BONUS:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDL
            // 
            this.lblDL.BackColor = System.Drawing.Color.Blue;
            this.lblDL.ForeColor = System.Drawing.Color.White;
            this.lblDL.Location = new System.Drawing.Point(1, 18);
            this.lblDL.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblDL.Name = "lblDL";
            this.lblDL.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblDL.Size = new System.Drawing.Size(27, 16);
            this.lblDL.TabIndex = 7;
            this.lblDL.Text = "DL";
            this.lblDL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDL.Click += new System.EventHandler(this.lblDL_Click);
            // 
            // lblTL
            // 
            this.lblTL.BackColor = System.Drawing.Color.LightGreen;
            this.lblTL.ForeColor = System.Drawing.Color.White;
            this.lblTL.Location = new System.Drawing.Point(34, 18);
            this.lblTL.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblTL.Name = "lblTL";
            this.lblTL.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblTL.Size = new System.Drawing.Size(27, 16);
            this.lblTL.TabIndex = 7;
            this.lblTL.Text = "TL";
            this.lblTL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTL.Click += new System.EventHandler(this.lblTL_Click);
            // 
            // lblDW
            // 
            this.lblDW.BackColor = System.Drawing.Color.Red;
            this.lblDW.ForeColor = System.Drawing.Color.White;
            this.lblDW.Location = new System.Drawing.Point(67, 18);
            this.lblDW.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblDW.Name = "lblDW";
            this.lblDW.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblDW.Size = new System.Drawing.Size(27, 16);
            this.lblDW.TabIndex = 7;
            this.lblDW.Text = "DW";
            this.lblDW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDW.Click += new System.EventHandler(this.lblDW_Click);
            // 
            // lblTW
            // 
            this.lblTW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTW.ForeColor = System.Drawing.Color.White;
            this.lblTW.Location = new System.Drawing.Point(100, 18);
            this.lblTW.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblTW.Name = "lblTW";
            this.lblTW.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblTW.Size = new System.Drawing.Size(27, 16);
            this.lblTW.TabIndex = 7;
            this.lblTW.Text = "TW";
            this.lblTW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTW.Click += new System.EventHandler(this.lblTW_Click);
            // 
            // lblMI
            // 
            this.lblMI.BackColor = System.Drawing.Color.DarkRed;
            this.lblMI.ForeColor = System.Drawing.Color.White;
            this.lblMI.Location = new System.Drawing.Point(133, 18);
            this.lblMI.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblMI.Name = "lblMI";
            this.lblMI.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblMI.Size = new System.Drawing.Size(27, 16);
            this.lblMI.TabIndex = 7;
            this.lblMI.Text = "**";
            this.lblMI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMI.Click += new System.EventHandler(this.lblMI_Click);
            // 
            // lblNoSpecial
            // 
            this.lblNoSpecial.BackColor = System.Drawing.Color.Black;
            this.lblNoSpecial.ForeColor = System.Drawing.Color.White;
            this.lblNoSpecial.Location = new System.Drawing.Point(166, 18);
            this.lblNoSpecial.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblNoSpecial.Name = "lblNoSpecial";
            this.lblNoSpecial.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblNoSpecial.Size = new System.Drawing.Size(27, 16);
            this.lblNoSpecial.TabIndex = 7;
            this.lblNoSpecial.Text = "--";
            this.lblNoSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoSpecial.Click += new System.EventHandler(this.lblNoSpecial_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(1, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label3.Size = new System.Drawing.Size(199, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "(Right click to set individual tiles.)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerAutoAdvance
            // 
            this.timerAutoAdvance.Interval = 1000;
            this.timerAutoAdvance.Tick += new System.EventHandler(this.timerAutoAdvance_Tick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label4.Size = new System.Drawing.Size(199, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "WORD LENGTH";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(1, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "MIN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(1, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "MAX";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(1, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label7.Size = new System.Drawing.Size(199, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "AUTO RUN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAutoRunGo
            // 
            this.btnAutoRunGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAutoRunGo.Location = new System.Drawing.Point(4, 19);
            this.btnAutoRunGo.Name = "btnAutoRunGo";
            this.btnAutoRunGo.Size = new System.Drawing.Size(75, 23);
            this.btnAutoRunGo.TabIndex = 8;
            this.btnAutoRunGo.Text = "GO";
            this.btnAutoRunGo.UseVisualStyleBackColor = false;
            this.btnAutoRunGo.Click += new System.EventHandler(this.btnAutoRunGo_Click);
            // 
            // btnAutoRunStop
            // 
            this.btnAutoRunStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAutoRunStop.Location = new System.Drawing.Point(85, 19);
            this.btnAutoRunStop.Name = "btnAutoRunStop";
            this.btnAutoRunStop.Size = new System.Drawing.Size(75, 23);
            this.btnAutoRunStop.TabIndex = 8;
            this.btnAutoRunStop.Text = "STOP";
            this.btnAutoRunStop.UseVisualStyleBackColor = false;
            this.btnAutoRunStop.Click += new System.EventHandler(this.btnAutoRunStop_Click);
            // 
            // cbkSortbyScore
            // 
            this.cbkSortbyScore.AutoSize = true;
            this.cbkSortbyScore.Checked = true;
            this.cbkSortbyScore.Location = new System.Drawing.Point(4, 20);
            this.cbkSortbyScore.Name = "cbkSortbyScore";
            this.cbkSortbyScore.Size = new System.Drawing.Size(53, 17);
            this.cbkSortbyScore.TabIndex = 9;
            this.cbkSortbyScore.TabStop = true;
            this.cbkSortbyScore.Text = "Score";
            this.cbkSortbyScore.UseVisualStyleBackColor = true;
            this.cbkSortbyScore.CheckedChanged += new System.EventHandler(this.cbkSortbyScore_CheckedChanged_1);
            // 
            // cbkSortbyPath
            // 
            this.cbkSortbyPath.AutoSize = true;
            this.cbkSortbyPath.Location = new System.Drawing.Point(4, 89);
            this.cbkSortbyPath.Name = "cbkSortbyPath";
            this.cbkSortbyPath.Size = new System.Drawing.Size(47, 17);
            this.cbkSortbyPath.TabIndex = 9;
            this.cbkSortbyPath.Text = "Path";
            this.cbkSortbyPath.UseVisualStyleBackColor = true;
            this.cbkSortbyPath.CheckedChanged += new System.EventHandler(this.cbkSortbyPath_CheckedChanged);
            // 
            // cbkSortbyLength
            // 
            this.cbkSortbyLength.AutoSize = true;
            this.cbkSortbyLength.Location = new System.Drawing.Point(4, 66);
            this.cbkSortbyLength.Name = "cbkSortbyLength";
            this.cbkSortbyLength.Size = new System.Drawing.Size(58, 17);
            this.cbkSortbyLength.TabIndex = 9;
            this.cbkSortbyLength.Text = "Length";
            this.cbkSortbyLength.UseVisualStyleBackColor = true;
            this.cbkSortbyLength.CheckedChanged += new System.EventHandler(this.cbkSortbyLength_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Min. Score:";
            // 
            // txtMinScore
            // 
            this.txtMinScore.Location = new System.Drawing.Point(145, 88);
            this.txtMinScore.Name = "txtMinScore";
            this.txtMinScore.Size = new System.Drawing.Size(51, 20);
            this.txtMinScore.TabIndex = 11;
            this.txtMinScore.Text = "25";
            this.txtMinScore.TextChanged += new System.EventHandler(this.txtMinScore_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Words Found:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Max. Possible Score:";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(116, 26);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(13, 13);
            this.lblWords.TabIndex = 10;
            this.lblWords.Text = "0";
            // 
            // lblMaxPossibleScore
            // 
            this.lblMaxPossibleScore.AutoSize = true;
            this.lblMaxPossibleScore.Location = new System.Drawing.Point(116, 51);
            this.lblMaxPossibleScore.Name = "lblMaxPossibleScore";
            this.lblMaxPossibleScore.Size = new System.Drawing.Size(13, 13);
            this.lblMaxPossibleScore.TabIndex = 10;
            this.lblMaxPossibleScore.Text = "0";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Blue;
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(1, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label11.Size = new System.Drawing.Size(199, 16);
            this.label11.TabIndex = 7;
            this.label11.Text = "DICTIONARY";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkDictOSPD);
            this.panel1.Controls.Add(this.chkDictUKACD);
            this.panel1.Controls.Add(this.chkDictEnable);
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 25);
            this.panel1.TabIndex = 12;
            // 
            // chkDictOSPD
            // 
            this.chkDictOSPD.AutoSize = true;
            this.chkDictOSPD.Location = new System.Drawing.Point(77, 3);
            this.chkDictOSPD.Name = "chkDictOSPD";
            this.chkDictOSPD.Size = new System.Drawing.Size(55, 17);
            this.chkDictOSPD.TabIndex = 1;
            this.chkDictOSPD.Text = "OSPD";
            this.chkDictOSPD.UseVisualStyleBackColor = true;
            this.chkDictOSPD.CheckedChanged += new System.EventHandler(this.chkDictOSPD_CheckedChanged);
            // 
            // chkDictUKACD
            // 
            this.chkDictUKACD.AutoSize = true;
            this.chkDictUKACD.Location = new System.Drawing.Point(137, 3);
            this.chkDictUKACD.Name = "chkDictUKACD";
            this.chkDictUKACD.Size = new System.Drawing.Size(62, 17);
            this.chkDictUKACD.TabIndex = 2;
            this.chkDictUKACD.Text = "UKACD";
            this.chkDictUKACD.UseVisualStyleBackColor = true;
            this.chkDictUKACD.CheckedChanged += new System.EventHandler(this.chkDictUKACD_CheckedChanged);
            // 
            // chkDictEnable
            // 
            this.chkDictEnable.AutoSize = true;
            this.chkDictEnable.Checked = true;
            this.chkDictEnable.Location = new System.Drawing.Point(4, 3);
            this.chkDictEnable.Name = "chkDictEnable";
            this.chkDictEnable.Size = new System.Drawing.Size(67, 17);
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
            this.label12.Location = new System.Drawing.Point(1, 1);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label12.Size = new System.Drawing.Size(199, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "SORT ORDER";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(1, 1);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label13.Size = new System.Drawing.Size(199, 16);
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
            this.panel2.Location = new System.Drawing.Point(3, 578);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 70);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(3, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 48);
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
            this.panel4.Location = new System.Drawing.Point(3, 405);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 113);
            this.panel4.TabIndex = 15;
            // 
            // cbkSortbyScoreComplexity
            // 
            this.cbkSortbyScoreComplexity.AutoSize = true;
            this.cbkSortbyScoreComplexity.Location = new System.Drawing.Point(4, 43);
            this.cbkSortbyScoreComplexity.Name = "cbkSortbyScoreComplexity";
            this.cbkSortbyScoreComplexity.Size = new System.Drawing.Size(108, 17);
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
            this.panel5.Location = new System.Drawing.Point(3, 210);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 79);
            this.panel5.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 293);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 58);
            this.panel6.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.btnAutoRunGo);
            this.panel7.Controls.Add(this.btnAutoRunStop);
            this.panel7.Location = new System.Drawing.Point(3, 357);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 45);
            this.panel7.TabIndex = 16;
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
            this.SelectedWordPanel.Location = new System.Drawing.Point(2, 654);
            this.SelectedWordPanel.Name = "SelectedWordPanel";
            this.SelectedWordPanel.Size = new System.Drawing.Size(200, 91);
            this.SelectedWordPanel.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Blue;
            this.label14.ForeColor = System.Drawing.Color.Yellow;
            this.label14.Location = new System.Drawing.Point(1, 1);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label14.Size = new System.Drawing.Size(199, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Selected Word";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Letters:";
            // 
            // lblCurrentWordLetters
            // 
            this.lblCurrentWordLetters.AutoSize = true;
            this.lblCurrentWordLetters.Location = new System.Drawing.Point(116, 26);
            this.lblCurrentWordLetters.Name = "lblCurrentWordLetters";
            this.lblCurrentWordLetters.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentWordLetters.TabIndex = 10;
            this.lblCurrentWordLetters.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Cross-overs:";
            // 
            // lblCurrentWordCrossovers
            // 
            this.lblCurrentWordCrossovers.AutoSize = true;
            this.lblCurrentWordCrossovers.Location = new System.Drawing.Point(116, 52);
            this.lblCurrentWordCrossovers.Name = "lblCurrentWordCrossovers";
            this.lblCurrentWordCrossovers.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentWordCrossovers.TabIndex = 10;
            this.lblCurrentWordCrossovers.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Direction Changes:";
            // 
            // lblCurrentWordDirChanges
            // 
            this.lblCurrentWordDirChanges.AutoSize = true;
            this.lblCurrentWordDirChanges.Location = new System.Drawing.Point(116, 39);
            this.lblCurrentWordDirChanges.Name = "lblCurrentWordDirChanges";
            this.lblCurrentWordDirChanges.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentWordDirChanges.TabIndex = 10;
            this.lblCurrentWordDirChanges.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(209, 823);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(220, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Press Space Bar to scroll current word to top.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 836);
            this.Controls.Add(this.SelectedWordPanel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.pnlLetters);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.label1);
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
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.SelectedWordPanel.ResumeLayout(false);
            this.SelectedWordPanel.PerformLayout();
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
        private System.Windows.Forms.Timer timerAutoAdvance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAutoRunGo;
        private System.Windows.Forms.Button btnAutoRunStop;
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
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel SelectedWordPanel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCurrentWordLetters;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCurrentWordCrossovers;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCurrentWordDirChanges;
        private System.Windows.Forms.Label label16;
    }
}

