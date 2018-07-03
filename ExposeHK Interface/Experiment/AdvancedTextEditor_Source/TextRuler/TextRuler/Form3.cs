using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRuler
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            panel3.Location = new Point(
                this.ClientSize.Width / 2 - panel3.Size.Width / 2,
                this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
            String text = "Hello, \r\n\r\n" +
                "You are going to edit a text on one side that we will give you so that it is the same as the one on the other side.\r\n\r\n" +
                "You will edit this text " + Program.rep.ToString() + " times and you have the buttons and keyboard shortcuts to format the text.\r\n\r\n" +
                "In phase 2 we will provide you with a visual aid. Phases 3 and 5 consist of shortcut memorization tests.\r\n\r\n" +
                "Thank you for your participation in our experiment.";
            instruction.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("You must fill all the sections", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (radioButton1.Checked) Program.phase = 1;
            else if (radioButton2.Checked) Program.phase = 2;
            else if (radioButton3.Checked) Program.phase = 3;
            else if (radioButton4.Checked) Program.phase = 4;
            else if (radioButton5.Checked) Program.phase = 5;
            else
            {
                MessageBox.Show("You must fill all the sections", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (radioButton6.Checked) Program.help = "ExposeHK";
            else if (radioButton7.Checked) Program.help = "ExposeKeyboard";
            else if (radioButton8.Checked) Program.help = "StickerKeyboard";
            else if (radioButton9.Checked) Program.help = "Optimus";
            else
            {
                MessageBox.Show("You must fill all the sections", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            Program.name = textBox1.Text;
            Close();
        }
    }
}
