using System;
using System.Collections.Generic;
using System.Linq;

/*
Private 1 Pesho Peshev 22,22
Commando 13 Stamat Stamov 13,1 Airforces
Private 222 Toncho Tonchev 80,08
LeutenantGeneral 3 Joro Jorev 100 222 1

Engineer 7 Pencho Penchev 12,23 Marines Boat 2 Crane 17
Commando 19 Penka Ivanova 150,15 Airforces HairyFoot finished Freedom inProgress
End
*/

public interface ISoldier
{
    int Id { get; }
    string FirstName { get; }
    string LastName { get; }
}

public interface IPrivate : ISoldier
{
    decimal Salary { get; }
}

public interface ILeutenantGeneral : IPrivate
{
    List<IPrivate> Privates { get; }
}

interface ISpecialisedSoldier : IPrivate
{
    string Corps { get; }
}

interface IEngineer : ISpecialisedSoldier
{
    List<Repair> Repairs { get; }
}

interface ICommando : ISpecialisedSoldier
{
    List<Mission> Missions { get; }
}

interface ISpy : ISoldier
{
    int CodeNumber { get; }
}

public abstract class Soldier : ISoldier
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}

public class Private : Soldier, IPrivate
{
    public decimal Salary { get; }

    public Private(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {Salary:F2}";
    }
}

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<IPrivate> Privates { get; }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        Privates = new List<IPrivate>();
    }

    public override string ToString()
    {
        string result = $"{base.ToString()}\nPrivates:";
        List<IPrivate> orderedPrivates = Privates.OrderByDescending(p => p.Salary).ToList();
        for (int i = 0; i < orderedPrivates.Count; i++)
        {
            result += $"\n {orderedPrivates[i]}";
        }
        return result;
    }

}

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; }

    protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        if (corps != "Airforces" && corps != "Marines")
        {
            throw new ArgumentException("Invalid corps");
        }
        Corps = corps;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCorps: {Corps}";
    }
}

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; }

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<Repair>();
    }

    public override string ToString()
    {
        string result = $"{base.ToString()}\nRepairs:";
        for (int i = 0; i < Repairs.Count; i++)
        {
            result += $"\n {Repairs[i]}";
        }
        return result;
    }
}

public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; }

    public Commando(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<Mission>();
    }

    public override string ToString()
    {
        string result = $"{base.ToString()}\nMissions:";
        for (int i = 0; i < Missions.Count; i++)
        {
            result += $"\n {Missions[i]}";
        }
        return result;
    }

}

public class Spy : Soldier, ISpy
{
    public int CodeNumber { get; }

    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {CodeNumber}";
    }
}

public class Repair
{
    public string PartName { get; }
    public int HoursWorked { get; }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}

public class Mission
{
    public string CodeName { get; }
    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        if (state != "inProgress" && state != "Finished")
        {
            throw new ArgumentException("Invalid mission state");
        }

        CodeName = codeName;
        State = state;
    }

    public void CompleteMission()
    {
        State = "Finished";
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State}";
    }
}

public class Program
{
    public static void Main()
    {
        List<Soldier> soldiers = new List<Soldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = parts[0];

            try
            {
                switch (type)
                {
                    case "Private":
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            decimal salary = decimal.Parse(parts[4]);

                            soldiers.Add(new Private(id, firstName, lastName, salary));
                            break;
                        }

                    case "LeutenantGeneral":
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            decimal salary = decimal.Parse(parts[4]);

                            LeutenantGeneral general = new LeutenantGeneral(id, firstName, lastName, salary);

                            for (int i = 5; i < parts.Length; i++)
                            {
                                string pidText = parts[i];
                                int pid = int.Parse(pidText);

                                for (int j = 0; j < soldiers.Count; j++)
                                {
                                    IPrivate privateSolider = (IPrivate)soldiers[j];

                                    if (privateSolider.Id == pid)
                                    {
                                        general.Privates.Add(privateSolider);
                                        break;
                                    }
                                }
                            }

                            soldiers.Add(general);
                            break;
                        }

                    case "Engineer":
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            string corps = parts[5];

                            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string partName = parts[i];
                                int hoursWorked = int.Parse(parts[i + 1]);
                                engineer.Repairs.Add(new Repair(partName, hoursWorked));
                            }

                            soldiers.Add(engineer);
                            break;
                        }

                    case "Commando":
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            decimal salary = decimal.Parse(parts[4]);
                            string corps = parts[5];

                            Commando commando = new Commando(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                string codeName = parts[i];
                                string state = parts[i + 1];

                                try
                                {
                                    commando.Missions.Add(new Mission(codeName, state));
                                }
                                catch
                                {
                                    continue;
                                }
                            }

                            soldiers.Add(commando);
                            break;
                        }

                    case "Spy":
                        {
                            int id = int.Parse(parts[1]);
                            string firstName = parts[2];
                            string lastName = parts[3];
                            int codeNumber = int.Parse(parts[4]);

                            soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                            break;
                        }
                }
            }
            catch
            {
                continue;
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}
