using BlogPlatform.Application.Interfaces;
using BlogPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

}