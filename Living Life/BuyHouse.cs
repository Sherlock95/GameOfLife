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

        private bool cancelBtnPressed = false;
        private bool confirmBtnPressed = false;

        public BuyHouse(OptionsMenu parentOptions)
        {
            InitializeComponent();
            this.parentOptions = parentOptions;
            GetHouses();
            this.TopMost = true;
        }

        //Load in the houses to be bought
        public void GetHouses()
        {
            
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

            if (cancelBtnPressed) return;

            if (confirmBtnPressed) return;


        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirmBtnPressed = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelBtnPressed = true;
        }
    }
}
