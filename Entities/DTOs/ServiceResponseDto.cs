namespace Problem.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ServiceResponseDto
{
    public string Message { get; set; }

    public string Status { get; set; }

    public string ProblemReference { get; set; }

    public string ProblemName { get; set; }

    public DateTime DateTime { get; set; }

    public Language Language { get; set; }

    public String SourceCode { get; set; }

    public ServiceResponseDto(ServiceResponse serviceResponse)
    {
        this.Message = serviceResponse.Message;
        this.Status = serviceResponse.Status;
        this.ProblemReference = serviceResponse.ProblemReference;
        this.ProblemName = serviceResponse.ProblemName;
        this.DateTime = serviceResponse.DateTime;
        this.Language = serviceResponse.Language;
        this.SourceCode = serviceResponse.SourceCode;
    }
}