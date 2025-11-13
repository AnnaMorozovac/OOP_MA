using System;

class Employee
{
    public string Name;
    public decimal Salary;
    public string Position;
    public string Depart;
    public string Email;
    public int Age;

    public Employee(string name, decimal salary, string position, 
                    string depart)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Depart = depart;
        Email = "n/a";
        Age = -1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введiть кiлькiсть працiвникiв: ");
        int n = int.Parse(Console.ReadLine());

        Employee[] employee = new Employee[n];
        Console.WriteLine("Введiть працiвникiв: ");
        for(int i=0; i<n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0];
            decimal salary = decimal.Parse(parts[1]);
            string position = parts[2];
            string depart = parts[3];

            Employee emp = new Employee(name, salary, position, depart);

            if(parts.Length == 5)
            {
                if (parts[4].All(char.IsDigit))
                {
                    emp.Age = int.Parse(parts[4]);
                }
                else
                {
                    emp.Email = parts[4];
                }
            } else if(parts.Length == 6)
            {
                emp.Email = parts[4];
                emp.Age = int.Parse(parts[5]);
            }

            employee[i] = emp;
        }

        string[] departs = new string[n];
        int count = 0;
        for(int i=0; i<n; i++)
        {
            bool temp = false;
            for(int j=0; j<count; j++)
            {
                if (departs[j] == employee[i].Depart)
                {
                    temp = true;
                    break;
                }
            }
            if (!temp)
            {
                departs[count] = employee[i].Depart;
                count++;
            }
        }

        string dept1 = "";
        decimal avg1 = 0;
        for(int i=0; i<count; i++)
        {
            string dept = departs[i];
            decimal total = 0;
            int countEm1 = 0;

            for(int j=0; j<n; j++)
            {
                if (employee[j].Depart == dept)
                {
                    total += employee[j].Salary;
                    countEm1++;
                }
            }

            decimal avg = total / countEm1;
            if(avg > avg1)
            {
                avg1 = avg;
                dept1 = dept;
            }
        }

        Console.WriteLine(" ");
        Console.WriteLine($"Найвища середня зарплата: {dept1}");

        for(int i=0; i<n-1; i++)
        {
            for (int j = i+1; j<n; j++)
            {
                if (employee[i].Salary < employee[j].Salary)
                {
                    Employee temp = employee[i];
                    employee[i] = employee[j];
                    employee[j] = temp;
                }
            }
        }

        for(int i=0; i<n; i++)
        {
            if (employee[i].Depart == dept1)
            {
                Console.WriteLine($"{employee[i].Name}, {employee[i].Salary}, {employee[i].Email}, {employee[i].Age}");
            }
        }
        

    }

}