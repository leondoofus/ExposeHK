using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using OfficeWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace TextRuler
{
    public partial class Form1 : Form
    {
        String filetoOpen = "";
        public Form1(String file)
        {
            filetoOpen = file;
            filetoOpen = "startPoint.rtf";
            InitializeComponent();
            this.advancedTextEditor1.openFile(filetoOpen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;

            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Bounds.Height / 2);
            

            this.Focus();
            this.BringToFront();
            this.Activate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /***
            DialogResult res = MessageBox.Show(
                this,
                "Save changes?",
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            switch (res)
            {
                case DialogResult.Yes: this.advancedTextEditor1.Save(true); return;
                case DialogResult.No: return;
                case DialogResult.Cancel: return;
                default: Debug.Assert(false); return;
            }
            ***/
            //this.advancedTextEditor1.TextEditor.SaveFile(advancedTextEditor1.logFile + "TextFile.rtf", RichTextBoxStreamType.RichText);
            this.advancedTextEditor1.TextEditor.SaveFile("tmp.rtf", RichTextBoxStreamType.RichText);
            OfficeWord.Application wordApp = new OfficeWord.Application();
            wordApp.Visible = true;
            string dir = Directory.GetCurrentDirectory();
            object filename1 = dir+"/test.docx";
            object filename2 = dir+"tmp.rtf";
            object missing = System.Reflection.Missing.Value;
            object readonlyobj = false;
            OfficeWord.Application app = new OfficeWord.Application();
            /*Document doc1 = app.Documents.Open(
            ref filename1, ref missing, ref readonlyobj, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);*/
            /*doc1.TrackRevisions = true;
            doc1.ShowRevisions = false;
            doc1.PrintRevisions = true;*/
            Document doc2 = app.Documents.Open(
            ref filename2, ref missing, ref readonlyobj, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            /*doc2.TrackRevisions = true;
            doc2.ShowRevisions = false;
            doc2.PrintRevisions = true;*/
            //Document docx = wordApp.CompareDocuments(doc1, doc2, WdCompareDestination.wdCompareDestinationNew, WdGranularity.wdGranularityWordLevel,
            //    true, true, true, true, true, true, true, true, true, true, "", true);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.advancedTextEditor1.log("Focus Gained");
            Debug.WriteLine("Focus Gained");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.advancedTextEditor1.log("Focus Lost");
            Debug.WriteLine("Focus Lost");
        }

        private void advancedTextEditor1_Load(object sender, EventArgs e)
        {

        }

        /***
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        ***/


    }
}
