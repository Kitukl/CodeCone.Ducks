using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodeCone.Ducks.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CodeConeDucksContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodeConeDucksContext") ?? throw new InvalidOperationException("Connection string 'CodeConeDucksContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CodeConeDucksContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CodeConeDucksContext")
    ));

builder.Services.AddCors(options => options.AddPolicy("default", new CorsPolicyBuilder().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().Build()));

var app = builder.Build();

app.UseCors("default");

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
