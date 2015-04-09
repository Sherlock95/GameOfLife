using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Living_Life
{
    public class Player
    {
        public string name;
        public int age;
        public int wife;
        public int children;
        public float income;
        public float savings;
        public int educationLevel;
        public int schoolMonths;
        public Property car;
        public Property house;
        public Job job;

        public Player()
        {
            name = "John";
            age = 18;
            wife = 0;
            children = 0;
            income = 0;
            savings = 0;
            educationLevel = 0;
            schoolMonths = 0;
            car = null;
            house = null;
            job = null;
        }

        public Player(string name) //make new player
        {
            this.name = name;
            age = 18;
            wife = 0;
            children = 0;
            income = 0;
            savings = 0;
            educationLevel = 0;
            schoolMonths = 0;
            car = null;
            house = null;
            job = null;
        }

        public Player(string Name, int Age, int Wife, int Children, int Income, int Savings, int EducationLevel, int SchoolMonths, Property Car, Property House, Job job) //remake existing player
        {
            name = Name;
            age = Age;
            wife = Wife;
            children = Children;
            income = Income;
            savings = Savings;
            educationLevel = EducationLevel;
            schoolMonths = SchoolMonths;
            car = Car;
            house = House;
            this.job = job;
        }

    }
}
