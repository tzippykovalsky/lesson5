using Lesson5.Core.Repositories;
using Lesson5.Data.Repositories;
using Lesson5.Data;
using Lesson5.Service;

namespace Lesson5.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void setService(this IServiceCollection services)
        {
            services.AddScoped<PilotService>();
            services.AddScoped<FlightService>();
            services.AddScoped<PassengerService>();
            services.AddScoped<IPilotRepository, PilotRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();

            services.AddDbContext<DataContext>();
        }
    }
}
