using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Living_Life
{
    public partial class MainScreen : Form
    {

        public Main mainGame;
        public Random generator;
        public int monthsPassed;
        public Player player;

        public MainScreen()
        {
            InitializeComponent();
            mainGame = new Main();
            generator = new Random();
            player = mainGame.player;
            monthsPassed = 0;
        }

        public MainScreen(Player player)
        {
            InitializeComponent();
            mainGame = new Main();
            mainGame.player = player;
            this.player = mainGame.player;
            generator = new Random();
            monthsPassed = 0;
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            monthsPassed++;
            player = mainGame.player;
            (new EndMonth(this, generator, player)).Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Close();
                    break;
            }   
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

            this.Enabled = false;
            LoadScreen loadGame = new LoadScreen(this);

            loadGame.Show();
        }

        //This is called from the load menu when it closes to let the main screen know that it should set fields.
        //Also can be used to update the fields for each month.
        public void UpdateFields()
        {
            lblName.Text = "Name: " + mainGame.player.name;
            lblAge.Text = "Age: " + mainGame.player.age.ToString();
            lblSavings.Text = "Savings: " + mainGame.player.savings.ToString();

            if(mainGame.player.tithe)
                lblCurrentTithes.Text = "Tithes: $" + (mainGame.player.job.salary * 0.1).ToString();
            else
                lblCurrentTithes.Text = "Tithes: $0";

            if (mainGame.player.job != null)
            {
                lblJob.Text = "Job: " + mainGame.player.job.name;
                lblSalary.Text = "Salary (Per Month): " + mainGame.player.job.salary;
                lblCurrentSalary.Text = "Salary: " + mainGame.player.job.salary;
            }
            else 
            {
                lblJob.Text = "Job: None";
                lblSalary.Text = "Salary (Per Month): $0";
                lblCurrentSalary.Text = "Salary: $0";
            }

            if (mainGame.player.car != null)
            {
                lblCar.Text = "Car: " + mainGame.player.car.name;
                lblCarBills.Text = "Car Bills:  " + mainGame.player.car.monthlyPayment;
                lblCurrentCarBills.Text = "Car Bills:  " + mainGame.player.car.monthlyPayment;
                picCar.Image = Image.FromFile(mainGame.player.car.name + ".jpg");
                // What is the difference between car bills and monthly car bills????
                //I don't knooooooooooooooowwwwwwwww!!!!!!!!!
            }
            else
            {
                lblCar.Text = "Car: None";
                lblCarBills.Text = "Car Bills (Monthly): None";
                lblCurrentCarBills.Text = "Car Bills:  None";
                picCar.Image= null;
                
            }

            if (mainGame.player.house != null)
            {
                lblHouse.Text = "House:  " + mainGame.player.house.name;
                lblHouseBills.Text = "House Bills:  " + mainGame.player.house.monthlyPayment;
                lblCurrentHouseBills.Text = "House Bills:  " + mainGame.player.house.monthlyPayment;
                picHouse.Image = Image.FromFile(mainGame.player.house.name + ".jpg");
            }
            else
            {
                lblHouse.Text = "House:  None";
                lblHouseBills.Text = "House Bills: None";
                lblCurrentHouseBills.Text = "House Bills:  None";
                picHouse.Image=null;
            }


            if (mainGame.player.wife == 0)
            {
                lblMarriage.Text = "Marriage Status: Not Married";
            }
            else 
            {
                lblMarriage.Text = "Marriage Status: Married";
            }

            if (mainGame.player.schoolMonths > 0)
            {
                lblSchool.Text = "College Status:  " + mainGame.player.schoolMonths + " months left";
            }
            else
            {
                lblSchool.Text = "College Status:  Not In College";
            }

            //detect end game
            if (mainGame.player.savings < 0)
            {
                //game over
                //lose

                MessageBox.Show("You ran out of money");
                MessageBox.Show("You Lose");
                this.Enabled = false;
                LoadScreen loadGame = new LoadScreen(this);

                loadGame.Show();

            }
            if (mainGame.player.age >= 50)
            {
                //game over
                //win

                MessageBox.Show("You Made it to age 50!");
                MessageBox.Show("You Win!");
                this.Enabled = false;
                LoadScreen loadGame = new LoadScreen(this);

                loadGame.Show();

            }

        }

        // Save Game and Exit
        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveFile = mainGame.player.name + ".xml";

            try
            {
                using (StreamWriter sw = new StreamWriter(saveFile))
                {
                    XmlSerializer writer = new XmlSerializer(typeof(Player));
                    writer.Serialize(sw, mainGame.player);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred when writing player to file: " + ex.Message);
            }

            switch (MessageBox.Show(this, "Progress saved.\nAre you sure you want to quit?", "Save and Quit", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    break;
                default:
                    this.Close();
                    break;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            OptionsMenu options = new OptionsMenu(this, player);
            options.Show();
        }

        private void lblCheat_Click(object sender, EventArgs e)
        {
            mainGame.player.savings += 10000;
            UpdateFields();
        }
    }
}
