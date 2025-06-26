namespace ConsoleApp1;

public class Student(string name, Dictionary<string, int> grades)
{
    public string Name { get; set; } = name;
    public Dictionary<string,int> Grades { get; set; } = grades;
    
    public double Average => Grades.Count == 0 ? 0.0 : Grades.Values.Average();
}