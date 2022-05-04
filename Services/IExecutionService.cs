namespace Problem.Services;

using Problem.Entities;

public interface IExecutionService
{
    ServiceResponse Execute(Submission submission);

}