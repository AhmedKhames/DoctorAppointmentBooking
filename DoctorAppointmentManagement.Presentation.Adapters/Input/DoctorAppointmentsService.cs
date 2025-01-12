using DoctorAppointmentManagement.Core.Enums;
using DoctorAppointmentManagement.Core.Ports.Output;
using DoctorAppointmentManagement.Presentation.Adapters.Dtos;

namespace DoctorAppointmentManagement.Presentation.Adapters.Input;

public class DoctorAppointmentsService(IAppointmentPort appointmentPort)
{
    public async Task<List<SlotAppointmentDto>> GetDoctorUpcomingAppointments(Guid doctorId)
    {
        var appointments = await appointmentPort.GetDoctorUpcomingAppointments(doctorId);

        return appointments.Select(appointment => new SlotAppointmentDto(
            new SlotDto(
                appointment.Slot.Id,
                appointment.Slot.DoctorId,
                appointment.Slot.Time,
                appointment.Slot.DoctorName,
                appointment.Slot.Cost,
                appointment.Slot.IsReserved
            ),
            new AppointmentDto(appointment.Appointment.AppointmentId, appointment.Appointment.PatientId,
                appointment.Appointment.SlotId, appointment.Appointment.PatientName, appointment.Appointment.ReservedAt,
                appointment.Appointment.AppointmentStatus)
        )).ToList();
    }

    public async Task<bool> UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status)
    {
        return await appointmentPort.UpdateAppointmentStatus(appointmentId, status);
    }
}