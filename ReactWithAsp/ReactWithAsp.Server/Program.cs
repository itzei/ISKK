using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;
using ReactWithAsp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var mysqlDb = config["MySQL:Db"];
var mysqlUser = config["MySQL:User"];
var mysqlPassword = config["MySQL:Password"];
var mysqlConn = $"server=localhost;port=3306;user={mysqlUser};password={mysqlPassword};database={mysqlDb};CharSet=utf8;TreatTinyAsBoolean = false";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mysqlConn, ServerVersion.AutoDetect(mysqlConn)
    ));
// Add services to the container.

var services = builder.Services;

services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

services.AddAntiforgery(options =>
{
    options.HeaderName = "X-XSRF-TOKEN";
    options.Cookie.Name = "Antiforgery";
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.SuppressXFrameOptionsHeader = false;
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return Task.CompletedTask;
            }
        };
    });

services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
});

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    builder.WithOrigins("https://localhost:5173")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetStudentService, GetStudentService>();
builder.Services.AddScoped<ISaveStudentService, SaveStudentService>();

builder.Services.AddScoped<IGetLecturerService, GetLecturerService>();
builder.Services.AddScoped<ISaveLecturerService, SaveLecturerService>();

builder.Services.AddScoped<IGetProgramService, GetProgramService>();
builder.Services.AddScoped<ISaveProgramService, SaveProgramService>();

builder.Services.AddScoped<IGetGroupService, GetGroupService>();
builder.Services.AddScoped<ISaveGroupService, SaveGroupService>();

builder.Services.AddScoped<IGetSubjectService, GetSubjectService>();
builder.Services.AddScoped<ISaveSubjectService, SaveSubjectService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IGetIdentityUserService, GetIdentityUserService>();

var app = builder.Build();
app.UseCors("AllowAll");
app.UseDefaultFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

var antiforgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use((context, next) =>
{
    if (HttpMethods.IsPost(context.Request.Method) ||
        HttpMethods.IsDelete(context.Request.Method) ||
        HttpMethods.IsPut(context.Request.Method) ||
        HttpMethods.IsPatch(context.Request.Method))
        return next(context);
    var tokens = antiforgery.GetAndStoreTokens(context);

    if (context.Request.Path.Value != null && context.Request.Path.Value.Contains("signin")) return next(context);

    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
        new CookieOptions
        {
            HttpOnly = false,
            Secure = true,
            SameSite = SameSiteMode.Lax
        });
    return next(context);
});


app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
