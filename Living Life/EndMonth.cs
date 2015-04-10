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
    public partial class EndMonth : Form
    {
        public MainScreen mainScreen;
        public Player player;

        private Random generator;
        private bool continueCalled;
        private bool eventHappens;

        struct Event 
        {
            public string description;
            public int cost;
        }

        public EndMonth()
        {
            InitializeComponent();
            continueCalled = false;
        }

        public EndMonth(MainScreen mainScreen)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            continueCalled = false;
            eventHappens = false;
            UpdateFields();
        }

        public EndMonth(MainScreen mainScreen, Random generator, Player player)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.generator = generator;
            this.player = player;
            continueCalled = false;
            eventHappens = false;
            UpdateFields();
        }

        private Event GenerateEvent()
        {
            int eventNum = generator.Next(0, 11);
            Console.WriteLine(eventNum.ToString());
            //No Event
            if (eventNum < 4)
            {
                eventHappens = false;
                Event randomEvent = new Event();
                randomEvent.description = "Nothing";
                randomEvent.cost = 0;
                Console.WriteLine("NOTHING");
                return randomEvent;
            }
            //Common event
            else if (eventNum < 9)
            {
                eventHappens = true;
                Event randomEvent = new Event();
                int index = generator.Next(0, mainScreen.mainGame.commonEvents.Length);
                randomEvent.description = mainScreen.mainGame.commonEvents[index].description;
                randomEvent.cost = mainScreen.mainGame.commonEvents[index].cost;
                Console.WriteLine(index.ToString());
                Console.WriteLine(randomEvent.description);
                return randomEvent;
            }
            //Rare Event
            else
            {
                eventHappens = true;
                Event randomEvent = new Event();
                int index = generator.Next(0, mainScreen.mainGame.rareEvents.Length);
                randomEvent.description = mainScreen.mainGame.rareEvents[index].description;
                randomEvent.cost = mainScreen.mainGame.rareEvents[index].cost;
                Console.WriteLine(index.ToString());
                Console.WriteLine(randomEvent.description);
                return randomEvent;
            }
        }

        private void UpdateFields()
        {
            Event[] randomEvents = new Event[3];
            int earnings = 0;
            int expenses = 0;

            for (int i = 0; i < 3; i++)
            {
                randomEvents[i] = GenerateEvent();
                if (randomEvents[i].cost < 0)
                    expenses += randomEvents[i].cost;
                else if (randomEvents[i].cost > 0)
                    earnings += randomEvents[i].cost;
                else
                    continue;
            }

            lblEventTitle1.Text = randomEvents[0].description;
            lblEventDescription1.Text = "This event costed: $" + randomEvents[0].cost.ToString();
            lblEventTitle2.Text = randomEvents[1].description;
            lblEventDescription2.Text = "This event costed: $" + randomEvents[1].cost.ToString();
            lblEventTitle3.Text = randomEvents[2].description;
            lblEventDescription3.Text = "This event costed: $" + randomEvents[2].cost.ToString();

            if (!(player.house == null || player.house.duration == 0))
            {
                expenses -= player.house.monthlyPayment;
                player.house.duration--;
            }

            if (!(player.car == null || player.car.duration == 0))
            {
                expenses -= player.car.monthlyPayment;
                player.car.duration--;
            }

            player.income = ((player.job != null) ?  player.job.salary - (player.job.salary*10)/100 : 0);
            earnings += player.income;

            lblEarningsSummary.Text = earnings.ToString();
            lblTotalExpenses.Text = expenses.ToString();

            player.savings = player.savings + earnings + expenses;
            lblTotalSavings.Text = player.savings.ToString();

            if (mainScreen.monthsPassed == 12)
            {
                mainScreen.monthsPassed = 0;
                player.age++;
            }

            if (player.schoolMonths != 0)
            {
                player.schoolMonths--;
                if (player.schoolMonths == 0)
                {
                    player.educationLevel++;
                    player.job.salary *= 2;
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            continueCalled = true;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                mainScreen.Close();
                return;
            }

            if (continueCalled)
                mainScreen.UpdateFields();

            mainScreen.Enabled = true;
        }
    }
}
