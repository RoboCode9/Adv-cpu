using System;

namespace Assignment3_1_
{
    class Manager : Worker // manager class created which inherited from the worker class
    {
        private int yearPromoted; // year promo field added

        public Manager(string FirstName, string LastName, string id, int startedWorking, double startSalary, int yearPromoted)
       : base(FirstName, LastName, id, startedWorking, startSalary)
        {
            this.yearPromoted = yearPromoted;
        }

        public override double CalculateCurrentSalary(double startSalary, int currentYear) //calculatecurrentsalary function overrided to calculate the salary as manager
        {
            double yearlyIncrement = 0.05; 
            double bonus = 0.10;

            if (currentYear <= yearPromoted) //if the current year is less than or equal to the year promoted calculate as a worker
            {
                return base.CalculateCurrentSalary(startSalary, currentYear);
            }

            else // else calculate as manager
            {
                int yearsWorkedBeforePromotion = yearPromoted - startedWorking;
                double salaryBeforePromotion = base.CalculateCurrentSalary(startSalary, yearPromoted);
                double salaryAfterPromotion = salaryBeforePromotion * Math.Pow(1 + yearlyIncrement, currentYear - yearPromoted);
                return salaryAfterPromotion + (salaryBeforePromotion * bonus);
            }

        }

        public void DisplayManagerInformation()
        {
            Console.WriteLine($"Manager: {FirstName} {LastName}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Years Worked: {CalculateYearsWorked(DateTime.Now.Year)}");
            Console.WriteLine($"Current Salary: ${CalculateCurrentSalary(startSalary, DateTime.Now.Year):F2}");
            Console.WriteLine();
        }
    }
}