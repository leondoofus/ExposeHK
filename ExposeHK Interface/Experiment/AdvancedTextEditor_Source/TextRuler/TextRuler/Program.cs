using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace TextRuler
{
    static class Program
    {
        public static int rep = 2;
        public static String name;
        public static int phase;
        public static String help;

        /* Keyboard detection
        const int KL_NAMELENGTH = 9;

        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(
              System.Text.StringBuilder pwszKLID);
        */

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*StringBuilder name = new StringBuilder(KL_NAMELENGTH);

            GetKeyboardLayoutName(name);

            Console.WriteLine(name);*/

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
            if (name == null || help == null || phase == 0)
                Application.Exit();
            else if (phase == 3 || phase == 5)
                Application.Run(new Form4());
            else
                Application.Run(new Form1(fileName));
        }
    }
}
