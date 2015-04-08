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
    public partial class MainScreen : Form
    {

        public Main mainGame;

        public MainScreen()
        {
            InitializeComponent();
        }

        public MainScreen(Player newPlayer)
        {
            InitializeComponent();
            mainGame.player = newPlayer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EndMonth monthEnd = new EndMonth();
            monthEnd.Show();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            EndMonth monthEnd = new EndMonth();
            monthEnd.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

            this.Enabled = false;
            LoadScreen loadGame = new LoadScreen(this);
            mainGame = new Main();
            loadGame.Show();
        }

        //This is called from the load menu when it closes to let the main screen know that it should set fields.
        public void InitFields()
        {
            lblName.Text = lblName.Text + " " + mainGame.player.name;
            lblAge.Text = lblAge.Text + " " + mainGame.player.age.ToString();
            lblSavings.Text = lblSavings.Text + " " + mainGame.player.savings.ToString();
            lblJob.Text = lblJob.Text + " " + mainGame.player.job.name;

            if (mainGame.player.car != null)
            {
                lblCar.Text = mainGame.player.car.name;
                // What is the difference between car bills and monthly car bills????
            }
            else
            {
                lblCar.Text = "None";
                lblCarBills.Text = "None";
            }
        }
    }
}
