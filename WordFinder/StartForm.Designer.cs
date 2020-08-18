namespace WordFinder
{
    partial class StartForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LettersButton = new System.Windows.Forms.Button();
            this.GridButton = new System.Windows.Forms.Button();
            this.BoardButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.BoardButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LettersButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.GridButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 534);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LettersButton
            // 
            this.LettersButton.Location = new System.Drawing.Point(426, 3);
            this.LettersButton.Name = "LettersButton";
            this.LettersButton.Size = new System.Drawing.Size(265, 219);
            this.LettersButton.TabIndex = 1;
            this.LettersButton.Text = "Letters";
            this.LettersButton.UseVisualStyleBackColor = true;
            this.LettersButton.Click += new System.EventHandler(this.LettersButton_Click);
            // 
            // GridButton
            // 
            this.GridButton.Location = new System.Drawing.Point(3, 3);
            this.GridButton.Name = "GridButton";
            this.GridButton.Size = new System.Drawing.Size(265, 219);
            this.GridButton.TabIndex = 0;
            this.GridButton.Text = "Grid";
            this.GridButton.UseVisualStyleBackColor = true;
            this.GridButton.Click += new System.EventHandler(this.GridButton_Click);
            // 
            // BoardButton
            // 
            this.BoardButton.Location = new System.Drawing.Point(3, 270);
            this.BoardButton.Name = "BoardButton";
            this.BoardButton.Size = new System.Drawing.Size(265, 219);
            this.BoardButton.TabIndex = 2;
            this.BoardButton.Text = "Board";
            this.BoardButton.UseVisualStyleBackColor = true;
            this.BoardButton.Click += new System.EventHandler(this.BoardButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 534);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button GridButton;
        private System.Windows.Forms.Button LettersButton;
        private System.Windows.Forms.Button BoardButton;
    }
}