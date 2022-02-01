namespace Problem.Entities;

public record Request
{

    public string Input { get; set; }

    public string ExpectedOutput { get; set; }

    public string SourceCode { get; set; }

    public Language Language { get; set; }

    public int TimeLimit { get; set; }

    public int MemoryLimit { get; set; }

    public Request(string input, string expectedOutput, string sourceCode, Language language, int timeLimit, int memoryLimit)
    {
        Input = input;
        ExpectedOutput = expectedOutput;
        SourceCode = sourceCode;
        Language = language;
        TimeLimit = timeLimit;
        MemoryLimit = memoryLimit;
    }

}