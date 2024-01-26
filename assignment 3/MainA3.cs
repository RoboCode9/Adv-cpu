using System;
using System.IO;

namespace Assignment3_1_
{
    class MainProgram
    {
        static void Main()
        {
            string workerTextFilePath = "worker.txt"; //read from local file where exe is located
            string managerTextFilePath = "manager.txt";

            Worker[] workers = ReadWorker(workerTextFilePath); // create a dynamic array object 
            Manager[] managers = ReadManagers(managerTextFilePath);

            Console.Write("Enter the current year: "); //prompt user for current year
            int currentYear = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWorkers information:"); //display workers information
            foreach (Worker worker in workers)
            {
                worker.DisplayWorkerInformation();
            }

            Console.WriteLine("Managers information:");//display managers information
            foreach (Manager manager in managers)
            {
                manager.DisplayManagerInformation();
            }
        }

        static Worker[] ReadWorker(string filePath) //creating the workers array based on the file worker.txt
        {
            string[] lines = File.ReadAllLines(filePath);

            int numberOfWorkers = int.Parse(lines[0]);
            Worker[] workers = new Worker[numberOfWorkers];

            int currentIndex = 1;

            for (int i = 0; i < numberOfWorkers; i++)
            {
                string firstName = lines[currentIndex++];
                string lastName = lines[currentIndex++];
                string id = lines[currentIndex++];
                int startedWorking = int.Parse(lines[currentIndex++]);
                double startSalary = double.Parse(lines[currentIndex++]);
                workers[i] = new Worker(firstName, lastName, id, startedWorking, startSalary);
            }

            return workers;
        }

        static Manager[] ReadManagers(string filePath) //creating the managers array based on the file manager.txt
        {
            string[] lines = File.ReadAllLines(filePath);

            int numberOfManagers = int.Parse(lines[0]);
            Manager[] managers = new Manager[numberOfManagers];

            int currentIndex = 1;

            for (int i = 0; i < numberOfManagers; i++)
            {
                string firstName = lines[currentIndex++];
                string lastName = lines[currentIndex++];
                string id = lines[currentIndex++];
                int startedWorking = int.Parse(lines[currentIndex++]);
                double startSalary = double.Parse(lines[currentIndex++]);
                int yearPromoted = int.Parse(lines[currentIndex++]);
                managers[i] = new Manager(firstName, lastName, id, startedWorking, startSalary, yearPromoted);
            }

            return managers;
        }
    }
}
