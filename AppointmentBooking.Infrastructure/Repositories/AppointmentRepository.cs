using AppointmentBooking.Domain.Entities;
using AppointmentBooking.Domain.Repositories;

namespace AppointmentBooking.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly DoctorAppointmentDbContext _context;

    public AppointmentRepository(DoctorAppointmentDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ReserveAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        return (await _context.SaveChangesAsync()) > 0;
    }
}