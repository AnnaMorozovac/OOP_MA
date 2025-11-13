using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            if (value.Length < 4)
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        protected set
        {
            if (!char.IsUpper(value[0]))
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            if (value.Length < 4)
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\n" +
               $"Last Name: {LastName}";
    }
}

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        private set
        {
            if (value.Length < 5 || value.Length > 10)
                throw new ArgumentException("Invalid faculty number");

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetterOrDigit(value[i]))
                    throw new ArgumentException("Invalid faculty number");
            }
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"\nFaculty number: {facultyNumber}\n";
    }
}

public class Worker : Human
{
    private decimal weekSalary;
    private double workHoursePerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursePerDay)
            : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursePerDay = workHoursePerDay;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value <= 10)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            weekSalary = value;
        }
    }

    public double WorkHoursePerDay
    {
        get { return workHoursePerDay; }
        private set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            workHoursePerDay = value;
        }
    }

    public decimal SalaryPerHour()
    {
        decimal dailySalary = WeekSalary / 5; //п'ять робочих днів
        return dailySalary / (decimal)WorkHoursePerDay;
    }

    public override string ToString()
    {
        return base.ToString()
               + $"\nWeek Salary: {WeekSalary:F2}\n"
               + $"Hours per day: {WorkHoursePerDay:F2}\n"
               + $"Salary per hour: {SalaryPerHour():F2}\n";
    }
}

public class Program
{
    static void Main()
    {
        try
        {
            string[] studentData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string studFirst = studentData[0];
            string studLast = studentData[1];
            string faculty = studentData[2];
            Student student = new Student(studFirst, studLast, faculty);

            string[] workerData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string workFirst = workerData[0];
            string workLast = workerData[1];
            decimal weekSalary = decimal.Parse(workerData[2]);
            double hoursePerDay = double.Parse(workerData[3]);
            Worker worker = new Worker(workFirst, workLast, weekSalary, hoursePerDay);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException er)
        {
            Console.WriteLine(er.Message);
        }
    }
}