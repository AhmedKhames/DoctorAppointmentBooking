using AppointmentBooking.Domain.Entities;
using AppointmentBooking.Domain.Enums;
using AppointmentBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure.Repositories;

public class AppointmentRepository(DoctorAppointmentDbContext context) : IAppointmentRepository
{
    public async Task<Appointment> ReserveAppointment(Appointment appointment)
    {
        await context.Appointments.AddAsync(appointment);
        return appointment;
    }

    public Task<List<Appointment>> GetSlotUpcommingAppointments(Guid slotId)
    {
        return context.Appointments
            .Where(a => a.SlotId == slotId && a.AppointmentStatus == AppointmentStatus.Upcoming).ToListAsync();
    }

    public Task<Appointment?> GetAppointmentById(Guid appointmentId)
    {
        return context.Appointments
            .FirstOrDefaultAsync(a =>
                a.AppointmentId == appointmentId && a.AppointmentStatus == AppointmentStatus.Upcoming);
    }

    public bool UpdateAppointment(Appointment appointment)
    {
        return context.Update(appointment) != null;
    }
}