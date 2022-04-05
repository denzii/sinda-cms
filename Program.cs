
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SindaCMS.Data;

var builder = WebApplication.CreateBuilder(args);

var logger = LoggerFactory.Create(config =>
    {
        config.AddConsole();
        config.AddConfiguration(builder.Configuration.GetSection("Logging"));
    }).CreateLogger("Program");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>((options) => {
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IRepository, Repository>();

if (bool.Parse(builder.Configuration["MigrateDbOnStartup"]))
{
    var dbContext = builder.Services.BuildServiceProvider().GetService<DataContext>();
    dbContext.Database.Migrate();

    // if (!dbContext.Database.GetService<IRelationalDatabaseCreator>().Exists())
    // {
    //     dbContext.Database.Migrate();
    // }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
