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
        public MainScreen mainScreen;  //gets the main screen so we can get game info
        public Player player;  
        public OptionsMenu()
        {
            InitializeComponent();

            if(mainScreen.mainGame.player.schoolMonths>0)  //checks to see if in college
            {
                btnGoToCollege.Text = "Drop Out Of College";  //sets college button to tell player they are in college
            }
        }

        public OptionsMenu(MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;  //sets mainscreen so we can have game stuffs
            this.TopMost = true;  //sets this to the top scree
            this.player = mainScreen.mainGame.player;
        }

        private void btnGetJob_Click(object sender, EventArgs e)
        {
      
            (new GetJob(this)).Show();  //makes a get job form
            this.Enabled = false;  //prevents user from messing with things while picking a job

        }

        private void btnBuyHouse_Click(object sender, EventArgs e)
        {
            (new BuyHouse(this)).Show();  //makes a buy house form
            this.Enabled = false;  //prevents user from messing with things while picking a house
        }

        private void btnBuyCar_Click(object sender, EventArgs e)
        {
            (new BuyCar(this)).Show();  //makes a buy car form
            this.Enabled = false; //prevents user from messing with things while picking a car
        }

        protected override void OnFormClosing(FormClosingEventArgs e)  //overrides close so that control goes to the correct form
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                mainScreen.Close();
                return;
            }

            mainScreen.Enabled = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            mainScreen.Enabled = true;  //gives control to mainscreen
            this.Close();
        }

        private void btnGoToCollege_Click(object sender, EventArgs e)  //goes to or drops out of college
        {
            if (mainScreen.mainGame.player.schoolMonths <= 0)  //checks to see if player is not in college
            {
                mainScreen.mainGame.player.schoolMonths = 20;  //sets the number of months the player still needs
                mainScreen.mainGame.player.job.salary /= 2; //halfs pay
                btnGoToCollege.Text = "Drop Out";  //sets the option to drop out
                mainScreen.UpdateFields();  //updates the main screen
                return;
            }
            else //player is in college
            {
                mainScreen.mainGame.player.schoolMonths = 0;  //sets the number of months in college to 0
                mainScreen.mainGame.player.job.salary *= 2;  //double pay
                btnGoToCollege.Text = "Go To College";  //set option to go to college
                mainScreen.UpdateFields();  //update main screen

                player.schoolMonths = 0;
                player.job.salary *= 2;

                return;
            }
        }

        private void OptionsMenu_Load(object sender, EventArgs e)
        {


            if (player.schoolMonths < 1)  //tells the player what the college options are
            {
                btnGoToCollege.Text = "Go To College";
            }
            else
            {
                btnGoToCollege.Text = "Drop Out";
            }
        }
    }
}
