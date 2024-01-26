using System;

class Employee
{
    private string firstN;
    private string lastN;
    private int idNum;
    private double wage;
    private int weekHrsWkd;
    private int regHrsAmt = 40;
    private double regPay;
    private double otPay;

    public Employee() // default constructor
    {
        firstN = "No Name";
        lastN = "No Name";
        idNum = 12345678;
        wage = 0.0;
        weekHrsWkd = 0;
    }

    public double CalcPay() // for calculating reguler pay and overtime pay and returning those two totaled.
    {
        if (weekHrsWkd <= regHrsAmt) // if the weekday work is equal to or less 40 hours
        {
            regPay = weekHrsWkd * wage; //weekdaywork is appropriate since it can be 40 hours or less.
            otPay = 0;
        }

        else
        {
            regPay = regHrsAmt * wage; // since it is over time reghrsamt is used since it is fixed to 40 hours
            otPay = (weekHrsWkd - regHrsAmt) * (wage * 1.5); // calculate overtime pay
        }

        return regPay + otPay; // return total of regulerpay plus overtime pay
    }

    public string FirstN //property for first name
    {
        get{ return firstN; }
        set{ firstN = value; }
    }

    public string LastN //property for last name
    {
        get{ return lastN; }
        set{ lastN = value; }
    }

    public int IdNum //propert for IdNum
    {
        get { return idNum; }
        set { idNum = value; }
    }

    public double Wage //property for Wage
    {
        get { return wage; }
        set { wage = value; }
    }

    public int WeekHrsWkd // property for weekhrswkd
    {
        get { return weekHrsWkd; }
        set { weekHrsWkd = value; }
    }
}