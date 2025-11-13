using System;
using System.Collections.Generic;
using System.Linq;

class Patient
{
    public string Name { get; }
    
    public Patient(string name)
    {
        Name = name;
    }

}

class Room
{
    private List<Patient> beds = new List<Patient>();
    public int Number { get; private set; }

    public Room(int number)
    {
        Number = number;
    }

    public bool AddPatient(Patient p)
    {
        if (beds.Count < 3)
        {
            beds.Add(p);
            return true;
        }
        return false;
    }

    public List<Patient> GetPatients()
    {
        return beds;
    }
}

class Department
{
    public string Name { get; private set; }
    private List<Room> rooms = new List<Room>();

    public Department(string name)
    {
        Name = name;
        for (int i = 1; i <= 20; i++)
            rooms.Add(new Room(i));
    }

    public bool AddPatient(Patient p)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].AddPatient(p))
            {
                return true;
            }
        }

        return false;
    }

    public List<Patient> GetAllPatients()
    {
        List<Patient> all = new List<Patient>();
        for (int i = 0; i < rooms.Count; i++)
        {
            List<Patient> roomP = rooms[i].GetPatients();
            for (int j = 0; j < roomP.Count; j++)
            {
                all.Add(roomP[j]);
            }
        }

        return all;
    }

    public List<Patient> GetPatientFromRoom(int roomN)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].Number == roomN)
            {
                return rooms[i].GetPatients();
            }
        }

        return new List<Patient>();
    }
}

class Doctor
{
    public string FullName { get; private set; }
    private List<Patient> patients = new List<Patient>();

    public Doctor(string fullName)
    {
        FullName = fullName;
    }

    public void AddPatient(Patient p)
    {
        patients.Add(p);
    }

    public List<Patient> GetPatients()
    {
        return patients;
    }
}

class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>();
        List<Doctor> doctors = new List<Doctor>();
        List<string> output = new List<string>();

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "Output") break;

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string depName = parts[0];
            string doctorName = parts[1] + " " + parts[2];
            string patientName = parts[3];

            Department dep = null;
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name == depName)
                {
                    dep = departments[i];
                    break;
                }
            }
            if (dep == null)
            {
                dep = new Department(depName);
                departments.Add(dep);
            }

            Doctor doc = null;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].FullName == doctorName)
                {
                    doc = doctors[i];
                    break;
                }
            }
            if (doc == null)
            {
                doc = new Doctor(doctorName);
                doctors.Add(doc);
            }

            Patient p = new Patient(patientName);

            if (dep.AddPatient(p))
            {
                doc.AddPatient(p);
            }
        }

        while (true)
        {
            string cmd = Console.ReadLine();
            if (cmd == "End") break;

            string[] parts = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1)
            {
                string depName = parts[0];
                Department dep = null;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].Name == depName)
                    {
                        dep = departments[i];
                        break;
                    }
                }

                if (dep != null)
                {
                    List<Patient> allP = dep.GetAllPatients();
                    for (int i = 0; i < allP.Count; i++)
                    {
                        output.Add(allP[i].Name);
                    }
                }
            }
            else if (parts.Length == 2 && int.TryParse(parts[1], out int roomNum))
            {
                string depName = parts[0];
                Department dep = null;
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].Name == depName)
                    {
                        dep = departments[i];
                        break;
                    }
                }

                if (dep != null)
                {
                    List<Patient> roomP = dep.GetPatientFromRoom(roomNum);
                    roomP.Sort((a, b) => string.Compare(a.Name, b.Name));
                    for (int i = 0; i < roomP.Count; i++)
                    {
                        output.Add(roomP[i].Name);
                    }
                }
            }
            else if (parts.Length == 2)
            {
                string doctorName = parts[0] + " " + parts[1];
                Doctor doc = null;
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].FullName == doctorName)
                    {
                        doc = doctors[i];
                        break;
                    }
                }

                if (doc != null)
                {
                    List<Patient> docPat = doc.GetPatients();
                    docPat.Sort((a, b) => string.Compare(a.Name, b.Name));
                    for (int i = 0; i < docPat.Count; i++)
                    {
                        output.Add(docPat[i].Name);
                    }
                }
            }
        }

        for (int i = 0; i < output.Count; i++)
        {
            Console.WriteLine(output[i]);
        }
    }
}