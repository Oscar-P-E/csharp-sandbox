using System.Diagnostics;

const int examAssignmentCount = 5;

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
    name: kvp.Key,
    score: CalculateScores(kvp.Value)["Overall Score"],
    grade: CalculateGrade(CalculateScores(kvp.Value)["Overall Score"]),
    examScore: CalculateScores(kvp.Value)["Exam Score"],
    credit: CalculateScores(kvp.Value)["Extra Credit"]
    ));


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

// Student         Exam Score      Overall Grade   Extra Credit
//
// Sophia          0               95.8    A       0 (0 pts)
// Andrew          0               91.2    A-      0 (0 pts)
// Emma            0               90.4    A-      0 (0 pts)
// Logan           0               93      A       0 (0 pts)

Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

foreach (var student in students) Console.WriteLine($"{student.Name}:\t\t{student.ExamScore}\t\t{student.Score}\t{student.Grade}\t({student.Credit})");

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
return;

Dictionary<string, decimal> CalculateScores(int[] scores)
{
    var examScores = scores[..examAssignmentCount];
    var extraScores = scores.Length >= examAssignmentCount ? scores[examAssignmentCount..] : [];
    
    var sumOfScores = examScores.Sum() + extraScores.Sum() * 0.10m;

    var overallExamScore = 1.0m * examScores.Sum() / examAssignmentCount;
    var overallTotalScore = (decimal)sumOfScores / examAssignmentCount;
    var extraCredit = overallTotalScore - overallExamScore;

    return new Dictionary<string, decimal>
    {
        { "Exam Score", overallExamScore },
        { "Overall Score", overallTotalScore },
        { "Extra Credit", extraCredit }
    };
}

internal class Student(string name, decimal score, string grade, decimal examScore, decimal credit)
{
    public string Name { get; } = name;
    public decimal Score { get; } = score;
    public string Grade { get; } = grade;
    public decimal ExamScore { get; } = examScore;
    public decimal Credit { get; } = credit;
}