using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private const int MinNamesLength = 2;
    private const int MaxNamesLenth = 15;
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            this.ValidateStudentNames(value, "Student firstName");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            this.ValidateStudentNames(value, "Student lastName");
            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return new List<Exam>(this.exams);
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("Student exams cannot be null!");
            }
            else if (value.Count == 0)
            {
                throw new ArgumentException("Student exams cannot be empty!");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }

    private void ValidateStudentNames(string value, string name)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(name + " cannot be null or empty!");
        }
        else if (value.Length < Student.MinNamesLength || value.Length > Student.MaxNamesLenth)
        {
            throw new ArgumentException(name + " length must be between " + Student.MinNamesLength + " and " + Student.MaxNamesLenth + " symbols!");
        }
    }
}
