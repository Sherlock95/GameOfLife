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
            confirmBtnPressed = false;
            cancelBtnPressed = false;
            this.parentOptions = parentOptions;
            GetJobs();
            this.TopMost = true;
        }

        private void GetJobs()
        {

            foreach (Job job in parentOptions.mainScreen.mainGame.jobs)
            {
                string jobString = job.name + "\n\tEducation Level Required: " + job.level + "\n\tSalary: $" + job.salary + "\n";
                lstJobs.Items.Add(jobString);
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
            if(lstJobs.SelectedItem==null){
                MessageBox.Show("You must select a job or cancel");
            }
            else if (parentOptions.mainScreen.mainGame.player.educationLevel >= parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].level)
            {

                Job newJob = new Job();
                newJob.level = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].level;
                newJob.name = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].name;
                newJob.salary = parentOptions.mainScreen.mainGame.jobs[lstJobs.SelectedIndex].salary;
                if (parentOptions.mainScreen.mainGame.player.schoolMonths > 0)
                {
                    newJob.salary /= 2;
                }
                parentOptions.mainScreen.mainGame.player.job = newJob; //sets new job
                confirmBtnPressed = true;
                parentOptions.Enabled = true;
                parentOptions.mainScreen.UpdateFields();
                this.Close();

            }
            else
            {
                MessageBox.Show("You have not the education required for this job");
            }

        }
        
    }
}
