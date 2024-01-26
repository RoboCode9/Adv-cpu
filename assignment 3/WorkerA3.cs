using System;
namespace Assignment3_1_
{
    class Worker : Employee, ISalaryCalculate // worker class created that inherited from employee class and isalarycalculate interface.
    {
        private int numberOfYearsWorked; // nYearWked field added
        private double currentSalary; // curSalary field added.

        public Worker(string FirstName, string LastName, string id, int startedWorking, double startSalary) : base(FirstName, LastName, id, startedWorking, startSalary)
        {
            numberOfYearsWorked = CalculateYearsWorked(DateTime.Now.Year);
            currentSalary = CalculateCurrentSalary(startSalary, DateTime.Now.Year);
        }

        public int CalculateYearsWorked(int currentyear) //calculateyearsworked function implemented.
        {
            numberOfYearsWorked = currentyear - startedWorking;
            return numberOfYearsWorked;
        }

        public virtual double CalculateCurrentSalary(double startSalary, int currentYear) //calculatecurrentsalary function implemented.
        {
            double yearlyIncrement = 0.03;
            return startSalary * Math.Pow(1 + yearlyIncrement, numberOfYearsWorked);
        }

        public void DisplayWorkerInformation()
        {
            Console.WriteLine($"Worker: {FirstName} {LastName}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Number of years worked: {numberOfYearsWorked}");
            Console.WriteLine($"Current salary: ${currentSalary:F2}");
            Console.WriteLine();
        }
    }
}
