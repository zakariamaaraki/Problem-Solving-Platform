namespace Problem.Entities;

public record Submission
{
    public string ProblemId { set; get; }

    public Language Language { set; get; }

    public string SourceCode { set; get; }
}