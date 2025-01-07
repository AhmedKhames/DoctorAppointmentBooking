using DoctorAvailability.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAvailability.Business.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureBusiness(this IServiceCollection services)
    {
        services.AddScoped<SlotsService>();
    }
}