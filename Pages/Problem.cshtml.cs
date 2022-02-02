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

        List<ProblemResponseDto> problems = new List<ProblemResponseDto>();
        HashSet<string> companies = new HashSet<string>();
        HashSet<string> tags = new HashSet<string>();
        _problemService.GetAsync().Result.ForEach(problem =>
        {
            problems.Add(new ProblemResponseDto(problem));
            problem.Companies.ForEach(company => companies.Add(company));
            problem.Tags.ForEach(tag => tags.Add(tag));
        });
        ViewData["Problems"] = problems;
        ViewData["Companies"] = companies;
        ViewData["Tags"] = tags;
    }
}