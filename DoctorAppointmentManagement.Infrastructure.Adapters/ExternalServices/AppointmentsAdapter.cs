using AppointmentBooking.Shared.Contracts;
using DoctorAppointmentManagement.Core.Entities;
using DoctorAppointmentManagement.Core.Enums;
using DoctorAppointmentManagement.Core.Ports.Output;
using DoctorAvailability.Shared.Contracts;

namespace DoctorAppointmentManagement.Infrastructure.Adapters.ExternalServices;

public class AppointmentsAdapter : IAppointmentPort
{
    private readonly IAppointmentsApi _appointmentsApi;
    private readonly ISlotsServiceApi _slotsApi;

    public AppointmentsAdapter(IAppointmentsApi appointmentsApi, ISlotsServiceApi slotsApi)
    {
        _appointmentsApi = appointmentsApi;
        _slotsApi = slotsApi;
    }

    public async Task<List<SlotAppointment>> GetDoctorUpcomingAppointments(Guid doctorId)
    {
        var slots = await _slotsApi.GetDoctorSlotsAsync(doctorId);
        var result = new List<SlotAppointment>();
        foreach (var slot in slots)
        {
            var appointment = await _appointmentsApi.GetDoctorUpcomingAppointments(slot.SlotId);
            result.Add(new SlotAppointment
            {
                Slot = new Slot(),
                Appointment = new Appointment()
            });
        }

        return result;
    }

    public async Task<bool> UpdateAppointmentStatus(Guid appointmentId, AppointmentStatus status)
    {
        var appointment = await _appointmentsApi.GetAppointmentById(appointmentId);
        if (appointment == null)
        {
            return false;
        }
        var updatedDto = appointment with { AppointmentStatus = (int)status};
        
        var isUpdated =  _appointmentsApi.UpdateAppointment(updatedDto);
        return isUpdated;
    }
}