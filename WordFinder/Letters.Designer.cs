namespace WordFinder
{
    partial class Letters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLetters = new System.Windows.Forms.Panel();
            this.lettersGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLetters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLetters
            // 
            this.pnlLetters.Controls.Add(this.lettersGrid);
            this.pnlLetters.Location = new System.Drawing.Point(6, 6);
            this.pnlLetters.Margin = new System.Windows.Forms.Padding(6);
            this.pnlLetters.Name = "pnlLetters";
            this.pnlLetters.Size = new System.Drawing.Size(392, 346);
            this.pnlLetters.TabIndex = 3;
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
            this.lettersGrid.Margin = new System.Windows.Forms.Padding(6);
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
            // Letters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlLetters);
            this.Name = "Letters";
            this.Size = new System.Drawing.Size(404, 358);
            this.pnlLetters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLetters;
        private System.Windows.Forms.TableLayoutPanel lettersGrid;
    }
}
