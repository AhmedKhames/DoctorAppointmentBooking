namespace DoctorAvailability.Shared.Dtos;


public record SlotsResponse(Guid SlotId,Guid DoctorId, DateTime Time, string DoctorName, decimal Cost, bool IsReserved);
