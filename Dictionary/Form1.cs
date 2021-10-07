using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //flowLayoutPanelBig
        void PopulateTheBigPanel(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Label labsel = new Label();
            labsel.AutoSize = true;

            flowLayoutPanelBig.Controls.Clear();
            labsel.Text = $"Oppa! \n\t{clickedButton.Text}";
            flowLayoutPanelBig.Controls.Add(labsel);
        }


        //-------------Buttons==========//
        private void ButtonMake(int n, object sender, EventArgs e)
        {
            PopulateTheBigPanel(sender, e);
            flowLayoutPanelSmall.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Button button = new Button();
                button.Name = $"brutton{i}";
                button.Text = $"Brutton_{i+1}";
                button.Width = 200;
                button.Height = 50;
                button.BackColor = Color.White;
                button.Click += new EventHandler(this.PopulateTheBigPanel);
                flowLayoutPanelSmall.Controls.Add(button);
            }
        }


        private void buttonUnit1_Click(object sender, EventArgs e)
        {
            ButtonMake(1, sender, e);
        }

        private void buttonUnit2_Click(object sender, EventArgs e)
        {
            ButtonMake(2, sender, e);
        }

        private void buttonUnit3_Click(object sender, EventArgs e)
        {
            ButtonMake(3, sender, e);
        }

        private void buttonUnit4_Click(object sender, EventArgs e)
        {
            ButtonMake(4, sender, e);
        }

        private void buttonUnit5_Click(object sender, EventArgs e)
        {
            ButtonMake(5, sender, e);
        }
    }
}
