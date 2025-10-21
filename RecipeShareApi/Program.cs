using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using RecipeShareApi.Data;
using RecipeShareApi.Orchestration.Implementation;
using RecipeShareApi.Orchestration.Interface;
using RecipeShareApi.Services.Implementation;
using RecipeShareApi.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<RecipeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeConn"));
});
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeOrchestration, RecipeOrchestration>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"), spaApp =>
//{
//    spaApp.UseSpa(spa =>
//    {
//        //spa.Options.SourcePath = "ClientApp";
//        spa.UseAngularCliServer(npmScript: "start");

//        if (app.Environment.IsDevelopment())
//        {
//            spa.UseAngularCliServer(npmScript: "start");
//            //spa.UseProxyToSpaDevelopmentServer("https://localhost:7062");
//        }
//    });
//});

app.Run();
