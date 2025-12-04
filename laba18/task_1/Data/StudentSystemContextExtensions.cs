namespace P01_StudentSystem.Data
{
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class StudentSystemContextExtensions
    {
        public static void Seed(this StudentSystemContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any() || context.Courses.Any())
            {
                return;
            }

            var random = new Random();

            var students = CreateStudents();
            var courses = CreateCourses();

            var resources = CreateResources(random, courses);
            var homeworks = CreateHomeworks(random, students, courses);
            var studentCourses = CreateStudentCourses(random, students, courses);


            context.Students.AddRange(students);
            context.Courses.AddRange(courses);
            context.Resources.AddRange(resources);
            context.HomeworkSubmissions.AddRange(homeworks);
            context.StudentCourses.AddRange(studentCourses);

            context.SaveChanges();
        }

        private static List<Student> CreateStudents()
        {
            return new List<Student>
            {
                new Student { Name = "Світлана Гончар", PhoneNumber = "0987654321", RegisteredOn = new DateTime(2024, 03, 12), Birthday = new DateTime(2000, 05, 15)},
                new Student { Name = "Дмитро Левченко", PhoneNumber = "1234567898", RegisteredOn = new DateTime(2023, 07, 25), Birthday = new DateTime(1998, 11, 19)},
                new Student { Name = "Ольга Романюк", PhoneNumber = "2345678912", RegisteredOn = new DateTime(2024, 05, 02), Birthday = new DateTime(2001, 04, 10)},
                new Student { Name = "Сергій Ткаченко", PhoneNumber = "4567891231", RegisteredOn = new DateTime(2023, 10, 18), Birthday = new DateTime(2000, 08, 27)},
                new Student { Name = "Наталія Кравець", PhoneNumber = "1234567890", RegisteredOn = new DateTime(2024, 06, 07), Birthday = new DateTime(1999, 02, 14)},
             };
        }

        private static List<Course> CreateCourses()
        {
            return new List<Course>
            {
                new Course { Name = "Кібербезпека та захист даних", Description = "Основи інформаційної безпеки, криптографія, захист мереж та даних.", Price = 1200.00m, StartDate = new DateTime(2025, 05, 01), EndDate = new DateTime(2025, 08, 15)},
                new Course { Name = "Мобільна розробка", Description = "Створення мобільних додатків.", Price = 870.00m, StartDate = new DateTime(2025, 01, 15), EndDate = new DateTime(2025, 04, 30)},
                new Course { Name = "Машинна розробка", Description = "Вступний курс з машинного навчання.", Price = 1100.00m, StartDate = new DateTime(2025, 04, 10), EndDate = new DateTime(2025, 07, 20)},
            };
        }

        private static List<Resource> CreateResources(Random random, List<Course> courses)
        {
            var resourceNames = new[] { "Вступне відео", "Презентація", "Код прикладу", "Документація API" };
            var resources = new List<Resource>();

            for (int i = 0; i < 8; i++)
            {
                resources.Add(new Resource
                {
                    Name = resourceNames[random.Next(resourceNames.Length)] + $" #{i + 1}",
                    Url = $"https://task.com/resource/{Guid.NewGuid()}",
                    ResourceType = (ResourceType)random.Next(0, 4),
                    Course = courses[random.Next(courses.Count)]
                });
            }
            return resources;
        }

        private static List<Homework> CreateHomeworks(Random random, List<Student> students, List<Course> courses)
        {
            var homeworks = new List<Homework>();
            var contentTypes = Enum.GetValues(typeof(ContentType));

            for (int i = 0; i < 10; i++)
            {
                homeworks.Add(new Homework
                {
                    Content = $"C:\\Users\\Submit\\HomeWork_{i + 1}.zip",
                    ContentType = (ContentType)contentTypes.GetValue(random.Next(contentTypes.Length)),
                    SubmissionTime = DateTime.Now.AddDays(-random.Next(1, 30)),
                    Student = students[random.Next(students.Count)],
                    Course = courses[random.Next(courses.Count)]
                });
            }
            return homeworks;
        }

        private static List<StudentCourse> CreateStudentCourses(Random random, List<Student> students, List<Course> courses)
        {
            var studentCourses = new List<StudentCourse>();

            foreach (var student in students)
            {
                for (int i = 0; i < random.Next(1, 3); i++)
                {
                    var course = courses[random.Next(courses.Count)];

                    if (!studentCourses.Any(sc => sc.StudentId == student.StudentId && sc.CourseId == course.CourseId))
                    {
                        studentCourses.Add(new StudentCourse
                        {
                            Student = student,
                            Course = course
                        });
                    }
                }
            }
            return studentCourses;
        }
    }
}
