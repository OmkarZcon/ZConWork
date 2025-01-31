using Microsoft.AspNetCore.Diagnostics;
using RealEstate.Api;
using RealEstate.Api.Services;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IExceptionHandler, AppExceptionHandler>(); // Register custom exception handler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SieveProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add global exception handling
app.Use(async (context, next) =>
{
    var exceptionHandler = context.RequestServices.GetRequiredService<IExceptionHandler>();
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        var handled = await exceptionHandler.TryHandleAsync(context, ex, CancellationToken.None);
        if (!handled)
        {
            throw; 
        }
    }
});



// This line maps all controllers to their respective routes.
app.MapControllers();



app.Run();
