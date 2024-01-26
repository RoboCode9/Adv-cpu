public class Taxpayer // tax payer class created
{
    private double yearlyGrossIncome; // variable for yearly gross income 

    public string SSN //get and set for variable 1 ssn
    { get; set; }

    public double YearlyGrossIncome // get and set for variable 2 YearlyGrossIncome
    {
        get { return yearlyGrossIncome; }
        set
        {
            yearlyGrossIncome = value; // income is set
            CalculateTax(); // tax is calculated after income is et
        }
    }

    public double TaxOwed { get; private set; } //TaxOwed made to read-only property

    public static double TotalTaxAmount { get; private set; } = 0.0; // totaltaxamount is static

    private void CalculateTax() // tax calculation occurs here
    {
        if (yearlyGrossIncome < 30000) // if income is 30k or less apply 15% tax and assign this value to "TaxOwed"
        {
            TaxOwed = yearlyGrossIncome * 0.15;
        }
        else
        {
            TaxOwed = yearlyGrossIncome * 0.28; // else apply 28% tax and assign this value to "TaxOwed"
        }

        TotalTaxAmount = TaxOwed + TotalTaxAmount; // tax owed was calculated and added to total tax amount
    }

    public Taxpayer() //default constructor
    {
        SSN = string.Empty;
        yearlyGrossIncome = 0.0;
        TaxOwed = 0.0;
    }
}