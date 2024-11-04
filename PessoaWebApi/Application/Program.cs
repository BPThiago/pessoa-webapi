using Microsoft.EntityFrameworkCore;
using pessoa_webapi.Model.Usercase.EnderecoUsercase;
using PessoaWebApi.Model;
using PessoaWebApi.Model.Service;
using PessoaWebApi.Model.Usercase.PessoaUsercase;

namespace PessoaWebApi.Controller.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            
            builder.Services.AddDbContext<PessoaDb>(opt => opt.UseInMemoryDatabase("WebAPI"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            
            builder.Services.AddScoped<PessoaService>();
            builder.Services.AddScoped<EnderecoService>();
            builder.Services.AddScoped<GetAllPessoasUsercase>();
            builder.Services.AddScoped<GetPessoaUsercase>();
            builder.Services.AddScoped<CreatePessoaUsercase>();
            builder.Services.AddScoped<GetEnderecoUsercase>();
            builder.Services.AddScoped<CreateEnderecoUsercase>();
            
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}