namespace Problem.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ServiceResponse
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Message { get; set; }

    public string Status { get; set; }

    public string ProblemReference { get; set; }

    public string ProblemName { get; set; }

    public DateTime DateTime { get; set; }

    public Language Language { get; set; }

    public String SourceCode { get; set; }

    public ServiceResponse() { }

    public ServiceResponse(string message, string status, string problemReference, string problemName, DateTime dateTime, Language language, string sourceCode)
    {
        Message = message;
        Status = status;
        ProblemReference = problemReference;
        ProblemName = problemName;
        DateTime = dateTime;
        SourceCode = sourceCode;
        Language = language;
    }

}