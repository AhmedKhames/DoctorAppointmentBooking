using AppointmentBooking.Application.Responses;
using DoctorAvailability.Shared.Contracts;
using Microsoft.Extensions.Logging;

namespace AppointmentBooking.Application.Query;

public class AppointmentQueries(ISlotsServiceApi slotsServiceApi, ILogger<AppointmentQueries> logger)
{
    public async Task<List<SlotsResponseDto>?> GetAvailableSlotsAsync()
    {
        try
        {
            var slots = await slotsServiceApi.GetAllAvailableSlotsAsync();

            return slots
                .Select(s => new SlotsResponseDto(s.DoctorId, s.Time, s.DoctorName, s.Cost, s.IsReserved))
                .ToList();
        }
        catch (Exception e)
        {
            logger.LogError(e,"Error getting available slots");
            return null;
        }
    }
}