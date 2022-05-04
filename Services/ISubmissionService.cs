namespace Problem.Services;

using Problem.Entities;

public interface ISubmissionService
{
    Task<List<ServiceResponse>> GetAsync(int limit);

    Task<ServiceResponse> GetAsync(string id);

    Task CreateAsync(ServiceResponse serviceResponse);

    Task RemoveAsync(string id);
}