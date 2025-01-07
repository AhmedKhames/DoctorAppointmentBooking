namespace DoctorAvailability.Business.Response;

public record DoctorSlotResponse(Guid DoctorId, DateTime Time, string DoctorName, decimal Cost, bool IsReserved);