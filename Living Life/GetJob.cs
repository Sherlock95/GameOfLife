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
    public partial class GetJob : Form
    {

        public OptionsMenu parentOptions;

        private bool cancelBtnPressed;
        private bool confirmBtnPressed;

        public GetJob(OptionsMenu parentOptions)
        {
            InitializeComponent();
            confirmBtnPressed = false;  //a variable that doesn't seem to be doing much
            cancelBtnPressed = false;  //another seemingly useless variable
            this.parentOptions = parentOptions;  //gets the parent menu so that we can have access to all the game information.  we will need it.  
            GetJobs();  //displays all the jobs available in a listbox
            this.TopMost = true;  //sets this form as the dominant form on the screen
        }

        private void GetJobs()
        {

            foreach (Job job in parentOptions.mainScreen.mainGame.jobs)
            {
                string jobString = job.name + "\n\tEducation Level Required: " + job.level + "\n\tSalary: $" + job.salary + "\n";  //stores job info to a string
                lstJobs.Items.Add(jobString); //displays job info in a listbox
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelBtnPressed = true;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstJobs.SelectedItem == null) MessageBox.Show("Chose a job");
            else if (parentOptions.mainScreen.mainGame.player.educationLevel >= parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].level)  //check to see if the player is educated enough
            {

                Job newJob = new Job();
                newJob.level = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].level;
                newJob.name = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].name;
                newJob.salary = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].salary;
                parentOptions.mainScreen.mainGame.player.income = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].salary / 2;
                parentOptions.mainScreen.mainGame.player.job = newJob;
                if (parentOptions.mainScreen.mainGame.player.schoolMonths > 0)
                {
                    parentOptions.mainScreen.mainGame.player.income = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].salary / 2;
                }
                else
                {
                    parentOptions.mainScreen.mainGame.player.income = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].salary;
                }

                confirmBtnPressed = true;
                parentOptions.Enabled = true;
                parentOptions.mainScreen.UpdateFields();
                this.Close();

            }
            else
            {
                MessageBox.Show("You have not the education required for this job");  //tell player they are dumb
            }

        }
        
    }
}
