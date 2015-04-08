using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Living_Life
{
    public class Player
    {
        public string name;
        public int age = 18;
        public int wife = 0;
        public int children = 0;
        public int income = 0;
        public int savings = 0;
        public int educationLevel = 0;
        public int schoolMonths = 0;
        public Property car = null;
        public Property house = null;

        public Player() //make new player
        {

            age = 18;
            wife = 0;
            children = 0;
            income = 0;
            savings = 0;
            educationLevel = 0;
            schoolMonths = 0;
            car = null;
            house = null;

        }

        public Player(int Age, int Wife, int Children, int Income, int Savings, int EducationLevel, int SchoolMonths, Property Car, Property House) //remake existing player
        {

            age = Age;
            wife = Wife;
            children = Children;
            income = Income;
            savings = Savings;
            educationLevel = EducationLevel;
            schoolMonths = SchoolMonths;
            car = Car;
            house = House;

        }

    }
}
