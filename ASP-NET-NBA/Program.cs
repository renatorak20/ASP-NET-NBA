using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using NBA.DAL;
using NBA.Model;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NBAManagerDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("NBAManagerDbContext"),
			options => options.EnableRetryOnFailure(
					maxRetryCount: 5,
					maxRetryDelay: System.TimeSpan.FromSeconds(30),
					errorNumbersToAdd: null).MigrationsAssembly("NBA.DAL")

                )
	);

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<NBAManagerDbContext>();

services.AddAuthentication().AddGoogle(googleOptions =>
{
	googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
	googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});
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
app.UseStatusCodePages();

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

app.Use(async (context, next) => {
	await next();
	if (context.Response.StatusCode == 404)
	{
		context.Request.Path = "/404";
		await next();
	}
});

//app.UseMvcWithDefaultRoute();

app.MapRazorPages();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "nba-teams",
    pattern: "nba-teams",
    defaults: new { controller = "Team", action = "Index" });

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Manager" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    var emails = new[] { "admin@admin.com", "manager@manager.com" };
    var passwords = new[] { "Mojalozinka123!", "Tvojalozinka123!" };
    var roles = new[] { "Admin", "Manager" };

    for (int i = 0; i < 2; i++)
    {
        if (await userManager.FindByEmailAsync(emails[i]) == null)
        {
            var user = new AppUser();
            user.UserName = emails[i];
            user.Email = emails[i];

            await userManager.CreateAsync(user, passwords[i]);
            await userManager.AddToRoleAsync(user, roles[i]);
        }
    }
}

app.Run();
