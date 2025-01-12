using AppointmentBooking.Shared.Dtos;

namespace AppointmentBooking.Shared.Contracts;

public interface IAppointmentsApi
{
    Task<AppointmentDto?> GetDoctorUpcomingAppointments(Guid slotId);
    Task<AppointmentDto?> GetAppointmentById(Guid appointmentId);
    bool UpdateAppointment(AppointmentDto updatedDto);
}