namespace RazorPages.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Problem.Services;
using Problem.Entities;


public class SubmissionPage : PageModel
{
    private readonly ISubmissionService _submissionService;

    private readonly int LIMIT = 10;

    public SubmissionPage(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    public void OnGet()
    {
        List<ServiceResponseDto> submissions = new List<ServiceResponseDto>();
        _submissionService.GetAsync(LIMIT).Result.ForEach(submission => submissions.Add(new ServiceResponseDto(submission)));
        ViewData["Submissions"] = submissions;
    }
}