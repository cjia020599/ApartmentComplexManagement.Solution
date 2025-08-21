using Microsoft.Extensions.DependencyInjection;
using Property.Application.CommandHandler;
using Property.Application.Commands;

namespace Property.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyApplication(this IServiceCollection services)
        {
            services.AddScoped<IPropertyCommands, PropertyCommands>();
            return services;
        }
    }
}
