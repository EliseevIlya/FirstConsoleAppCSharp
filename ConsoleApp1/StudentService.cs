namespace ConsoleApp1;

public class StudentService
{
    public static List<Student> InputStudent()
    {
        var students = new List<Student>();

        string[] subjects = ["Математика", "Информатика", "Русский"];
        
        int studentsCount = 0;

        while (true)
        {
            Console.WriteLine("Введите количество учеников");
            var input = Console.ReadLine();
            if (int.TryParse(input, out studentsCount) && studentsCount >= 1)
            {
                break;
            }

            Console.WriteLine("Ошибка: введите положительное целое число");
        }

        for (int i = 0; i < studentsCount; i++)
        {
            Console.WriteLine("Имя");
            var iputName = Console.ReadLine();
            
            var grades = new Dictionary<string, int>();
            foreach (var subject in subjects)
            {
                while (true)
                {
                    Console.Write($"{subject}: ");
                    if (int.TryParse(Console.ReadLine(), out int grade) && grade is >= 0 and <= 5)
                    {
                        grades[subject] = grade;
                        break;
                    }

                    Console.WriteLine("Некорректная оценка.");
                }
            }

            if (iputName != null) students.Add(new Student(iputName, grades));
        }
        return students;
    }

    public static void PrintStudents(List<Student> students)
    {
        students.ForEach(student => Console.WriteLine(student));
    }

    public static void PrintAverage(List<Student> students)
    {
        Console.WriteLine("Средний балл каждого");
        students.ForEach(student => Console.WriteLine($"{student.Name}: {student.Average:F2}"));
    }

    public static void PrintMinStudent(List<Student> students)
    {
        var first = students.OrderBy(student => student.Average).First();
        Console.WriteLine($"Худший результат {first.Name} с результатом: {first.Average:F2}");
    }
    
    public static void PrintMaxStudent(List<Student> students)
    {
        var first = students.OrderByDescending(student => student.Average).First();
        Console.WriteLine($"Лучший результат {first.Name} с результатом: {first.Average:F2}");
    }
    
    public static void PrintSubjectAverages(List<Student> students)
    {
        Console.WriteLine("Средний балл по предметам:");
        var subjects = students.SelectMany(s => s.Grades.Keys).Distinct();
        foreach (var subject in subjects)
        {
            double avg = students.Average(s => s.Grades[subject]);
            Console.WriteLine($"{subject}: {avg:F2}");
        }
    }

    public static void FindStudentByName(List<Student> students)
    {
        Console.WriteLine("Введите имя");
        var search = Console.ReadLine();
        var student = students.FirstOrDefault(student => student.Name.Equals(search, StringComparison.OrdinalIgnoreCase));
        if (student != null)
        {
            Console.WriteLine($"Оценки {student.Name}");
            foreach (var grade in student.Grades)
            {
                Console.WriteLine($"{grade.Key}: {grade.Value:F2}");
            }
        }
        else
        {
            Console.WriteLine("Не найден");
        }
    }
}