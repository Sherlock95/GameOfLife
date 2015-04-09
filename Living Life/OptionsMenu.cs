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
        public MainScreen mainScreen;
        public OptionsMenu()
        {
            InitializeComponent();
        }
        public OptionsMenu(MainScreen mainScreen)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.TopMost = true;
        }

        private void btnGetJob_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int r = rand.Next(0,mainScreen.mainGame.jobs.Length);
            mainScreen.mainGame.player.job = mainScreen.mainGame.jobs[r];
        }

        private void btnBuyHouse_Click(object sender, EventArgs e)
        {
            (new BuyHouse(this)).Show();
            this.Enabled = false;
        }

        private void btnBuyCar_Click(object sender, EventArgs e)
        {
            (new BuyCar(this)).Show();
            this.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                mainScreen.Close();
                return;
            }

            mainScreen.Enabled = true;
        }

        // Need a way of telling if an option was chosen.
        private void btnContinue_Click(object sender, EventArgs e)
        {
            mainScreen.Enabled = true;
            this.Close();
        }
    }
}
