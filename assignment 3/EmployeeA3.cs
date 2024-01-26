using System;

namespace Assignment3_1_
{
    class Employee // defined employee class
    {
        //default constructor
        public Employee()
        {
            FirstName = "John";
            LastName = "Doe";
            id = "123456789";
            startedWorking = DateTime.Now.Year;
            startSalary = 0.0;
        }

        //constructor created
        public Employee(string FirstName, string LastName, string id, int startedWorking, double startSalary)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.id = id;
            this.startedWorking = startedWorking;
            this.startSalary = startSalary;
        }
        // the five fields created
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string id { get; set; }
        public int startedWorking { get; set; }
        public double startSalary { get; set; }
    }
}
