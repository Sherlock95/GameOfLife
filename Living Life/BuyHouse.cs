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
    public partial class BuyHouse : Form
    {
        public OptionsMenu parentOptions;
        public Player player;

        private bool cancelBtnPressed;
        private bool confirmBtnPressed;

        public BuyHouse(OptionsMenu parentOptions)
        {
            InitializeComponent();
            confirmBtnPressed = false;
            cancelBtnPressed = false;
            this.parentOptions = parentOptions;
            this.player = parentOptions.mainScreen.mainGame.player;
            GetHouses();
            this.TopMost = true;
        }

        //Load in the houses to be bought
        public void GetHouses()
        {

            foreach (Property house in parentOptions.mainScreen.mainGame.houses)
            {
                string houseString = house.name + "\n\tTotal Value: $" + house.totalValue + "\n\tDown Payment: $" + house.downPayment + "\n\tMonthly Payment: $" + house.monthlyPayment + " for " + house.duration + " months\n\tInsurance: " + house.insurance + "\n";
                lstHouses.Items.Add(houseString);
            }

        }

        //Override the default closing operation because clicking the "x" should re-enable the options.
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

         
            if ((player.savings + parentOptions.mainScreen.mainGame.calculateValue(parentOptions.mainScreen.mainGame.houses[lstHouses.SelectedIndex]) > parentOptions.mainScreen.mainGame.houses[lstHouses.SelectedIndex].downPayment))
            {
                player.savings -= parentOptions.mainScreen.mainGame.houses[lstHouses.SelectedIndex].downPayment;
                confirmBtnPressed = true;
                parentOptions.Enabled = true;
                player.house = parentOptions.mainScreen.mainGame.houses[lstHouses.SelectedIndex]; //sets the new car
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
            this.Close();
        }
    }
}
