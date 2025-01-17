using AppointmentConfirmation.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;
using AppointmentConfirmation.EventHandler.AppointmentConfirmationHandler;

namespace AppointmentConfirmation.EventHandler.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureEventHandler(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentConfirmationHandler, AppointmentConfirmationEventHandler>();
    }
}