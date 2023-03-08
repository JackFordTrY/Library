using Library.WebUI.Mapping;

namespace Library.WebUI;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services) 
    {
        services.AddControllersWithViews();
        services.AddMapping();

        services.AddAuthentication("Cookie")
            .AddCookie("Cookie", options =>
            {
                options.LoginPath = "/User/Login";
                options.Cookie.Name = "library-session";
            });

        services.AddAuthorization();

        return services;
    }
}
