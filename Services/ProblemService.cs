namespace Problem.Services;

using Problem.Config;
using Problem.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ProblemService : IProblemService
{
    private readonly IMongoCollection<Problem> _problemsCollection;

    public ProblemService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _problemsCollection = mongoDatabase.GetCollection<Problem>(
            databaseSettings.Value.ProblemsCollectionName);
    }

    public async Task<List<Problem>> GetAsync() =>
        await _problemsCollection.Find(_ => true).ToListAsync();

    public async Task<Problem> GetAsync(string id) =>
        await _problemsCollection.Find(problem => problem.Id == id).FirstOrDefaultAsync();

    public async Task<List<Problem>> GetByCompanyAsync(string company) =>
        await _problemsCollection.Find(problem => problem.Companies.Any(problemCompany => problemCompany.Equals(company))).ToListAsync();

    public async Task<List<Problem>> GetByTagAsync(string tag) =>
        await _problemsCollection.Find(problem => problem.Tags.Any(problemTag => problemTag.Equals(tag))).ToListAsync();

    public async Task<List<Problem>> GetByDifficultyAsync(Difficulty difficulty) =>
        await _problemsCollection.Find(problem => problem.Difficulty == difficulty).ToListAsync();

    public async Task CreateAsync(Problem problem) =>
        await _problemsCollection.InsertOneAsync(problem);

    public async Task UpdateAsync(string id, Problem updatedProblem) =>
        await _problemsCollection.ReplaceOneAsync(problem => problem.Id == id, updatedProblem);

    public async Task RemoveAsync(string id) =>
        await _problemsCollection.DeleteOneAsync(problem => problem.Id == id);

}