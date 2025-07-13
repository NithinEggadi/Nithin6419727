using Microsoft.OpenApi.Models;
using WebApi_3.Filters; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CustomAuthorizationFilter>(); 
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>(); 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebApi_3",
        Version = "v1",
        Description = "Demo API with Custom Filters",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "you@example.com"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();

app.Run();