using Core.Repository;
using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Service;
using SweetDictionary.Service.Mapings;
using SweetDictionary.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));


builder.Services.AddRepositoryDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();
builder.Services.AddAutoMapper(typeof(PostProfiles));
builder.Services.AddAutoMapper(typeof(CategoryProfiles));
builder.Services.AddAutoMapper(typeof(CommentProfiles));


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
    {
        opt.User.RequireUniqueEmail = true;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 6; // Example, adjust as needed
        opt.Password.RequireDigit = false; // Example
        opt.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<BaseDbContext>();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOptions.SecurityKey),
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
