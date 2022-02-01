namespace Problem.Services;

using Problem.Entities;
using Microsoft.AspNetCore.Mvc;

public interface IExecutionService
{

    ServiceResponse Execute(Submission submission);

}