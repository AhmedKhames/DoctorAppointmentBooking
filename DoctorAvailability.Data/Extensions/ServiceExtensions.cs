using DoctorAvailability.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorAvailability.Data.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureData(this IServiceCollection services)
    {
        services.AddDbContext<DoctorAvailabilityDbContext>(options =>
        {
            options.UseInMemoryDatabase("DoctorBookings");
        });
        services.AddScoped<SlotRepository>();
    }
}