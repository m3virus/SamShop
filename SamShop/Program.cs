using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.AppServices.AddressAppServices;
using SamShop.Domain.Appservices.BoothAppServices;
using SamShop.Domain.Appservices.SellerAppServices;
using SamShop.Domain.Appservices.UserAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.AddressAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.BoothAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.SellerAppServices;
using SamShop.Domain.Core.Interfaces.AppServices.UserAppServices;
using SamShop.Domain.Core.Interfaces.Repositories;
using SamShop.Domain.Core.Interfaces.Services;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Domain.Service;
using SamShop.Infrastructure.DataAccess.Repositories;
using SamShop.Infrastructure.EntityFramework.DBContext;

var builder = WebApplication.CreateBuilder(args);



#region Identity settings

var connectionString = builder.Configuration.GetConnectionString("SamShopConnection") ?? throw new InvalidOperationException("Connection string 'SamShopConnection' not found.");
builder.Services.AddDbContext<SamShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<SamShopDbContext>()
    .AddDefaultTokenProviders().AddRoles<AppRole>();

#endregion


#region Repository DI

builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<IAddressAppService, AddressAppService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminServices, AdminServices>();

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IAuctionServices, AuctionServices>();

builder.Services.AddScoped<IAuctionOfferRepository, AuctionOfferRepository>();
builder.Services.AddScoped<IAuctionOfferServices, AuctionOfferServices>();

builder.Services.AddScoped<IBoothRepository, BoothRepository>();
builder.Services.AddScoped<IBoothServices, BoothServices>();
builder.Services.AddScoped<IBoothAppServices, BoothAppService>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartServices, CartServices>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentServices, CommentServices>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();

builder.Services.AddScoped<IMedalRepository, MedalRepository>();
builder.Services.AddScoped<IMedalServices, MedalServices>();

builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IPictureServices, PictureServices>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerServices, SellerServices>();
builder.Services.AddScoped<ISellerAppServices, SellerAppService>();

builder.Services.AddScoped<IWageRepository, WageRepository>();
builder.Services.AddScoped<IWageServices, WageServices>();


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

app.Run();
