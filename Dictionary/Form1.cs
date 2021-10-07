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
        private void ButtonDestroy()
        {
            flowLayoutPanelSmall.Controls.Clear();
        }
        private void ButtonMake(int n)
        {
            ButtonDestroy();
            for (int i = 0; i < n; i++)
            {
                Button button = new Button();
                button.Name = $"brutton{i}";
                button.Text = $"Brutton_{i+1}";
                button.Width = 116;
                button.Height = 40;
                flowLayoutPanelSmall.Controls.Add(button);
            }
        }

        private void buttonUnit1_Click(object sender, EventArgs e)
        {
            ButtonMake(1);
        }

        private void buttonUnit2_Click(object sender, EventArgs e)
        {
            ButtonMake(2);
        }

        private void buttonUnit3_Click(object sender, EventArgs e)
        {
            ButtonMake(3);
        }

        private void buttonUnit4_Click(object sender, EventArgs e)
        {
            ButtonMake(4);
        }

        private void buttonUnit5_Click(object sender, EventArgs e)
        {
            ButtonMake(5);
        }
    }
}
