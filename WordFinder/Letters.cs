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


    }
}
