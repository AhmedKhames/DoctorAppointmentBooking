using AppointmentBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Infrastructure
{
    public class DoctorAppointmentDbContext(DbContextOptions<DoctorAppointmentDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Appointment> Appointments { get; set; }
    }
}