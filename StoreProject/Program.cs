using Microsoft.EntityFrameworkCore;
using StoreProject.Data;
using StoreProject.Repositories;
using StoreProject.Repositories.Interface;
using StoreProject.Services;
using StoreProject.Services.Interface;

namespace StoreProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            
            builder.Services.AddScoped<IProdutoApplicationServices, ProdutoApplicationServices>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<AppDbContext>(opts =>
                opts.UseMySql(builder.Configuration.GetConnectionString("ProdutoConnection"), new MySqlServerVersion(new Version())));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("corsapp");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}