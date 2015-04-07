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
    public partial class OptionsMenu : Form
    {
        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void btnGetJob_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            rand.Next(0,21);
            Main.job tmp = new Main.job();
            
        }
    }
}
