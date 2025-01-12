using DoctorAppointmentManagement.Presentation.Adapters.Input;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAppointmentManagement.Presentation.Adapters.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePresentationAdapters(this IServiceCollection services)
    {
        services.AddScoped<DoctorAppointmentsService>();
    }
}