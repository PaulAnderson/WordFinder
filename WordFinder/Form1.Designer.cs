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
            this.btnFind = new System.Windows.Forms.Button();
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
            this.pnlLetters.SuspendLayout();
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
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(128, 210);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find ->";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(7, 210);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear X";
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
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(4, 269);
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
            this.lblDL.Location = new System.Drawing.Point(4, 286);
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
            this.lblTL.Location = new System.Drawing.Point(37, 286);
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
            this.lblDW.Location = new System.Drawing.Point(70, 286);
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
            this.lblTW.Location = new System.Drawing.Point(103, 286);
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
            this.lblMI.Location = new System.Drawing.Point(136, 286);
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
            this.lblNoSpecial.Location = new System.Drawing.Point(169, 286);
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
            this.label3.Location = new System.Drawing.Point(4, 303);
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
            this.label4.Location = new System.Drawing.Point(4, 332);
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
            this.label5.Location = new System.Drawing.Point(4, 349);
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
            this.label6.Location = new System.Drawing.Point(4, 366);
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
            this.label7.Location = new System.Drawing.Point(4, 400);
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
            this.btnAutoRunGo.Location = new System.Drawing.Point(7, 419);
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
            this.btnAutoRunStop.Location = new System.Drawing.Point(88, 419);
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
            this.cbkSortbyScore.Location = new System.Drawing.Point(7, 457);
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
            this.cbkSortbyPath.Location = new System.Drawing.Point(7, 480);
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
            this.cbkSortbyLength.Location = new System.Drawing.Point(7, 503);
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
            this.label8.Location = new System.Drawing.Point(85, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Min. Score:";
            // 
            // txtMinScore
            // 
            this.txtMinScore.Location = new System.Drawing.Point(152, 479);
            this.txtMinScore.Name = "txtMinScore";
            this.txtMinScore.Size = new System.Drawing.Size(51, 20);
            this.txtMinScore.TabIndex = 11;
            this.txtMinScore.Text = "25";
            this.txtMinScore.TextChanged += new System.EventHandler(this.txtMinScore_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 549);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Words:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 574);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Max. Possible Score:";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(125, 549);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(13, 13);
            this.lblWords.TabIndex = 10;
            this.lblWords.Text = "0";
            // 
            // lblMaxPossibleScore
            // 
            this.lblMaxPossibleScore.AutoSize = true;
            this.lblMaxPossibleScore.Location = new System.Drawing.Point(125, 574);
            this.lblMaxPossibleScore.Name = "lblMaxPossibleScore";
            this.lblMaxPossibleScore.Size = new System.Drawing.Size(13, 13);
            this.lblMaxPossibleScore.TabIndex = 10;
            this.lblMaxPossibleScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 836);
            this.Controls.Add(this.txtMinScore);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMaxPossibleScore);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbkSortbyLength);
            this.Controls.Add(this.cbkSortbyPath);
            this.Controls.Add(this.cbkSortbyScore);
            this.Controls.Add(this.btnAutoRunStop);
            this.Controls.Add(this.btnAutoRunGo);
            this.Controls.Add(this.lblNoSpecial);
            this.Controls.Add(this.lblMI);
            this.Controls.Add(this.lblTW);
            this.Controls.Add(this.lblDW);
            this.Controls.Add(this.lblTL);
            this.Controls.Add(this.lblDL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.pnlLetters);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Word Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLetters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLetters;
        private System.Windows.Forms.TableLayoutPanel lettersGrid;
        private System.Windows.Forms.Button btnFind;
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
    }
}

