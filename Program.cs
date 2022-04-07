using Microsoft.EntityFrameworkCore;
using FullStackApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy("Allow", policies =>
    policies.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    );
});

builder.Services.AddDbContext<FullStackApiContext>(options => options.UseSqlite("Data Source = FullStackDatabase.db"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("Allow");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DefaultFilesOptions newOptions = new DefaultFilesOptions();
newOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(newOptions);
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
