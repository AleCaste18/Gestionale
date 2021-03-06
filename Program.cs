using Gestionale.Authorization;
using Gestionale.Authorization.Handler;
using Gestionale.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<IdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = true) 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditRolePolicyHasClaim", 
                       policy => policy.RequireClaim("Edit Role", "true", "yes", "test")); //policy basata sugli allowedValues della claimType

    options.AddPolicy("EditRolePolicyHasClaimNoValue",
                       policy => policy.RequireClaim("Edit Role")); //policy basata sulla presenza della claimType

    options.AddPolicy("AdminOrManager",
                       policy => policy.RequireRole("Admin", "Manager")); //policy basata sui ruoli

    options.AddPolicy("EditRolePolicyCustom", //policy personalizzata
        policy => policy.RequireAssertion(context => 
                                          context.User.IsInRole("Manager") && 
                                          context.User.HasClaim(claim =>
                                                                claim.Type == "Edit Role" && claim.Value == "true") || //Approccio OR, per approccio AND usare policy.RequireClaim() + policy.RequireRole()
                                          context.User.IsInRole("Administrator")));

    options.AddPolicy("EditRolePolicyWithHandler",  //policy basata su un requirement basato su handler esplicito 
        policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

    options.FallbackPolicy = new AuthorizationPolicyBuilder() //Policy globale -> 
        .RequireAuthenticatedUser() //tutto richiede un'autenticazione (eccetto [allowed])
        .Build();
});

// Authorization handlers.
builder.Services.AddScoped<IAuthorizationHandler, EmployeeIsOwnerAuthorizationHandler>();

builder.Services.AddSingleton<IAuthorizationHandler, EmployeeAdministratorsAuthorizationHandler>();

builder.Services.AddSingleton<IAuthorizationHandler, EmployeeManagerAuthorizationHandler>();

builder.Services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, AdminHandler>();

var app = builder.Build();


using (var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

    await SeedData.Initialize(services, testUserPw);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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


