using System;

public class CSharpExam : Exam
{
    private const int MinScoreValue = 0;
    private const int MaxScoreValue = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < CSharpExam.MinScoreValue || value > CSharpExam.MaxScoreValue)
            {
                throw new ArgumentOutOfRangeException("Exam score must be between " + CSharpExam.MinScoreValue + " and " + CSharpExam.MaxScoreValue);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, CSharpExam.MinScoreValue, CSharpExam.MaxScoreValue, "Exam results calculated by score.");
    }
}
