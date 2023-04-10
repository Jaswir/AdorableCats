using AdorableCats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//MySQL
//builder.Services.AddDbContext<CatDbContext>(options =>
//{
//    var connetionString = builder.Configuration.GetConnectionString("MySQLConnection");
//    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
//});

//SQLite
builder.Services.AddDbContext<CatDbContext>(options =>
{
    //var connetionString = builder.Configuration.GetConnectionString("sqliteConnection");
    options.UseSqlite(@"Data Source=C:\Temp\Cats.db");
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

return; 

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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
