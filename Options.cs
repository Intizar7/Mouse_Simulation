using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_Simulation
{
    public partial class Options : Form
    {
        public bool StopReplay=false;

        public Options()
        {
            InitializeComponent();
        }

        private void web_recorder_settings_Click(object sender, EventArgs e)
        {
            webScrape web = new webScrape();
            this.Hide();
            web.ShowDialog();
            this.Close();
        }

        private void plugin_settings_Click(object sender, EventArgs e)
        {
            browser browsers = new browser();
            this.Hide();
            browsers.ShowDialog();
            this.Close();
        }
        private void EscapeReplay(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                StopReplay = true;
        }
    }
}
