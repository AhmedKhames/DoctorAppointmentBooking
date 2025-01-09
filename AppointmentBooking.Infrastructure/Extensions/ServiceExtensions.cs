using AppointmentBooking.Domain.Repositories;
using AppointmentBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DoctorAppointmentDbContext>(options =>
        {
            options.UseInMemoryDatabase("DoctorBookings");
        });
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
    }
}