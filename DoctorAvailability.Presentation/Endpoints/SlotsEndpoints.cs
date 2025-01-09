using DoctorAvailability.Business.Request;
using DoctorAvailability.Business.Response;
using DoctorAvailability.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace DoctorAvailability.Presentation.Endpoints;

public static class SlotsEndpoints
{
    public static RouteGroupBuilder MapSlotsApis(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/slot");

        api.MapGet("/", GetAllDoctorSlotsAsync);
        api.MapPost("/create-slot", CreateDoctorSlotAsync);
        return api;
    }

    private static Results<Created, BadRequest<string>> CreateDoctorSlotAsync(CreateSlotRequest request,
        SlotsService slotsService, ILogger<SlotsService> logger)
    {
        if (request.DoctorId == Guid.Empty)
        {
            logger.LogWarning("Invalid request - doctor id is missing - {@Request}", request);
            return TypedResults.BadRequest("doctor id is missing.");
        }

        if (slotsService.CreateSlot(request))
        {
            return TypedResults.Created();
        }

        return TypedResults.BadRequest("cannot create a doctor time slot");
    }

    private static async Task<Results<Ok<IEnumerable<DoctorSlotResponse>>, BadRequest<string>>> GetAllDoctorSlotsAsync(
        Guid doctorId,
        SlotsService slotsService)
    {
        if (doctorId == Guid.Empty)
        {
            return TypedResults.BadRequest("Empty GUID is not valid for request ID");
        }

        return TypedResults.Ok(await slotsService.GetAllSlotsByDoctorIdAsync(doctorId));
    }
}