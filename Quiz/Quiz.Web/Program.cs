using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Quiz.Database.Data;
using Quiz.Database.Migrations;
using Quiz.Database.Models;
using Quiz.Database.Repositories;
using Quiz.Web.Models;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

//Authorization settings.  
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Login/Login/index");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});
//Authorization settings.  
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Login");
    options.Conventions.AllowAnonymousToPage("/Login/Login/index");
});


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

    //auto migration
    //var context = services.GetService<ApplicationDBContext>();
    //context.Database.Migrate();

    SeedData_Examination.Initialize(services);
    SeedData_Examination_Detail.Initialize(services);

    SeedData_Question_Bank.Initialize(services);
    SeedData_Question.Initialize(services);
    SeedData__Account.Initialize(services);
    SeedData_Answer.Initialize(services);
    SeedData_List_Question_In_Exam.Initialize(services);
    SeedData_Exam_History.Initialize(services);
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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
Path.Combine("D:/RK/DN3GIT/DN3InterK1/Quiz/Quiz.Web/wwwroot/")),
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