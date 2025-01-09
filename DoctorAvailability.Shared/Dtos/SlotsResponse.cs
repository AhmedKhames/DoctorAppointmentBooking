namespace DoctorAvailability.Shared.Dtos;


public record SlotsResponse(Guid DoctorId, DateTime Time, string DoctorName, decimal Cost, bool IsReserved);
