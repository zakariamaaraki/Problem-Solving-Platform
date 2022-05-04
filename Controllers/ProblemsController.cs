namespace Problem.Controllers;

using Problem.Entities;
using Problem.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProblemsController : ControllerBase
{
    private readonly IProblemService _problemService;

    public ProblemsController(IProblemService problemService) =>
        _problemService = problemService;

    [HttpGet]
    public async Task<List<ProblemResponseDto>> Get()
    {
        return await Task.Run(() =>
        {
            List<ProblemResponseDto> problemResponseDtos = new List<ProblemResponseDto>();
            _problemService
                .GetAsync()
                .Result
                .ForEach(problem => problemResponseDtos.Add(new ProblemResponseDto(problem)));
            return problemResponseDtos;
        });
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ProblemResponseDto>> Get(string id)
    {
        var problem = await _problemService.GetAsync(id);

        if (problem is null)
        {
            return NotFound();
        }

        return new ProblemResponseDto(problem);
    }

    [HttpGet("company/{company}")]
    public async Task<List<ProblemResponseDto>> GetByCompanyName(string company)
    {
        return await Task.Run(() =>
        {
            List<ProblemResponseDto> problemResponseDtos = new List<ProblemResponseDto>();
            _problemService
                .GetByCompanyAsync(company)
                .Result
                .ForEach(problem => problemResponseDtos.Add(new ProblemResponseDto(problem)));
            return problemResponseDtos;
        });
    }

    [HttpGet("tag/{tag}")]
    public async Task<List<ProblemResponseDto>> GetByTag(string tag)
    {
        return await Task.Run(() =>
        {
            List<ProblemResponseDto> problemResponseDtos = new List<ProblemResponseDto>();
            _problemService
                .GetByTagAsync(tag)
                .Result
                .ForEach(problem => problemResponseDtos.Add(new ProblemResponseDto(problem)));
            return problemResponseDtos;
        });
    }

    [HttpGet("difficulty/{difficulty}")]
    public async Task<List<ProblemResponseDto>> GetByDifficulty(Difficulty difficulty)
    {
        return await Task.Run(() =>
        {
            List<ProblemResponseDto> problemResponseDtos = new List<ProblemResponseDto>();
            _problemService
                .GetByDifficultyAsync(difficulty)
                .Result
                .ForEach(problem => problemResponseDtos.Add(new ProblemResponseDto(problem)));
            return problemResponseDtos;
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProblemRequestDto newProblem)
    {
        Problem problem = newProblem.toProblem();

        await _problemService.CreateAsync(problem);

        return CreatedAtAction(nameof(Get), new { id = problem.Id }, problem);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ProblemRequestDto updatedProblem)
    {
        var problem = await _problemService.GetAsync(id);

        if (problem is null)
        {
            return NotFound();
        }

        Problem newProblem = updatedProblem.toProblem();
        newProblem.NumberOfSubmissions = problem.NumberOfSubmissions;
        newProblem.NumberOfAcceptedAnswer = problem.NumberOfAcceptedAnswer;
        newProblem.Id = problem.Id;

        await _problemService.UpdateAsync(id, newProblem);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var problem = await _problemService.GetAsync(id);

        if (problem is null)
        {
            return NotFound();
        }

        await _problemService.RemoveAsync(problem.Id);

        return NoContent();
    }
}


