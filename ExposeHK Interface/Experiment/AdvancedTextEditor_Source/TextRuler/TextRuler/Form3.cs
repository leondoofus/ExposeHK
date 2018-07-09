﻿using gma.System.Windows;
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

namespace TextRuler
{
    public partial class Form3 : Form
    {
        UserActivityHook hook;
        Stopwatch globalWatch;
        String logFile;
        public Form3()
        {
            InitializeComponent();
            panel3.Location = new Point(
                this.ClientSize.Width / 2 - panel3.Size.Width / 2,
                this.ClientSize.Height / 2 - panel3.Size.Height / 2);
            panel3.Anchor = AnchorStyles.None;
            String text = "Hello, \r\n\r\n" +
                "You are going to edit a text on one side that we will give you so that it is the same as the one on the other side.\r\n\r\n" +
                "You will edit the text " + Program.rep.ToString() + " times and you have the buttons and keyboard shortcuts to format the text.\r\n\r\n" +
                "Once you've done editing please click on Done button finish.\r\n\r\n" +
                "In phase 2 we will provide you with a visual aid. Phases 3 and 5 consist of shortcut memorization tests.\r\n\r\n" +
                "Thank you for your participation in our experiment.";
            instruction.Text = text;
            hook = new UserActivityHook();
            hook.KeyDown += new KeyEventHandler(hook_KeyDown);
            hook.KeyUp += new KeyEventHandler(hook_KeyUp);
            hook.OnMouseActivity += new MouseEventHandler(hook_MouseMove);
            hook.Start();
            logFile = "RequestForm_" +
                DateTime.Now.ToString().Replace(".", "").Replace("/", " ").Replace(":", " ") + " Log";
            globalWatch = new Stopwatch();
            globalWatch.Start();
        }

        public void log_init()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);
            file.WriteLine("Timestamp;Event");
            file.Close();
        }

        private void log(string s)
        {
            //Debug.WriteLine(s + " " + DateTime.Now + " " + DateTime.Now.Millisecond);

            // create a writer and open the file
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);

            // write a    line of text to the file
            file.WriteLine(DateTime.Now + " " + DateTime.Now.Millisecond + ";" + s);

            // close the stream
            file.Close();
        }

        private void hook_KeyUp(object sender, KeyEventArgs e)
        {
            log("KEYPRESS UP " + e.KeyData);
        }

        private void hook_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 0)
            {
                log("MOUSE click " + e.Location);
            }

            if (e.Clicks == -1)
            {
                log("MOUSE release " + e.Location);
            }
            log("MOUSE Move " + e.Location);
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            log("KEYPRESS DOWN " + e.KeyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((Button)sender).Name);
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
            globalWatch.Stop();
            log("Total time " + globalWatch.ElapsedMilliseconds);
            hook.Stop();
            Close();
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((RadioButton)sender).Name);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((TextBox)sender).Name);
        }
    }
}
