using DoctorAppointmentManagement.Core.Enums;

namespace DoctorAppointmentManagement.Presentation.Adapters.Dtos;

public record SlotAppointmentDto(SlotDto Slot, AppointmentDto Appointment);

public record AppointmentDto(
    Guid AppointmentId,
    Guid PatientId,
    Guid SlotId,
    string PatientName,
    DateTime ReservedAt,
    AppointmentStatus AppointmentStatus
);

public record SlotDto(
    Guid SlotId,
    Guid DoctorId,
    DateTime Time,
    string DoctorName,
    decimal Cost,
    bool IsReserved
);