var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllSpecificOrigins", builder =>
    {
        builder
        .AllowAnyOrigin()
        .WithOrigins("http://localhost:7126")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("_myAllSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
