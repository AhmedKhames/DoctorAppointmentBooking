using App.Extensions;
using AppointmentBooking.Presentation.Endpoints;
using DoctorAppointmentManagement.Presentation.Endpoints;
using DoctorAvailability.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDoctorAvailabilityModules();
builder.Services.AddAppointmentsBookingModules();
builder.Services.AddAppointmentsManagementModules();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapSlotsApis();
app.MapAppointmentApis();
app.MapAppointmentManagementApis();
app.Run();

