using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rocky_DataAccess;
using Rocky_DataAccess.Repository;
using Rocky_DataAccess.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromSeconds(10);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<IApplicationUserRepository,ApplicationUserRepository>();
builder.Services.AddScoped<IInquiryHeaderRepository, InquiryHeaderRepository>();
builder.Services.AddScoped<IInquiryDetailRepository, InquiryDetailRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
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
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
