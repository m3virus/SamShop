using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamShop.Infrastructure.EntityFramework.DBContext;

var builder = WebApplication.CreateBuilder(args);




var connectionString = builder.Configuration.GetConnectionString("SamShopConnection") ?? throw new InvalidOperationException("Connection string 'SamShopConnection' not found.");
builder.Services.AddDbContext<SamShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SamShopDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
.AddEntityFrameworkStores<SamShopDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();



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
