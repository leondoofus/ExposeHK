using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TextRuler.AdvancedTextEditorControl;

namespace TextRuler
{
    public partial class Form2 : Form
    {
        private Size formOriginalSize;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        private Rectangle button6OriginalRect;
        private Rectangle button7OriginalRect;
        private Rectangle button8OriginalRect;
        private Rectangle button9OriginalRect;
        private Rectangle button10OriginalRect;
        private Rectangle button11OriginalRect;
        private Rectangle button12OriginalRect;
        private Rectangle button13OriginalRect;
        private Rectangle button14OriginalRect;
        private Rectangle button15OriginalRect;
        private Rectangle button16OriginalRect;
        private Rectangle button17OriginalRect;
        private Rectangle button18OriginalRect;
        private Rectangle button19OriginalRect;
        private Rectangle button20OriginalRect;
        private Rectangle button21OriginalRect;
        private Rectangle button22OriginalRect;
        private Rectangle button23OriginalRect;
        private Rectangle button24OriginalRect;
        private Rectangle button25OriginalRect;
        private Rectangle button26OriginalRect;
        private Rectangle button27OriginalRect;
        private Rectangle button28OriginalRect;
        private Rectangle button29OriginalRect;
        private Rectangle button30OriginalRect;
        private Rectangle button31OriginalRect;
        private Rectangle button32OriginalRect;
        private Rectangle button33OriginalRect;
        private Rectangle button34OriginalRect;
        private Rectangle button35OriginalRect;
        private Rectangle button36OriginalRect;
        private Rectangle button37OriginalRect;
        private Rectangle button38OriginalRect;
        private Rectangle button39OriginalRect;
        private Rectangle button40OriginalRect;
        private Rectangle button41OriginalRect;
        private Rectangle button42OriginalRect;
        private Rectangle button47OriginalRect;
        private Rectangle button48OriginalRect;
        private Rectangle button49OriginalRect;
        private Rectangle button50OriginalRect;
        private Rectangle button51OriginalRect;
        private Rectangle button52OriginalRect;
        private Rectangle button53OriginalRect;
        private Rectangle button54OriginalRect;
        private Rectangle button55OriginalRect;
        private Rectangle button56OriginalRect;
        private Rectangle button57OriginalRect;
        private Rectangle panel1OriginalRect;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedTextEditor));
        private Image decrease, increase, bold, italic, underline, strike, bullet, number, justify, aLeft, aRight;
        private Image aCenter, copy, paste, undo, redo, cut;
        private List<Button> allButtons = new List<Button>();

        public Form2()
        {
            InitializeComponent();
            Create();
            panel1.Location = new Point(
                this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width/2 - this.Bounds.Width/2   ;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Bounds.Height;
        }

        public void Create()
        {
            this.decrease = ((System.Drawing.Image)(resources.GetObject("DecreaseSizeBtn.Image")));
            this.increase = ((System.Drawing.Image)(resources.GetObject("IncreaseSizeButton.Image")));
            this.bold = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.italic = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.underline = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.strike = ((System.Drawing.Image)(resources.GetObject("btnStrikeThrough.Image")));
            this.bullet = ((System.Drawing.Image)(resources.GetObject("btnBulletedList.Image")));
            this.number = ((System.Drawing.Image)(resources.GetObject("btnNumberedList.Image")));
            this.justify = ((System.Drawing.Image)(resources.GetObject("btnJustify.Image")));
            this.aLeft = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.aRight = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.aCenter = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.copy = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.paste = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.undo = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.redo = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.cut = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));

            this.allButtons.Add(this.button30);
            this.allButtons.Add(this.button29);
            this.allButtons.Add(this.button16);
            this.allButtons.Add(this.button15);
            this.allButtons.Add(this.button57);
            this.allButtons.Add(this.button47);
            this.allButtons.Add(this.button48);
            this.allButtons.Add(this.button49);
            this.allButtons.Add(this.button50);
            this.allButtons.Add(this.button51);
            this.allButtons.Add(this.button52);
            this.allButtons.Add(this.button53);
            this.allButtons.Add(this.button54);
            this.allButtons.Add(this.button55);
            this.allButtons.Add(this.button56);
            this.allButtons.Add(this.button31);
            this.allButtons.Add(this.button32);
            this.allButtons.Add(this.button33);
            this.allButtons.Add(this.button34);
            this.allButtons.Add(this.button35);
            this.allButtons.Add(this.button36);
            this.allButtons.Add(this.button37);
            this.allButtons.Add(this.button38);
            this.allButtons.Add(this.button39);
            this.allButtons.Add(this.button40);
            this.allButtons.Add(this.button41);
            this.allButtons.Add(this.button42);
            this.allButtons.Add(this.button17);
            this.allButtons.Add(this.button18);
            this.allButtons.Add(this.button19);
            this.allButtons.Add(this.button20);
            this.allButtons.Add(this.button21);
            this.allButtons.Add(this.button22);
            this.allButtons.Add(this.button23);
            this.allButtons.Add(this.button24);
            this.allButtons.Add(this.button25);
            this.allButtons.Add(this.button26);
            this.allButtons.Add(this.button27);
            this.allButtons.Add(this.button28);
            this.allButtons.Add(this.button14);
            this.allButtons.Add(this.button13);
            this.allButtons.Add(this.button12);
            this.allButtons.Add(this.button11);
            this.allButtons.Add(this.button10);
            this.allButtons.Add(this.button9);
            this.allButtons.Add(this.button8);
            this.allButtons.Add(this.button7);
            this.allButtons.Add(this.button6);
            this.allButtons.Add(this.button5);
            this.allButtons.Add(this.button4);
            this.allButtons.Add(this.button3);
            this.allButtons.Add(this.button2);
            this.allButtons.Add(this.button1);
        }

        public void Shifted()
        {
            button2.Text = "1";
            button3.Text = "2";
            button4.Text = "3";
            button5.Text = "4";
            button6.Text = "5";
            button7.Text = "6";
            button8.Text = "7";
            button9.Text = "8";
            button10.Text = "9";
            button11.Text = "0";
            button12.Text = "°";
            button13.Text = "+";
            button18.Text = "¨";
            button17.Text = "£";
            button32.Text = "%";
            button31.Text = "µ";
            button57.Text = ">";
            button50.Text = "?";
            button49.Text = ".";
            button48.Text = "/";
            button47.Text = "§";
            button54.Image = null;
            button52.Image = null;
            button21.Image = null;
            button55.Image = null;
            button53.Image = null;
            button27.Image = null;
            button23.Image = null;
            button22.Image = null;
            button42.Image = null;
            button56.Image = null;
            button40.Image = null;
            button36.Image = null;
            button25.Image = null;
            button34.Image = null;
            button26.Image = null;
            button6.Image = null;
            button12.Image = null;
            button35.BackColor = Color.White;
            button33.BackColor = Color.White;
            button38.BackColor = Color.White;
            button37.BackColor = Color.White;
            button35.ForeColor = System.Drawing.Color.Black;
        }

        public void UnShifted()
        {
            button2.Text = "&&";
            button3.Text = "é";
            button4.Text = "\"";
            button5.Text = "\'";
            button6.Text = "(";
            button7.Text = "-";
            button8.Text = "è";
            button9.Text = "_";
            button10.Text = "ç";
            button11.Text = "à";
            button12.Text = ")";
            button13.Text = "=";
            button18.Text = "^";
            button17.Text = "$";
            button32.Text = "ù";
            button31.Text = "*";
            button57.Text = "<";
            button50.Text = ",";
            button49.Text = ";";
            button48.Text = ":";
            button47.Text = "!";
            button54.Image = this.copy;
            button52.Image = this.bold;
            button21.Image = this.italic;
            button55.Image = this.cut;
            button53.Image = this.paste;
            button27.Image = this.undo;
            button23.Image = this.redo;
            button22.Image = this.underline;
            button42.Image = this.strike;
            button56.Image = this.bullet;
            button40.Image = this.number;
            button36.Image = this.justify;
            button25.Image = this.aRight;
            button34.Image = this.aLeft;
            button26.Image = this.aCenter;
            button35.BackColor = Color.Black;
            button33.BackColor = Color.Magenta;
            button38.BackColor = Color.LimeGreen;
            button37.BackColor = Color.DarkCyan;
            button6.Image = this.decrease;
            button12.Image = this.increase;
            button35.ForeColor = System.Drawing.Color.White;
        }

        public void Alted()
        {
            button2.Text = "&";
            button3.Text = "~";
            button4.Text = "#";
            button5.Text = "{";
            button6.Text = "[";
            button7.Text = "|";
            button8.Text = "`";
            button9.Text = "\\";
            button10.Text = "^";
            button11.Text = "@";
            button12.Text = "]";
            button13.Text = "}";
            button18.Text = "";
            button17.Text = "¤";
            button32.Text = "";
            button31.Text = "";
            button57.Text = "";
            button50.Text = "";
            button49.Text = "";
            button48.Text = "";
            button47.Text = "";
            button26.Text = "€";
            button54.Image = null;
            button52.Image = null;
            button21.Image = null;
            button55.Image = null;
            button53.Image = null;
            button27.Image = null;
            button23.Image = null;
            button22.Image = null;
            button42.Image = null;
            button56.Image = null;
            button40.Image = null;
            button36.Image = null;
            button25.Image = null;
            button34.Image = null;
            button26.Image = null;
            button6.Image = null;
            button12.Image = null;
            button35.BackColor = Color.White;
            button33.BackColor = Color.White;
            button38.BackColor = Color.White;
            button37.BackColor = Color.White;
            button35.ForeColor = System.Drawing.Color.Black;
        }

        public void UnAlted()
        {
            button2.Text = "&&";
            button3.Text = "é";
            button4.Text = "\"";
            button5.Text = "\'";
            button6.Text = "(";
            button7.Text = "-";
            button8.Text = "è";
            button9.Text = "_";
            button10.Text = "ç";
            button11.Text = "à";
            button12.Text = ")";
            button13.Text = "=";
            button18.Text = "^";
            button17.Text = "$";
            button32.Text = "ù";
            button31.Text = "*";
            button57.Text = "<";
            button50.Text = ",";
            button49.Text = ";";
            button48.Text = ":";
            button47.Text = "!";
            button26.Text = "E";
            button54.Image = this.copy;
            button52.Image = this.bold;
            button21.Image = this.italic;
            button55.Image = this.cut;
            button53.Image = this.paste;
            button27.Image = this.undo;
            button23.Image = this.redo;
            button22.Image = this.underline;
            button42.Image = this.strike;
            button56.Image = this.bullet;
            button40.Image = this.number;
            button36.Image = this.justify;
            button25.Image = this.aRight;
            button34.Image = this.aLeft;
            button26.Image = this.aCenter;
            button35.BackColor = Color.Black;
            button33.BackColor = Color.Magenta;
            button38.BackColor = Color.LimeGreen;
            button37.BackColor = Color.DarkCyan;
            button6.Image = this.decrease;
            button12.Image = this.increase;
            button35.ForeColor = System.Drawing.Color.White;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.formOriginalSize = this.Size;
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button2OriginalRect = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            button3OriginalRect = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            button4OriginalRect = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);
            button5OriginalRect = new Rectangle(button5.Location.X, button5.Location.Y, button5.Width, button5.Height);
            button6OriginalRect = new Rectangle(button6.Location.X, button6.Location.Y, button6.Width, button6.Height);
            button7OriginalRect = new Rectangle(button7.Location.X, button7.Location.Y, button7.Width, button7.Height);
            button8OriginalRect = new Rectangle(button8.Location.X, button8.Location.Y, button8.Width, button8.Height);
            button9OriginalRect = new Rectangle(button9.Location.X, button9.Location.Y, button9.Width, button9.Height);
            button10OriginalRect = new Rectangle(button10.Location.X, button10.Location.Y, button10.Width, button10.Height);
            button11OriginalRect = new Rectangle(button11.Location.X, button11.Location.Y, button11.Width, button11.Height);
            button12OriginalRect = new Rectangle(button12.Location.X, button12.Location.Y, button12.Width, button12.Height);
            button13OriginalRect = new Rectangle(button13.Location.X, button13.Location.Y, button13.Width, button13.Height);
            button14OriginalRect = new Rectangle(button14.Location.X, button14.Location.Y, button14.Width, button14.Height);
            button15OriginalRect = new Rectangle(button15.Location.X, button15.Location.Y, button15.Width, button15.Height);
            button16OriginalRect = new Rectangle(button16.Location.X, button16.Location.Y, button16.Width, button16.Height);
            button17OriginalRect = new Rectangle(button17.Location.X, button17.Location.Y, button17.Width, button17.Height);
            button18OriginalRect = new Rectangle(button18.Location.X, button18.Location.Y, button18.Width, button18.Height);
            button19OriginalRect = new Rectangle(button19.Location.X, button19.Location.Y, button19.Width, button19.Height);
            button20OriginalRect = new Rectangle(button20.Location.X, button20.Location.Y, button20.Width, button20.Height);
            button21OriginalRect = new Rectangle(button21.Location.X, button21.Location.Y, button21.Width, button21.Height);
            button22OriginalRect = new Rectangle(button22.Location.X, button22.Location.Y, button22.Width, button22.Height);
            button23OriginalRect = new Rectangle(button23.Location.X, button23.Location.Y, button23.Width, button23.Height);
            button24OriginalRect = new Rectangle(button24.Location.X, button24.Location.Y, button24.Width, button24.Height);
            button25OriginalRect = new Rectangle(button25.Location.X, button25.Location.Y, button25.Width, button25.Height);
            button26OriginalRect = new Rectangle(button26.Location.X, button26.Location.Y, button26.Width, button26.Height);
            button27OriginalRect = new Rectangle(button27.Location.X, button27.Location.Y, button27.Width, button27.Height);
            button28OriginalRect = new Rectangle(button28.Location.X, button28.Location.Y, button28.Width, button28.Height);
            button29OriginalRect = new Rectangle(button29.Location.X, button29.Location.Y, button29.Width, button29.Height);
            button30OriginalRect = new Rectangle(button30.Location.X, button30.Location.Y, button30.Width, button30.Height);
            button31OriginalRect = new Rectangle(button31.Location.X, button31.Location.Y, button31.Width, button31.Height);
            button32OriginalRect = new Rectangle(button32.Location.X, button32.Location.Y, button32.Width, button32.Height);
            button33OriginalRect = new Rectangle(button33.Location.X, button33.Location.Y, button33.Width, button33.Height);
            button34OriginalRect = new Rectangle(button34.Location.X, button34.Location.Y, button34.Width, button34.Height);
            button35OriginalRect = new Rectangle(button35.Location.X, button35.Location.Y, button35.Width, button35.Height);
            button36OriginalRect = new Rectangle(button36.Location.X, button36.Location.Y, button36.Width, button36.Height);
            button37OriginalRect = new Rectangle(button37.Location.X, button37.Location.Y, button37.Width, button37.Height);
            button38OriginalRect = new Rectangle(button38.Location.X, button38.Location.Y, button38.Width, button38.Height);
            button39OriginalRect = new Rectangle(button39.Location.X, button39.Location.Y, button39.Width, button39.Height);
            button40OriginalRect = new Rectangle(button40.Location.X, button40.Location.Y, button40.Width, button40.Height);
            button41OriginalRect = new Rectangle(button41.Location.X, button41.Location.Y, button41.Width, button41.Height);
            button42OriginalRect = new Rectangle(button42.Location.X, button42.Location.Y, button42.Width, button42.Height);
            button47OriginalRect = new Rectangle(button47.Location.X, button47.Location.Y, button47.Width, button47.Height);
            button48OriginalRect = new Rectangle(button48.Location.X, button48.Location.Y, button48.Width, button48.Height);
            button49OriginalRect = new Rectangle(button49.Location.X, button49.Location.Y, button49.Width, button49.Height);
            button50OriginalRect = new Rectangle(button50.Location.X, button50.Location.Y, button50.Width, button50.Height);
            button51OriginalRect = new Rectangle(button51.Location.X, button51.Location.Y, button51.Width, button51.Height);
            button52OriginalRect = new Rectangle(button52.Location.X, button52.Location.Y, button52.Width, button52.Height);
            button53OriginalRect = new Rectangle(button53.Location.X, button53.Location.Y, button53.Width, button53.Height);
            button54OriginalRect = new Rectangle(button54.Location.X, button54.Location.Y, button54.Width, button54.Height);
            button55OriginalRect = new Rectangle(button55.Location.X, button55.Location.Y, button55.Width, button55.Height);
            button56OriginalRect = new Rectangle(button56.Location.X, button56.Location.Y, button56.Width, button56.Height);
            button57OriginalRect = new Rectangle(button57.Location.X, button57.Location.Y, button57.Width, button57.Height);
            panel1OriginalRect = new Rectangle(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            resizeControl(panel1OriginalRect, panel1);
            resizeControl(button1OriginalRect, button1);
            resizeControl(button2OriginalRect, button2);
            resizeControl(button3OriginalRect, button3);
            resizeControl(button4OriginalRect, button4);
            resizeControl(button5OriginalRect, button5);
            resizeControl(button6OriginalRect, button6);
            resizeControl(button7OriginalRect, button7);
            resizeControl(button8OriginalRect, button8);
            resizeControl(button9OriginalRect, button9);
            resizeControl(button10OriginalRect, button10);
            resizeControl(button11OriginalRect, button11);
            resizeControl(button12OriginalRect, button12);
            resizeControl(button13OriginalRect, button13);
            resizeControl(button14OriginalRect, button14);
            resizeControl(button15OriginalRect, button15);
            resizeControl(button16OriginalRect, button16);
            resizeControl(button17OriginalRect, button17);
            resizeControl(button18OriginalRect, button18);
            resizeControl(button19OriginalRect, button19);
            resizeControl(button20OriginalRect, button20);
            resizeControl(button21OriginalRect, button21);
            resizeControl(button22OriginalRect, button22);
            resizeControl(button23OriginalRect, button23);
            resizeControl(button24OriginalRect, button24);
            resizeControl(button25OriginalRect, button25);
            resizeControl(button26OriginalRect, button26);
            resizeControl(button27OriginalRect, button27);
            resizeControl(button28OriginalRect, button28);
            resizeControl(button29OriginalRect, button29);
            resizeControl(button30OriginalRect, button30);
            resizeControl(button31OriginalRect, button31);
            resizeControl(button32OriginalRect, button32);
            resizeControl(button33OriginalRect, button33);
            resizeControl(button34OriginalRect, button34);
            resizeControl(button35OriginalRect, button35);
            resizeControl(button36OriginalRect, button36);
            resizeControl(button37OriginalRect, button37);
            resizeControl(button38OriginalRect, button38);
            resizeControl(button39OriginalRect, button39);
            resizeControl(button40OriginalRect, button40);
            resizeControl(button41OriginalRect, button41);
            resizeControl(button42OriginalRect, button42);
            resizeControl(button47OriginalRect, button47);
            resizeControl(button48OriginalRect, button48);
            resizeControl(button49OriginalRect, button49);
            resizeControl(button50OriginalRect, button50);
            resizeControl(button51OriginalRect, button51);
            resizeControl(button52OriginalRect, button52);
            resizeControl(button53OriginalRect, button53);
            resizeControl(button54OriginalRect, button54);
            resizeControl(button55OriginalRect, button55);
            resizeControl(button56OriginalRect, button56);
            resizeControl(button57OriginalRect, button57);
        }

        private void resizeControl (Rectangle originalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(originalControlRect.X * xRatio);
            int newY = (int)(originalControlRect.Y * yRatio);
            int newWidth = (int)(originalControlRect.Width * xRatio);
            int newHeight = (int)(originalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        public void myDispose(bool disposing)
        {
            Dispose(disposing);
        }
    }

    
}
