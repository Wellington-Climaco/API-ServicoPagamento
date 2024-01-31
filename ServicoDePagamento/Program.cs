
using Microsoft.EntityFrameworkCore;
using ServicoDePagamento.Data;
using ServicoDePagamento.Interface;
using ServicoDePagamento.Repository;
using System.Text.Json.Serialization;

namespace ServicoDePagamento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.


            builder.Services.AddDbContext<ServicoDbContexto>(options => options.UseSqlServer(ConnectionString));
            builder.Services.AddControllers().AddJsonOptions(x => {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
            builder.Services.AddScoped<IClienteRepository,ClienteRepository > ();
            builder.Services.AddScoped<ITransacaoRepository,TransacaoRepository> ();
            builder.Services.AddScoped<IRecebivelRepository,RecebiveisRepository> ();
            


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
