var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddSingleton<ProblemDetailsFactory, AmsProblemDetailsFactory>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.Map("/error", (HttpContext httpContext) =>
{
    var exception= httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
