
using AutotraderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutotraderAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AutotraderContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MySQL");
                options.UseMySQL(connectionString);
            }); 
            //Regisztr�lom az oszt�lyt aminek a p�ld�nyos�t�sa innent�l kezdve a builder feladata

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {

                options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3000",
                                                 "http://localhost:3000")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                          });
            });




            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapControllers();

            app.Run();
        }
    }
}
