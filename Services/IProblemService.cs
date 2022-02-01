namespace Problem.Services;

using Problem.Entities;
using Microsoft.Extensions.Options;

public interface IProblemService
{

    Task<List<Problem>> GetAsync();

    Task<Problem> GetAsync(string id);

    Task<List<Problem>> GetByCompanyAsync(string company);

    Task<List<Problem>> GetByTagAsync(string tag);

    Task<List<Problem>> GetByDifficultyAsync(Difficulty difficulty);

    Task CreateAsync(Problem problem);

    Task UpdateAsync(string id, Problem updatedProblem);

    Task RemoveAsync(string id);

}