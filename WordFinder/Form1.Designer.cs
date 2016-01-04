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
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.cbkSortbyScore = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDL = new System.Windows.Forms.Label();
            this.lblTL = new System.Windows.Forms.Label();
            this.lblDW = new System.Windows.Forms.Label();
            this.lblTW = new System.Windows.Forms.Label();
            this.lblMI = new System.Windows.Forms.Label();
            this.lblNoSpecial = new System.Windows.Forms.Label();
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
            // cbkSortbyScore
            // 
            this.cbkSortbyScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbkSortbyScore.AutoSize = true;
            this.cbkSortbyScore.Checked = true;
            this.cbkSortbyScore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkSortbyScore.Location = new System.Drawing.Point(606, 4);
            this.cbkSortbyScore.Name = "cbkSortbyScore";
            this.cbkSortbyScore.Size = new System.Drawing.Size(88, 17);
            this.cbkSortbyScore.TabIndex = 6;
            this.cbkSortbyScore.Text = "Sort by score";
            this.cbkSortbyScore.UseVisualStyleBackColor = true;
            this.cbkSortbyScore.CheckedChanged += new System.EventHandler(this.cbkSortbyScore_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(4, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label2.Size = new System.Drawing.Size(199, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "ALL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDL
            // 
            this.lblDL.BackColor = System.Drawing.Color.Blue;
            this.lblDL.ForeColor = System.Drawing.Color.White;
            this.lblDL.Location = new System.Drawing.Point(4, 253);
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
            this.lblTL.Location = new System.Drawing.Point(37, 253);
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
            this.lblDW.Location = new System.Drawing.Point(70, 253);
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
            this.lblTW.Location = new System.Drawing.Point(103, 253);
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
            this.lblMI.Location = new System.Drawing.Point(136, 253);
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
            this.lblNoSpecial.Location = new System.Drawing.Point(169, 253);
            this.lblNoSpecial.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblNoSpecial.Name = "lblNoSpecial";
            this.lblNoSpecial.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblNoSpecial.Size = new System.Drawing.Size(27, 16);
            this.lblNoSpecial.TabIndex = 7;
            this.lblNoSpecial.Text = "--";
            this.lblNoSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoSpecial.Click += new System.EventHandler(this.lblNoSpecial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 836);
            this.Controls.Add(this.lblNoSpecial);
            this.Controls.Add(this.lblMI);
            this.Controls.Add(this.lblTW);
            this.Controls.Add(this.lblDW);
            this.Controls.Add(this.lblTL);
            this.Controls.Add(this.lblDL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbkSortbyScore);
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
        private System.Windows.Forms.CheckBox cbkSortbyScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDL;
        private System.Windows.Forms.Label lblTL;
        private System.Windows.Forms.Label lblDW;
        private System.Windows.Forms.Label lblTW;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.Label lblNoSpecial;
    }
}

