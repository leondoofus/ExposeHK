using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TextRuler
{
    public partial class Form2 : Form
    {
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
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            double ratio = (double)control.Size.Width / (double)control.Size.Height;
            //By calculating 2.84864
            if (ratio >= 2.80833) //size calculated by width
            {

            }
            else //size calculated by width
            {

            }
            Debug.WriteLine(ratio);
            /*foreach (Button b in allButtons)
            {
                Console.WriteLine(b.Text);
            }*/
            /*
           

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new System.Drawing.Size(control.Size.Width, control.Size.Width);
            }*/
        }
    }
}
