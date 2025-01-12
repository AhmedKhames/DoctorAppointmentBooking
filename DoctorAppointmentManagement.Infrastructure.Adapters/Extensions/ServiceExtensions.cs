using DoctorAppointmentManagement.Core.Ports.Output;
using DoctorAppointmentManagement.Infrastructure.Adapters.ExternalServices;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentManagement.Infrastructure.Adapters.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructureAdapters(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentPort, AppointmentsAdapter>();
    }
}