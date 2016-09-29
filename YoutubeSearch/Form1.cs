using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YoutubeSearch
{
    public partial class Form1 : Form
    {
        Logic l;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            l = new Logic();
            if(!Properties.Settings.Default.browserSet)
            {
                l.SetBrowserPath();
            }
        }

        
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            { l.Search(tB_SearchText.Text); }
            catch { }
        }

        private void tB_SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                { l.Search(tB_SearchText.Text); }
                catch { }
            }
        }

        private void setBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l.SetBrowserPath();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show something :p
            MessageBox.Show("Made for fun by Sebastian Arriola.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
