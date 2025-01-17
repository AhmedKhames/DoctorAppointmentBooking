using AppointmentConfirmation.Shared.Contracts;
using AppointmentConfirmation.Shared.Dtos;
using Microsoft.Extensions.Logging;

namespace AppointmentConfirmation.EventHandler.AppointmentConfirmationHandler;

public class AppointmentConfirmationEventHandler(ILogger<AppointmentConfirmationEventHandler> logger)
    : IAppointmentConfirmationHandler
{
    public Task SendConfirmationAsync(AppointmentsCreatedEvent @event)
    {
        const string logSignature = "AppointmentConfirmationEventHandler - SendConfirmationAsync => ";
        logger.LogInformation(
            "{logSignature} Start sending confirmation for appointment {AppointmentId} to {PatientName} and {DoctorName}",
            logSignature, @event.AppointmentId, @event.PatientName, @event.DoctorName);
        return Task.CompletedTask;
    }
}