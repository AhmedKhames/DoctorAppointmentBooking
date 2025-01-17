namespace AppointmentConfirmation.Shared.Dtos;

public record AppointmentsCreatedEvent(
    Guid AppointmentId,
    string PatientName,
    DateTime AppointmentTime,
    string DoctorName);