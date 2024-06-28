using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHealthChecks()
    .AddMongoDb(builder.Configuration.GetConnectionString("mongodb")!);
    


var app = builder.Build();



app.UseHttpsRedirection();

app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


app.Run();

