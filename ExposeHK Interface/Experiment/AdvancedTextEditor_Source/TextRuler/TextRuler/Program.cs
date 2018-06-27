using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace TextRuler
{
    static class Program
    {
        public static int rep = 2;
        public static String name;
        public static int phase;
        public static int help;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String fileName = "";
            /***
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = false;
            o.RestoreDirectory = true;
            o.ShowReadOnly = false;
            o.ReadOnlyChecked = false;
            o.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
            if (o.ShowDialog() == DialogResult.OK)
            {
                fileName =  o.FileName;
            }
            else
            {
                return;
            }
            ***/
            Application.Run(new Form3());
            if (phase == 3 || phase == 5)
                Application.Run(new Form4());
            else
                Application.Run(new Form1(fileName));
        }
    }
}
