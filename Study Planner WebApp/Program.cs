using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Study_Planner_WebApp.Auth;
using Study_Planner_WebApp.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Study_Planner_WebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Study_Planner_WebAppContext") ?? throw new InvalidOperationException("Connection string 'Study_Planner_WebAppContext' not found.")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<AuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
