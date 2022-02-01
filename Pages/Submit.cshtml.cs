namespace RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Problem.Entities;
using Problem.Services;
using Microsoft.AspNetCore.Mvc;

[IgnoreAntiforgeryToken]
public class SubmitPage : PageModel
{
    private readonly IExecutionService _executionService;

    private readonly IProblemService _problemService;

    [BindProperty]
    public Language language { get; set; }

    [BindProperty]
    public string sourceCode { get; set; }

    [BindProperty]
    public string problemId { get; set; }

    public SubmitPage(IExecutionService executionService, IProblemService problemService)
    {
        _executionService = executionService;
        _problemService = problemService;
    }

    public void OnGet()
    {
        var problemReference = HttpContext.Request.Query["problemReference"];
        ViewData["ProblemReference"] = problemReference;
        ViewData["ProblemName"] = _problemService.GetAsync(problemReference).Result.Name;
    }

    public void OnPostAsync()
    {
        Task.Run(() =>
        {
            Submission submission = new Submission();
            Console.Write(language);
            submission.Language = language;
            submission.SourceCode = sourceCode;
            submission.ProblemId = problemId;
            _executionService.Execute(submission);
        });

        Response.Redirect("/Submissions");
    }
}