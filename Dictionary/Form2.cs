using System;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form2 : Form
    {
        #region Initialization

        static readonly CatalogAcces ca = new CatalogAcces("Data Source=Dictionary.db");
        DictClass[] unitArray;
        TextBox[] textBoxes;
        Label[] labels;
        Button[] buttons;

        int id;
        int unit;
        string name;
        string info;
        string pic;
        string link;
        public Form2()
        {
            InitializeComponent();

            textBoxes = new TextBox[] { textBox1, textBox2, textBox3 };
            labels = new Label[] { label1, label2, label3, label4 };
            buttons = new Button[] { button9, button8, button7, button6, button5 };

            ShowOrHide(false);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Hide/Unhide Controls used for Create and Update on the big container
        /// </summary>
        private void ShowOrHide(bool show)
        {
            bool a = show == true? groupBox1.Visible = true : groupBox1.Visible = false;
            bool b = show == true ? richTextBox1.Visible = true : richTextBox1.Visible = false;
            
            dataGridView1.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;

            foreach (var item in textBoxes)
            {
                if (show)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }

            foreach (var item in labels)
            {
                if (show)
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }

            foreach (var item in buttons)
            {
                item.Visible = false;
            }
        }

        /// <summary>
        /// Disable or Disable the Controls for Update Function
        /// </summary>
        /// <param name="dis"></param>
        private void AbleOrDisable( bool dis )
        {
            bool a = dis == true ? groupBox1.Enabled = true : groupBox1.Enabled = false;
            bool b = dis == true ? richTextBox1.Enabled = true : richTextBox1.Enabled = false;
            textBox4.Enabled = false;
            label5.Enabled = false;

            foreach (var item in textBoxes)
            {
                if (dis)
                {
                    item.Enabled = true;
                }
                else
                {
                    item.Enabled = false;
                }
            }

            foreach (var item in labels)
            {
                if (dis)
                {
                    item.Enabled = true;
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }

        #endregion

        #region SideButtons

        /// <summary>
        /// Show Create Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ShowOrHide(true);
            AbleOrDisable(true);
            button5.Visible = true;
        }

        /// <summary>
        /// Show Update Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ShowOrHide(true);
            AbleOrDisable(false);
            textBox4.Enabled = true;
            button8.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            dataGridView1.Visible = true;
            button9.Visible = true;
        }

        /// <summary>
        /// Show Delete Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ShowOrHide(false);
            textBox4.Enabled = true;
            button7.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            dataGridView1.Visible = true;
            button9.Visible = true;
        }


        /// <summary>
        /// Show Id, Name and Unit Fields from database to get the ID you need
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            unitArray = ca.ShowAll();
            dataGridView1.Visible = true;
            dataGridView1.DataSource = unitArray;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        #endregion

        #region ControlButtons
        /// <summary>
        /// Create Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            info = richTextBox1.Text;
            pic = textBox2.Text;
            if (pic == "") { pic = "picture"; };
            link = textBox3.Text;
            if (link == "") { link = "link"; };

            DictClass CreateField = new DictClass(unit, name, info, pic, link);
            ca.CreateNewField(CreateField);

            this.Close();
        }

        /// <summary>
        /// Find the Field by ID Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            var fieldInfo = ca.GetInfoById(Int32.Parse(textBox4.Text));
            textBox1.Text = fieldInfo.Name;
            textBox2.Text = fieldInfo.Pic;
            textBox3.Text = fieldInfo.Link;
            richTextBox1.Text = fieldInfo.Info;
            switch (fieldInfo.Unit)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
                default:
                    radioButton5.Checked = true;
                    break;
            }
            AbleOrDisable(true);
            button6.Visible = true;
            dataGridView1.Visible = false;
        }

        /// <summary>
        /// Update Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            id = Int32.Parse(textBox4.Text);
            name = textBox1.Text;
            info = richTextBox1.Text;
            pic = textBox2.Text;
            if (pic == "") { pic = "picture"; };
            link = textBox3.Text;
            if (link == "") { link = "link"; };

            DictClass updateField = new DictClass(id, unit, name, info, pic, link);
            ca.UpdateField(updateField);

            this.Close();
        }

        /// <summary>
        /// Delete Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                id = Int32.Parse(textBox4.Text);
                if (id < 29 && id > 1)
                {
                    MessBox("protected");
                }else if(id<1)
                {
                    MessBox("negative");
                }
                else
                {
                    var war = MessageBox.Show(@"Are you sure?
If you delete the field 
all information will be gone!", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (war == DialogResult.Yes)
                    {
                        DictClass deleteField = new DictClass(id);
                        ca.DeleteField(deleteField);
                        this.Close();
                    }
                }
            }
            catch (FormatException)
            {
                MessBox("letter");
            }
        }

        /// <summary>
        /// Error Messages.
        /// </summary>
        /// <param name="why"></param>
        private void MessBox(string why)
        {
            string text = "Something went wrong!";
            switch (why)
            {
                case "letter":
                    text += @"
That doesn't look like a number.";
                    break;
                case "negative":
                    text += @"
The ID can't be smaller than 1";
                    break;
                case "protected":
                    text += @"
You are not able to delete
protected fields";
                    break;
                default:
                    text += @"
check the ID you've entered";
                    break;
            }
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Cancel Button to close the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Radio Buttons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            unit = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            unit = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            unit = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            unit = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            unit = 5;
        }
        #endregion

        #endregion

    }
}
