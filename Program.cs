using Microsoft.EntityFrameworkCore;
using pra_test;
using pra_test.Data;
using pra_test.Interface;
using pra_test.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContextData>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Pra_test")));
builder.Services.AddAutoMapper(typeof(DataMapping));
builder.Services.AddScoped<IPerson,PersonManagement>();
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
