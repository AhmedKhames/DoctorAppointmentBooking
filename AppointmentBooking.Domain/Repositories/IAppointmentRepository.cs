using AppointmentBooking.Domain.Entities;

namespace AppointmentBooking.Domain.Repositories;

public interface IAppointmentRepository
{
    public Task<bool> ReserveAppointment(Appointment appointment);
    Task<List<Appointment>> GetSlotUpcommingAppointments(Guid slotId);
    Task<Appointment?> GetAppointmentById(Guid appointmentId); 
    bool UpdateAppointment(Appointment appointment);
}