using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;

namespace SweetDictionary.Repository;

public static class RepositoryDependencies
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPostRepository, EfPostRepository>();
        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}