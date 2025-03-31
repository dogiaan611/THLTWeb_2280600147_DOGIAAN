using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using THLTWeb_2280600147_DOGIAAN.Models;
using THLTWeb_2280600147_DOGIAAN.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AnDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<AnDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

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
app.MapRazorPages();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "areas",
//        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
app.Run();
