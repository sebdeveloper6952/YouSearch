using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace YoutubeSearch
{
    /// <summary>
    /// Handles the operations needed to set the default browser and search
    /// things on YouTube.
    /// </summary>
    class Logic
    {
        // the full path to the browser.exe
        string appPath;
        // this is the YouTube url prefix.
        const string yPrefix = "https://youtube.com/results?search_query=";
        // to choose the path to the default browser;
        OpenFileDialog o;
        
        public Logic()
        {
            o = new OpenFileDialog();
            o.Title = "Please choose your default browser.";
            o.ShowHelp = true;
            o.HelpRequest += new EventHandler(this.ShowHelpText);
            appPath = Properties.Settings.Default.appPath;
        }

        /// <summary>
        /// Shows a OpenFileDialog so the user points to the desired browser.
        /// For example chrome.exe
        /// Saves the path.
        /// </summary>
        public void SetBrowserPath()
        {
            o.ShowDialog();
            appPath = Properties.Settings.Default.appPath = o.FileName;
            Properties.Settings.Default.browserSet = true;
            Properties.Settings.Default.Save();
            //appPath = Properties.Settings.Default.appPath;
        }

        /// <summary>
        /// Takes the text on the TextBox and opens the default browser with 
        /// the YouTube search. If the browser is already open, it opens a new tab.
        /// </summary>
        /// <param name="s">The text the user types on the TextBox</param>
        public void Search(string s)
        {
            string[] search = s.Split(' ');
            string searchS = "";
            for (int i = 0; i < search.Length; i++)
            {
                searchS += search[i];
                searchS += "+";
            }
            Process.Start(appPath, string.Concat(yPrefix, searchS));
        }

        private void ShowHelpText(object sender, EventArgs e)
        {
            MessageBox.Show(@"Please choose the web broser you want to use. The easiest way is to choose 
                             your browser icon from your desktop.");
        }
    }
}
