using AppointmentBooking.Application.Command;
using AppointmentBooking.Application.Query;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Application.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped< AppointmentQueries>();
        services.AddScoped<BookAppointmentCommandHandler>();
    }
}