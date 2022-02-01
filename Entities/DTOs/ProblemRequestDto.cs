namespace Problem.Entities;

public record ProblemRequestDto
{

    public string Name { get; set; }

    public string ProblemDescription { get; set; }

    public string InputDescription { get; set; }

    public string OutputDescription { get; set; }

    public List<string> Companies { get; set; }

    public List<string> Tags { get; set; }

    public List<ProblemExample> ProblemExamples { get; set; }

    public List<TestCase> TestCases { get; set; }

    public int TimeLimit { get; set; }

    public int MemoryLimit { get; set; }

    public Difficulty Difficulty { get; set; }

    public Problem toProblem()
    {
        Problem problem = new Problem();
        problem.Name = this.Name;
        problem.ProblemDescription = this.ProblemDescription;
        problem.InputDescription = this.InputDescription;
        problem.OutputDescription = this.OutputDescription;
        problem.Companies = this.Companies;
        problem.Tags = this.Tags;
        problem.ProblemExamples = this.ProblemExamples;
        problem.TestCases = this.TestCases;
        problem.TimeLimit = this.TimeLimit;
        problem.MemoryLimit = this.MemoryLimit;
        problem.Difficulty = this.Difficulty;

        return problem;
    }

}