using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFinder
{
    public partial class Letters : UserControl
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        public List<Point> LinePath;

        public Letters()
        {
            InitializeComponent();
        }

        internal void Add(CustomTextBox textBox, int c, int r)
        {
            lettersGrid.Controls.Add(textBox, c, r);
        }

        internal void AdvanceCursor(Control control)
        {
            lettersGrid.SelectNextControl(control, false, true, false, true);
        }

        internal void OnChanged()
        {
            OnTextChanged(new EventArgs());
        }

        public override void Refresh()
        {
            lettersGrid.Refresh();
            base.Refresh();
        }

        private void lettersGrid_Paint(object sender, PaintEventArgs e)
        {
            if (LinePath != null && LinePath.Count > 1)
            {
                for (int i = 0; i < LinePath.Count - 1; i++)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 3), LinePath[i], LinePath[i + 1]);
                }
            }
        }

        public void SetTableSize(int rows, int columns)
        {
            TableLayoutPanel panel = lettersGrid;

            //one extra row/column so that all the textboxes are the same size
            rows += 1;
            columns += 1;

            panel.RowCount = rows;
            panel.ColumnCount = columns;

            var rowHeight = 100 / rows;
            var colHeight = 100 / columns;

            panel.RowStyles.Clear();
            panel.ColumnStyles.Clear();

            for (var i = 0; i< panel.RowCount-1; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            for(var i = 0; i < panel.ColumnCount-1; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colHeight));
            }

            //last row/column autosize
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0));

        }

    }
}
