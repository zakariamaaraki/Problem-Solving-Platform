using Problem.Config;
using Problem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));

builder.Services.Configure<RemoteCompilerSettings>(
    builder.Configuration.GetSection("RemoteCompiler"));

builder.Services.AddScoped<IProblemService, ProblemService>();

builder.Services.AddScoped<ISubmissionService, SubmissionService>();

builder.Services.AddScoped<IExecutionService, ExecutionService>();

builder.Services.AddHttpClient();

builder.Services.AddRazorPages();

var app = builder.Build();

IWebHostEnvironment env = builder.Environment;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
