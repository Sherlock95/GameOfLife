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

        public MainScreen()
        {
            InitializeComponent();
        }

        public MainScreen(Player newPlayer)
        {
            InitializeComponent();
            mainGame.player = newPlayer;
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            EndMonth monthEnd = new EndMonth();
            monthEnd.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure you want to quit?", "Closing", MessageBoxButtons.YesNo))
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
            mainGame = new Main();
            loadGame.Show();
        }

        //This is called from the load menu when it closes to let the main screen know that it should set fields.
        public void InitFields()
        {
            lblName.Text = "Name: " + mainGame.player.name;
            lblAge.Text = "Age " + mainGame.player.age.ToString();
            lblSavings.Text = "Savings: " + mainGame.player.savings.ToString();
            lblTithes.Text = "Tithes: $" + (mainGame.player.income / 10).ToString();

            if (mainGame.player.job != null)
            {
                lblJob.Text = "Job: " + mainGame.player.job.name;
                lblSalary.Text = "Salary: " + mainGame.player.job.salary;
            }
            else 
            {
                lblJob.Text = "Job: None";
                lblSalary.Text = "Salary: $0";
            }
            if (mainGame.player.car != null)
            {
                lblCar.Text = "Car: " + mainGame.player.car.name;
                // What is the difference between car bills and monthly car bills????
            }
            else
            {
                lblCar.Text = "Car: None";
                lblCarBills.Text = "Car Bills (Monthly): None";
            }
            if (mainGame.player.wife == 0)
            {
                lblMarriage.Text = "Marriage Status: Not Married";
            }
            else 
            {
                lblMarriage.Text = "Marriage Status: Married";
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

            this.Close();
        }
    }
}
