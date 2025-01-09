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
            return slots.Select(s => new SlotsResponse(s.DoctorId, s.Time, s.DoctorName, s.Cost, s.IsReserved));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<SlotsResponse>();
        }
    }
}