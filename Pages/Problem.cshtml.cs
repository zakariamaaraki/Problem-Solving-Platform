namespace RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Problem.Services;
using Problem.Entities;


public class ProblemPage : PageModel
{
    private readonly IProblemService _problemService;

    public ProblemPage(IProblemService problemService)
    {
        _problemService = problemService;
    }

    public void OnGet()
    {
        string problemReference = HttpContext.Request.Query["problemReference"];
        @ViewData["Problem"] = new ProblemResponseDto(_problemService.GetAsync(problemReference).Result);
        @ViewData["ProblemReference"] = problemReference;
    }
}