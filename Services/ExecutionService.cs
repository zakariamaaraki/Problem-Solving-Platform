namespace Problem.Services;

using Problem.Entities;
using System.Text.Json;
using Problem.Config;
using Microsoft.Extensions.Options;

public class ExecutionService : IExecutionService
{
    private readonly IProblemService _problemService;

    private readonly ISubmissionService _submissionService;

    private readonly IHttpClientFactory _httpClientFactory;

    private readonly ILogger<ExecutionService> _logger;

    private readonly string _remoteCompilerUrl;

    private readonly string _ACCEPTED_STATUS = "Accepted";

    public ExecutionService(
        IOptions<RemoteCompilerSettings> remoteCompilerSettings, 
        IProblemService problemService,
        IHttpClientFactory httpClientFactory, 
        ILogger<ExecutionService> logger,
        ISubmissionService submissionService)
    {
        _problemService = problemService;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _submissionService = submissionService;
        _remoteCompilerUrl = remoteCompilerSettings.Value.Url;
    }

    public ServiceResponse Execute(Submission submission)
    {
        _logger.LogInformation("New execution request for problem id = ", submission.ProblemId);

        Problem problem = _problemService.GetAsync(submission.ProblemId).Result;

        ServiceResponse serviceResponse;

        if (problem == null || problem.TestCases.Count == 0)
        {
            return null;
        }

        int testCaseIndex = 0;

        var httpClient = _httpClientFactory.CreateClient();

        foreach (var testCase in problem.TestCases)
        {
            testCaseIndex++;

            Request request = new Request(
                testCase.Input, testCase.ExpectedOutput, submission.SourceCode,
                submission.Language, problem.TimeLimit, problem.MemoryLimit
            );

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                _remoteCompilerUrl
            );

            httpRequestMessage.Content = JsonContent.Create(request);

            _logger.LogInformation("Sending request to the compiler");

            var httpResponseMessage = httpClient.Send(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var contentStream = httpResponseMessage.Content.ReadAsStream();

                CompilerResponse compilerResponse = JsonSerializer.DeserializeAsync<CompilerResponse>(contentStream).Result;

                _logger.LogInformation("Response : ", compilerResponse);

                if (compilerResponse != null && !compilerResponse.Status.Equals(_ACCEPTED_STATUS))
                {

                    serviceResponse = new ServiceResponse(
                        compilerResponse.Status + " in test case " + testCaseIndex + ", expected output : " 
                        + compilerResponse.ExpectedOutput + ", actual output : " 
                        + compilerResponse.Output, compilerResponse.Status,
                     problem.Id, problem.Name, DateTime.Now, submission.Language, submission.SourceCode);

                    _submissionService.CreateAsync(serviceResponse);

                    // Increment Problem Acceptance
                    problem.NumberOfSubmissions++;
                    _problemService.UpdateAsync(problem.Id, problem);

                    return serviceResponse;
                }

                _logger.LogInformation("Test case {} passed", testCaseIndex);
            }
            else
            {
                throw new Exception("Error occured during execution, while running test case number " + testCaseIndex);
            }
        }

        serviceResponse = new ServiceResponse(_ACCEPTED_STATUS + ", all test cases passed", _ACCEPTED_STATUS,
        problem.Id, problem.Name, DateTime.Now, submission.Language, submission.SourceCode);

        _submissionService.CreateAsync(serviceResponse);

        // Increment Problem Acceptance
        problem.NumberOfSubmissions++;
        problem.NumberOfAcceptedAnswer++;
        _problemService.UpdateAsync(problem.Id, problem);

        return serviceResponse;
    }
}