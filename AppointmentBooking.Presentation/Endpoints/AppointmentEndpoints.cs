using AppointmentBooking.Application.Command;
using AppointmentBooking.Application.Query;
using AppointmentBooking.Application.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace AppointmentBooking.Presentation.Endpoints;

public static class AppointmentEndpoints
{
    public static RouteGroupBuilder MapAppointmentApis(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/appointments");

        api.MapGet("/available-slots", GetAvailableSlots);
        api.MapPost("/book", BookAppointment);
        return api;
    }

    private static async Task<Results<Ok<List<SlotsResponseDto>>, BadRequest<string>, NotFound<string>>>
        GetAvailableSlots(AppointmentQueries appointmentQueries)
    {
        var slots = await appointmentQueries.GetAvailableSlotsAsync();
        if (slots == null)
        {
            return TypedResults.BadRequest("no available slots found");
        }

        if (slots.Count == 0)
        {
            return TypedResults.NotFound("no available slots found");
        }

        return TypedResults.Ok(slots);
    }


    private static async Task<Results<Created, BadRequest<string>>> BookAppointment(
        BookAppointmentCommand bookAppointmentCommand,
        BookAppointmentCommandHandler bookAppointmentCommandHandler)
    {
        var result = await bookAppointmentCommandHandler.Handle(bookAppointmentCommand);
        if (result)
        {
            return TypedResults.Created();
        }

        return TypedResults.BadRequest("cannot create a book appointment");
    }
}