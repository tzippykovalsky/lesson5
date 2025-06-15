using Lesson5.Core.Repositories;
using Lesson5.Data.Repositories;
using Lesson5.Data;
using Lesson5.Service;



namespace Lesson5.Api.MyExtensions
{
    public static class ServicesExtension
    {
        public static void setService(this IServiceCollection services)
        {
            services.AddScoped<PilotService>();
            services.AddScoped<FlightService>();
            services.AddScoped<PassengerService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();

            services.AddScoped<IManager, Manager>();

            services.AddAutoMapper(typeof(MyAutoMapper).Assembly);

            services.AddDbContext<DataContext>();
        }
    }
}
