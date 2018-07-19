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
        private string date;
        private string pending = "";
        Stopwatch globalWatch;

        public Form4()
        {
            InitializeComponent();
            panel11.Location = new Point(
                this.ClientSize.Width / 2 - panel11.Size.Width / 2,
                this.ClientSize.Height / 2 - panel11.Size.Height / 2);
            panel11.Anchor = AnchorStyles.None;
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
            //hook.KeyUp += new KeyEventHandler(sender_KeyUp);
            hook.OnMouseActivity += new MouseEventHandler(hook_MouseMove);
            hook.Start();

            date = DateTime.Now.ToString();
            logFile = Program.name + "_" + Program.help + "_" + Program.phase + "-1_" +
                date.Replace(".", "").Replace("/", " ").Replace(":", " ") + " Log";
            globalWatch = new Stopwatch();
            log_init();
            globalWatch.Start();
        }

        public void log_init()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);
            file.WriteLine("Date;Timestamp;Participant;Aid;Phase;BlockID;Device;Event;PosX;PosY;Key;Other");
            file.Close();
        }

        public void log(String s)
        {

            //Debug.WriteLine(s + " " + DateTime.Now + " " + DateTime.Now.Millisecond);

            // create a writer and open the file
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFile + ".txt", true);

            // write a    line of text to the file
            file.WriteLine(DateTime.Now + "." + DateTime.Now.Millisecond + ";" + globalWatch.ElapsedMilliseconds +
                ";" + Program.name + ";" + Program.help + ";" + Program.phase + ";1;" + s);

            // close the stream
            file.Close();

        }

        private void hook_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 0)
            {
                log("Mouse;Click;" + e.X + ";" + e.Y + ";none;none");
            }

            if (e.Clicks == -1)
            {
                log("Mouse;Release;" + e.X + ";" + e.Y + ";none;none");
            }
            log("Mouse;Move;" + e.X + ";" + e.Y + ";none;none");
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            log("Key;Down;none;none;" + e.KeyData + ";none");
            for (int i = 0; i < allShortcuts.Count; i++)
                if (allShortcuts[i].Focused)
                    sender_KeyDown(allShortcuts[i], e);
        }

        private void setTextBox (TextBox textbox, String s)
        {
            if (s.Equals(pending)) return;
            String val = "";
            if (ctrl) val += "Ctrl + ";
            if (shift) val += "Shift + ";
            if (alt) val += "Alt + ";
            val += s;
            if (val.Equals(s)) { textbox.Text = "Shortcut ..."; return; }
            pending = s;
            textbox.Text = val;
            int i = 0;
            for (; i < allShortcuts.Count; i++)
            {
                if (allShortcuts[i] == textbox)
                    break;
            }
            if (i < allShortcuts.Count - 1)
            {
                allShortcuts[i + 1].Focus();
            }
        }

        private void sender_KeyDown(TextBox textBox, KeyEventArgs e)
        {
            //log("KEYPRESS DOWN " + e.KeyData);
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
                case Keys.D1 : setTextBox(textBox, "&"); break;
                case Keys.D2 : setTextBox(textBox, "é"); break;
                case Keys.D3 : setTextBox(textBox, "\""); break;
                case Keys.D4 : setTextBox(textBox, "'"); break;
                case Keys.D5 : setTextBox(textBox, "("); break;
                case Keys.D6 : setTextBox(textBox, "-"); break;
                case Keys.D7 : setTextBox(textBox, "è"); break;
                case Keys.D8 : setTextBox(textBox, "_"); break;
                case Keys.D9 : setTextBox(textBox, "ç"); break;
                case Keys.D0 : setTextBox(textBox, "à"); break;
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
                pending = "";
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = true;
                pending = "";
            }
            if (e.KeyCode == Keys.Menu)
            {
                alt = true;
                pending = "";
            }
        }

        private void sender_KeyUp(object sender, KeyEventArgs e)
        {
            log("Key;Up;none;none;" + e.KeyCode + ";none");
            pending = "";
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

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            sender_KeyDown((TextBox)sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log("none;none;none;none;none;Click " + ((Button)sender).Name);
            globalWatch.Stop();
            for (int i = 0; i < allShortcuts.Count; i++)
            {
                if(allShortcuts[i].Text.Equals("Shortcut ...") || (!allRadios[i * 2].Checked && !allRadios[i * 2 + 1].Checked))
                {
                        MessageBox.Show("You must fill all the shortcuts' propeties", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        return;
                }
            }
            write_log();
            Close();
        }

        private void write_log()
        {
            String logFileTmp = logFile + "_Data";

            // create a writer and open the file
            System.IO.StreamWriter file = new System.IO.StreamWriter(logFileTmp + ".txt", true);
            file.WriteLine("Timestamp;Participant;Aid;Phase;BlockID;Shortcut;LearnedByAid;Comment");
            String tmp = date.Replace(" ", ";") + ";" + Program.name + ";" + Program.help + ";" + Program.phase + ";" + "1;";
            for (int i = 0; i < allShortcuts.Count; i++)
            {
                if(allRadios[i * 2].Checked) //learned by aid
                {
                    if (allAids[i].Equals(""))
                    {
                        Debug.WriteLine(tmp + allShortcuts[i].Text + ";0;none");
                        file.WriteLine(tmp + allShortcuts[i].Text + ";0;none");
                    }
                    else
                    {
                        Debug.WriteLine(tmp + allShortcuts[i].Text + ";0;" + allAids[i].Text);
                        file.WriteLine(tmp + allShortcuts[i].Text + ";0;" + allAids[i].Text);
                    }
                }
                else //learned by self
                {
                    if (allAids[i].Equals(""))
                    {
                        Debug.WriteLine(tmp + allShortcuts[i].Text + ";1;none");
                        file.WriteLine(tmp + allShortcuts[i].Text + ";1;none");
                    }
                    else
                    {
                        Debug.WriteLine(tmp + allShortcuts[i].Text + ";1;" + allAids[i].Text);
                        file.WriteLine(tmp + allShortcuts[i].Text + ";1;" + allAids[i].Text);
                    }
                }
            }
            // close the stream
            file.Close();
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            log("none;none;none;none;none;Click " + ((TextBox)sender).Name);
        }

        private void toolStrip_Click(object sender, EventArgs e)
        {
            log("none;none;none;none;none;Click " + ((ToolStripButton)sender).Name);
        }

        private void radio_Click(object sender, EventArgs e)
        {
            log("none;none;none;none;none;Click " + ((RadioButton)sender).Name);
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
            log("none;none;none;none;none;;Focus Gained");
            Debug.WriteLine("Focus Gained");
        }

        private void Form4_Deactivate(object sender, EventArgs e)
        {
            log("none;none;none;none;none;Focus Lost");
            Debug.WriteLine("Focus Lost");
        }
    }
}
