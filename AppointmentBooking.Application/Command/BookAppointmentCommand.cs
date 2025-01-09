namespace AppointmentBooking.Application.Command;

public record BookAppointmentCommand(Guid PatientId, Guid SlotId, string PatientName);