using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using NBA.DAL;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NBAManagerDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("NBAManagerDbContext"),
			options => options.EnableRetryOnFailure(
					maxRetryCount: 5,
					maxRetryDelay: System.TimeSpan.FromSeconds(30),
					errorNumbersToAdd: null)
				)
	);
services.AddMvc();
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

var supportedCultures = new[]
{
	new CultureInfo("hr"), new CultureInfo("en-US")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("hr"),
	SupportedCultures = supportedCultures,
	SupportedUICultures = supportedCultures
});
app.UseEndpoints(endpoints =>
{
	endpoints.MapDefaultControllerRoute();
	endpoints.MapRazorPages();
});
app.MapRazorPages();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
