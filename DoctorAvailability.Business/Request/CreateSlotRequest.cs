namespace DoctorAvailability.Business.Request;

public record CreateSlotRequest(Guid DoctorId, DateTime Time, string DoctorName, decimal Cost);