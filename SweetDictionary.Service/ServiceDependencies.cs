using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Service.Abstracts;
using SweetDictionary.Service.Concretes;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<PostBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        return services;
    }
}