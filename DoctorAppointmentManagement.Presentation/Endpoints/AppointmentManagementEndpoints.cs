using DoctorAppointmentManagement.Core.Enums;
using DoctorAppointmentManagement.Presentation.Adapters.Dtos;
using DoctorAppointmentManagement.Presentation.Adapters.Input;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace DoctorAppointmentManagement.Presentation.Endpoints;

public static class AppointmentManagementEndpoints
{
    public static RouteGroupBuilder MapAppointmentManagementApis(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/AppointmentManagement");

        api.MapGet("/upcoming", GetUpcomingAppointmentsAsync);
        api.MapPut("/update-status{appointmentId:guid}/{status}", UpdateAppointmentStatusAsync);
        return api;
    }

    private static async Task<Results<Ok, BadRequest<string>>> UpdateAppointmentStatusAsync(
        Guid appointmentId, AppointmentStatus status,
        DoctorAppointmentsService doctorAppointmentsService)
    {
        return await doctorAppointmentsService.UpdateAppointmentStatus(appointmentId, status)
            ? TypedResults.Ok()
            : TypedResults.BadRequest("cannot update appointment status");
    }

    private static async Task<Results<Ok<List<SlotAppointmentDto>>, BadRequest<string>>> GetUpcomingAppointmentsAsync(
        Guid doctorId,
        DoctorAppointmentsService doctorAppointmentsService)
    {
        if (doctorId == Guid.Empty)
        {
            return TypedResults.BadRequest("Empty GUID is not valid for request ID");
        }

        return TypedResults.Ok(await doctorAppointmentsService.GetDoctorUpcomingAppointments(doctorId));
    }
}