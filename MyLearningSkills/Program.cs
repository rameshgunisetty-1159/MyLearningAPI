using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using MyLearningSkills.BL;
using MyLearningSkills.BL.Interfaces;
using MyLearningSkills.DL;
using MyLearningSkills.DL.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();

builder.Services.AddTransient<ICoursesBusinessLogic, CoursesBusinessLogic>();

builder.Services.AddTransient<ICoursesRepository, CoursesRepository>();
builder.Services.AddDbContext<MyLearningSkillsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Swagger/OpenAPI

builder.Services.AddCors(o =>
{
    var allowedOrgins = new string[] { "http://localhost:4200" };

    o.AddPolicy("Default", b => b.WithOrigins(allowedOrgins)
    .AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "My Learning API",
        Version = "v1"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Register the Swagger middleware only in Development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Learning API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Ensure CORS is applied before mapping controllers
app.UseCors("Default");

app.MapControllers();

app.Run();
