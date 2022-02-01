namespace Problem.Entities;

public record ProblemResponseDto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string ProblemDescription { get; set; }

    public string InputDescription { get; set; }

    public string OutputDescription { get; set; }

    public List<string> Companies { get; set; }

    public List<string> Tags { get; set; }

    public List<ProblemExample> ProblemExamples { get; set; }

    public int TimeLimit { get; set; }

    public int MemoryLimit { get; set; }

    public Difficulty Difficulty { get; set; }

    public float Acceptance { get; set; }

    public ProblemResponseDto(Problem problem)
    {
        this.Id = problem.Id;
        this.Name = problem.Name;
        this.ProblemDescription = problem.ProblemDescription;
        this.InputDescription = problem.InputDescription;
        this.OutputDescription = problem.OutputDescription;
        this.Companies = problem.Companies;
        this.Tags = problem.Tags;
        this.ProblemExamples = problem.ProblemExamples;
        this.TimeLimit = problem.TimeLimit;
        this.MemoryLimit = problem.MemoryLimit;
        this.Difficulty = problem.Difficulty;
        this.Acceptance = problem.NumberOfSubmissions == 0 ? 0 : (float)problem.NumberOfAcceptedAnswer / problem.NumberOfSubmissions * 100;
    }

}