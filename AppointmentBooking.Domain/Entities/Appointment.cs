namespace AppointmentBooking.Domain.Entities;

public class Appointment
{
    public Guid AppointmentId { get; set; }
    public Guid PatientId { get; set; }
    public Guid SlotId { get; set; }
    public string PatientName { get; set; }
    public DateTime ReservedAt { get; set; } = DateTime.Now; 
}