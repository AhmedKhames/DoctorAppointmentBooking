using AppointmentBooking.Domain.Entities;
using AppointmentBooking.Domain.Repositories;
using AppointmentConfirmation.Shared.Contracts;
using AppointmentConfirmation.Shared.Dtos;
using DoctorAvailability.Shared.Contracts;

namespace AppointmentBooking.Application.Command;

public class BookAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IAppointmentConfirmationHandler appointmentConfirmationHandler,
    ISlotsServiceApi slotsServiceApi)
{
    public async Task<bool> Handle(BookAppointmentCommand command)
    {
        try
        {
            var appointment = new Appointment
            {
                PatientId = command.PatientId,
                SlotId = command.SlotId,
                PatientName = command.PatientName
            };
            var createdAppointment = await appointmentRepository.ReserveAppointment(appointment);
            var slotDetails = await slotsServiceApi.GetSlotByIdAsync(command.SlotId);
            _ = appointmentConfirmationHandler.SendConfirmationAsync(new AppointmentsCreatedEvent(
                createdAppointment.AppointmentId, createdAppointment.PatientName, slotDetails.Time,
                slotDetails.DoctorName));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}