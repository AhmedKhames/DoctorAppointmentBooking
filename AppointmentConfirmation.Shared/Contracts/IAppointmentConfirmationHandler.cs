using AppointmentConfirmation.Shared.Dtos;

namespace AppointmentConfirmation.Shared.Contracts;

public interface IAppointmentConfirmationHandler
{
    Task SendConfirmationAsync(AppointmentsCreatedEvent @event);
}