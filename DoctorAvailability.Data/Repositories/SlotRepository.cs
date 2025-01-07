using DoctorAvailability.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAvailability.Data.Repositories;

public class SlotRepository
{
    private readonly DoctorAvailabilityDbContext _context;

    public SlotRepository(DoctorAvailabilityDbContext context)
    {
        _context = context;
    }

    public Task<List<Slot>> GetAllBySlotsAsync(Guid doctorId)
    {
        return _context.Slots.Where(s => s.DoctorId == doctorId).ToListAsync();
    }

    public bool CreateSlot(Slot slot)
    {
        _context.Slots.Add(slot);
        return _context.SaveChanges() > 0;
    }
}