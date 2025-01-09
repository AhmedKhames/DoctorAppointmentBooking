using DoctorAvailability.Shared.Dtos;

namespace DoctorAvailability.Shared.Contracts;

public interface ISlotsServiceApi
{
    Task<IEnumerable<SlotsResponse>> GetAllAvailableSlotsAsync();
}