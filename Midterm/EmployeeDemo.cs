using System;
using System.Linq;
using System.IO;

class EmployeeDemo
{
    static void Main()
    {
        Employee[] employees = ReadData("worker.txt", "manager.txt"); //read data function called
        ObjSort(employees);

        Console.Write("Enter the range of salary, use 1 space after entering first value. (minimum maximum): ");// prompt the user to enter a salary range
        string[] salaryRange = Console.ReadLine().Split(); //user is entering range of salary then the program splits the two values, makes a array of two elements and stores them onto it
        double minimumSalary = double.Parse(salaryRange[0]); // then the program stores the first element of the salaryrange array onto the variable "minimum salary"
        double maximumSalary = double.Parse(salaryRange[1]);

        // display the employee’s information based on the specified range in a descending order
        Console.WriteLine("Employees with current salary in the range specified");
        foreach (var emp in employees)
        {
            if (emp.CurrentSalary >= minimumSalary && emp.CurrentSalary <= maximumSalary)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - Worker ID: {emp.WorkerID}, Current Salary: {emp.CurrentSalary}");
            }
        }
    }

    // read data function that reads from the files worker.txt and manager.txt
    static Employee[] ReadData(string workerFile, string managerFile)
    {
        string[] workerLines = File.ReadAllLines(workerFile);
        string[] managerLines = File.ReadAllLines(managerFile);

        int currentIndex = 0;
        int workerCount = int.Parse(workerLines[currentIndex++]);

        Worker[] workers = new Worker[workerCount];// create a array called workers and the number of elements in this array is based on worker count.

        for (int i = 0; i < workerCount; i++) 
        {
            string firstName = workerLines[currentIndex++];
            string lastName = workerLines[currentIndex++];
            string workerID = workerLines[currentIndex++];
            int yearStartedWorking = int.Parse(workerLines[currentIndex++]);
            double initialSalary = double.Parse(workerLines[currentIndex++]);

            workers[i] = new Worker(firstName, lastName, workerID, yearStartedWorking, initialSalary); // populate each element of the workers array with this information
        }

        currentIndex = 0;
        int managerCount = int.Parse(managerLines[currentIndex++]);

        Manager[] managers = new Manager[managerCount];

        for (int i = 0; i < managerCount; i++)
        {
            string firstName = managerLines[currentIndex++];
            string lastName = managerLines[currentIndex++];
            string workerID = managerLines[currentIndex++];
            int yearStartedWorking = int.Parse(managerLines[currentIndex++]);
            double initialSalary = double.Parse(managerLines[currentIndex++]);
            int yearPromoted = int.Parse(managerLines[currentIndex++]);

            managers[i] = new Manager(firstName, lastName, workerID, yearStartedWorking, initialSalary, yearPromoted); // populate each element of the managers array with this information
        }

        Console.Write("Enter the current year: "); //prompt user for current year
        int currentYear = int.Parse(Console.ReadLine());

        foreach (var worker in workers)
        {
            worker.CalculateYearsWorked(currentYear); // calcuate years worked
            worker.CalculateCurrentSalary(); // calculate current salary
        }

        foreach (var manager in managers)
        {
            manager.CalculateYearsWorked(currentYear);
            manager.CalculateCurrentSalary();
        }

        Employee[] employees = workers.Cast<Employee>().Concat(managers.Cast<Employee>()).ToArray();

        return employees;
    }

    // object sort function that sorts the employees array in descending order based on salary
    static void ObjSort(Employee[] employees) // take 1 object parameter
    {
        // sort array by salary in descending order
        Array.Sort(employees, (emp1, emp2) => emp2.CurrentSalary.CompareTo(emp1.CurrentSalary));
    }
}