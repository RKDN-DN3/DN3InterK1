using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quiz.Database.Data;
using Quiz.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuizConnect"), b => b.MigrationsAssembly("Quiz.Database"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //SeedData_Exam_History_Detail.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
string startupPath = Environment.CurrentDirectory;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
Path.Combine(startupPath+ "/wwwroot/")),
    RequestPath = "/StaticFiles"
});

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Login}/{controller=Login}/{action=Index}/{id?}");

app.Run();