namespace RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Problem.Services;
using Problem.Entities;


public class SubmissionPage : PageModel
{
    private readonly ISubmissionService _submissionService;

    private readonly IProblemService _problemService;

    private readonly int LIMIT = 10;

    public SubmissionPage(ISubmissionService submissionService, IProblemService problemService)
    {
        _submissionService = submissionService;
        _problemService = problemService;
    }

    public void OnGet()
    {
        List<ServiceResponseDto> submissions = new List<ServiceResponseDto>();
        _submissionService.GetAsync(LIMIT).Result.ForEach(submission => submissions.Add(new ServiceResponseDto(submission)));
        ViewData["Submissions"] = submissions;

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