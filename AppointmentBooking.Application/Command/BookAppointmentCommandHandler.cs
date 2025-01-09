using AppointmentBooking.Domain.Entities;
using AppointmentBooking.Domain.Repositories;

namespace AppointmentBooking.Application.Command;

public class BookAppointmentCommandHandler
{
    private readonly IAppointmentRepository _appointmentRepository;

    public BookAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
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
            await _appointmentRepository.ReserveAppointment(appointment);
            //TODO: send domain event to notification service so that it can notify the patient and the doctor
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}