using Microsoft.EntityFrameworkCore;
using TodoWebApi.Model;

namespace TodoWebApi.Controller.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}