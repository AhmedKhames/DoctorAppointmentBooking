using DoctorAvailability.Business.Request;
using DoctorAvailability.Business.Response;
using DoctorAvailability.Data.Entities;
using DoctorAvailability.Data.Repositories;

namespace DoctorAvailability.Business.Services;

public class SlotsService
{
    private readonly SlotRepository _slotRepository;

    public SlotsService(SlotRepository slotRepository)
    {
        _slotRepository = slotRepository;
    }

    public async Task<IEnumerable<DoctorSlotResponse>> GetAllSlotsByDoctorIdAsync(Guid doctorId)
    {
        try
        {
            var slots = await _slotRepository.GetAllBySlotsAsync(doctorId);
            return slots.Select(s => new DoctorSlotResponse(s.DoctorId, s.Time, s.DoctorName, s.Cost, s.IsReserved));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public bool CreateSlot(CreateSlotRequest request)
    {
        try
        {
            var slot = new Slot
            {
                DoctorId = request.DoctorId,
                Time = request.Time,
                DoctorName = request.DoctorName,
                Cost = request.Cost
            };
            return _slotRepository.CreateSlot(slot);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}