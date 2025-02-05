using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models;
using web_api_for_books_app.Repositories;

namespace web_api_for_books_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<LibraryContext>();
            builder.Services.AddTransient<IRepository<Book>, BookRepository>();
            builder.Services.AddTransient<IRepository<Author>, AuthorRepository>();

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
