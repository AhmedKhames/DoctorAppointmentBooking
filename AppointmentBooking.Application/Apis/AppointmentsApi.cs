using AppointmentBooking.Domain.Entities;
using AppointmentBooking.Domain.Enums;
using AppointmentBooking.Domain.Repositories;
using AppointmentBooking.Shared.Contracts;
using AppointmentBooking.Shared.Dtos;

namespace AppointmentBooking.Application.Apis;

public class AppointmentsApi(IAppointmentRepository appointmentRepository) : IAppointmentsApi
{
    public async Task<AppointmentDto?> GetDoctorUpcomingAppointments(Guid slotId)
    {
        try
        {
            var appointments = await appointmentRepository.GetSlotUpcommingAppointments(slotId);

            return appointments
                .Select(a => new AppointmentDto(a.AppointmentId, a.PatientId, a.SlotId, a.PatientName, a.ReservedAt,
                    (int)a.AppointmentStatus))
                .FirstOrDefault();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<AppointmentDto?> GetAppointmentById(Guid appointmentId)
    {
        var appointments = await appointmentRepository.GetAppointmentById(appointmentId);
        return appointments != null
            ? new AppointmentDto(appointments.AppointmentId, appointments.PatientId, appointments.SlotId,
                appointments.PatientName, appointments.ReservedAt, (int)appointments.AppointmentStatus)
            : null;
    }

    public bool UpdateAppointment(AppointmentDto updatedDto)
    {
        var appointment = new Appointment
        {
            AppointmentId = updatedDto.AppointmentId,
            PatientId = updatedDto.PatientId,
            SlotId = updatedDto.SlotId,
            PatientName = updatedDto.PatientName,
            ReservedAt = updatedDto.ReservedAt,
            AppointmentStatus = (AppointmentStatus)updatedDto.AppointmentStatus
        };

        return appointmentRepository.UpdateAppointment(appointment);
    }
}