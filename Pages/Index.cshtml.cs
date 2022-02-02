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
        string topic = HttpContext.Request.Query["topic"];
        string company = HttpContext.Request.Query["company"];

        List<ProblemResponseDto> problems = new List<ProblemResponseDto>();
        HashSet<string> companies = new HashSet<string>();
        HashSet<string> tags = new HashSet<string>();
        _problemService.GetAsync().Result.ForEach(problem =>
        {
            problem.Companies.ForEach(company => companies.Add(company));
            problem.Tags.ForEach(tag => tags.Add(tag));
        });

        if ((topic is not null) && topic != "")
        {
            _problemService.GetByTagAsync(topic).Result.ForEach(problem => problems.Add(new ProblemResponseDto(problem)));
        }
        else if ((company is not null) && company != "")
        {
            _problemService.GetByCompanyAsync(company).Result.ForEach(problem => problems.Add(new ProblemResponseDto(problem)));
        }
        else
        {
            _problemService.GetAsync().Result.ForEach(problem => problems.Add(new ProblemResponseDto(problem)));
        }

        ViewData["Problems"] = problems;
        ViewData["Companies"] = companies;
        ViewData["Tags"] = tags;
    }
}