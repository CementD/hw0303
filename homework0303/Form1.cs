namespace homework0303
{
    public partial class Form1 : Form
    {
        List<Button> buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            buttons.AddRange(new[]
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,
                button11, button12, button13, button14, button15, button16, button17, button18, button19, button20
            });
            ToolTip toolTip = new ToolTip();

            foreach (Button btn in buttons)
            {
                btn.Tag = $"Description: {btn.Text}";
                toolTip.SetToolTip(btn, btn.Tag.ToString());
                btn.Click += ProductButton_Click;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Left -= e.NewValue - e.OldValue;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Top -= e.NewValue - e.OldValue;
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                label1.Text += $"\n-{btn.Text} ";
                NumericUpDown numeric = new NumericUpDown()
                {
                    Width = btn.Width - 100,
                    Left = btn.Left,
                    Top = btn.Bottom + 5,
                    Minimum = 1,
                    Maximum = 100,
                    Value = 1,
                    Tag = btn 
                };
                this.Controls.Add(numeric);
                Button selectButton = new Button()
                {
                    Text = "Choose",
                    Width = 100,
                    Height = numeric.Height,
                    Left = btn.Left + numeric.Width,
                    Top = btn.Bottom + 5,
                };
                
                selectButton.Click += (s, e) =>
                {
                    label1.Text += $"{numeric.Value} p.";
                    numeric.Visible = false;
                    selectButton.Visible = false;    
                };
                this.Controls.Add(selectButton);
            }
        }

    }
}
