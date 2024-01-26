using System;
using System.Linq;

namespace TaxPayer2
{ 
    class TaxPayerDemo
    {
        public static void Main(string[] args)
        {
            int taxpayers;

            // prompt user to enter number of taxpayers
            Console.Write("Enter the number of taxpayers: "); 
            taxpayers = Convert.ToInt32((Console.ReadLine()));

            //create dynamic array objects based on the number of taxpayers
            Taxpayer[] taxpayer = new Taxpayer[taxpayers];


            for (int index = 0; index < taxpayers; index++)
            {
                bool validSSN = false;

                // initialize a object with default values I made in taxpayer.cs and assign it to the current element
                taxpayer[index] = new Taxpayer();

                //prompt the user for data (ssn and yearly income)
                while(!validSSN)
                {
                    Console.WriteLine("Please enter a Social Security Number for taxpayer number {0}, do not use dashes or any other character besides digits:", index + 1);
                    string ssnInput = Console.ReadLine();

                    if (ssnInput.All(char.IsDigit))
                    {
                        taxpayer[index].SSN = ssnInput;
                        validSSN = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid social security format, try again.");
                    }

                }

                Console.WriteLine("");

                Console.Write("Enter the yearly gross income for taxpayer number {0}: ", index + 1);
                taxpayer[index].YearlyGrossIncome = Convert.ToDouble((Console.ReadLine()));

                Console.WriteLine("");
            }

            //Sorting the taxpayers in order of tax owed (least to greatest)
            Array.Sort(taxpayer, (x, y) => x.TaxOwed.CompareTo(y.TaxOwed));

            //Print the result
            Console.WriteLine("Taxpayer sorted by tax owed (least to greatest)");
            Console.WriteLine("");

            foreach (var z in taxpayer)
            {
                Console.WriteLine("Social Security Number: " + z.SSN);
                Console.WriteLine("Tax Owed: " + z.TaxOwed);
                Console.WriteLine("");
            }

            Console.WriteLine("Total tax owed on all taxpayers: " + Taxpayer.TotalTaxAmount);
        }
    }
}
