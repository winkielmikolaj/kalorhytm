using Kalorhytm.Infrastructure.Extensions;
using Kalorhytm.Infrastructure.USDAFood.Extensions;
using Kalorhytm.Logic.Services;
using Kalorhytm.Logic.UseCases;
using Kalorhytm.WebApp.Components;
using Kalorhytm.WebApp.Components.Account;
using Kalorhytm.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Kalorhytm.Logic.Interfaces;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;
using Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases;
using Kalorhytm.Logic.UseCases.BodyMeasurementUseCases;
using Kalorhytm.Logic.UseCases.MyFridgeUseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();
builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();

//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<InMemoryDbContext>(opt => opt.UseInMemoryDatabase("KalorhytmDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => { options.SignIn.RequireConfirmedAccount = true; })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<InMemoryDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// Add HttpClient for USDA API and SpoonacularApi
builder.Services.AddUSDAFood();
builder.Services.AddSpoonacularRecipes();


builder.Services.AddInfrastructure();

// Register USDA Food Service and SpoonacularApi
builder.Services.AddScoped<IUSDAFoodService, USDAFoodService>();
builder.Services.AddScoped<ISpoonacularRecipesService, SpoonacularRecipesService>();

// Register use cases
builder.Services.AddScoped<IGetDailyNutritionUseCase, GetDailyNutritionUseCase>();
builder.Services.AddScoped<ISearchFoodsUseCase, SearchFoodsUseCase>();
builder.Services.AddScoped<IAddMealEntryUseCase, AddMealEntryUseCase>();

// Body Measurement Use Cases
builder.Services.AddScoped<IGetBodyMeasurementUseCase, GetBodyMeasurementUseCase>();
builder.Services.AddScoped<IAddBodyMeasurementUseCase, AddBodyMeasurementUseCase>();
builder.Services.AddScoped<IUpdateBodyMeasurementUseCase, UpdateBodyMeasurementUseCase>();
builder.Services.AddScoped<IDeleteBodyMeasurementUseCase, DeleteBodyMeasurementUseCase>();
// Body Measurement Goal Use Cases
builder.Services.AddScoped<IGetBodyMeasurementGoalUseCase, GetBodyMeasurementGoalUseCase>();
builder.Services.AddScoped<IAddBodyMeasurementGoalUseCase, AddBodyMeasurementGoalUseCase>();
builder.Services.AddScoped<IUpdateBodyMeasurementGoalUseCase, UpdateBodyMeasurementGoalUseCase>();
builder.Services.AddScoped<IDeleteBodyMeasurementGoalUseCase, DeleteBodyMeasurementGoalUseCase>();

//Adding ingredients to my fridge Use Cases
builder.Services.AddScoped<IAddIngredientUseCase, AddIngredientUseCase>();
//todo wyswietlanie z lodowki
builder.Services.AddScoped<IGetIngredientUseCase, GetIngredientUseCase>();
//todo edytowanie nazw lodowki
//todo usuwanie z lodowki

var app = builder.Build();

// Seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<InMemoryDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await AppSeeder.SeedAsync(context, userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
