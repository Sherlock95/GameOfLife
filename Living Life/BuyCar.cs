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
    public partial class BuyCar : Form
    {
        public OptionsMenu parentOptions;
        public Player player;

        private bool cancelBtnPressed;
        private bool confirmBtnPressed;

        public BuyCar(OptionsMenu parentOptions)
        {
            InitializeComponent();
            cancelBtnPressed = false;
            confirmBtnPressed = false;
            this.parentOptions = parentOptions;
            this.player = parentOptions.mainScreen.mainGame.player;
            this.TopMost = true;
            getCars();
        }

        //Load in the cars into lstCars
        private void getCars()
        {
            foreach (Property car in parentOptions.mainScreen.mainGame.cars)
            {
                string carString = car.name + "\n\tTotal Value: $" + car.totalValue + "\n\tDown Payment: $" + car.downPayment + "\n\tMonthly Payment: $" + car.monthlyPayment + " for " + car.duration + " months\n\tInsurance: " + car.insurance + "\n";
                lstCars.Items.Add(carString);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                parentOptions.mainScreen.Close();
                parentOptions.Close();
                return;
            }

            parentOptions.Enabled = true;

            if (cancelBtnPressed || confirmBtnPressed)
            {
                return;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (lstCars.SelectedItem == null) MessageBox.Show("Chose a car");
            else if ((player.savings + parentOptions.mainScreen.mainGame.calculateValue(parentOptions.mainScreen.mainGame.cars[lstCars.SelectedIndex]) > parentOptions.mainScreen.mainGame.cars[lstCars.SelectedIndex].downPayment))
            {
                player.savings -= parentOptions.mainScreen.mainGame.houses[lstCars.SelectedIndex].downPayment;
                confirmBtnPressed = true;
                parentOptions.Enabled = true;
                player.car = parentOptions.mainScreen.mainGame.cars[lstCars.SelectedIndex]; //sets the new car
                parentOptions.mainScreen.UpdateFields();
                this.Close();
            }
            else
            {
                MessageBox.Show("You has not the monies");  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelBtnPressed = true;
            parentOptions.Enabled = true;
            this.Close();
        }
    }
}
