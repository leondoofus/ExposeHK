using gma.System.Windows;
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
using TextRuler.AdvancedTextEditorControl;

namespace TextRuler
{
    public partial class Form4 : Form
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(AdvancedTextEditor));
        UserActivityHook hook;
        bool ctrl = false;
        bool alt = false;
        bool shift = false;
        private List<TextBox> allShortcuts = new List<TextBox>();
        private List<RadioButton> allRadios = new List<RadioButton>();
        private List<TextBox> allAids = new List<TextBox>();
        private string logFile;

        public Form4()
        {
            InitializeComponent();
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("DecreaseSizeBtn.Image")));
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("IncreaseSizeButton.Image")));
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("btnStrikeThrough.Image")));
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("btnBulletedList.Image")));
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("btnNumberedList.Image")));
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("btnJustify.Image")));
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));

            allShortcuts.Add(textBox1);
            allShortcuts.Add(textBox2);
            allShortcuts.Add(textBox3);
            allShortcuts.Add(textBox4);
            allShortcuts.Add(textBox5);
            allShortcuts.Add(textBox6);
            allShortcuts.Add(textBox7);
            allShortcuts.Add(textBox8);
            allShortcuts.Add(textBox9);
            allShortcuts.Add(textBox10);
            allShortcuts.Add(textBox11);
            allShortcuts.Add(textBox12);
            allShortcuts.Add(textBox13);
            allShortcuts.Add(textBox14);
            allShortcuts.Add(textBox15);
            allShortcuts.Add(textBox16);
            allShortcuts.Add(textBox17);
            allShortcuts.Add(textBox18);
            allShortcuts.Add(textBox19);
            allShortcuts.Add(textBox20);
            allShortcuts.Add(textBox21);

            allRadios.Add(radioButton1);
            allRadios.Add(radioButton2);
            allRadios.Add(radioButton3);
            allRadios.Add(radioButton4);
            allRadios.Add(radioButton5);
            allRadios.Add(radioButton6);
            allRadios.Add(radioButton7);
            allRadios.Add(radioButton8);
            allRadios.Add(radioButton9);
            allRadios.Add(radioButton10);
            allRadios.Add(radioButton11);
            allRadios.Add(radioButton12);
            allRadios.Add(radioButton13);
            allRadios.Add(radioButton14);
            allRadios.Add(radioButton15);
            allRadios.Add(radioButton16);
            allRadios.Add(radioButton17);
            allRadios.Add(radioButton18);
            allRadios.Add(radioButton19);
            allRadios.Add(radioButton20);
            allRadios.Add(radioButton21);
            allRadios.Add(radioButton22);
            allRadios.Add(radioButton23);
            allRadios.Add(radioButton24);
            allRadios.Add(radioButton25);
            allRadios.Add(radioButton26);
            allRadios.Add(radioButton27);
            allRadios.Add(radioButton28);
            allRadios.Add(radioButton29);
            allRadios.Add(radioButton30);
            allRadios.Add(radioButton31);
            allRadios.Add(radioButton32);
            allRadios.Add(radioButton33);
            allRadios.Add(radioButton34);
            allRadios.Add(radioButton35);
            allRadios.Add(radioButton36);
            allRadios.Add(radioButton37);
            allRadios.Add(radioButton38);
            allRadios.Add(radioButton39);
            allRadios.Add(radioButton40);
            allRadios.Add(radioButton41);
            allRadios.Add(radioButton42);
            allRadios.Add(radioButton43);
            allRadios.Add(radioButton44);

            allAids.Add(textBox22);
            allAids.Add(textBox23);
            allAids.Add(textBox24);
            allAids.Add(textBox25);
            allAids.Add(textBox26);
            allAids.Add(textBox27);
            allAids.Add(textBox28);
            allAids.Add(textBox29);
            allAids.Add(textBox30);
            allAids.Add(textBox31);
            allAids.Add(textBox32);
            allAids.Add(textBox33);
            allAids.Add(textBox34);
            allAids.Add(textBox35);
            allAids.Add(textBox36);
            allAids.Add(textBox37);
            allAids.Add(textBox38);
            allAids.Add(textBox39);
            allAids.Add(textBox40);
            allAids.Add(textBox41);
            allAids.Add(textBox42);

            hook = new UserActivityHook();
            hook.KeyDown += new KeyEventHandler(hook_KeyDown);
            hook.KeyUp += new KeyEventHandler(sender_KeyUp);
            hook.OnMouseActivity += new MouseEventHandler(hook_MouseMove);
            hook.Start();

            logFile = Program.name + "_" + Program.phase.ToString() + "_" + Program.help.ToString() + "_" +
                DateTime.Now.ToString().Replace(".", "").Replace("/", " ").Replace(":", " ") + " Log";
        }

        public void log(String s)
        {

            Debug.WriteLine(s + " " + DateTime.Now + " " + DateTime.Now.Millisecond);

            // create a writer and open the file
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);

            // write a    line of text to the file
            file.WriteLine(s + " " + DateTime.Now + " " + DateTime.Now.Millisecond);

            // close the stream
            file.Close();

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
            for (int i = 0; i < allShortcuts.Count; i++)
                if (allShortcuts[i].Focused)
                    sender_KeyDown(allShortcuts[i], e);
        }

        private void setTextBox (TextBox textbox, String s)
        {
            Console.WriteLine("ICI");
            String val = "";
            if (ctrl) val += "Ctrl + ";
            if (shift) val += "Shift + ";
            if (alt) val += "Alt + ";
            val += s;
            if (val.Equals(s)) { textbox.Text = "Shorcut ..."; return; }
            textbox.Text = val;
        }

        private void sender_KeyDown(TextBox textBox, KeyEventArgs e)
        {
            log("KEYPRESS DOWN " + e.KeyData);
            switch (e.KeyCode)
            {
                case Keys.A : setTextBox(textBox, "A"); break;
                case Keys.Z : setTextBox(textBox, "Z"); break;
                case Keys.E : setTextBox(textBox, "E"); break;
                case Keys.R : setTextBox(textBox, "R"); break;
                case Keys.T : setTextBox(textBox, "T"); break;
                case Keys.Y : setTextBox(textBox, "Y"); break;
                case Keys.U : setTextBox(textBox, "U"); break;
                case Keys.I : setTextBox(textBox, "I"); break;
                case Keys.O : setTextBox(textBox, "O"); break;
                case Keys.P : setTextBox(textBox, "P"); break;
                case Keys.Q : setTextBox(textBox, "Q"); break;
                case Keys.S : setTextBox(textBox, "S"); break;
                case Keys.D : setTextBox(textBox, "D"); break;
                case Keys.F : setTextBox(textBox, "F"); break;
                case Keys.G : setTextBox(textBox, "G"); break;
                case Keys.H : setTextBox(textBox, "H"); break;
                case Keys.J : setTextBox(textBox, "J"); break;
                case Keys.K : setTextBox(textBox, "K"); break;
                case Keys.L : setTextBox(textBox, "L"); break;
                case Keys.M : setTextBox(textBox, "M"); break;
                case Keys.W : setTextBox(textBox, "W"); break;
                case Keys.X : setTextBox(textBox, "X"); break;
                case Keys.C : setTextBox(textBox, "C"); break;
                case Keys.V : setTextBox(textBox, "V"); break;
                case Keys.B : setTextBox(textBox, "B"); break;
                case Keys.N : setTextBox(textBox, "N"); break;
                case Keys.OemBackslash: setTextBox(textBox, "<"); break;
                case Keys.OemOpenBrackets : setTextBox(textBox, ")"); break;
                case Keys.Oemplus : setTextBox(textBox, "="); break;
                case Keys.Oem6 : setTextBox(textBox, "^"); break;
                case Keys.Oem1 : setTextBox(textBox, "$"); break;
                case Keys.Oemtilde : setTextBox(textBox, "ù"); break;
                case Keys.Oem5 : setTextBox(textBox, "*"); break;
                case Keys.Oemcomma : setTextBox(textBox, ","); break;
                case Keys.OemPeriod : setTextBox(textBox, ";"); break;
                case Keys.OemQuestion : setTextBox(textBox, ":"); break;
                case Keys.Oem8 : setTextBox(textBox, "!"); break;
                case Keys.Oem7 : setTextBox(textBox, "²"); break;
                case Keys.D1 : setTextBox(textBox, "1"); break;
                case Keys.D2 : setTextBox(textBox, "2"); break;
                case Keys.D3 : setTextBox(textBox, "3"); break;
                case Keys.D4 : setTextBox(textBox, "4"); break;
                case Keys.D5 : setTextBox(textBox, "5"); break;
                case Keys.D6 : setTextBox(textBox, "6"); break;
                case Keys.D7 : setTextBox(textBox, "7"); break;
                case Keys.D8 : setTextBox(textBox, "8"); break;
                case Keys.D9 : setTextBox(textBox, "9"); break;
                case Keys.D0 : setTextBox(textBox, "0"); break;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = true;
            }
            if (e.KeyCode == Keys.Menu)
            {
                alt = true;
            }
        }

        private void sender_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = false;
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = false;
            }
            if (e.KeyCode == Keys.Menu)
            {
                alt = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox1, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox2, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox3, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox4, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox5, e);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox6, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox7, e);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox8, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox9, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox10, e);
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox11, e);
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox12, e);
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox13, e);
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox14, e);
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox15, e);
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox16, e);
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox17, e);
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox18, e);
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox19, e);
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox20, e);
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown(textBox21, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < allShortcuts.Count; i++)
            {
                if (!allShortcuts[i].Text.Equals("Shortcut ..."))
                {
                    if (!allRadios[i*2].Checked && !allRadios[i * 2 + 1].Checked)
                    {
                        MessageBox.Show("Error in line " + (i+1).ToString(), "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            write_log();
            Close();
        }

        private void write_log()
        {
            logFile += "_Data";

            // create a writer and open the file
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);
            
            for (int i = 0; i < allShortcuts.Count; i++)
            {
                if (allShortcuts[i].Text.Equals("Shortcut ..."))
                {
                    file.WriteLine("null\t0\tnull");
                }
                else
                {
                    if(allRadios[i * 2].Checked)
                    {
                        if(allAids[i].Equals(""))
                            file.WriteLine(allShortcuts[i].Text+"\t0\tnull");
                        else
                            file.WriteLine(allShortcuts[i].Text + "\t1\t"+allAids[i].Text);
                    }
                }
            }
            // close the stream
            file.Close();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((TextBox)sender).Name);
        }

        private void toolStrip_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((ToolStripButton)sender).Name);
        }

        private void radio_Click(object sender, EventArgs e)
        {
            log("CLICK " + ((RadioButton)sender).Name);
        }
    }
}
