using DbConnection.db.Supercharge.Context;
using DbConnection.db.Supercharge.Domain.DbRepositories;
using DbConnection.db.Supercharge.Persistance.DbRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbConnection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            string conStr = configuration.GetConnectionString("SuperChargeDataConnection");
            services.AddDbContext<SuperchargeContext>(options =>
                                        options.UseSqlServer(
                                            conStr,
                                            sqlServerOptionsAction: sqlOptions =>
                                            {
                                                sqlOptions.EnableRetryOnFailure(
                                                    maxRetryCount: 5,
                                                    maxRetryDelay: TimeSpan.FromSeconds(30),
                                                    errorNumbersToAdd: null);
                                            }))

                //Repositories
                .AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>))
                .AddScoped<IBookingRepository,BookingRepository>()
                .AddScoped<IHotelRepository,HotelRepository>()
                .AddScoped<IPriceRepository, PriceRepository>()
                .AddScoped<IRoomRepository, RoomRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IVisitorRepository, VisitorRepository>()
                ;

            return services;
        }
    }
}