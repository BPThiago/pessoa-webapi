using Microsoft.EntityFrameworkCore;
using PessoaWebApi.Model;

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

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}