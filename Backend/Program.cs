using Backend.Data;
using Backend.I18n.Middlewares;
using Backend.I18n.Models;
using Backend.I18n.Services;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

I18nConfigurationModel I18nSettings = await new I18nSettingsController().Load();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<UserModel>(options =>
{
  options.Lockout.AllowedForNewUsers = true;
  options.Lockout.MaxFailedAccessAttempts = 5;
  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

  options.Password.RequireDigit = true;
  options.Password.RequireNonAlphanumeric = false;
  options.Password.RequireLowercase = true;
  options.Password.RequireUppercase = true;
  options.Password.RequiredLength = 6;
  options.Password.RequiredUniqueChars = 1;

  options.SignIn.RequireConfirmedAccount = true;
  options.SignIn.RequireConfirmedEmail = true;

  options.User.RequireUniqueEmail = true;
})
  .AddRoles<IdentityRole>()
  .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();
builder.Services.AddLocalization();
builder.Services.AddSingleton(I18nSettings);
builder.Services.AddTransient<I18nMiddleware>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddTransient<IStringLocalizerFactory, JsonStringLocalizerFactory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<I18nMiddleware>();
app.UseRequestLocalization();
app.UseRouting();
app.MapIdentityApi<UserModel>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();