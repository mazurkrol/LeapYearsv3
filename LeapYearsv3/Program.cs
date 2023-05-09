using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeapYearsv3.Data;
using LeapYearsv3.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LeapYearsv3ContextConnection") ?? throw new InvalidOperationException("Connection string 'LeapYearsv3ContextConnection' not found.");
builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddDbContext<LeapYearsDbContext>(options =>
	options.UseSqlServer(builder.Configuration["ConnectionStrings:LeapYearsDBContextConnection"]));
builder.Services.AddDbContext<LeapYearsv3Context>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:LeapYearsv3ContextConnection"]));
builder.Services.AddSession(options =>
{
	// Set session expiration timeout (default is 20 minutes)
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LeapYearsv3Context>();

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
app.UseSession();
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
	endpoints.MapRazorPages();
});
app.Run();
