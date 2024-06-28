var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecksUI(settings =>
{
    settings.AddHealthCheckEndpoint("A.Service", "https://localhost:7106/health");
    settings.AddHealthCheckEndpoint("B.Service", "https://localhost:7005/health");
    settings.SetEvaluationTimeInSeconds(5);
}).AddSqlServerStorage(builder.Configuration.GetConnectionString("sqlserver")!);


var app = builder.Build();

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/health-ui";
});


app.UseHttpsRedirection();



app.Run();

