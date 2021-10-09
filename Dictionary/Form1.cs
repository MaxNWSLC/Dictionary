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
        static readonly CatalogAcces ca = new CatalogAcces("Data Source=Dictionary.db");
        Button[] buttonsArray;
        DictClass[] unitArray;
        List<Button> sideBtns = new List<Button> { };
        public Form1()
        {
            InitializeComponent();
            buttonsArray = new Button[] { buttonUnit1, buttonUnit2, buttonUnit3, buttonUnit4, buttonUnit5 };

            unitArray = ca.GetInfoByUnit();
        }
        /// <summary>
        /// We populate the BigPanel with the info from the unitArray 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PopulateTheBigPanel(Object sender, EventArgs e)
        {
            ChangeBtnColor();
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Chocolate;
            flowLayoutPanelBig.Controls.Clear();

            int index = 0;

            if (clickedButton.Name.StartsWith("brut")) 
            { 
                index = Int32.Parse(clickedButton.Name[4..]);
            }

            Label labelTitle = new Label();
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            labelTitle.Text = $"{clickedButton.Text}";
            Label labelInfo = new Label();
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 15);
            labelInfo.Text = $"{unitArray[index].Info}";


            if (unitArray[index].Pic != "picture")
            {
                PictureBox pic = new PictureBox();
                Image newImage = Image.FromFile($"{unitArray[index].Pic}");
                pic.Image = newImage;
                pic.Width = 400;
                pic.Height = 300;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                flowLayoutPanelBig.Controls.Add(pic);
            }


            flowLayoutPanelBig.Controls.Add(labelTitle);
            flowLayoutPanelBig.Controls.Add(labelInfo);
        }

        /// <summary>
        /// Reset Buttons Color
        /// </summary>
        private void ChangeBtnColor()
        {
            foreach (Button button in buttonsArray)
            {
                button.BackColor = Color.OrangeRed;
            }
            if (sideBtns != null)
            {
                foreach (Button button in sideBtns)
                {
                    button.BackColor = Color.OrangeRed;
                }
            }
        }

        /// <summary>
        /// Create the Buttons on the side panel
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMake(int n, object sender, EventArgs e)
        {
            Button senderBtn = (Button)sender;
            senderBtn.BackColor = Color.Chocolate;
            List<Button> tempBtn = new List<Button> { };

            PopulateTheBigPanel(sender, e);
            flowLayoutPanelSmall.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Button button = new Button();
                button.Name = $"brut{i}";
                button.Text = $"{unitArray[i].Name}";
                button.Width = 200;
                button.Height = 80;
                button.BackColor = Color.OrangeRed;
                button.ForeColor = Color.Azure;
                button.Click += new EventHandler(this.PopulateTheBigPanel);
                flowLayoutPanelSmall.Controls.Add(button);
                tempBtn.Add(button);
                if (button.Text.StartsWith("Unit"))
                {
                    button.Visible = false;
                }
            }
            sideBtns = tempBtn;
        }


        private void buttonUnit1_Click(object sender, EventArgs e)
        {
            unitArray = ca.GetInfoByUnit(1);
            ButtonMake(unitArray.Length, sender, e);
        }

        private void buttonUnit2_Click(object sender, EventArgs e)
        {
            unitArray = ca.GetInfoByUnit(2);
            ButtonMake(unitArray.Length, sender, e);
        }

        private void buttonUnit3_Click(object sender, EventArgs e)
        {
            unitArray = ca.GetInfoByUnit(3);
            ButtonMake(unitArray.Length, sender, e);
        }

        private void buttonUnit4_Click(object sender, EventArgs e)
        {
            unitArray = ca.GetInfoByUnit(4);
            ButtonMake(unitArray.Length, sender, e);
        }

        private void buttonUnit5_Click(object sender, EventArgs e)
        {
            unitArray = ca.GetInfoByUnit(5);
            ButtonMake(unitArray.Length, sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 help = new Form2();
            help.ShowDialog();
        }
    }
}