namespace Problem.Services;

using Problem.Config;
using Problem.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class SubmissionService : ISubmissionService
{

    private readonly IMongoCollection<ServiceResponse> _submissionsCollection;

    public SubmissionService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _submissionsCollection = mongoDatabase.GetCollection<ServiceResponse>(
            databaseSettings.Value.SubmissionsCollectionName);
    }

    public async Task<List<ServiceResponse>> GetAsync(int limit) =>
        await _submissionsCollection
            .Find(_ => true)
            .SortByDescending((submission) => submission.DateTime)
            .Limit(limit)
            .ToListAsync();

    public async Task<ServiceResponse> GetAsync(string id) =>
        await _submissionsCollection
            .Find(submission => submission.Id == id)
            .FirstOrDefaultAsync();

    public async Task CreateAsync(ServiceResponse serviceResponse) =>
        await _submissionsCollection.InsertOneAsync(serviceResponse);

    public async Task RemoveAsync(string id) =>
        await _submissionsCollection.DeleteOneAsync(submission => submission.Id == id);

}