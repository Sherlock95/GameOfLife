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

        private bool cancelBtnPressed;
        private bool confirmBtnPressed;

        public BuyCar(OptionsMenu parentOptions)
        {
            InitializeComponent();
            cancelBtnPressed = false;
            confirmBtnPressed = false;
            this.parentOptions = parentOptions;
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
            //cars[0].name = "Old Hoopty";
            //cars[0].totalValue = 1500;
            //cars[0].downPayment = 300;
            //cars[0].monthlyPayment = 185;
            //cars[0].duration = 12;
            //cars[0].insurance = 45;

            //cars[01].name = "VW Bug, 2010";
            //cars[01].totalValue = 10000;
            //cars[01].downPayment = 2000;
            //cars[01].monthlyPayment = 185;
            //cars[01].duration = 48;
            //cars[01].insurance = 75;

            //cars[02].name = "Honda Civic, 2010";
            //cars[02].totalValue = 13000;
            //cars[02].downPayment = 2600;
            //cars[02].monthlyPayment = 222;
            //cars[02].duration = 48;
            //cars[02].insurance = 80;

            //cars[03].name = "Lexus";
            //cars[03].totalValue = 36000;
            //cars[03].downPayment = 7200;
            //cars[03].monthlyPayment = 495;
            //cars[03].duration = 60;
            //cars[03].insurance = 150;

            //cars[04].name = "BMW";
            //cars[04].totalValue = 45000;
            //cars[04].downPayment = 9000;
            //cars[04].monthlyPayment = 618;
            //cars[04].duration = 60;
            //cars[04].insurance = 200;

            //cars[05].name = "Subaru";
            //cars[05].totalValue = 25000;
            //cars[05].downPayment = 5000;
            //cars[05].monthlyPayment = 425;
            //cars[05].duration = 48;
            //cars[05].insurance = 100;

            //cars[06].name = "Minivan";
            //cars[06].totalValue = 34000;
            //cars[06].downPayment = 6800;
            //cars[06].monthlyPayment = 465;
            //cars[06].duration = 60;
            //cars[06].insurance = 95;

            //cars[07].name = "Bike";
            //cars[07].totalValue = 300;
            //cars[07].downPayment = 0;
            //cars[07].monthlyPayment = 0;
            //cars[07].duration = 0;
            //cars[07].insurance = 0;

            //cars[08].name = "Bus";
            //cars[08].totalValue = 0;
            //cars[08].downPayment = 0;
            //cars[08].monthlyPayment = 175;
            //cars[08].duration = 0;
            //cars[08].insurance = 0;

            //cars[09].name = "Motorcycle";
            //cars[09].totalValue = 7000;
            //cars[09].downPayment = 1400;
            //cars[09].monthlyPayment = 120;
            //cars[09].duration = 48;
            //cars[09].insurance = 70;
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
            confirmBtnPressed = true;
            parentOptions.Enabled = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelBtnPressed = true;
            parentOptions.Enabled = true;
            this.Close();
        }
    }
}
