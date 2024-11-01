using Core.Repository;
using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using SweetDictionary.Service;
using SweetDictionary.Service.Abstracts;
using SweetDictionary.Service.Concretes;
using SweetDictionary.Service.Mapings;
using SweetDictionary.Service.Rules;
using SweetDictionary.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));


builder.Services.AddRepositoryDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
    {
        opt.User.RequireUniqueEmail = true;
        opt.Password.RequireDigit = true;
        opt.Password.RequireLowercase = true;
        opt.Password.RequireUppercase = true;
        opt.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<BaseDbContext>();



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudiences = [tokenOptions.Audience.First()],
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

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => { });
app.MapControllers();

app.Run();
