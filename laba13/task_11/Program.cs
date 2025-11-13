using System;
using System.Collections.Generic;
using System.Linq;

class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNum { get; set; }

    public StudentSpecialty(string specialtyName, string facultyNumb)
    {
        SpecialtyName = specialtyName;
        FacultyNum = facultyNumb;
    }
}

class Student
{
    public string Name { get; set; }
    public string FacultyNum { get; set; }

    public Student(string name, string facultyNum)
    {
        Name = name;
        FacultyNum = facultyNum;
    }
}

class Program
{
    static void Main()
    {
        var specialty = new List<StudentSpecialty>();
        var student = new List<Student>();

        string input1;
        while ((input1 = Console.ReadLine()) != "Students:")
        {
            string[] parts = input1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string sName = string.Join(" ", parts.Take(parts.Length - 1));
            string facNum = parts.Last();

            specialty.Add(new StudentSpecialty(sName, facNum));
        }

        string input2;
        while ((input2 = Console.ReadLine()) != "END")
        {
            string[] parts = input2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string facName = parts[0];
            string name = string.Join(' ', parts.Skip(1));

            student.Add(new Student(name, facName));
        }

        var result = specialty.Join(student, specialty => specialty.FacultyNum, student => student.FacultyNum,
                              (specialty, student) => new
                              {
                                  SpecialtyName = specialty.SpecialtyName,
                                  StudentName = student.Name,
                                  FacultNum = student.FacultyNum
                              }).OrderBy(s => s.StudentName);

        foreach (var students in result)
        {
            Console.WriteLine($"{students.StudentName} {students.FacultNum} {students.SpecialtyName}");
        }
    }
}