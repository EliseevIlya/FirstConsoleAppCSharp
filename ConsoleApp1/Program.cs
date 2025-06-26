using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Привет, эта программа для обработки оценок учеников");
        try
        {
            List<Student> students = StudentService.InputStudent();
            
            StudentService.PrintStudents(students);
            StudentService.PrintMaxStudent(students);
            StudentService.PrintMinStudent(students);
            StudentService.PrintAverage(students);
            StudentService.PrintSubjectAverages(students);
            StudentService.FindStudentByName(students);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}