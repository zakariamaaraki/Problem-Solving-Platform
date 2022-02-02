namespace Problem.Entities;

using System.ComponentModel.DataAnnotations;

public record ProblemRequestDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public string ProblemDescription { get; set; }

    [Required]
    public string InputDescription { get; set; }

    [Required]
    public string OutputDescription { get; set; }

    [Required]
    public List<string> Companies { get; set; }

    [Required]
    public List<string> Tags { get; set; }

    [Required]
    public List<ProblemExample> ProblemExamples { get; set; }

    [Required]
    public List<TestCase> TestCases { get; set; }

    [Required]
    public int TimeLimit { get; set; }

    [Required]
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