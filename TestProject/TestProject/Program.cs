using Microsoft.AspNetCore.Builder;
using TestProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("Use Middleware Incoming Request \n");
        await next();
        await context.Response.WriteAsync("Use Middleware Outgoing Response \n");
    });

    app.UseMiddleware<MyCustomMiddleware>();
    app.Run(async context => {
        await context.Response.WriteAsync("Run Middleware Component\n");
    });

}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();






