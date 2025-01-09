using DoctorAvailability.Business.Apis;
using DoctorAvailability.Business.Services;
using DoctorAvailability.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAvailability.Business.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureBusiness(this IServiceCollection services)
    {
        services.AddScoped<SlotsService>();
        services.AddScoped<ISlotsServiceApi, SlotsServiceApi>();
    }
}