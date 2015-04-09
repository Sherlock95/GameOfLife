using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Living_Life
{
    public partial class OptionsMenu : Form
    {
        MainScreen mainScreen;
        public OptionsMenu()
        {
            InitializeComponent();
        }
        public OptionsMenu(MainScreen mainScreen0)
        {
            InitializeComponent();
            mainScreen = mainScreen0;
            this.TopMost = true;
        }

        private void btnGetJob_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int r = rand.Next(0,mainScreen.mainGame.jobs.Length);
            mainScreen.mainGame.player.job = mainScreen.mainGame.jobs[r];
        }
    }
}
