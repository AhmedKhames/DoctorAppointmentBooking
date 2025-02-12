using DoctorAvailability.Business.Response;
using DoctorAvailability.Data.Repositories;
using DoctorAvailability.Shared.Contracts;
using DoctorAvailability.Shared.Dtos;

namespace DoctorAvailability.Business.Apis;

public class SlotsServiceApi : ISlotsServiceApi
{
    private readonly SlotRepository _slotRepository;

    public SlotsServiceApi(SlotRepository slotRepository)
    {
        _slotRepository = slotRepository;
    }

    public async Task<IEnumerable<SlotsResponse>> GetAllAvailableSlotsAsync()
    {
        try
        {
            var slots = await _slotRepository.GetAvailableSlotsAsync();
            return slots.Select(s => new SlotsResponse(s.Id, s.DoctorId, s.Time, s.DoctorName, s.Cost, s.IsReserved));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<SlotsResponse>();
        }
    }

    public async Task<IEnumerable<SlotsResponse>> GetDoctorSlotsAsync(Guid doctorId)
    {
        try
        {
            var slots = await _slotRepository.GetAllBySlotsAsync(doctorId);
            return slots.Select(s => new SlotsResponse(s.Id, s.DoctorId, s.Time, s.DoctorName, s.Cost, s.IsReserved));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<SlotsResponse>();
        }
    }

    public async Task<SlotsResponse> GetSlotByIdAsync(Guid slotId)
    {
        try
        {
            var slot = await _slotRepository.GetSlotByIdAsync(slotId);
            if (slot is null)
            {
                return null;
            }

            return new SlotsResponse(slot.Id, slot.DoctorId, slot.Time, slot.DoctorName, slot.Cost, slot.IsReserved);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}