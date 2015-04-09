using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Living_Life
{
    public partial class LoadScreen : Form
    {

        MainScreen mainScreen;
        private bool gameCalled = false;
        public Player player;

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

                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem reading the master saves file:");
                Console.WriteLine(exception.Message);
            }
        }

        // NOTE: WE MAY WANT TO LOOK INTO SAVING AND LOADING THE OBJECTS USING XML FILES. IT SEEMS TO BE AN EASIER METHOD THAN USING TEXT.
        private void btnNew_Click(object sender, EventArgs e)
        {
            bool playerExists = false;

            if (txtNewName.Text != "")
                player = new Player(txtNewName.Text);
            else
                errLabel.Visible = true;

            if (errLabel.Visible)
                errLabel.Visible = false;

            //save new name
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                if (player.name == lstFiles.Items[i].ToString()) 
                {
                    playerExists = true;
                }
            }

            if (!playerExists)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("SaveFiles.txt", append: true))
                    {
                        sw.WriteLine(player.name);
                        sw.Close();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("There was a problem writing to the master saves file:");
                    Console.WriteLine(exception.Message);
                }
            }

            XmlSerializer writer = new XmlSerializer(typeof(Player));

            try
            {
                using (StreamWriter sw = new StreamWriter(player.name + ".xml"))
                {
                    writer.Serialize(sw, player);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem creating the player save file.");
                Console.WriteLine(ex.Message);
            }

            //Keeping around just in case
            //save new file
            //try
            //{
            //    using (StreamWriter sw = new StreamWriter(txtNewName.Text + ".txt"))
            //    {

            //        sw.Write(""); //clear a possibly existing file
            //        sw.WriteLine(txtNewName.Text); //Name
            //        sw.WriteLine("18"); //age
            //        sw.WriteLine("0"); //wife
            //        sw.WriteLine("0"); //children
            //        sw.WriteLine("0"); //income
            //        sw.WriteLine("0"); //savings
            //        sw.WriteLine("0"); //education level
            //        sw.WriteLine("0"); //school months
            //        sw.WriteLine("none"); //car
            //        sw.WriteLine("none"); //house

            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("There was a problem writing to the save file:");
            //    Console.WriteLine(exception.Message);
            //}

            gameCalled = true;
            mainScreen.Enabled = true;
            mainScreen.mainGame.player = player;
            mainScreen.UpdateFields();
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
            string loadFile = lstFiles.SelectedItem.ToString() + ".xml";

            //File info order: NAME, AGE, WIFE, CHILDREN, INCOME, SAVINGS, EDUCATION LEVEL, SCHOOL MONTHS, CAR, HOUSE
            try
            {
                using (StreamReader sr = new StreamReader(loadFile))
                {
                    //Load character status here
                    XmlSerializer reader = new XmlSerializer(typeof(Player));
                    player = (Player)reader.Deserialize(sr);
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem reading the master saves file:");
                Console.WriteLine(exception.Message);
            }

            mainScreen.mainGame.player = this.player;
            gameCalled = true;
            mainScreen.Enabled = true;
            mainScreen.UpdateFields();
            this.Close();
        }
    }
}
