namespace AOP.WebAPI
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Repositories;
    using AutoMapper;
    using AOP.WebAPI.Core.Data.Entities;
    using AOP.WebAPI.Core.Repositories.Base;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AOPDatabaseContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AdvertisingOperationsSQLDatabase"),
                    x => x.MigrationsAssembly("AOP.WebAPI.Core")
                )
            );

            builder.Services.AddScoped<DbContext, AOPDatabaseContext>();

            builder.Services.AddScoped<IRepositoryBaseWrapper, RepositoryBaseWrapper>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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


            app.MapControllers();

            app.Run();
        }
    }
}