using AppointmentBooking.Application.Apis;
using AppointmentBooking.Application.Command;
using AppointmentBooking.Application.Query;
using AppointmentBooking.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Application.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped< AppointmentQueries>();
        services.AddScoped<BookAppointmentCommandHandler>();
        services.AddScoped<IAppointmentsApi, AppointmentsApi>();
    }
}