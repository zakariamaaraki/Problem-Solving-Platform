namespace Problem.Entities;

public record Request
{
    public string Input { get; }

    public string ExpectedOutput { get; }

    public string SourceCode { get; }

    public Language Language { get; }

    public int TimeLimit { get; }

    public int MemoryLimit { get; }

    public Request(
        string input, 
        string expectedOutput, 
        string sourceCode, 
        Language language, 
        int timeLimit, 
        int memoryLimit)
    {
        Input = input;
        ExpectedOutput = expectedOutput;
        SourceCode = sourceCode;
        Language = language;
        TimeLimit = timeLimit;
        MemoryLimit = memoryLimit;
    }
}