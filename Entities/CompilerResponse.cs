namespace Problem.Entities;

public record CompilerResponse
{

    public string output { get; set; }

    public string expectedOutput { get; set; }

    public string status { get; set; }

    public DateTime dateTime { get; set; }

}