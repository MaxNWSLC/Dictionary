using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form1 : Form
    {
        private Color primaryBack = Color.MediumAquamarine;
        private Color primaryFont = Color.DarkGreen;
        private Color primarySelect = Color.MediumSeaGreen;
        private Color secondaryBack = Color.Khaki;
        private Color secondaryFont = Color.Maroon;
        private Color secondarySelect = Color.DarkKhaki;

        static readonly CatalogAcces ca = new CatalogAcces("Data Source=Dictionary.db");
        Button[] buttonsArray;
        DictClass[] unitArray;
        List<Button> sideBtns = new List<Button> { };
        string linkLink = "https://www.google.com/";


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
            ChangeBtnColor(sender);
            Button clickedButton = (Button)sender;
            if (clickedButton.Text.StartsWith("Unit"))
            {
                clickedButton.BackColor = primarySelect;
                clickedButton.ForeColor = primaryFont;
            }
            else
            {
                clickedButton.BackColor = secondarySelect;
                clickedButton.ForeColor = secondaryFont;
            }

            flowLayoutPanelBig.Controls.Clear();

            //we need index to show correct info
            int index = 0;
            if (clickedButton.Name.StartsWith("brut"))
            {
                index = Int32.Parse(clickedButton.Name[4..]);
            }

            //Title
            Label labelTitle = new Label();
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            labelTitle.Text = $"{clickedButton.Text}";

            //Info
            Label labelInfo = new Label();
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 15);
            labelInfo.Text = $"{unitArray[index].Info}";

            //Link
            LinkLabel linkLabelText = new LinkLabel();
            linkLabelText.AutoSize = true;
            linkLabelText.Font = new Font("Segoe UI", 15);
            linkLabelText.Text = "For more Info click me.";
            linkLabelText.Click += new EventHandler(this.openLink);

            //Picture
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

            //if there is no link in the database we send user to google :D
            if (unitArray[index].Link != "link")
            {
                linkLink = $"{unitArray[index].Link}";
            }
            else
            {
                linkLink = $"https://www.google.com/search?q={unitArray[index].Name}";
            }

            //We populate the Big Panel 
            flowLayoutPanelBig.Controls.Add(labelTitle);
            flowLayoutPanelBig.Controls.Add(labelInfo);
            flowLayoutPanelBig.Controls.Add(linkLabelText);
        }

        /// <summary>
        /// It's making the link openable in Chrome browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLink(object sender, EventArgs e)
        {
            LinkLabel linkLabelText = (LinkLabel)sender;
            linkLabelText.LinkVisited = true;

            var processes = Process.GetProcessesByName("Chrome");
            var path = processes.FirstOrDefault()?.MainModule?.FileName;
            Process.Start(path, linkLink);
        }

        /// <summary>
        /// Reset Buttons Color
        /// </summary>
        private void ChangeBtnColor(Object Sender)
        {
            if (buttonsArray.Contains(Sender))
            {
                foreach (Button button in buttonsArray)
                {
                    button.BackColor = primaryBack;
                    button.ForeColor = primaryFont;
                }
            }
            if (sideBtns != null)
            {
                foreach (Button button in sideBtns)
                {
                    button.BackColor = secondaryBack;
                    button.ForeColor = secondaryFont;
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
            senderBtn.BackColor = primaryBack;
            List<Button> tempBtn = new List<Button> { };

            PopulateTheBigPanel(sender, e);
            flowLayoutPanelSmall.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Button button = new Button();
                button.Name = $"brut{i}";
                button.Text = $"{unitArray[i].Name}";
                button.Width = 195;
                button.Height = 80;
                button.BackColor = secondaryBack;
                button.ForeColor = secondaryFont;
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Form2 help = new Form2();
            help.ShowDialog();
        }
    }
}