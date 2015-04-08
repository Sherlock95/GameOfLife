﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Living_Life
{
    public partial class LoadScreen : Form
    {

        MainScreen mainScreen;
        private bool gameCalled = false;

        public LoadScreen()
        {
            InitializeComponent();
        }

        public LoadScreen(MainScreen mainScreen0)
        {
            InitializeComponent();
            mainScreen = mainScreen0;
            this.TopMost = true;
        }

        private void LoadScreen_Load(object sender, EventArgs e)
        {

            //load save files
            try
            {
                using (StreamReader sr = new StreamReader("SaveFiles.txt"))
                {

                    while (!sr.EndOfStream)
                    {
                        lstFiles.Items.Add(sr.ReadLine());
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem reading the master saves file:");
                Console.WriteLine(exception.Message);
            }

            //gameCalled = true;
        }

        // NOTE: WE MAY WANT TO LOOK INTO SAVING AND LOADING THE OBJECTS USING XML FILES. IT SEEMS TO BE AN EASIER METHOD THAN USING TEXT.
        private void btnNew_Click(object sender, EventArgs e)
        {

            //save new name
            try
            {
                using (StreamWriter sw = new StreamWriter("SaveFiles.txt", append:true))
                {
                    if (txtNewName.Text != "")
                    {
                        sw.WriteLine(txtNewName.Text);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem writing to the master saves file:");
                Console.WriteLine(exception.Message);
            }

            //save new file
            try
            {
                using (StreamWriter sw = new StreamWriter(txtNewName.Text + ".txt"))
                {

                    sw.Write(""); //clear a possibly existing file
                    sw.WriteLine(txtNewName.Text); //Name
                    sw.WriteLine("18"); //age
                    sw.WriteLine("0"); //wife
                    sw.WriteLine("0"); //children
                    sw.WriteLine("0"); //income
                    sw.WriteLine("0"); //savings
                    sw.WriteLine("0"); //education level
                    sw.WriteLine("0"); //school months
                    sw.WriteLine("none"); //car
                    sw.WriteLine("none"); //house

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem writing to the save file:");
                Console.WriteLine(exception.Message);
            }

            mainScreen.Enabled = true;
            mainScreen.mainGame.player = new Player(18, 0, 0, 0, 0, 0, 0, null, null);
            gameCalled = true;
            this.Close();

        }

        private void lstFiles_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = true;
        }

        private void txtNewName_TextChanged(object sender, EventArgs e)
        {
            if (txtNewName.Text != "")
            {
                btnNew.Enabled = true;
            }
        }

        //Overrided the closing method so clicking the "x" on the load screen closes the entire game.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                mainScreen.Close();
                return;
            }

            if (gameCalled) return;

            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    mainScreen.Close();
                    break;
            }        
        }

        // NOTE: WE MAY WANT TO LOOK INTO SAVING AND LOADING THE OBJECTS USING XML FILES. IT SEEMS TO BE AN EASIER METHOD THAN USING TEXT.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string loadFile = lstFiles.SelectedItem.ToString() + ".txt";

            //File info order: NAME, AGE, WIFE, CHILDREN, INCOME, SAVINGS, EDUCATION LEVEL, SCHOOL MONTHS, CAR, HOUSE
            try
            {
                using (StreamReader sr = new StreamReader(loadFile))
                {
                    //Load character status here
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem reading the master saves file:");
                Console.WriteLine(exception.Message);
            }
        }
    }
}
