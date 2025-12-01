using System;
using System.Numerics;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PO1_HpspitalDatabase.Data;
using PO1_HpspitalDatabase.Data.Models;

class Program
{
    static Doctor LoggedInDoctor = null;
    static void Main()
    {
        using var context = new HospitalContext();
        //context.Database.EnsureCreated();

        //Console.WriteLine("Hospital database created!");

        while (LoggedInDoctor == null)
        {
            Console.WriteLine(" -- Hospital System -- ");
            Console.WriteLine("1. Register as Doctor");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": RegisterDoctor(context); break;
                case "2": Login(context); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }


        while (true)
        {
            Console.WriteLine($"\n -- Welcome, Dr. {LoggedInDoctor.Name} -- ");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. View all patient");
            Console.WriteLine("3. Add doctor");
            Console.WriteLine("4. View all doctor");
            Console.WriteLine("5. Add visitation");
            Console.WriteLine("0. Exit");
            Console.Write("Select choose: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": AddPatient(context); break;
                case "2": ViewPatients(context); break;
                case "3": AddDoctor(context); break;
                case "4": ViewDoctors(context); break;
                case "5": AddVisitation(context); break;
                case "0": return;
            }

            Console.WriteLine();
        }
    }

    static void RegisterDoctor(HospitalContext context)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Specialty: ");
        string specialty = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var doctor = new Doctor
        {
            Name = name,
            Specialty = specialty,
            Email = email,
            Password = password
        };

        context.Doctors.Add(doctor);
        context.SaveChanges();

        Console.WriteLine("Doctor registred successfully");
    }

    static void Login(HospitalContext context)
    {
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var doc = context.Doctors
            .FirstOrDefault(d => d.Email == email && d.Password == password);

        if (doc == null)
        {
            Console.WriteLine("Invalid login!");
            return;
        }

        LoggedInDoctor = doc;
        Console.WriteLine($"Welcome, Dr. {doc.Name}");
    }

    static void AddPatient(HospitalContext context)
    {
        Console.Write("First name: ");
        string firstname = Console.ReadLine();
        
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("HasInsurance (yes/no): ");
        bool hasInsurance = Console.ReadLine().Trim().ToLower() == "yes";

        var patient = new Patient
        {
            FirstName = firstname,
            LastName = lastName,
            Address = address,
            Email = email,
            HasInsurance = hasInsurance
        };

        context.Patients.Add(patient);
        context.SaveChanges();

        Console.WriteLine("Patient added!");
    }

    static void ViewPatients(HospitalContext context)
    {
        foreach (var p in context.Patients)
        {
            Console.WriteLine($"{p.PatientId}: {p.FirstName} {p.LastName} - {p.Email}");

            if (p.Visitations.Count > 0)
            {
                Console.WriteLine("  Visitions: ");
                foreach (var v in p.Visitations)
                {
                    string doctorName = v.Doctor != null ? v.Doctor.Name : "No doctor";
                    Console.WriteLine($"   {v.Date}: {doctorName} - {v.Comments}");
                }
            }
        }
    }

    static void AddDoctor(HospitalContext context)
    {
        Console.Write("Doctor name: ");
        string name = Console.ReadLine();

        Console.Write("Specialty: ");
        string specialty = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var doctor = new Doctor
        {
            Name = name,
            Specialty = specialty,
            Email = email,
            Password = password
        };

        context.Doctors.Add(doctor);
        context.SaveChanges();

        Console.WriteLine("Doctor added!");
    }

    static void ViewDoctors(HospitalContext context)
    {
        foreach (var d in context.Doctors)
        {
            Console.WriteLine($"{d.DoctorId}: {d.Name} - {d.Specialty}");
        }
    }

    static void AddVisitation(HospitalContext context)
    {
        Console.Write("Patient ID: ");
        int patientId = int.Parse(Console.ReadLine());

        Console.Write("Doctor ID (optional, press Enter to skip): ");
        string doctorInput = Console.ReadLine();
        int? doctorId = string.IsNullOrEmpty(doctorInput) ? null : int.Parse(doctorInput);

        Console.Write("Comments: ");
        string comments = Console.ReadLine();

        var visitarion = new Visitation()
        {
            PatientId = patientId,
            DoctorId = doctorId,
            Date = DateTime.Now,
            Comments = comments
        };

        context.Visitations.Add(visitarion);
        context.SaveChanges();

        Console.WriteLine("Visitoin added!");
    }
}
