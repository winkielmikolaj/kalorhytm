using FluentValidation;
using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Infrastructure.Extensions;
using Kalorhytm.Infrastructure.External.Extensions;
using Kalorhytm.Logic.Services;
using Kalorhytm.Logic.UseCases;
using Kalorhytm.WebApp.Components;
using Kalorhytm.WebApp.Components.Account;
using Kalorhytm.Infrastructure;
using Kalorhytm.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Kalorhytm.Logic.Interfaces;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;
using Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;
using Kalorhytm.Logic.Interfaces.IRecipeLikes;
using Kalorhytm.Logic.StateContainer;
using Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases;
using Kalorhytm.Logic.UseCases.BodyMeasurementUseCases;
using Kalorhytm.Logic.UseCases.FavouriteRecipesUseCase;
using Kalorhytm.Logic.UseCases.MyFridgeUseCases;
using Kalorhytm.Logic.UseCases.RecipeLikes;
using Kalorhytm.Logic.UseCases.WaterIntakeUseCases;
using Kalorhytm.Logic.Validation;
using MudBlazor.Services;

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


// Register MudBlazor
builder.Services.AddMudServices();

// Add HttpClient for Spoonacular API
builder.Services.AddSpoonacular();


builder.Services.AddInfrastructure();

// Register Spoonacular Food Service and Recipes Service
builder.Services.AddScoped<ISpoonacularFoodService, SpoonacularFoodService>();
builder.Services.AddScoped<ISpoonacularRecipesService, SpoonacularRecipesService>();

// Register use cases
builder.Services.AddScoped<IGetDailyNutritionUseCase, GetDailyNutritionUseCase>();
builder.Services.AddScoped<ISearchFoodsUseCase, SearchFoodsUseCase>();
builder.Services.AddScoped<IAddMealEntryUseCase, AddMealEntryUseCase>();
builder.Services.AddScoped<IAddRecipeToMealUseCase, AddRecipeToMealUseCase>();

// Water Intake Use Cases
builder.Services.AddScoped<IGetDailyWaterIntakeUseCase, GetDailyWaterIntakeUseCase>();
builder.Services.AddScoped<IAddWaterGlassUseCase, AddWaterGlassUseCase>();
builder.Services.AddScoped<IRemoveWaterGlassUseCase, RemoveWaterGlassUseCase>();

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
//displaying fridge use case
builder.Services.AddScoped<IGetIngredientUseCase, GetIngredientUseCase>();
//deleting products from fridge use case
builder.Services.AddScoped<IDeleteIngredientUseCase, DeleteIngredientUseCase>();

//favourite recipe
builder.Services.AddScoped<IFavouriteRecipesRepository, FavouriteRecipesRepository>();
builder.Services.AddScoped<IAddFavouriteRecipeUseCase, AddFavouriteRecipeUseCase>();
builder.Services.AddScoped<IGetFavouriteRecipeUseCase, GetFavouriteRecipeUseCase>();
builder.Services.AddScoped<IDeleteFavouriteRecipeUseCase, DeleteFavouriteRecipeUseCase>();

//validator
builder.Services.AddScoped<IValidator<MyFridgeModel>, MyFridgeModelValidator>();

//stateContainer
builder.Services.AddScoped<FridgeStateContainer>();

//RecipeLikes
builder.Services.AddScoped<IGetRecipeLikesUseCase, GetRecipeLikesUseCase>();

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
