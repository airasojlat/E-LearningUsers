global using Microsoft.EntityFrameworkCore;
global using superheroapi.Data;
global using superheroapi.Models;
using superheroapi.Services.CoursesServices;
using superheroapi.Services.InstructorsServices;
using superheroapi.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IinstructorService, InstructorService>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddCors(o => o.AddPolicy(name: "DefaulPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200").AllowAnyMethod()
                                            .AllowAnyHeader();
                      }));



var app = builder.Build();
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<DataContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("DefaulPolicy");

app.MapControllers();

app.Run();
