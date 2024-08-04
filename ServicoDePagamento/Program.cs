
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


            builder.Services.AddDbContext<ServicoDbContexto>(options => options.UseSqlServer(ConnectionString,sqlServerOptions =>{
                sqlServerOptions.EnableRetryOnFailure();
            }));
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            builder.Services.AddScoped<IRecebivelRepository, RecebiveisRepository>();


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

            {
                var scope =app.Services.CreateScope();
                var dbcontext = scope.ServiceProvider.GetService<ServicoDbContexto>();
                dbcontext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
