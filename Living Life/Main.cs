using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Living_Life
{
    public class Main
    {

        public struct randomEvent
        {
            public string description;
            public double cost;
        };

        public Player player;

        public randomEvent[] commonEvents = new randomEvent[0];
        public randomEvent[] rareEvents = new randomEvent[0];

        public Property[] houses = new Property[10];
        public Property[] cars = new Property[10];

        public Job[] jobs = new Job[21];

        public Main()
        {
            setUpMain();
        }

        public int calculateValue(Property property)
        {
            return (property.downPayment + (property.monthlyPayment * property.duration));
        }

        void setUpMain()
        {
            commonEvents = new randomEvent[0];
            rareEvents = new randomEvent[0];

            houses = new Property[10];
            cars = new Property[10];

            jobs = new Job[21];

            //house information

            for (int i = 0; i < houses.Length; i++)
            {
                houses[i] = new Property();
            }

            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Property();
            }

            houses[0].name = "Trailer";
            houses[0].totalValue = 50000;
            houses[0].downPayment = 10000;
            houses[0].monthlyPayment = 345;
            houses[0].duration = 120;
            houses[0].insurance = 50;

            houses[1].name = "Studio Apt.";
            houses[1].totalValue = 0;
            houses[1].downPayment = 500;
            houses[1].monthlyPayment = 500;
            houses[1].duration = 12;
            houses[1].insurance = 0;

            houses[2].name = "2 Apt.";
            houses[2].totalValue = 0;
            houses[2].downPayment = 800;
            houses[2].monthlyPayment = 800;
            houses[2].duration = 12;
            houses[2].insurance = 0;

            houses[03].name = "3 Apt.";
            houses[03].totalValue = 0;
            houses[03].downPayment = 1100;
            houses[03].monthlyPayment = 1100;
            houses[03].duration = 12;
            houses[03].insurance = 0;

            houses[04].name = "Duplex (2 bedrooms)";
            houses[04].totalValue = 0;
            houses[04].downPayment = 950;
            houses[04].monthlyPayment = 950;
            houses[04].duration = 12;
            houses[04].insurance = 0;

            houses[05].name = "6 bedroom house";
            houses[05].totalValue = 800000;
            houses[05].downPayment = 160000;
            houses[05].monthlyPayment = 2200;
            houses[05].duration = 360;
            houses[05].insurance = 650;

            houses[06].name = "4 bedroom house";
            houses[06].totalValue = 300000;
            houses[06].downPayment = 60000;
            houses[06].monthlyPayment = 825;
            houses[06].duration = 300;
            houses[06].insurance = 250;

            houses[07].name = "Tent";
            houses[07].totalValue = 45;
            houses[07].downPayment = 0;
            houses[07].monthlyPayment = 0;
            houses[07].duration = 0;
            houses[07].insurance = 0;

            houses[08].name = "Box";
            houses[08].totalValue = 0;
            houses[08].downPayment = 0;
            houses[08].monthlyPayment = 0;
            houses[08].duration = 0;
            houses[08].insurance = 0;

            houses[09].name = "Parent's House";
            houses[09].totalValue = 0;
            houses[09].downPayment = 0;
            houses[09].monthlyPayment = 0;
            houses[09].duration = 0;
            houses[09].insurance = 0;

            //car information

            cars[0].name = "Old Hoopty";
            cars[0].totalValue = 1500;
            cars[0].downPayment = 300;
            cars[0].monthlyPayment = 185;
            cars[0].duration = 12;
            cars[0].insurance = 45;

            cars[01].name = "VW Bug, 2010";
            cars[01].totalValue = 10000;
            cars[01].downPayment = 2000;
            cars[01].monthlyPayment = 185;
            cars[01].duration = 48;
            cars[01].insurance = 75;

            cars[02].name = "Honda Civic, 2010";
            cars[02].totalValue = 13000;
            cars[02].downPayment = 2600;
            cars[02].monthlyPayment = 222;
            cars[02].duration = 48;
            cars[02].insurance = 80;

            cars[03].name = "Lexus";
            cars[03].totalValue = 36000;
            cars[03].downPayment = 7200;
            cars[03].monthlyPayment = 495;
            cars[03].duration = 60;
            cars[03].insurance = 150;

            cars[04].name = "BMW";
            cars[04].totalValue = 45000;
            cars[04].downPayment = 9000;
            cars[04].monthlyPayment = 618;
            cars[04].duration = 60;
            cars[04].insurance = 200;

            cars[05].name = "Subaru";
            cars[05].totalValue = 25000;
            cars[05].downPayment = 5000;
            cars[05].monthlyPayment = 425;
            cars[05].duration = 48;
            cars[05].insurance = 100;

            cars[06].name = "Minivan";
            cars[06].totalValue = 34000;
            cars[06].downPayment = 6800;
            cars[06].monthlyPayment = 465;
            cars[06].duration = 60;
            cars[06].insurance = 95;

            cars[07].name = "Bike";
            cars[07].totalValue = 300;
            cars[07].downPayment = 0;
            cars[07].monthlyPayment = 0;
            cars[07].duration = 0;
            cars[07].insurance = 0;

            cars[08].name = "Bus";
            cars[08].totalValue = 0;
            cars[08].downPayment = 0;
            cars[08].monthlyPayment = 175;
            cars[08].duration = 0;
            cars[08].insurance = 0;

            cars[09].name = "Motorcycle";
            cars[09].totalValue = 7000;
            cars[09].downPayment = 1400;
            cars[09].monthlyPayment = 120;
            cars[09].duration = 48;
            cars[09].insurance = 70;

            //job information

            jobs[0].name = "Fast Food";
            jobs[0].level = 0;
            jobs[0].salary = 1105;

            jobs[01].name = "Waiter";
            jobs[01].level = 0;
            jobs[01].salary = 1697;

            jobs[02].name = "Lifeguard";
            jobs[02].level = 0;
            jobs[02].salary = 1406;

            jobs[03].name = "Truck Driver";
            jobs[03].level = 0;
            jobs[03].salary = 4046;

            jobs[04].name = "Receptionist";
            jobs[04].level = 0;
            jobs[04].salary = 2667;

            jobs[05].name = "Bank Teller";
            jobs[05].level = 1;
            jobs[05].salary = 2000;

            jobs[06].name = "Technician";
            jobs[06].level = 1;
            jobs[06].salary = 3000;

            jobs[07].name = "Web Developer";
            jobs[07].level = 1;
            jobs[07].salary = 3500;

            jobs[08].name = "Taxidermist";
            jobs[08].level = 1;
            jobs[08].salary = 1167;

            jobs[09].name = "Programmer";
            jobs[09].level = 2;
            jobs[09].salary = 5000;

            jobs[010].name = "Engineer";
            jobs[010].level = 2;
            jobs[010].salary = 5500;

            jobs[011].name = "Teacher";
            jobs[011].level = 2;
            jobs[011].salary = 3000;

            jobs[012].name = "Insurance consultant";
            jobs[012].level = 2;
            jobs[012].salary = 4700;

            jobs[013].name = "Finance Manager";
            jobs[013].level = 3;
            jobs[013].salary = 7000;

            jobs[014].name = "Software Engineer";
            jobs[014].level = 3;
            jobs[014].salary = 6000;

            jobs[015].name = "Physicist";
            jobs[015].level = 3;
            jobs[015].salary = 5700;

            jobs[016].name = "Nurse";
            jobs[016].level = 3;
            jobs[016].salary = 6000;

            jobs[017].name = "Doctor/Dentist";
            jobs[017].level = 4;
            jobs[017].salary = 15475;

            jobs[018].name = "Professor";
            jobs[018].level = 4;
            jobs[018].salary = 8500;

            jobs[019].name = "Surgeon";
            jobs[019].level = 4;
            jobs[019].salary = 29149;

            jobs[020].name = "Senior Software Engineer";
            jobs[020].level = 4;
            jobs[020].salary = 13380;

            //jobs[021].name = "King of the World";
            //jobs[021].level = 100;
            //jobs[021].salary = 1000000000;

            //bring in event information
            try
            {
                using (StreamReader sr = new StreamReader("EventsCommon.txt"))
                {
                    int i = 0;
                    randomEvent[] tempEvents;

                    //read in common events
                    while (!sr.EndOfStream)
                    {

                        tempEvents = new randomEvent[commonEvents.Length + 1];

                        for (int j = 0; j < commonEvents.Length; j++)
                        {
                            tempEvents[j] = commonEvents[j];
                        }

                        String line = sr.ReadLine();
                        tempEvents[i].description = line;
                        line = sr.ReadLine();
                        tempEvents[i].cost = Convert.ToInt32(line);
                        commonEvents = new randomEvent[commonEvents.Length + 1];
                        commonEvents = tempEvents;
                        i++;
                    }
                }

                using (StreamReader sr = new StreamReader("EventsRare.txt"))
                {
                    int i = 0;
                    randomEvent[] tempEvents;

                    //read in common events
                    while (!sr.EndOfStream)
                    {

                        tempEvents = new randomEvent[rareEvents.Length + 1];

                        for (int j = 0; j < rareEvents.Length; j++)
                        {
                            tempEvents[j] = rareEvents[j];
                        }

                        String line = sr.ReadLine();
                        tempEvents[i].description = line;
                        line = sr.ReadLine();
                        tempEvents[i].cost = Convert.ToInt32(line);
                        rareEvents = new randomEvent[rareEvents.Length + 1];
                        rareEvents = tempEvents;
                        i++;
                    }
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem reading an event file:");
                Console.WriteLine(exception.Message);
            }


            //stuff used for debug purposes
            //for (int j = 0; j < commonEvents.Length; j++)
            //{
            //    textBox1.Text += " " + commonEvents[j].description + " " + commonEvents[j].cost + " \n";
            //}
            //for (int j = 0; j < rareEvents.Length; j++)
            //{
            //    textBox1.Text += " " + rareEvents[j].description + " " + rareEvents[j].cost + " \n";
            //}

            
        }
    }
}
