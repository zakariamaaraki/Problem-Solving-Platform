namespace RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Problem.Services;
using Problem.Entities;


public class HomePage : PageModel
{
    private readonly IProblemService _problemService;

    public HomePage(IProblemService problemService)
    {
        _problemService = problemService;
    }

    public void OnGet()
    {
        List<ProblemResponseDto> problems = new List<ProblemResponseDto>();
        _problemService.GetAsync().Result.ForEach(problem => problems.Add(new ProblemResponseDto(problem)));
        ViewData["Problems"] = problems;
    }
}