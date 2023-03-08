using Library.Application.Interfaces;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Library.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IPasswordEncryption, PasswordEncryptionService>();
        services.AddTransient<IUserRepository, UserRepositoryService>();
        services.AddTransient<IBookRepository, BookRepositoryService>();
        services.AddDbContext<ApplicationDbContext>();

        return services;
    }
}
