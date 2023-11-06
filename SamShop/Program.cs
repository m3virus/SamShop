using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Infrastructure.DataAccess.Repositories;
using SamShop.Infrastructure.EntityFramework.DBContext;

var builder = WebApplication.CreateBuilder(args);



#region Identity settings

var connectionString = builder.Configuration.GetConnectionString("SamShopConnection") ?? throw new InvalidOperationException("Connection string 'SamShopConnection' not found.");
builder.Services.AddDbContext<SamShopDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SamShopDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
    .AddEntityFrameworkStores<SamShopDbContext>();

#endregion


#region Repository DI

builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IAdminReository, AdminRepository>();

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddScoped<IAuctionOfferRepository, AuctionOfferRepository>();

builder.Services.AddScoped<IBoothRepository, BoothRepository>();

builder.Services.AddScoped<ICartRepository, CartRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IMedalRepository, MedalRepository>();

builder.Services.AddScoped<IPictureRepository, PictureRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ISellerRepository, SellerRepository>();


#endregion




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
