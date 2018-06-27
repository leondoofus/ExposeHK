using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        bool ctrl = false;
        bool alt = false;
        bool shift = false;

        private void setTextBox (TextBox textbox, String s)
        {
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
    }
}
