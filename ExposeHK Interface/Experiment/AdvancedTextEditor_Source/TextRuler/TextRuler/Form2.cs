using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

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

        public Form2()
        {
            InitializeComponent();
            Create();
            this.Text = "Virtual Keyboard";
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width/2 - this.Bounds.Width/2   ;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Bounds.Height;
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
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
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
