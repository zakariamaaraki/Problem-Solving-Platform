namespace Problem.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public record Problem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

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

    public long NumberOfSubmissions { get; set; }

    public long NumberOfAcceptedAnswer { get; set; }
}