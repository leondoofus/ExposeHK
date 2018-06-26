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
            Console.WriteLine("Ici");
            String val = "";
            if (ctrl) val += "Ctrl + ";
            if (shift) val += "Shift + ";
            if (alt) val += "Alt + ";
            val += s;
            textbox.Text = val;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.E:
                    setTextBox(this.sender, "E");
                    break;
                case Keys.L:
                    setTextBox(this.sender, "L");
                    break;
                case Keys.R:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.W:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.C:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.X:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.I:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.J:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.N:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.D:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.O:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.V:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.P:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.Y:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.S:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.Q:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.U:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.Z:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.G:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.K:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.H:
                    setTextBox(this.sender, "B");
                    break;
                case Keys.M:
                    setTextBox(this.sender, "B");
                    break;
                //AZERTY keyboard
                case Keys.OemBackslash:
                    if (!shift)
                    {
                        setTextBox(this.sender, "<");
                    }
                    else
                    {
                        setTextBox(this.sender, ">");
                    }
                    break;
            }
            Console.WriteLine(e.KeyData);
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
                Console.WriteLine("in ctrl");
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = true;
                Console.WriteLine("in shft");
            }
            if (e.KeyCode == Keys.Menu)
            {
                alt = true;
                Console.WriteLine("in alt");
            }
        }

    }
}
