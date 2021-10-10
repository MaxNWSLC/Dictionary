using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form2 : Form
    {
        TextBox[] textBoxes;
        Label[] labels;
        public Form2()
        {
            InitializeComponent();

            textBoxes = new TextBox[] { textBox1, textBox2, textBox3 };
            labels = new Label[] { label1, label2, label3, label4 };

            containerControlParts(false);
        }

        /// <summary>
        /// Hide/Unhide Controls used for Create and Update on the big container
        /// </summary>
        private void containerControlParts(bool show)
        {
            bool a = show == true? checkedListBox1.Visible = true : checkedListBox1.Visible = false;
            bool b = show == true ? richTextBox1.Visible = true : richTextBox1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
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
        }


        /// <summary>
        /// Create Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Update Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Delete Field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Show Create Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            containerControlParts(true);
            button5.Visible = true;
        }
        /// <summary>
        /// Show Update Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            containerControlParts(true);
            button6.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
        }
        /// <summary>
        /// Show Delete Controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            containerControlParts(false);
            button7.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            containerControlParts(false);
        }
    }
}
