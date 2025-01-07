using DoctorAvailability.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.Data;

public class DoctorAvailabilityDbContext(DbContextOptions<DoctorAvailabilityDbContext> options) : DbContext(options)
{
    public virtual DbSet<Slot> Slots { get; set; } 
}