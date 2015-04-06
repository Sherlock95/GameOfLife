using System;
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

        public LoadScreen()
        {
            InitializeComponent();
        }

        public LoadScreen(MainScreen mainScreen0)
        {
            InitializeComponent();
            mainScreen = mainScreen0;
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            //save new name
            try
            {
                using (StreamWriter sw = new StreamWriter("SaveFiles.txt"))
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

       


        //private void LoadScreen_Leave(object sender, EventArgs e)
        //{
        //    mainScreen.Enabled = true;
        //}

        //private void LoadScreen_Deactivate(object sender, EventArgs e)
        //{
        //    mainScreen.Enabled = true;
        //}
    }
}
