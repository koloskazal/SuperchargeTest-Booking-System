
using DbConnection;
using SuperchargeTestApi.db.Supercharge.Domain.DbServices;
using SuperchargeTestApi.db.Supercharge.Persistance.DbServices;

namespace SuperchargeTestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbServices(builder.Configuration);
            // Add services to the container.
            builder.Services
                .AddScoped<IBookingService, BookingService>()
                .AddScoped<IHotelService, HotelService>()
                .AddScoped<IPriceService, PriceService>()
                .AddScoped<IRoomService, RoomService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IVisitorService, VisitorService>()
            ;

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
