using DoctorAppointmentManagement.Core.Entities;
using DoctorAppointmentManagement.Core.Enums;

namespace DoctorAppointmentManagement.Core.Ports.Output;

public interface IAppointmentPort
{
    Task<List<SlotAppointment>> GetDoctorUpcomingAppointments(Guid doctorId);
    Task<bool> UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status);
}