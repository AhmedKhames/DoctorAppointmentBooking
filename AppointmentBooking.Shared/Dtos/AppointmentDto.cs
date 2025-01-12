namespace AppointmentBooking.Shared.Dtos;

public record AppointmentDto(
    Guid AppointmentId,
    Guid PatientId,
    Guid SlotId,
    string PatientName,
    DateTime ReservedAt,
    int AppointmentStatus
);