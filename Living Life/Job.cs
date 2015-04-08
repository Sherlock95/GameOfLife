using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Living_Life
{
    public class Job
    {
        public String name;
        public int level;
        public int salary;

        public Job()
        {
            name = "none";
            level = 0;
            salary = 0;
        }

        public Job(string name, int level, int salary)
        {
            this.name = name;
            this.level = level;
            this.salary = salary;
        }
    }
}
