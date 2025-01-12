using AppointmentBooking.Application.Extensions;
using AppointmentBooking.Infrastructure.Extensions;
using DoctorAppointmentManagement.Infrastructure.Adapters.Extensions;
using DoctorAppointmentManagement.Presentation.Adapters.Extensions;
using DoctorAvailability.Business.Extensions;
using DoctorAvailability.Data.Extensions;

namespace App.Extensions;

public static class ModulesExtensions
{
    public static void AddDoctorAvailabilityModules(this IServiceCollection services)
    {
        services.ConfigureData();
        services.ConfigureBusiness();
    }
    public static void AddAppointmentsBookingModules(this IServiceCollection services)
    {
        services.ConfigureInfrastructure();
        services.AddApplicationServices();
    } 
    public static void AddAppointmentsManagementModules(this IServiceCollection services)
    {
        services.ConfigureInfrastructureAdapters();
        services.ConfigurePresentationAdapters();
    } 
}