using System.Windows.Forms;
using System.Drawing;
using System;

class CustomTextBox : TextBox {
    private ScoreModifier _Modifier;
    public ScoreModifier Modifier {
        get  {   return _Modifier;  }
        set
        {
            _Modifier = value;
            RefreshModifier();
        }
    }

    public delegate void ChangedEventHandler(object sender);
    public event ChangedEventHandler Changed;


    private Control subCtrl;
    public enum ScoreModifier
    {
		None,
		DL,
		TL,
		DW,
		TW,
        MI //Must include

    }
	public CustomTextBox()
    {
        SetStyle(ControlStyles.Selectable, true);
        this.Modifier = ScoreModifier.None;

        this.ShortcutsEnabled = false;
         

        subCtrl = new Label();
        subCtrl.Font = new System.Drawing.Font(this.Font.FontFamily, 6);
        subCtrl.ForeColor = Color.White;
        subCtrl.Visible = false; 
        subCtrl.Size = new Size(10, 20);
        subCtrl.Padding = new Padding(0);
        subCtrl.Margin = new Padding(0);
        subCtrl.MouseDown += SubCtrl_MouseDown;
        Controls.Add(subCtrl);
    }

    protected override void OnEnter(EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(this.Text))
            this.Text = "";
        base.OnEnter(e);
    }

    private void SubCtrl_MouseDown(object sender, MouseEventArgs e)
    {
        OnMouseDown(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
        {
            IncrementModifier();

            if (Changed != null)
                Changed(this);
        }
    }
  
    public void IncrementModifier()
    {
        switch (Modifier)
        {
            case ScoreModifier.None:
                Modifier = ScoreModifier.DL;
                break;
            case ScoreModifier.DL:
                Modifier = ScoreModifier.TL;
                break;
            case ScoreModifier.TL:
                Modifier = ScoreModifier.DW;
                break;
            case ScoreModifier.DW:
                Modifier = ScoreModifier.TW;
                break;
            case ScoreModifier.TW:
                Modifier = ScoreModifier.MI;
                break;
            case ScoreModifier.MI:
                Modifier = ScoreModifier.None;
                break;
        }
        RefreshModifier();
    }
    private void RefreshModifier()
    {
        if (subCtrl == null)
            return;

        switch (Modifier)
        {
            case ScoreModifier.DL:
                subCtrl.Text = "DL";
                subCtrl.BackColor = Color.Blue;
                subCtrl.Visible = true;
                break;
            case ScoreModifier.TL:
                subCtrl.Text = "TL";
                subCtrl.BackColor = Color.LightGreen;
                subCtrl.Visible = true;
                break;
            case ScoreModifier.DW:
                subCtrl.Text = "DW";
                subCtrl.BackColor = Color.Red;
                subCtrl.Visible = true;
                break;
            case ScoreModifier.TW:
                subCtrl.Text = "TW";
                subCtrl.BackColor = Color.Orange ;
                subCtrl.Visible = true;
                break;
            case ScoreModifier.MI:
                subCtrl.Text = "**";
                subCtrl.BackColor = Color.DarkRed ;
                subCtrl.Visible = true;
                break;
            case ScoreModifier.None:
                subCtrl.Text = "";
                subCtrl.Visible = false;
                break;
        }
    }
}