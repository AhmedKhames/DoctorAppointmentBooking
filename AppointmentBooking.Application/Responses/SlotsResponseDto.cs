namespace AppointmentBooking.Application.Responses;

public record SlotsResponseDto(Guid DoctorId, DateTime Time, string DoctorName, decimal Cost, bool IsReserved);
