namespace DoctorAppointmentManagement.Core.Entities;

public class Slot
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime Time { get; set; }
    public string DoctorName { get; set; }
    public decimal Cost { get; set; }
    public bool IsReserved { get; set; }
}