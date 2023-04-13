using AdorableCats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//SQLite
builder.Services.AddDbContext<CatDbContext>(options =>
{
    //todo path to in project file
    var path = Path.Combine(Environment.CurrentDirectory, "Data", "Cats.db");
    var connectionString = @"Data Source=" + path;
    options.UseSqlite(connectionString);
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Apply migration at runtime
//Applies initial Seeding if not already done
IApplicationBuilder applicationBuilder = app;
using (IServiceScope scope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var catDbContext = scope.ServiceProvider.GetService<CatDbContext>();
    catDbContext.Database.EnsureCreated();
    Seeder seeder = new Seeder();
    seeder.Seed(catDbContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();

app.Run();
