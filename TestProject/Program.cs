/*
97 - 100   A+
93 - 96    A
90 - 92    A-
87 - 89    B+
83 - 86    B
80 - 82    B-
77 - 79    C+
73 - 76    C
70 - 72    C-
67 - 69    D+
63 - 66    D
60 - 62    D-
0  - 59    F
*/

/*
Student         Grade

Sophia:         92.2    A-
Andrew:         89.6    B+
Emma:           85.6    B
Logan:          91.2    A-
*/

using System.Diagnostics;

const int examAssignments = 5;

var studentScores = new Dictionary<string, int[]>
{
    { "Sophia", new[] { 90, 86, 87, 98, 100, 94, 90 } },
    { "Andrew", new[] { 92, 89, 81, 96, 90, 89 } },
    { "Emma", new[] { 90, 85, 87, 98, 68, 89, 89, 89 } },
    { "Logan", new[] { 90, 95, 87, 88, 96, 96 } },
    { "Becky", new[] { 92, 91, 90, 91, 92, 92, 92 } },
    { "Chris", new[] { 84, 86, 88, 90, 92, 94, 96, 98 } },
    { "Eric", new[] { 80, 90, 100, 80, 90, 100, 80, 90 } },
    { "Gregor", new[] { 91, 91, 91, 91, 91, 91, 91 } }
};

var students = studentScores.Select(kvp => new Student(
    kvp.Key, CalculateScore(kvp.Value), CalculateGrade(CalculateScore(kvp.Value))));

static string CalculateGrade(decimal score)
{
    return score switch
    {
        >= 97 => "A+",
        >= 93 => "A",
        >= 90 => "A-",
        >= 87 => "B+",
        >= 83 => "B",
        >= 80 => "B-",
        >= 77 => "C+",
        >= 73 => "C",
        >= 70 => "C-",
        >= 67 => "D+",
        >= 63 => "D",
        >= 60 => "D-",
        _ => "F"
    };
}

Console.WriteLine("Student\t\tGrade\n");

foreach (var student in students) Console.WriteLine($"{student.Name}:\t\t{student.Score}\t{student.Grade}");

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
return;

decimal CalculateScore(int[] scores)
{
    if (scores.Length <= examAssignments) return (decimal)scores.Sum() / examAssignments;

    var examScores = scores[..examAssignments];
    var extraScores = scores[examAssignments..];

    Debug.Assert(extraScores != null, nameof(extraScores) + " != null");
    var totalScore = (decimal)examScores.Sum() + extraScores.Sum() / 10;

    return totalScore / examAssignments;
}

internal class Student(string name, decimal score, string grade)
{
    public string Name { get; } = name;
    public decimal Score { get; } = score;
    public string Grade { get; } = grade;
}