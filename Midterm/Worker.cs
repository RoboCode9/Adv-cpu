using System;

class Worker : Employee //worker class which inherited from employee class
{
    public int YearsWorked { get; protected set; } //year worked field

    public Worker(string firstName, string lastName, string workID, int yearStartedWorking, double initialSalary)
        : base (firstName, lastName, workID, yearStartedWorking, initialSalary)
    {
        CalculateYearsWorked(DateTime.Now.Year);
    }

    // calculate years worked function with one parameter
    public void CalculateYearsWorked(int currentYear) 
    {
        YearsWorked = currentYear - YearStartedWorking; // do calculations and save it to years worked variable
    }

    // the calculate current salary function being overriden to calculate the current year salary
    public override void CalculateCurrentSalary()
    {
        double yearlyIncrement = 0.03 * InitialSalary;
        CurrentSalary = InitialSalary + (YearsWorked * yearlyIncrement);
    }
}
