using System;

public class Employeedemo
{
    public static void Main()
    {
        int employeeinput; 
        int numOfEmployees;
        int selection;
        int idInput;
        double wageInput;
        short hoursInput;

        
        while (true)
        {
            Console.Write("Enter the number of employees in your company: ");
            if (int.TryParse(Console.ReadLine(), out employeeinput)) // this section is used to validate input
            {
                numOfEmployees = employeeinput;
                break;
            }
            else
            {
                Console.WriteLine("wrong input please enter a number of employees");
            }
        }

        Employee[] employees = new Employee[numOfEmployees]; //make an array of employee objects based on the value of numofemployees

        for (int index = 0; index < numOfEmployees; index++) // gather employees info
        {
            employees[index] = new Employee(); // populate the target index with the default constructor

            Console.WriteLine("Enter employee number {0} first name:", index + 1); // gather first name
            employees[index].FirstN = Console.ReadLine(); // add it to this index

            Console.WriteLine("Enter employee number {0} last name:", index + 1); // gather last name
            employees[index].LastN = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter employee number {0} ID Number:", index + 1);
                if (int.TryParse(Console.ReadLine(), out idInput)) // used to validate input for id number which cannot be a letter or else try again.
                {
                    employees[index].IdNum = idInput; // if succeed store to this index with the property IdNum
                    break;
                }
                else
                {
                    Console.WriteLine("wrong input please enter a number."); // if fail.
                }
            }

            while (true)
            {
                Console.WriteLine("Enter employee {0} wage:", index + 1);
                if (double.TryParse(Console.ReadLine(), out wageInput))
                {
                    employees[index].Wage = wageInput;
                    break;
                }
                else
                {
                    Console.WriteLine("wrong input please enter a number.");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter the number of hours worked this week for employee {0}:", index + 1);
                if (short.TryParse(Console.ReadLine(), out hoursInput))
                {
                    employees[index].WeekHrsWkd = hoursInput;
                    break;
                }
                else
                {
                    Console.WriteLine("wrong input please enter a valid amount.");
                }
            }
        }
        Console.Clear();
        do
        {
            Console.WriteLine("Select an employee number to view their infomation.");

            for (int item = 0; item < numOfEmployees; item++) 
            {
                Console.WriteLine($"{item + 1}: Employee {item + 1} "); // write to console based on the number of elements in numofemployees 
            }

            Console.WriteLine($"{numOfEmployees + 1}: exit"); // the option for this will depend on the # of employees.

            if (int.TryParse(Console.ReadLine(), out selection))
            {
               if (selection >= 1 && selection <= numOfEmployees) 
                {
                    Console.Clear();
                    InfoEmployee(employees[selection - 1]); //calls the method infoemployee from below
                }

               else if (selection == numOfEmployees + 1) // to exit the program.
                {
                    Console.WriteLine("bye.");
                }

               else // for input validation.
                {
                    Console.WriteLine("Wrong selection. please try again"); 
                }
            }

            else
            {
                Console.WriteLine("wrong input.");
            }
        } while (selection != numOfEmployees + 1);
    }

    private static void InfoEmployee(Employee employee) // the method infoemployee with its parameters for displaying employee information.
    {
        Console.WriteLine("Information about selected employee:");
        Console.WriteLine($"First Name: {employee.FirstN}");
        Console.WriteLine($"Last Name: {employee.LastN}");
        Console.WriteLine($"Wage: {employee.Wage:C}");
        Console.WriteLine($"Hours worked this week: {employee.WeekHrsWkd}");
        Console.WriteLine($"Payment: {employee.CalcPay():C}");
        Console.WriteLine("");
    }
}