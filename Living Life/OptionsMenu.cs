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
<<<<<<< HEAD


        public MainScreen mainScreen;  //gets the main screen so we can get game info
        public Player player;  


        public OptionsMenu(MainScreen mainScreen)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;  //sets mainscreen so we can have game stuffs
            player = mainScreen.mainGame.player;
            if(player.schoolMonths > 0)  //checks to see if in college
            {
                btnGoToCollege.Text = "Drop Out Of College";  //sets college button to tell player they are in college
            }
            this.TopMost = true;  //sets this to the top screen

            lblPrompt.Text = player.schoolMonths + " " + player.educationLevel; //debug stuff
=======
        public MainScreen mainScreen;
        public Player player;

        public OptionsMenu()
        {
            InitializeComponent();
            if(player.schoolMonths>0){
                btnGoToCollege.Text = "Drop Out Of College";
            }
        }
        public OptionsMenu(MainScreen mainScreen, Player player)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.player = player;
            this.TopMost = true;
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
        }


        private void btnGetJob_Click(object sender, EventArgs e)
        {
            //Should implement the ability to choose job, as I now realize that was the intent instead of random
            //Random rand = new Random();
            //int r = rand.Next(0,mainScreen.mainGame.jobs.Length);
            //Job tmpJob =  mainScreen.mainGame.jobs[r];
            //Player tmpPlayer = mainScreen.mainGame.player;
            //if (tmpPlayer.educationLevel >= tmpJob.level)
            //{
            //    mainScreen.mainGame.player.job = mainScreen.mainGame.jobs[r];
            //}
            //else { 
                
            //}

            (new GetJob(this)).Show();
            this.Enabled = false;

        }

        private void btnBuyHouse_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            (new BuyHouse(this)).Show();  //makes a buy house form
            this.Enabled = false;  //prevents user from messing with things while picking a house

=======
            (new BuyHouse(this, player)).Show();
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
            this.Enabled = false;
        }

        private void btnBuyCar_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD


            (new BuyCar(this)).Show();  //makes a buy car form
            this.Enabled = false; //prevents user from messing with things while picking a car

            (new BuyCar(this)).Show();

=======
            (new BuyCar(this, player)).Show();
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
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
            if (chkChurch.Checked) {
                player.tithe = true;
            }
            this.Close();
        }

        private void btnGoToCollege_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            if (mainScreen.mainGame.player.schoolMonths <= 0)  //checks to see if player is not in college
            {
                mainScreen.mainGame.player.schoolMonths = 20;  //sets the number of months the player still needs
                mainScreen.mainGame.player.job.salary /= 2; //halfs pay
                btnGoToCollege.Text = "Drop Out";  //sets the option to drop out
                mainScreen.UpdateFields();  //updates the main screen
=======
            if (player.schoolMonths <= 0)
            {
                player.schoolMonths = 20;
                player.job.salary /= 2;
                btnGoToCollege.Text = "Drop Out";
                mainScreen.UpdateFields();
                return;
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
            }
            else
            {
<<<<<<< HEAD


                mainScreen.mainGame.player.schoolMonths = 0;  //sets the number of months in college to 0
                mainScreen.mainGame.player.job.salary *= 2;  //double pay
                btnGoToCollege.Text = "Go To College";  //set option to go to college
                mainScreen.UpdateFields();  //update main screen

=======
                player.schoolMonths = 0;
                player.job.salary *= 2;
                btnGoToCollege.Text = "Go To College";
                mainScreen.UpdateFields();
                return;
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
            }
        }

        private void OptionsMenu_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

            if (mainScreen.mainGame.player.schoolMonths < 1)  //tells the player what the college options are

=======
>>>>>>> e2d85565f5f5e0a845126180898ca7d8a5ef6c6a
            if (player.schoolMonths < 1)
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
