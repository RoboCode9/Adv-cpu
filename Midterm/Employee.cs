class Employee
{
    //the specified six fields created
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string WorkerID { get; set; }
    public int YearStartedWorking { get; set; }
    public double InitialSalary { get; set; }
    public double CurrentSalary { get; protected set; } //read only but derived classes can access it

    public Employee(string firstName, string lastName, string workerId, int yearStartedWorking, double initialSalary)
    {
        //initialize values for all fields
        FirstName = firstName;
        LastName = lastName;
        WorkerID = workerId;
        YearStartedWorking = yearStartedWorking;
        InitialSalary = initialSalary;
        CurrentSalary = InitialSalary;
    }

    //a function that assigns the currentsalary value based on initialsalary value
    public virtual void CalculateCurrentSalary()
    {
        CurrentSalary = InitialSalary;
    }
}