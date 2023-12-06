using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PunchcodeStudios.Application.Contracts.Email;
using PunchcodeStudios.Application.Contracts.Logging;
using PunchcodeStudios.Application.Models.Email;
using PunchcodeStudios.Infrastructure.EmailService;
using PunchcodeStudios.Infrastructure.Logging;

namespace PunchcodeStudios.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PunchcodeEmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
