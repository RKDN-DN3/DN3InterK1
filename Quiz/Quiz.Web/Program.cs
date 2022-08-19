using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quiz.Database.Data;
using Quiz.Database.Migrations;
using Quiz.Database.Repositories;
using Quiz.Web.Models;

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

    SeedData_Examination.Initialize(services);
    SeedData_Examination_Detail.Initialize(services);

    SeedData_Question_Bank.Initialize(services);
    SeedData_Question.Initialize(services);
    SeedData__Account.Initialize(services);
    SeedData_Answer.Initialize(services);
    SeedData_List_Question_In_Exam.Initialize(services);
    SeedData_Exam_History.Initialize(services);
    SeedData_Exam_History_Detail.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
Path.Combine("D:/Git/DN3InterK1/Quiz/Quiz.Web/wwwroot/")),
    RequestPath = "/StaticFiles"
});

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();