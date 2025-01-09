using AppointmentBooking.Domain.Entities;

namespace AppointmentBooking.Domain.Repositories;

public interface IAppointmentRepository
{
    public Task<bool> ReserveAppointment(Appointment appointment);
}