namespace Problem.Entities;

public record CompilerResponse
{
    public string Output { get; set; }

    public string ExpectedOutput { get; set; }

    public string Status { get; set; }

    public DateTime DateTime { get; set; }
}