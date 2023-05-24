using bmerketo.Contexts;
using bmerketo.Factories;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//contexts
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductDatabase")));

// services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>(); 
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AdminService>();

// repositories

builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<ContactFormRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ProductTagRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<UserAddressRepo>();
builder.Services.AddScoped<UserRepo>();


// authentication
builder.Services.AddIdentity<UserEntity, IdentityRole>(x => 
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
  })
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    //x.AccessDeniedPath = "/denied";
});




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
