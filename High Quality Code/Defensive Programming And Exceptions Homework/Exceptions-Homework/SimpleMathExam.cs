using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemSolved = 0;
    private const int MaxProblemSolved = 10;
    private const int BadResultProblemsSolved = 2;
    private const int AverageResulrProblemsSolved = 5;
    private const int ExcellentResultProblemsSolved = 8;
    private const string BadResultProblemsSolvedComment = "Bad result!";
    private const string AverageResulrProblemsSolvedComment = "Average result!";
    private const string ExcellentResultProblemsSolvedComment = "Excellent result!";

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < SimpleMathExam.MinProblemSolved || value > SimpleMathExam.MaxProblemSolved)
            {
                throw new ArgumentOutOfRangeException("Problems solved must be in range " + SimpleMathExam.MinProblemSolved + " and " + SimpleMathExam.MaxProblemSolved);
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        string comment;

        if (this.ProblemsSolved <= SimpleMathExam.BadResultProblemsSolved)
        {
            comment = SimpleMathExam.BadResultProblemsSolvedComment;
        }
        else if (this.ProblemsSolved <= SimpleMathExam.AverageResulrProblemsSolved)
        {
            comment = SimpleMathExam.AverageResulrProblemsSolvedComment;
        }
        else
        {
            comment = SimpleMathExam.ExcellentResultProblemsSolvedComment;
        }

        return new ExamResult(this.ProblemsSolved, SimpleMathExam.MinProblemSolved, SimpleMathExam.MaxProblemSolved, comment);
    }
}