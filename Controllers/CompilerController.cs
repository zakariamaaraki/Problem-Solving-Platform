namespace Problem.Controllers;

using Problem.Entities;
using Problem.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CompilerController : ControllerBase
{
    private readonly IExecutionService _executionService;

    public CompilerController(IExecutionService executionService)
    {
        _executionService = executionService;
    }

    [HttpPost]
    public ActionResult<ServiceResponseDto> Post(Submission submission)
    {

        var response = _executionService.Execute(submission);

        if (response == null)
        {
            return BadRequest();
        }

        return new ServiceResponseDto(response);
    }
}