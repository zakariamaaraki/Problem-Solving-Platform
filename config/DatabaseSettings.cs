namespace Problem.Config;

public class DatabaseSettings
{

    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProblemsCollectionName { get; set; } = null!;

    public string SubmissionsCollectionName { get; set; } = null!;

}