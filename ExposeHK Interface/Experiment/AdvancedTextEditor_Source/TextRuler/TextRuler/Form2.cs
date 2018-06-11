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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Create();
            this.Text = "Virtual Keyboard";
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Bounds.Width;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Bounds.Height;
        }
    }
}
