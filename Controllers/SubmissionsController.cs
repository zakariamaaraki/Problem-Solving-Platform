namespace Problem.Controllers;

using Problem.Entities;
using Problem.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionsController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ServiceResponse>> Get(string id)
    {
        var serviceResponse = await _submissionService.GetAsync(id);

        if (serviceResponse == null)
        {
            return NotFound();
        }

        return serviceResponse;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceResponse>>> Get(int limit)
    {
        var serviceResponse = await _submissionService.GetAsync(limit);

        if (serviceResponse == null)
        {
            return NotFound();
        }

        return serviceResponse;
    }


}