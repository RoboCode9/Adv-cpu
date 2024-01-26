using System;

class Manager : Worker
{
    public int YearPromo { get; set; } // year promoted field added

    public Manager (string firstName, string lastName, string workerID, int yearStartedWorking, double initialSalary, int yearPromo)
        : base(firstName, lastName, workerID, yearStartedWorking, initialSalary)
    {
        YearPromo = yearPromo;
        CalculateYearsWorked(DateTime.Now.Year);
    }

    // calculate current salary function, that calculates the current year salary by overrriding the parent classes calculate current salary function
    public override void CalculateCurrentSalary()
    {
        double yearlyIncrement = 0.03 * InitialSalary;
        double bonus = 0.1 * InitialSalary;

        if (YearsWorked < YearPromo)
        {
            CurrentSalary = base.CurrentSalary + (YearsWorked * yearlyIncrement);
        }

        else
        {
            CurrentSalary = (YearPromo * yearlyIncrement) + ((YearsWorked - YearPromo) * (yearlyIncrement - bonus));
        }
    }
}